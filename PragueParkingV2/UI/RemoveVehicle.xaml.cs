using PragueParkingDataAccess;
using System.Windows;
using System.Linq;
using PragueParkingCore;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for RemoveVehicle.xaml
    /// </summary>
    public partial class RemoveVehicle : Window
    {
        ParkingContext context = DoStuffExtensions.context;
        DoStuff doStuff = new DoStuff();
        public RemoveVehicle()
        {
            InitializeComponent();
            doStuff.SupplyRemoveVehicleDataGrid(DoStuffExtensions.GetOccupiedParkingSpots(context));
            dataGridVehicleSelection.ItemsSource = DoStuffExtensions.GetOccupiedParkingSpots(context);
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridVehicleSelection.SelectedItems.GetType() == System.Type.GetType("ParkingSpot"))
            {
                foreach (ParkingSpot item in dataGridVehicleSelection.SelectedItems)
                {
                    // Print receipts here!!!
                    DoStuff.PrintReceipt();
                    //
                    item.Vehicles.Clear();
                }
            }
        }
    }
}
