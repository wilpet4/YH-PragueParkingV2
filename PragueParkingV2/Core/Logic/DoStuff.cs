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
using System.Windows;

namespace PragueParkingCore
{
    public class DoStuff
    {
        public DoStuff()
        {
            LoadConfig(); // Läser in xml-filen.
        }
        ParkingContext context = DbSingleton.Instance;
        XDocument configDocument;
        public void LoadSampleData() // Skapar p-platser med lite olika storlek.
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
                if (i < 8)
                {
                    p.Size = 2;
                }
                if (i > 90)
                {
                    p.Size = 6;
                }
                context.Garages.FirstOrDefault().ParkingSpots.Add(p);
            }
            context.SaveChanges();
        }
        public void LoadConfig()
        {
            configDocument = XDocument.Load(@"config.xml");
        }
        public void PrintReceipt(in Vehicle vehicle) // Simulerar utskrift av kvitto genom att
        {                                            // skapa en texfil i PragueParkingV2\UI\bin\Debug\net6.0-windows\Receipts
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string cleanDate = DateTime.Now.Date.ToString().Replace(':', '.');
            string fileName = $"{cleanDate}.{vehicle.Registration}.{vehicle.ParkingSpotId}.txt";
            int price = CalculatePriceTotal(vehicle);
            if (Directory.Exists($@"{basePath}\Receipts") == false)
            {
                Directory.CreateDirectory($@"{basePath}\Receipts");
            }
            context.Receipts.Add(new Receipt { Registration = vehicle.Registration, 
                                               ParkingSpotId = vehicle.ParkingSpotId, 
                                               Arrival = vehicle.Arrival, 
                                               Departure = DateTime.Now, 
                                               Price = price});
            using (StreamWriter sw = File.CreateText($@"{basePath}\Receipts\{fileName}"))
            {
                sw.WriteLine($"Registration: {vehicle.Registration}");
                sw.WriteLine($"Parking: {vehicle.ParkingSpotId}");
                sw.WriteLine($"Arrival Time: {vehicle.Arrival}");
                sw.WriteLine($"Departure Time: {DateTime.Now}");
                sw.WriteLine($"Price: {price}CZK");
            }
            context.SaveChanges();
        }
        private int CalculatePriceTotal(in Vehicle vehicle)
        {
            int result = 0;
            DateTime arrival = vehicle.Arrival;
            DateTime departure = DateTime.Now;
            TimeSpan time = departure - arrival; // Hämtar ut skillnad mellan 2 datum.
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
        public void AddNewVehicleToParkingSpot(in DoStuffStatics.VehicleTypes type, in ParkingSpot p, in string reg)
        {
            switch (type)
            {
                case DoStuffStatics.VehicleTypes.Car:
                    Car newCar = new Car(reg);
                    if (DoStuffStatics.CheckParkingSpotCapacity(context, p, newCar) == true)
                    {
                        p.Vehicles.Add(newCar);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("The selected spot is too full. Cannot add vehicle.", "Error");
                    }
                    break;
                case DoStuffStatics.VehicleTypes.MC:
                    MC newMC = new MC(reg);
                    if (DoStuffStatics.CheckParkingSpotCapacity(context, p, newMC) == true)
                    {
                        p.Vehicles.Add(newMC);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("The selected spot is too full. Cannot add vehicle.", "Error");
                    }
                    break;
                default:
                    break;
            }
        }
        public void MoveVehicleToParkingSpot(in Vehicle vehicle, in int parkingSpotID) // "Byter" plats på fordon genom att lägga in det i ny plats och ta bort från förra.
        {
            ParkingSpot previousParkingSpot = DoStuffStatics.GetParkingSpot(context, vehicle.ParkingSpotId);
            ParkingSpot newParkingSpot = DoStuffStatics.GetParkingSpot(context, parkingSpotID);
            if (DoStuffStatics.CheckParkingSpotCapacity(context, newParkingSpot, vehicle))
            {
                newParkingSpot.Vehicles.Add(vehicle);
                previousParkingSpot.Vehicles.Remove(vehicle);
                context.SaveChanges();
            }
        }
    }
}
