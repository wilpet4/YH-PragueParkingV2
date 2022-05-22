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
        ParkingContext context = DbSingleton.Instance;
        List<ParkingSpot> availableParkingSpots = new List<ParkingSpot>();
        DoStuff doStuff = new DoStuff();
        Vehicle selectedVehicle;
        public MoveVehicle()
        {
            InitializeComponent();
            SetDataGridSource();
        }
        private void SetDataGridSource()
        {
            dataGridVehicles.ItemsSource = FormatDataGrid(DoStuffStatics.GetAllVehicles(context));
            List<Vehicle> FormatDataGrid(in List<Vehicle> listToFormat)
            {
                return listToFormat.OrderBy(v => v.ParkingSpotId).ToList();
            }
        }
        private List<int> LoadAvailableParkingSpotsID(in int minimumSize)
        {
            List<int> result = new List<int>();
            availableParkingSpots = DoStuffStatics.GetAvailableParkingSpots(context, minimumSize);
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
                selectedVehicle = (Vehicle)dataGridVehicles.SelectedItem;
                comboBoxParking.ItemsSource = LoadAvailableParkingSpotsID(selectedVehicle.Size);
            }
            catch (System.Exception)
            {
                MessageBox.Show("selection is not a vehicle");
                buttonConfirm.IsEnabled = false;
            }
        }
        private void comboBoxParking_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            buttonConfirm.IsEnabled = true;
        }
        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (selectedVehicle != null)
            {
                int.TryParse(comboBoxParking.SelectedItem.ToString(), out int result);
                doStuff.MoveVehicleToParkingSpot(selectedVehicle, result);
            }
            Close();
        }
    }
}
