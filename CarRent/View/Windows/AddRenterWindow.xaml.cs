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
    /// Логика взаимодействия для AddRenterWindow.xaml
    /// </summary>
    public partial class AddRenterWindow : Window
    {
        public AddRenterWindow()
        {
            InitializeComponent();

            foreach(var item in App.Current.Windows)
            {
                if(item is MainWorkspaceWindow)
                {
                    Owner = (item as Window);
                }
            }//Определение родительского окна

            this.Focus();

            this.DataContext = new AddRenterWindowVM();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddRenterWindowVM).AddBtn_Click(sender, e);
            Owner.Focus();
            this.Close();
        }
    }
}
