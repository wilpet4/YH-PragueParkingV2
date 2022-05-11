using System;
using System.ComponentModel.DataAnnotations;

namespace PragueParkingDataAccess
{
    public class Receipt
    {
        public Receipt() { }
        public int ReceiptId { get; set; }
        public string Registration { get; set; }

        public int ParkingSpotId { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public int Price { get; set; }
    }
}
