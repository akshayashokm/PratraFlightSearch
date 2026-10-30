using PratraFlightSearch.DTOs;
using PratraFlightSearch.Models;

namespace PratraFlightSearch.Services
{
    public interface IFlightService
    {
        Task<List<FlightResponse>> SearchFlightsAsync(string source,string destination,DateTime date);
        Task<FlightResponse> CreateFlightAsync(CreateFlightRequest request);
    }
}
