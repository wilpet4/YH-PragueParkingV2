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
        } // Något ful property, finns säkeret ett bättre sätt, men fungerar bra nog.
        public int ParkingGarageId { get; set; }
        [Required] public ParkingGarage Garage { get; set; }
    }
}
