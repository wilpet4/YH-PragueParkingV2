using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PragueParkingDataAccess
{
    public abstract class Vehicle //Table-Per-Hierarchy. Alla subklasser visas i samma Vehicle-tabell.
    {
        public int VehicleId { get; set; }
        public byte Size { get; set; }
        public string? Registration { get; set; }
        public DateTime Arrival { get; set; }

        [Required] public ParkingSpot Parking { get; set; }
    }
    public class Car : Vehicle
    {
        public Car() // Tomma constructors behövs för att migrations ska fungera.
        {
            Size = 4;
            Arrival = DateTime.Now;
        }
        public Car(in string reg, in ParkingSpot parkingSpot, in ParkingContext context) // Använd alltid in-parametrar för att skapa objekt.
        {
            Size = 4;
            Registration = reg;
            Arrival = DateTime.Now;
        }
    }
    public class MC : Vehicle
    {
        public MC()
        {
            Size = 2;
            Arrival = DateTime.Now;
        }
        public MC(in string reg, in ParkingSpot parkingSpot, in ParkingContext context) // ?
        {
            Size = 2;
            Registration = reg;
            Arrival = DateTime.Now;
        }
    }
}
