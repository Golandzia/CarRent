using CarRent.dbEntities;
using CarRent.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.ViewModel
{
    public class CarsPageVM :  BaseVM
    {
        private ObservableCollection<Car> _cars;
        private Car _selectedItem;
        private bool _isDeleteFunctionAvaliable;

        public Car SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }
        public bool IsDeleteFunctionAvaliable
        {
            get => _isDeleteFunctionAvaliable;
            set
            {
                _isDeleteFunctionAvaliable = value;
                OnPropertyChanged(nameof(IsDeleteFunctionAvaliable));
            }
        }

        public CarsPageVM(Agent agent)
        {
            Cars = new ObservableCollection<Car>();

            var result = DBStorage.DB_s.Car.ToList();
            result.ForEach(elem => Cars?.Add(elem));

            if(agent.Post == 2)
            {
                IsDeleteFunctionAvaliable = true;
            }
            else IsDeleteFunctionAvaliable = false;
        }

        public void AddingCar(Car car)
        {
            var appWindow = new AddOrEditCarWindow(null);
            appWindow.Show();

            appWindow.Focus();
        }

    }
}
