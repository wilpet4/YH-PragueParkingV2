using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace PragueParkingDataAccess
{
    public class ParkingContext : DbContext
    {
        public ParkingContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);

            string connectionString = 
            builder.Build().GetConnectionString("DefaultConnection");

            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<ParkingGarage>? Garages { get; set; }
        public DbSet<ParkingSpot>? ParkingSpots { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<MC>? MCs { get; set; }
    }
}
