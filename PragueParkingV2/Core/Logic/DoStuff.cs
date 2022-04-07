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
        ParkingContext context = ParkingContext.Instance;
        public (List<string> cars, List<string> mcs) GetAllVehicles()
        {
            var cars = from c in context.Cars
                       select c.Registration;

            var mcs = from mc in context.MCs
                      select mc.Registration;
            return (cars.ToList(), mcs.ToList());
        }

        public static void PrintReceipt()
        {
            throw new NotImplementedException();
        }
    }
    public static class DoStuffExtensions // flytta till egen fil senare kanske
    {
        public enum VehicleTypes { Car, MC } // Måste hålla denna uppdaterad. Inte kommit på ett bättre sätt än.
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
        
        public static List<ParkingSpot> GetAvailableParkingSpots(in ParkingContext context) 
        {
            var query = from p in context.ParkingSpots
                        where p.Vehicles.Count == 0
                        select p;
            return query.ToList();
        }
        public static ParkingSpot GetParkingSpot(in ParkingContext context, in int id)
        {
            int i = id + 1;
            var query = from p in context.ParkingSpots
                        where p.ParkingSpotId == i
                        select p;
            if (query.Any())
            {
                return query.First();
            }
            else
            {
                return null;
            }
        }
    }
}
