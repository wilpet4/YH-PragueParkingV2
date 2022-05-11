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
        private List<dynamic> FormatDataGrid(in List<Vehicle> vehicles)
        {
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
        }
        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in dataGridVehicleSelection.SelectedItems)
            {
                if (item.GetType().BaseType == typeof(Vehicle))
                {
                    Vehicle v = (Vehicle)item;
                    doStuff.PrintReceipt(v);
                    context.Remove(v);
                }
            }
            context.SaveChanges();
            Close();
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e) // Fungerar men inte rätt.
        {
            Dictionary<Vehicle, int> container = new Dictionary<Vehicle, int>();
            char[] search = textBoxSearch.Text.ToLower().ToCharArray();
            List<Vehicle> vehicles = DoStuffExtensions.GetAllVehicles(context);
            for(int i = 0; i < vehicles.Count; i++)
            {
                int counter = 0;
                for (int j = 0; j < search.Length; j++)
                {
                    if (vehicles[i].Registration.ToLower().Contains(search[j]))
                    {
                        counter++;
                    }
                }
                if (counter > 0)
                {
                    container.Add(vehicles[i], counter);
                }
            }
            List<Vehicle> searchResultList = new List<Vehicle>();
            foreach (var item in container.OrderBy(x => x.Value))
            {
                searchResultList.Add(item.Key);
            }
            dataGridVehicleSelection.ItemsSource = FormatDataGrid(searchResultList);
        }
    }
}
