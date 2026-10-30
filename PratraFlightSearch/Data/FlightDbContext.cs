
using Microsoft.EntityFrameworkCore;
using PratraFlightSearch.Models;

namespace PratraFlightSearch.Data
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(
            DbContextOptions<FlightDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure price precision
            modelBuilder.Entity<Flight>()
                .Property(f => f.Price)
                .HasPrecision(18, 2);

            // Create index for faster flight searches
            modelBuilder.Entity<Flight>()
                .HasIndex(f => new
                {
                    f.Source,
                    f.Destination,
                    f.DepartureTime
                });
        }
    }
}
