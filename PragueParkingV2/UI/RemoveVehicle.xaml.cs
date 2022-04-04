﻿using PragueParkingDataAccess;
using System.Windows;
using System.Linq;
using PragueParkingCore;

namespace PragueParkingUI
{
    /// <summary>
    /// Interaction logic for RemoveVehicle.xaml
    /// </summary>
    public partial class RemoveVehicle : Window
    {
        ParkingContext? context;
        public RemoveVehicle(PragueParkingDataAccess.ParkingContext context)
        {
            InitializeComponent();
            this.context = context;
            dataGridVehicleSelection.ItemsSource = DoStuffExtensions.GetAllParkingSpots(context);
        }
    }
}
