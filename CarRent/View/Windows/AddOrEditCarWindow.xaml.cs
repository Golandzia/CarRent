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
using System.Windows.Shapes;

namespace CarRent.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditCarWindow.xaml
    /// </summary>
    public partial class AddOrEditCarWindow : Window
    {
        public AddOrEditCarWindow(Car car)
        {
            InitializeComponent();

            foreach(var item in App.Current.Windows)
            {
                if (item is MainWorkspaceWindow) Owner = item as Window;
            }

            this.DataContext = new AddOrEditCarWindowVM(car);
        }

        private void addMarkBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddOrEditCarWindowVM).AddMake();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddOrEditCarWindowVM).AddOrEditCar();
        }

        private void AddModelBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddOrEditCarWindowVM).AddModel();
        }

        private void AddColorBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddOrEditCarWindowVM).AddColor();
        }
    }
}
