using CarRent.dbEntities;
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
    /// Логика взаимодействия для RentersPage.xaml
    /// </summary>
    public partial class RentersPage : Page
    {
        public RentersPage(Agent agent)
        {
            InitializeComponent();

            this.DataContext = new RentersPageVM(agent);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as RentersPageVM).AddButton_Click(null);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as RentersPageVM).DeleteButton_Click();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if(MainDataGrid.SelectedItem != null)
            {
                (DataContext as RentersPageVM).AddButton_Click((DataContext as RentersPageVM).SelectedItem);
            }
            else MessageBox.Show("Select item to edit in first", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
