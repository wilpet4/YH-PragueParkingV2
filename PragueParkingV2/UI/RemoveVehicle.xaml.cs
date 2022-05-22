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
        ParkingContext context = DbSingleton.Instance;
        DoStuff doStuff = new DoStuff();
        public RemoveVehicle()
        {
            InitializeComponent();
            SetDataGridSource();
        }
        private List<Vehicle> FormatDataGrid()
        {
            List<Vehicle> vehicles = DoStuffStatics.GetAllVehicles(context);
            var format = from v in vehicles
                         orderby v.ParkingSpotId
                         select v;
            List<Vehicle> data = new List<Vehicle>();
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
            foreach (var item in dataGridVehicleSelection.SelectedItems) // Kanske i en egen metod fastän väldigt lite kod?
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

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            SimpleSearch(textBoxSearch.Text, out List<Vehicle> result);
            dataGridVehicleSelection.ItemsSource = result;
        }
        private void SimpleSearch(in string searchText, out List<Vehicle> result) // Väldigt enkel men dålig sökfunktion
        {                                                                         // Matchar bara mot exakta strängar
            string search = searchText;
            List<Vehicle> foundVehicles = new List<Vehicle>();
            if (search == string.Empty)
            {
                result = FormatDataGrid();
            }
            else
            {
                var carQuery = from c in context.Cars
                               where c.Registration.Equals(search)
                               select c;
                var mcQuery = from mc in context.MCs
                              where mc.Registration.Equals(search)
                              select mc;
                foundVehicles.AddRange(carQuery.ToList());
                foundVehicles.AddRange(mcQuery.ToList());
                result = foundVehicles;
            }
        }
    }
}
