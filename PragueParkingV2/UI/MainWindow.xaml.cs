﻿using System.Windows;
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
        public MainWindow()
        {
            InitializeComponent();
            ParkingContext context  = new ParkingContext();
            context.Database.Migrate();
        }

        private void buttonAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle addVehiclePopup = new AddVehicle();
            addVehiclePopup.Show();
        }
    }
}
