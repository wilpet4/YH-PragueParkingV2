using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParkingDataAccess
{
    public static class Db
    {
        private static ParkingContext instance; // Singleton
        public static ParkingContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ParkingContext();
                }
                return instance;
            }
        }
    }
}
