using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PragueParkingDataAccess
{
    public class ParkingGarage
    {
        public ParkingGarage()
        {
            ParkingSpots = new List<ParkingSpot>(); // Riktigt äckligt, borde inte användas, men gör så att listan
        }                                           // inte ger ett null-error när man lägger in data för första gången
        [Key]public int GarageId { get; set; }
        public ICollection<ParkingSpot> ParkingSpots { get; set; }
    }
}
