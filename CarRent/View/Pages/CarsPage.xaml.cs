﻿using CarRent.dbEntities;
using CarRent.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRent.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarsPage.xaml
    /// </summary>
    public partial class CarsPage : Page
    {
        public CarsPage(Agent agent)
        {
            InitializeComponent();

            this.DataContext = new CarsPageVM(agent);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CarsPageVM).AddingOrEditingCar(null);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainDataGrid.SelectedItem != null)
            {
                (DataContext as CarsPageVM).AddingOrEditingCar((DataContext as CarsPageVM).SelectedItem);
            }
            else MessageBox.Show("Please sellect car for editing first", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CarsPageVM).DeleteCar();
        }
    }
}
