using System.Windows;
using PragueParkingDataAccess;
using PragueParkingCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParkingContext context = new ParkingContext();
        public MainWindow()
        {
            InitializeComponent();
            context.Database.Migrate();
            RunSampleData(context);
        }

        private void buttonAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle addVehiclePopup = new AddVehicle(context);
            addVehiclePopup.Show();
        }
        private void RunSampleData(in ParkingContext context)
        {
            int garageSize = 8;
            ParkingGarage garage = new ParkingGarage();
            List<ParkingSpot> pSpots = new List<ParkingSpot>();
            for (int i = 0; i < garageSize; i++)
            {
                ParkingSpot p = new ParkingSpot();
                garage.ParkingSpots.Add(p);
                pSpots.Add(p);
            }
            context.Garages.Add(garage);
            context.SaveChanges();
        }
    }
}
