using System.Windows;
using PragueParkingDataAccess;
using PragueParkingCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Windows.Controls;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParkingContext context = Db.Instance;
        DoStuff doStuff = new DoStuff();
        public MainWindow()
        {
            InitializeComponent();
            doStuff.LoadConfig();
            if (context.Database.CanConnect() == false) // Nu kör den bara migrations när databasen inte finns.
            {
                context.Database.Migrate();
                doStuff.LoadSampleData();
            }
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

        private void dataGridMainDisplay_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e) // Fungerar lite konstigt. uppdaterar inte direkt, ibland måste 
        {                                                                                                          // man scrolla lite eller trycka på datagrid för att den ska uppdateras
            dataGridMainDisplay.ItemsSource = DoStuffExtensions.GetMainViewData(context);
        }

        private void buttonReloadConfig_Click(object sender, RoutedEventArgs e)
        {
            doStuff.LoadConfig();
        }

        private void buttonMoveVehicle_Click(object sender, RoutedEventArgs e)
        {
            MoveVehicle moveVehiclePopup = new MoveVehicle();
            moveVehiclePopup.Show();
        }
    }
}
