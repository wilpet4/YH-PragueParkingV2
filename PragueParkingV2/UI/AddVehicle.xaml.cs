using System.Windows;
using PragueParkingDataAccess;

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
            comboBoxParkingSpots.Items.Clear();
        }
    }
}
