using System.Windows;
using PragueParkingDataAccess;
using PragueParkingCore;
using Microsoft.EntityFrameworkCore;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParkingContext context = new ParkingContext();
        public MainWindow()
        {
            InitializeComponent();
            context.Database.Migrate();
        }

        private void buttonAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle addVehiclePopup = new AddVehicle(context);
            addVehiclePopup.Show();
            
        }
    }
}
