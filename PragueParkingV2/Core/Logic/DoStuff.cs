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
        DoStuff()
        {
            LoadConfig(); // Läser in xml-filen.
        }
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
        }
        private void LoadConfig()
        {
            configDocument = XDocument.Load(@"config.xml");
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
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string cleanDate = DateTime.Now.Date.ToString().Replace(':', '.');
            string fileName = $"{cleanDate}.{vehicle.Registration}.{vehicle.ParkingSpotId}.txt";
            if (Directory.Exists($@"{basePath}\Receipts") == false)
            {
                Directory.CreateDirectory($@"{basePath}\Receipts");
            }
            using (StreamWriter sw = File.CreateText($@"{basePath}\Receipts\{fileName}"))
            {
                sw.WriteLine($"Registration: {vehicle.Registration}");
                sw.WriteLine($"Parking: {vehicle.ParkingSpotId}");
                sw.WriteLine($"Arrival Time: {vehicle.Arrival}");
                sw.WriteLine($"Departure Time: {DateTime.Now}");
                sw.WriteLine($"Price: {CalculatePriceTotal(vehicle)}CZK");
                // Räkna ut pris här
            }
        }
        private int CalculatePriceTotal(in Vehicle vehicle)
        {
            int result = 0;
            DateTime arrival = vehicle.Arrival;
            DateTime departure = DateTime.Now;
            TimeSpan time = departure - arrival;
            double minutesParked = time.TotalMinutes;
            short freeTime = 10;
            short counter = 60;
            if (int.TryParse(configDocument.Descendants($"{vehicle.VehicleType.ToLower()}price").First().Value, out int price))
            {
                for (int i = 0; i < minutesParked; i++)
                {
                    if (i > freeTime)
                    {
                        counter++;
                        if (counter >= 60)
                        {
                            result += price;
                            counter = 0;
                        }
                    }
                }
            }
            return result;
        }
    }
}
