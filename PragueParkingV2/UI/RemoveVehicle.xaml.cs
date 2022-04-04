using PragueParkingDataAccess;
using System.Windows;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for RemoveVehicle.xaml
    /// </summary>
    public partial class RemoveVehicle : Window
    {
        ParkingContext? context;
        public RemoveVehicle(PragueParkingDataAccess.ParkingContext context)
        {
            InitializeComponent();
        }
    }
}
