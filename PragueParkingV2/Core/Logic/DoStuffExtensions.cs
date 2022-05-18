using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PragueParkingDataAccess;

namespace PragueParkingCore
{
    public static class DoStuffExtensions
    {
        public enum VehicleTypes { Car, MC } // Måste hålla denna uppdaterad om man vill lägga till fler fordonstyper. Inte kommit på ett bättre sätt än.
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
        public static List<ParkingSpot> GetAvailableParkingSpots(in ParkingContext context, in int minimumSize) 
        {
            List<ParkingSpot> result = new List<ParkingSpot>();
            var query = (from p in context.ParkingSpots
                        select p);
            foreach (var item in query)
            {
                if (item.Capacity >= minimumSize)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<ParkingSpot> GetOccupiedParkingSpots(in ParkingContext context)
        {
            var query = from p in context.ParkingSpots
                        where p.Vehicles.Count > 0
                        select p;
            return query.ToList();
        }
        public static ParkingSpot GetParkingSpot(in ParkingContext context, in int id)
        {
            int i = id;
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
        public static List<Vehicle> GetAllVehicles(in ParkingContext context)
        {
            List<Vehicle> result = new List<Vehicle>();
            var query = from v in context.Cars
                        select v;
            var query2 = from mc in context.MCs
                         select mc;
            result.AddRange(query.ToList());
            result.AddRange(query2.ToList());
            return result;
        }
        public static List<ParkingSpot> GetMainViewData(in ParkingContext context)
        {
            var query = (from p in context.ParkingSpots
                        orderby p.ParkingSpotId
                        select p).Include(p => p.Vehicles);
            List<ParkingSpot> result = query.ToList();
            return result;
        }
        public static bool CheckParkingSpotCapacity(in ParkingContext context, in ParkingSpot parkingSpot, Vehicle newVehicle)
        {
            int sum = 0;
            foreach (Vehicle item in parkingSpot.Vehicles)
            {
                sum += item.Size;
            }
            if (sum + newVehicle.Size <= parkingSpot.Size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int GetParkingSpotCapacity(in ParkingContext context, in ParkingSpot parkingSpot)
        {
            int sum = parkingSpot.Size;
            foreach (Vehicle v in parkingSpot.Vehicles)
            {
                sum -= v.Size;
            }
            return sum;
        }
    }
}
