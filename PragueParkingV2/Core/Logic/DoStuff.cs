using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PragueParkingDataAccess;

namespace PragueParkingCore
{
    public class DoStuff
    {
        public (List<string> cars, List<string> mcs) GetAllVehicles(in ParkingContext context)
        {
            var cars = from c in context.Cars
                       select c.Registration;

            var mcs = from mc in context.MCs
                      select mc.Registration;
            return (cars.ToList(), mcs.ToList());
        }
    }
}
