using CarRent.dbEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
