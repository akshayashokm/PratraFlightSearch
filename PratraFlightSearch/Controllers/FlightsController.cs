using Microsoft.AspNetCore.Mvc;
using PratraFlightSearch.DTOs;
using PratraFlightSearch.Models;
using PratraFlightSearch.Services;

namespace PratraFlightSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<FlightResponse>>> SearchFlights([FromQuery] string from,[FromQuery] string to,[FromQuery] DateTime date)
        {
            if (string.IsNullOrWhiteSpace(from) ||
                string.IsNullOrWhiteSpace(to))
            {
                return BadRequest("Source and destination are required.");
            }
            if (from.Equals(to, StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Source and destination cannot be the same.");
            }
            if (from.Length != 3 || to.Length != 3)
            {
                return BadRequest("Source and destination must be 3-character airport codes.");
            }

            if (from.Equals(to, StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Source and destination cannot be the same.");
            }

            var flights = await _flightService.SearchFlightsAsync(
                from.ToUpperInvariant(),
                to.ToUpperInvariant(),
                date);

            return Ok(flights);
        }
        [HttpPost]
        public async Task<ActionResult<FlightResponse>> CreateFlight([FromBody] CreateFlightRequest request)
        {
            if (request.ArrivalTime <= request.DepartureTime)
            {
                return BadRequest("Arrival time must be after departure time.");
            }

            if (request.Source.Equals(request.Destination, StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Source and destination cannot be the same.");
            }
            if (request.Source.Equals(request.Destination,StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Source and destination airport codes cannot be the same.");
            }

            var flight = await _flightService.CreateFlightAsync(request);

            return CreatedAtAction(
                nameof(SearchFlights),
                new
                {
                    from = flight.Source,
                    to = flight.Destination,
                    date = flight.DepartureTime.ToString("yyyy-MM-dd")
                },
                flight);
        }
    }
}