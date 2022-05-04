using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Xml;
using System;

namespace PragueParkingDataAccess
{
    public class ParkingContext : DbContext
    {
        int? parkingSpots = null;
        public ParkingContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);

            string connectionString = 
            builder.Build().GetConnectionString("DefaultConnection");

            XmlDocument xml = new XmlDocument();
            xml.Load(@"config.xml");
            parkingSpots = Int32.Parse(xml.GetElementsByTagName("parkingspots").Item(0).InnerText);

            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<ParkingGarage> Garages { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<MC>? MCs { get; set; }
    }
}
