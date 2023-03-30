using CarRent.dbEntities;
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
        
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }

        public CarsPageVM()
        {
            Cars = new ObservableCollection<Car>();

            var result = DbStorage.DB_s.Car.ToList();
            result.ForEach(car => Cars?.Add(car));


        }
    }
}
