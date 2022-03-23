using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PragueParkingDataAccess
{
    public abstract class Vehicle //Table-Per-Hierarchy. Alla subklasser visas i samma Vehicle-tabell.
    {
        public int VehicleId { get; set; }
        public byte Size { get; set; }
        public string? Registration { get; set; }
        public DateTime Arrival { get; set; }

        public int ParkingSpotId { get; set; }

        [ForeignKey("ParkingSpotId")]
        public ParkingSpot ParkingSpot { get; set; }
    }
    public class Car : Vehicle
    {
        public Car() { }
        public Car(in string reg, in int parkingSpot) // ?
        {
            Size = 4;
            Registration = reg;
            Arrival = DateTime.Now;
        }
    }
    public class MC : Vehicle
    {
        public MC() { }
        public MC(in string reg, in int parkingSpot) // ?
        {
            Size = 2;
            Registration = reg;
            Arrival = DateTime.Now;
        }
    }
}
