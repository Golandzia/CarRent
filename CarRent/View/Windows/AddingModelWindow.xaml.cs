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
    /// Логика взаимодействия для AddingModelWindow.xaml
    /// </summary>
    public partial class AddingModelWindow : Window
    {
        public AddingModelWindow()
        {
            InitializeComponent();

            this.DataContext = new AddingModelWindowVM();

            foreach(var item in App.Current.Windows)
            {
                if(item is AddOrEditCarWindow) Owner = (AddOrEditCarWindow)item;
            }
        }

        private void SaveModelBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddingModelWindowVM).SaveModelToDB();
        }
    }
}
