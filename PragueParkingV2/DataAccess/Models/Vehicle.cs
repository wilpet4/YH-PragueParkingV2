using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PragueParkingDataAccess
{
    public abstract class Vehicle : IArrive //Table-Per-Hierarchy. Alla subklasser visas i samma Vehicle-tabell.
    {
        public Vehicle()
        {
            Arrival = DateTime.Now;
        }
        public int VehicleId { get; set; }
        public byte Size { get; set; }
        public string? Registration { get; set; }
        public DateTime Arrival { get; set; }

        public int ParkingSpotId { get; set; }
        [Required] public ParkingSpot Parking { get; set; }
    }
    public class Car : Vehicle
    {
        public Car() // Tomma public constructors behövs för att migrations ska fungera.
        {
            Size = 4;
        }
        public Car(in string reg) // Använd alltid in-parametrar för att skapa objekt.
        {
            Size = 4;
            Registration = reg;
        }
    }
    public class MC : Vehicle
    {
        public MC()
        {
            Size = 2;
        }
        public MC(in string reg) // ?
        {
            Size = 2;
            Registration = reg;
        }
    }
}
