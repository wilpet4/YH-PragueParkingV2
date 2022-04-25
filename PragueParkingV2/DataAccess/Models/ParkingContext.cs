using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;

namespace PragueParkingDataAccess
{
    public class ParkingContext : DbContext
    {
        int amountOfParkingSpots = 32; // Denna ska in i en json/xml fil
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
            #region Data Seeding
            modelBuilder.Entity<ParkingGarage>().HasData(new ParkingGarage { GarageId = 1});

            int ParkingId = 1;
            for (int i = 0; i < amountOfParkingSpots; i++)
            {
                modelBuilder.Entity<ParkingSpot>().HasData(new ParkingSpot {ParkingGarageId = 1 ,ParkingSpotId = ParkingId});
                ParkingId++;
            }
            #endregion
        }
        public DbSet<ParkingGarage> Garages { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<MC>? MCs { get; set; }
    }
}
