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
    /// Логика взаимодействия для MainWorkspaceWindow.xaml
    /// </summary>
    public partial class MainWorkspaceWindow : Window
    {
        public MainWorkspaceWindow(Agent agent)
        {
            InitializeComponent();
            foreach (var item in App.Current.Windows)
            {
                if (item is MainWindow)
                {
                    Owner = (item as Window);
                }
            }// Определение родительского окна

            this.DataContext = new MainWorkspaceWindowVM(agent);
        }

        private void RentersNavigationBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWorkspaceWindowVM).RentersNavigationBtn_Click();
        }

        private void CurrentRentsNavigationBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWorkspaceWindowVM).CurrentRentsNavigationBtn_Click();
        }

        private void CarsNavigationBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWorkspaceWindowVM).CarsNavigationBtn_Click();
        }
    }
}
