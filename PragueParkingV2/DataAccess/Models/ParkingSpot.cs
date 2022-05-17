using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PragueParkingDataAccess
{
    public class ParkingSpot
    {
        public ParkingSpot()
        {
            //Vehicles = new List<Vehicle>(); // Detta gör så fordonen inte visas korrekt i MainWindow!
            if (Vehicles == null)
            {
                Vehicles = new List<Vehicle>();
            }
            Size = 4;
        }
        public ParkingSpot(in int size)
        {
            if (Vehicles == null)
            {
                Vehicles = new List<Vehicle>();
            }
            Size = size;
        }
        public int ParkingSpotId { get; set; }
        public int Size { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        [NotMapped] public string VehiclesString
        { 
            get 
            {
                string result = string.Empty;
                foreach (var item in Vehicles)
                {
                    result += $"#{item.Registration} ";
                }
                return result;
            } 
        }
        [NotMapped] public int Capacity
        {
            get
            {
                int capacity = Size;
                foreach (var item in Vehicles)
                {
                    capacity -= item.Size;
                }
                return capacity;
            }
        }
        [NotMapped] public string CellColor
        {
            get
            {
                int sum = Size; 
                string result = string.Empty;
                foreach (var item in Vehicles)
                {
                    sum -= item.Size;
                }
                if (sum >= Size)
                {
                    // Sets Cell Green
                    result = "empty";
                }
                if (sum <= 0)
                {
                    // Sets Cell Red
                    result = "full";
                }
                if (sum > 0 & sum < Size)
                {
                    // Sets Cell Yellow
                    result = "partial";
                }
                return result;
            }
        }
        public int ParkingGarageId { get; set; }
        [Required] public ParkingGarage Garage { get; set; }
    }
}
