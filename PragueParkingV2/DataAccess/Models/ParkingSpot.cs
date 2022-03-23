using System.Collections.Generic;

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
        public List<Vehicle>? Vehicles { get; set; }
    }
}
