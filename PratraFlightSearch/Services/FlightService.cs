using Microsoft.EntityFrameworkCore;
using PratraFlightSearch.Data;
using PratraFlightSearch.DTOs;
using PratraFlightSearch.Models;

namespace PratraFlightSearch.Services
{
    public class FlightService : IFlightService
    {
        private readonly FlightDbContext _context;

        public FlightService(FlightDbContext context)
        {
            _context = context;
        }

        // Search flights
        public async Task<List<FlightResponse>> SearchFlightsAsync(string source,string destination,DateTime date)
        {
            DateTime startDate = date.Date;
            DateTime endDate = startDate.AddDays(1);

            var flights = await _context.Flights
                .AsNoTracking()
                .Where(f =>
                    f.Source == source &&
                    f.Destination == destination &&
                    f.DepartureTime >= startDate &&
                    f.DepartureTime < endDate)
                .OrderBy(f => f.Price)
                .ThenBy(f => f.DepartureTime)
                .Select(f => new FlightResponse
                {
                    Id = f.Id,
                    AirlineName = f.AirlineName,
                    FlightNumber = f.FlightNumber,
                    Source = f.Source,
                    Destination = f.Destination,
                    DepartureTime = f.DepartureTime,
                    ArrivalTime = f.ArrivalTime,
                    Price = f.Price
                })
                .ToListAsync();

            return flights;
        }

        // Create a flight
        public async Task<FlightResponse> CreateFlightAsync(CreateFlightRequest request)
        {
            var flight = new Flight
            {
                AirlineName = request.AirlineName.Trim(),
                FlightNumber = request.FlightNumber.Trim(),
                Source = request.Source.Trim().ToUpperInvariant(),
                Destination = request.Destination.Trim().ToUpperInvariant(),
                DepartureTime = request.DepartureTime!.Value,
                ArrivalTime = request.ArrivalTime!.Value,
                Price = request.Price
            };

            _context.Flights.Add(flight);

            await _context.SaveChangesAsync();

            return new FlightResponse
            {
                Id = flight.Id,
                AirlineName = flight.AirlineName,
                FlightNumber = flight.FlightNumber,
                Source = flight.Source,
                Destination = flight.Destination,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                Price = flight.Price
            };
        }
    }
}