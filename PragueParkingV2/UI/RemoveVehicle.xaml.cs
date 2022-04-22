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
            SetDataGridSource();

        }
        private List<dynamic> FormatDataGrid()
        {
            List<Vehicle> vehicles = DoStuffExtensions.GetAllVehicles(context);
            var format = from v in vehicles
                         orderby v.ParkingSpotId
                         select v;
            List<dynamic> data = new List<dynamic>();
            data.AddRange(format.ToList());
            return data;
        }
        private void SetDataGridSource()
        {
            dataGridVehicleSelection.ItemsSource = FormatDataGrid();
            //dataGridVehicleSelection
        }
        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            int i = dataGridVehicleSelection.SelectedIndex;
            List<dynamic> data = FormatDataGrid();
            if (data[i] != null)
            {

            }
        }
    }
}
