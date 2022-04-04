using System.Windows;
using PragueParkingDataAccess;
using PragueParkingCore;
using System.Linq;
using System.Collections.Generic;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Window
    {
        ParkingContext? context;
        public AddVehicle(ParkingContext context)
        {
            InitializeComponent();
            this.context = context;
            comboBoxParkingSpots.ItemsSource = LoadAvailableParkingSpots();
            comboBoxVehicleType.ItemsSource = DoStuffExtensions.GetAllVehicleTypes();

            #region Local Functions
            List<int> LoadAvailableParkingSpots()
            {
                List<int> result = new List<int>();
                var query = DoStuffExtensions.GetAllParkingSpots(context);
                foreach (var pSpot in query)
                {
                    if (pSpot.Vehicles.Count == 0) // kanske dumt
                    {
                        result.Add(pSpot.ParkingSpotId);
                    }
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
            ParkingSpot p = DoStuffExtensions.GetParkingSpot(context, comboBoxParkingSpots.SelectedIndex);
            switch ((DoStuffExtensions.VehicleTypes)comboBoxVehicleType.SelectedItem)
            {
                case DoStuffExtensions.VehicleTypes.Car:
                    Car newCar = new Car(reg);
                    p.Vehicles.Add(newCar);
                    break;
                case DoStuffExtensions.VehicleTypes.MC:
                    MC newMC = new MC(reg);
                    p.Vehicles.Add(newMC);
                    break;
                default:
                    break;
            }
            context.SaveChanges();
            //
            Close();
        }
    }
}
