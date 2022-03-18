using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;

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
    // Bryt klasserna till sina egna filer senare.
    public class ParkingGarage
    {
        public int Id { get; set; }
        public ParkingSpot? ParkingSpots { get; set; }

    }
    public class ParkingSpot
    {
        public int Id { get; set; }
        public List<Vehicle>? Vehicles { get; set; }
    }
    public abstract class Vehicle //Table-Per-Hierarchy. Alla subklasser visas i samma Vehicle-tabell.
    {
        public int Id { get; set; }
        public byte Size { get; set; }
        public string? Registration { get; set; }
    }
    public class Car : Vehicle
    {
        public Car() { }
        public Car(in byte size = 4, in string reg = "") // ?
        {
            Size = size;
            Registration = reg;
        }
    }
    public class MC : Vehicle
    {
        public MC() { }
        public MC(in byte size = 2, in string reg = "") // ?
        {
            Size = size;
            Registration = reg;
        }
    }
}
