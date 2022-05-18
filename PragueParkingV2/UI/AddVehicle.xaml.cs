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
        private List<int> LoadAvailableParkingSpotsID(in int minimumSize)
        {
            List<int> result = new List<int>();
            availableParkingSpots = DoStuffExtensions.GetAvailableParkingSpots(context, minimumSize);
            foreach (var pSpot in availableParkingSpots)
            {
                result.Add(pSpot.ParkingSpotId); //Finns det ett bättre sätt att bara ta ut 1 property ur en lista?
            }
            return result;
        }
        private void comboBoxVehicleType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int minimumSize = 0;
            switch ((DoStuffExtensions.VehicleTypes)comboBoxVehicleType.SelectedItem)
            {
                case DoStuffExtensions.VehicleTypes.Car:
                    Car c = new Car();
                    minimumSize = c.Size;
                    break;
                case DoStuffExtensions.VehicleTypes.MC:
                    MC mc = new MC();
                    minimumSize = mc.Size;
                    break;
                default:
                    break;
            }
            comboBoxParkingSpots.IsEnabled = true;
            comboBoxParkingSpots.ItemsSource = LoadAvailableParkingSpotsID(minimumSize);
            // Fixa så att comboBoxParkingSpots visar rätt p-platser!
        }

        private void comboBoxParkingSpots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonAdd.IsEnabled = true;
        }
    }
}
