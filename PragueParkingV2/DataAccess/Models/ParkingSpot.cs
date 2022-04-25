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
        public int ParkingSpotId { get; set; }
        public int Size { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } // null problem här.
        public int ParkingGarageId { get; set; }
        [Required] public ParkingGarage Garage { get; set; }
    }
}
