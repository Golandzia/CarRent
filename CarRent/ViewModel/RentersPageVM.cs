using CarRent.dbEntities;
using CarRent.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRent.ViewModel
{
    public class RentersPageVM : BaseVM
    {
        private ObservableCollection<Renter> _renters;
        public ObservableCollection<Renter> Renters
        {
            get => _renters;
            set
            {
                _renters = value;
                OnPropertyChanged(nameof(Renters));
            }
        }

        public RentersPageVM()
        {
            Renters = new ObservableCollection<Renter>();//Обязательно инициализировать!

            LoadDataFromDB();
        }

        public void LoadDataFromDB()
        {
            var result = DbStorage.DB_s.Renter.ToList();

            result.ForEach(elem => Renters?.Add(elem));
        }


        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var appWindow = new AddRenterWindow();
            appWindow.Show();

            
        }
    }
}
