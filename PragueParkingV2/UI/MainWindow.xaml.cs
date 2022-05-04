using System.Windows;
using PragueParkingDataAccess;
using PragueParkingCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Windows.Controls;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParkingContext context = Db.Instance;
        DoStuff doStuff = new DoStuff();
        public MainWindow()
        {
            InitializeComponent();
            if (context.Database.CanConnect() == false) // Nu kör den bara migrations när databasen inte finns.
            {
                context.Database.Migrate();
                doStuff.LoadSampleData();
            }
            dataGridMainDisplay.ItemsSource = DoStuffExtensions.GetMainViewData(context);
        }
        private void DisplayMainViewData()
        {
            List<ParkingSpot> data = DoStuffExtensions.GetAllParkingSpots(context);
            dataGridMainDisplay.ItemsSource = DoStuffExtensions.GetMainViewData(context);
            DataGridCell cell;
            foreach (ParkingSpot item in data)
            {
                int capacity = DoStuffExtensions.GetParkingSpotCapacity(context, item);
                if (capacity == item.Size)
                {
                    // Set cell green
                    dataGridMainDisplay.Items.Contains(item);

                }
                else if (capacity == 0)
                {
                    // Set cell red
                }
                else if (capacity > 0 && capacity < item.Size)
                {
                    // Sett cell yellow
                }
            }
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
        private void buttonRefreshView_Click(object sender, RoutedEventArgs e) // MEMORY LEAK
        {
            dataGridMainDisplay.ItemsSource = DoStuffExtensions.GetMainViewData(context);
        }
    }
}
