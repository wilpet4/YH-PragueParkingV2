using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PragueParkingDataAccess
{
    public class AppContext : DbContext
    {
        public AppContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);

            string connectionsString = 
            builder.Build().GetConnectionString("DefaultConnection");

            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<ParkingGarage> Garages { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<MC> MCs { get; set; }
    }
    // Bryt klasserna till sina egna filer senare.
    public class ParkingGarage
    {
        public int Id { get; set; }

    }
    public class ParkingSpot
    {
        public int Id { get; set; }

    }
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public byte Size { get; set; }
    }
    public class Car : Vehicle
    {
        public Car(in byte size = 4) // ?
        {
            Size = size;
        }
    }
    public class MC : Vehicle
    {
        public MC(in byte size = 2) // ?
        {
            Size = size;
        }
    }
}
