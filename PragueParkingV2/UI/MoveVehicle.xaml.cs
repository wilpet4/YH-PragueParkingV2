using PragueParkingCore;
using PragueParkingDataAccess;
using System.Windows;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for MoveVehicle.xaml
    /// </summary>
    public partial class MoveVehicle : Window
    {
        ParkingContext context = Db.Instance;
        public MoveVehicle()
        {
            InitializeComponent();
            SetDataGridSource();
        }
        private void SetDataGridSource()
        {
            dataGridVehicles.ItemsSource = DoStuffExtensions.GetAllVehicles(context);
        }
    }
}
