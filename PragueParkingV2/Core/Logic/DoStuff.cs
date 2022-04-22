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
        ParkingContext context = Db.Instance;
        public void SupplyRemoveVehicleDataGrid(List<ParkingSpot> parkingSpots)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (var item in parkingSpots)
            {
                foreach (Vehicle vehicle in item.Vehicles)
                {
                    result.Add(vehicle);
                }
            }
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

        public static List<object> GetMainViewData(in ParkingContext context) // Skitful men fungerar. fixa senare!!!
        {
            //List<Vehicle> result1 = new List<Vehicle>();
            //List<dynamic> result2 = new List<dynamic>();
            //var query1 = from c in context.Cars
            //            select c;
            //result1.AddRange(query1.ToList());
            //var query2 = from mc in context.MCs
            //        select mc;
            //result1.AddRange(query2.ToList());
            //result1.OrderBy(x => x.ParkingSpotId);
            //var query3 = from x in result1
            //             orderby x.ParkingSpotId
            //             select new { x.ParkingSpotId, x.Registration, x.Arrival, x.VehicleType};
            //result2.AddRange(query3.ToList());
            //return result2;

            List<dynamic> result1 = new List<dynamic>();
            var query1 = from p in context.ParkingSpots
                         orderby p.ParkingSpotId
                         select new { p.ParkingSpotId, p.Vehicles, p.Size };
            result1.AddRange(query1.ToList());
            return result1;
        }
        public static void CheckParkingSpotCapacity(in ParkingContext context)
        {

        }
    }
}
