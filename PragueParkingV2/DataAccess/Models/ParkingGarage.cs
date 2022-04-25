using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PragueParkingDataAccess
{
    public class ParkingGarage
    {
        public ParkingGarage()
        {
            ParkingSpots = new List<ParkingSpot>();
        }
        [Key]public int GarageId { get; set; }
        public ICollection<ParkingSpot> ParkingSpots { get; set; }
    }
}
