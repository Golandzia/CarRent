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

        public void AddingOrEditingCar(Car car)
        {
            var appWindow = new AddOrEditCarWindow(car);
            appWindow.Show();

            appWindow.Focus();
        }

        public void DeleteCar()
        {
            var messageBoxResult = MessageBox.Show("The selected object will be permanently deleted.\nContinue?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            using (var db = new CarRentEntities1())
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    try
                    {
                        var entityForDelete = db.Car.Where(elem => elem.ID == SelectedItem.ID).FirstOrDefault();

                        db.Car.Remove(entityForDelete);
                        db.SaveChanges();

                        Cars.Clear();
                        var result = DBStorage.DB_s.Car.ToList();
                        result.ForEach(elem => Cars?.Add(elem));

                        MessageBox.Show("Selected item was deleted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Deletion error\n" + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

    }
}
