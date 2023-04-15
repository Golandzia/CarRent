using CarRent.dbEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.ViewModel
{
    public class RentsPageVM : BaseVM
    {
        private Rent _selectedItem;
        private ObservableCollection<Rent> _rents;
        private bool _isDeleteFunctionAvaliable;

        public Rent SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public ObservableCollection<Rent> Rents
        {
            get => _rents;
            set
            {
                _rents = value;
                OnPropertyChanged(nameof(Rents));
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

        public RentsPageVM(Agent agent)
        {
            Rents = new ObservableCollection<Rent>();

            var result = DBStorage.DB_s.Rent.ToList();

            result.ForEach(elem => Rents?.Add(elem));

            if(agent.Post == 2) IsDeleteFunctionAvaliable = true;
            else IsDeleteFunctionAvaliable = false;
        }
    }
}
