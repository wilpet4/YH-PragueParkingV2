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
        public AddVehicle(ParkingContext context)
        {
            InitializeComponent();
            comboBoxParkingSpots.ItemsSource = LoadAvailableParkingSpots();
            comboBoxVehicleType.ItemsSource += "Car"; //dumdum
            comboBoxVehicleType.ItemsSource += "MC";

            #region Local Functions
            List<int> LoadAvailableParkingSpots()
            {
                List<int> result = new List<int>();
                var query = DoStuffExtensions.GetAllParkingSpots(context);
                foreach (var pSpot in query)
                {
                    if (pSpot.Vehicles == null) // kanske dumt
                    {
                        result.Add(pSpot.ParkingSpotId);
                    }
                }
                return result;
            }
            #endregion
        }
    }
}
