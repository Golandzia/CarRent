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
    /// Логика взаимодействия для AddingCarColorWindow.xaml
    /// </summary>
    public partial class AddingCarColorWindow : Window
    {
        public AddingCarColorWindow()
        {
            InitializeComponent();

            this.DataContext = new AddingCarColorWindowVM();

            foreach(var item in App.Current.Windows)
            {
                if (item is AddOrEditCarWindow) Owner = (item as Window);
            }
        }

        private void SaveMarkBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddingCarColorWindowVM).AddColorToDB();
        }
    }
}
