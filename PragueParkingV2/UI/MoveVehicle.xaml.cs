using PragueParkingCore;
using PragueParkingDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for MoveVehicle.xaml
    /// </summary>
    public partial class MoveVehicle : Window
    {
        ParkingContext context = Db.Instance;
        List<ParkingSpot> availableParkingSpots = new List<ParkingSpot>();

        public MoveVehicle()
        {
            InitializeComponent();
            SetDataGridSource();
        }
        private void SetDataGridSource()
        {
            dataGridVehicles.ItemsSource = FormatDataGrid(DoStuffExtensions.GetAllVehicles(context));
            List<Vehicle> FormatDataGrid(in List<Vehicle> listToFormat)
            {
                return listToFormat.OrderBy(v => v.ParkingSpotId).ToList();
            }
        }
        private List<int> LoadAvailableParkingSpotsID(in int minimumSize)
        {
            List<int> result = new List<int>();
            availableParkingSpots = DoStuffExtensions.GetAvailableParkingSpots(context, minimumSize);
            foreach (var pSpot in availableParkingSpots)
            {
                result.Add(pSpot.ParkingSpotId); //Finns det ett bättre sätt att bara ta ut 1 property ur en lista?
            }
            return result;
        }
        private void dataGridVehicles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                Vehicle selectedVehicle = (Vehicle)dataGridVehicles.SelectedItem;
                comboBoxParking.ItemsSource = LoadAvailableParkingSpotsID(selectedVehicle.Size);
            }
            catch (System.Exception)
            {
                MessageBox.Show("selection is not a vehicle");
            }
        }
    }
}
