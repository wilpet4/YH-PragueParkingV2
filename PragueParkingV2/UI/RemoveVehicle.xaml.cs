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
        ParkingContext context = Db.Instance;
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
                         orderby v.ParkingSpotId
                         select new { v.ParkingSpotId, v.Registration, v.Arrival };
            List<dynamic> data = new List<dynamic>();
            data.AddRange(format.ToList());
            dataGridVehicleSelection.ItemsSource = data;
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
