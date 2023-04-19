using CarRent.dbEntities;
using CarRent.ViewModel.Windows;
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
    /// Логика взаимодействия для AddingEditingRentWindow.xaml
    /// </summary>
    public partial class AddingEditingRentWindow : Window
    {
        public AddingEditingRentWindow(Rent rent)
        {
            InitializeComponent();

            this.DataContext = new AddingEditingRentWindowVM(rent);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddingEditingRentWindowVM).AddOrEditRentToDB();
        }
    }
}
