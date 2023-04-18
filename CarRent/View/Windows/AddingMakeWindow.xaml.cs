using CarRent.ViewModel;
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
    /// Логика взаимодействия для AddingMakeWindow.xaml
    /// </summary>
    public partial class AddingMakeWindow : Window
    {
        public AddingMakeWindow()
        {
            InitializeComponent();

            foreach (var item in App.Current.Windows)
            {
                if(item is AddOrEditCarWindow)
                {
                    Owner = item as Window;
                }
            }

            this.DataContext = new AddingMakeWindowVM();
        }

        private void SaveMarkBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddingMakeWindowVM).AddMakeToDB();
        }
    }
}
