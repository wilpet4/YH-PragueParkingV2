using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PragueParkingDataAccess
{
    public class ParkingSpot
    {
        public ParkingSpot()
        {
            Vehicles = new List<Vehicle>();
            Size = 4;
        }
        public ParkingSpot(in int size)
        {
            Size = size;
        }
        public int ParkingSpotId { get; set; }
        public int Size { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        [NotMapped] public string VehiclesString // Något ful property, finns säkeret ett bättre sätt, men fungerar bra nog.
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
                    //Set Cell Green
                    result = "green";
                }
                if (sum <= 0)
                {
                    //Set Cell Red
                    result = "red";
                }
                if (sum > 0 & sum < Size)
                {
                    //Set Cell Yellow
                    result = "yellow";
                }
                return result;
            }
        }
        public int ParkingGarageId { get; set; }
        [Required] public ParkingGarage Garage { get; set; }
    }
}
