using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParkingDataAccess
{
    public class AppContext : DbContext
    {
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

    }
    public class Car : Vehicle
    {

    }
    public class MC : Vehicle
    {

    }
}
