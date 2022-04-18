using System.Windows;
using PragueParkingDataAccess;
using PragueParkingCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParkingContext context = Db.Instance;
        public MainWindow()
        {
            InitializeComponent();

            context.Database.Migrate();
            //RunSampleData();
            //AddParkingSpots();

            dataGridMainDisplay.ItemsSource = DoStuffExtensions.GetMainViewData(context);
        }

        private void buttonAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle addVehiclePopup = new AddVehicle();
            addVehiclePopup.Show();
        }
        private void buttonRemoveVehicle_Click(object sender, RoutedEventArgs e)
        {
            RemoveVehicle removeVehiclePopup = new RemoveVehicle();
            removeVehiclePopup.Show();
        }
        private void RunSampleData()
        {
            ParkingGarage garage = new ParkingGarage();
            context.Garages.Add(garage);
            context.SaveChanges();
        }
        private void AddParkingSpots()
        {
            int garageSize = 8;
            ParkingGarage garage = context.Garages.FirstOrDefault();
            for (int i = 0; i < garageSize; i++)
            {
                ParkingSpot p = new ParkingSpot();
                garage.ParkingSpots.Add(p);
            }
            context.SaveChanges();
        }
        private void buttonRefreshView_Click(object sender, RoutedEventArgs e)
        {
            dataGridMainDisplay.ItemsSource = DoStuffExtensions.GetMainViewData(context);
        }
    }
}
