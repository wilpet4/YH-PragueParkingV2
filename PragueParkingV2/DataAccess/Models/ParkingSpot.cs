using System.Collections.Generic;

namespace PragueParkingDataAccess
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public List<Vehicle>? Vehicles { get; set; }
    }
}
