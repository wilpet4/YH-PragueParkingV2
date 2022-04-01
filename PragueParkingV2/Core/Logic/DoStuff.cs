using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PragueParkingDataAccess;
using System.Collections;

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
    public static class DoStuffExtensions // flytta till egen fil senare kanske
    {
        public enum VehicleTypes { Car, MC }
        public static List<VehicleTypes> GetAllVehicleTypes()
        {
            List<VehicleTypes> result = new List<VehicleTypes>();
            result.Add(VehicleTypes.Car);
            result.Add(VehicleTypes.MC);
            return result;
        }
        public static List<ParkingSpot> GetAllParkingSpots(in ParkingContext context)
        {
            var query = from p in context.ParkingSpots
                        select p;
            return query.ToList();
        }
    }
}
