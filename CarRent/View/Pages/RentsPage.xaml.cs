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
    /// Логика взаимодействия для RentsPage.xaml
    /// </summary>
    public partial class RentsPage : Page
    {
        public RentsPage(Agent agent)
        {
            InitializeComponent();

            this.DataContext = new RentsPageVM(agent);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as RentsPageVM).DeleteRent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as RentsPageVM).AddRent(null);
        }
    }
}
