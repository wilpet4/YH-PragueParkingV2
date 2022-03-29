using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PragueParkingDataAccess
{
    public class ParkingSpot
    {
        public ParkingSpot()
        {
            Size = 4;
        }
        public int ParkingSpotId { get; set; }
        public int Size { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; }
        [Required] public ParkingGarage Garage { get; set; }
    }
}
