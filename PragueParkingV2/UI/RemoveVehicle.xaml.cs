using PragueParkingDataAccess;
using System.Windows;
using System.Linq;
using PragueParkingCore;
using System.Collections.Generic;

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
            FormatDataGrid();

        }
        private void FormatDataGrid()
        {
            List<Vehicle> vehicles = DoStuffExtensions.GetAllVehicles(context);
            var format = from v in vehicles
                         select new { v.Parking.ParkingSpotId, v.Registration, v.Arrival };
            dataGridVehicleSelection.ItemsSource = format.ToList();
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
