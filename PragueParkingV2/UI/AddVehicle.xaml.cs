using System.Windows;
using PragueParkingDataAccess;
using System.Linq;

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
            var query = from id in context.ParkingSpots
                        select id.ParkingSpotId;
            comboBoxParkingSpots.ItemsSource = query.ToList();
            comboBoxVehicleType.ItemsSource += "Car"; //dumdum
            comboBoxVehicleType.ItemsSource += "MC";

        }
    }
}
