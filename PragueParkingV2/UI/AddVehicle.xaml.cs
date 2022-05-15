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
        public AddVehicle()
        {
            InitializeComponent();
            comboBoxParkingSpots.ItemsSource = LoadAvailableParkingSpots();
            comboBoxVehicleType.ItemsSource = DoStuffExtensions.GetAllVehicleTypes();

            #region Local Functions
            List<int> LoadAvailableParkingSpots()
            {
                List<int> result = new List<int>();
                availableParkingSpots = DoStuffExtensions.GetAvailableParkingSpots(context);
                foreach (var pSpot in availableParkingSpots)
                {
                    result.Add(pSpot.ParkingSpotId);
                }
                return result;
            }
            #endregion
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
            switch ((DoStuffExtensions.VehicleTypes)comboBoxVehicleType.SelectedItem)
            {
                case DoStuffExtensions.VehicleTypes.Car:
                    Car newCar = new Car(reg);
                    if (DoStuffExtensions.CheckParkingSpotCapacity(context, p, newCar) == true)
                    {
                        p.Vehicles.Add(newCar);
                    }
                    break;
                case DoStuffExtensions.VehicleTypes.MC:
                    MC newMC = new MC(reg);
                    if (DoStuffExtensions.CheckParkingSpotCapacity(context, p, newMC) == true)
                    {
                        p.Vehicles.Add(newMC);
                    }
                    break;
                default:
                    break;
            }
            context.SaveChanges();
            //
            Close();
        }
        private void comboBoxVehicleType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxParkingSpots.IsEnabled = true;
            // Fixa så att comboBoxParkingSpots visar rätt p-platser!
        }

        private void comboBoxParkingSpots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonAdd.IsEnabled = true;
        }
    }
}
