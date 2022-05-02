using PragueParkingDataAccess;
using System.Windows;
using System.Linq;
using PragueParkingCore;
using System.Collections.Generic;
using System;

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
            foreach (var item in dataGridVehicleSelection.SelectedItems)
            {
                if (item.GetType().BaseType == typeof(Vehicle))
                {
                    Vehicle v = (Vehicle)item;
                    context.Remove(v);
                }
            }
            context.SaveChanges();
            Close();
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            char[] search = textBoxSearch.Text.ToLower().ToCharArray();
            List<Vehicle> vehicles = DoStuffExtensions.GetAllVehicles(context);
            for(int i = 0; i < vehicles.Count; i++)
            {

            }
        }
    }
}
