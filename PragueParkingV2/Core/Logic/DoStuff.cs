using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PragueParkingDataAccess;
using System.Collections;
using System.IO;
using System.Xml.Linq;

namespace PragueParkingCore
{
    public class DoStuff
    {
        ParkingContext context = Db.Instance;
        XDocument configDocument;
        public void LoadSampleData()
        {
            LoadConfig();
            int parkingSpots = 0;
            int.TryParse(configDocument.Descendants("parkingspots").First().Value, out parkingSpots);
            if (context.Garages.Any() == false)
            {
                context.Garages.Add(new ParkingGarage());
                context.SaveChanges();
            }
            for (int i = 0; i < parkingSpots; i++)
            {
                ParkingSpot p = new ParkingSpot { ParkingGarageId = 1 };
                context.Garages.FirstOrDefault().ParkingSpots.Add(p);
            }
            context.SaveChanges();
            void LoadConfig()
            {
                configDocument = XDocument.Load(@"config.xml");
            }
        }
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
        public void PrintReceipt(in Vehicle vehicle)
        {
            using (StreamWriter sw = File.CreateText($"{DateTime.Now.Date}.{vehicle.Registration}.{vehicle.ParkingSpotId}"))
            {
                sw.WriteLine($"Registration: {vehicle.Registration}");
                sw.WriteLine($"Parking: {vehicle.ParkingSpotId}");
                sw.WriteLine($"Arrival Time: {vehicle.Arrival}");
                sw.WriteLine($"Departure Time: {DateTime.Now}");
            }
        }
        private void CalculatePriceTotal()
        {
            foreach (DoStuffExtensions.VehicleTypes item in Enum.GetValues(typeof(DoStuffExtensions.VehicleTypes)))
            {

            }
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
            List<dynamic> result1 = new List<dynamic>();
            var query1 = from p in context.ParkingSpots
                         orderby p.ParkingSpotId
                         select new { p.ParkingSpotId, p.Vehicles, p.Size };
            result1.AddRange(query1.ToList());
            return result1;
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
