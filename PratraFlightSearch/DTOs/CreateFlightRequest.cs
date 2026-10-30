using System.ComponentModel.DataAnnotations;

namespace PratraFlightSearch.DTOs
{
    public class CreateFlightRequest
    {
        [Required(ErrorMessage = "Airline name is required.")]
        [StringLength(100, MinimumLength = 2)]
        public string AirlineName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Flight number is required.")]
        [StringLength(20, MinimumLength = 2)]
        public string FlightNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Source airport code is required.")]
        [RegularExpression(@"^[A-Za-z]{3}$",
            ErrorMessage = "Source must be a valid 3-letter airport code.")]
        public string Source { get; set; } = string.Empty;

        [Required(ErrorMessage = "Destination airport code is required.")]
        [RegularExpression(@"^[A-Za-z]{3}$",
            ErrorMessage = "Destination must be a valid 3-letter airport code.")]
        public string Destination { get; set; } = string.Empty;

        [Required]
        public DateTime? DepartureTime { get; set; }

        [Required]
        public DateTime? ArrivalTime { get; set; }

        [Range(typeof(decimal), "0.01", "10000000",
        ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
    }
}