using System.ComponentModel.DataAnnotations;

namespace PratraFlightSearch.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string AirlineName { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string FlightNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(3)]
        public string Source { get; set; } = string.Empty;

        [Required]
        [MaxLength(3)]
        public string Destination { get; set; } = string.Empty;

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal Price { get; set; }
    }
}
