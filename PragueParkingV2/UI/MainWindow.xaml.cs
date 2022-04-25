using System.Windows;
using PragueParkingDataAccess;
using PragueParkingCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParkingContext context = Db.Instance;
        public MainWindow()
        {
            InitializeComponent();
            context.Database.Migrate(); //Problemet med migration är att all data seeding följer med.
                                        //dvs ändringar i config.xml fungerar inte tills man gör en ny migration.
            dataGridMainDisplay.ItemsSource = DoStuffExtensions.GetMainViewData(context);
        }

        private void buttonAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle addVehiclePopup = new AddVehicle();
            addVehiclePopup.Show();
        }
        private void buttonRemoveVehicle_Click(object sender, RoutedEventArgs e)
        {
            RemoveVehicle removeVehiclePopup = new RemoveVehicle();
            removeVehiclePopup.Show();
        }
        private void buttonRefreshView_Click(object sender, RoutedEventArgs e)
        {
            dataGridMainDisplay.ItemsSource = DoStuffExtensions.GetMainViewData(context);
        }
    }
}
