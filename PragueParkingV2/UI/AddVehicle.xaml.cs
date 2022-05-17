using System.Windows;
using PragueParkingDataAccess;
using PragueParkingCore;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Window
    {
        ParkingContext context = Db.Instance;
        List<ParkingSpot> availableParkingSpots = new List<ParkingSpot>();
        DoStuff doStuff = new DoStuff();
        public AddVehicle()
        {
            InitializeComponent();
            comboBoxVehicleType.ItemsSource = DoStuffExtensions.GetAllVehicleTypes();
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (context == null)
            {
                return;
            }
            // Kanske flytta detta till en egen metod.
            string reg = textBoxRegistration.Text;
            var vehicleInput = (DoStuffExtensions.VehicleTypes)comboBoxVehicleType.SelectedItem;
            ParkingSpot p = DoStuffExtensions.GetParkingSpot(context, availableParkingSpots[comboBoxParkingSpots.SelectedIndex].ParkingSpotId);
            doStuff.AddNewVehicleToParkingSpot((DoStuffExtensions.VehicleTypes)comboBoxVehicleType.SelectedItem, p, reg);
            //
            Close();
        }
        private List<int> LoadAvailableParkingSpots()
        {
            List<int> result = new List<int>();
            availableParkingSpots = DoStuffExtensions.GetAvailableParkingSpots(context);
            foreach (var pSpot in availableParkingSpots)
            {
                result.Add(pSpot.ParkingSpotId);
            }
            return result;
        }
        private void comboBoxVehicleType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxParkingSpots.IsEnabled = true;
            comboBoxParkingSpots.ItemsSource = LoadAvailableParkingSpots();
            // Fixa så att comboBoxParkingSpots visar rätt p-platser!
        }

        private void comboBoxParkingSpots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonAdd.IsEnabled = true;
        }
    }
}
