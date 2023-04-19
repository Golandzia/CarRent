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
    public class RentsPageVM : BaseVM
    {
        private Rent _selectedItem;
        private ObservableCollection<Rent> _rents;
        private bool _isDeleteFunctionAvaliable;
        private Agent _agent;
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

            _agent = agent;

            if(agent.Post == 2) IsDeleteFunctionAvaliable = true;
            else IsDeleteFunctionAvaliable = false;
        }

        public void DeleteRent()
        {
            var messageBoxResult = MessageBox.Show("The selected object will be permanently deleted.\nContinue?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            using (var db = new CarRentEntities1())
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    try
                    {
                        var entityForDelete = db.Rent.Where(elem => elem.ID == SelectedItem.ID).FirstOrDefault();

                        db.Rent.Remove(entityForDelete);
                        db.SaveChanges();

                        Rents.Clear();
                        var result = DBStorage.DB_s.Rent.ToList();
                        result.ForEach(elem => Rents?.Add(elem));

                        MessageBox.Show("Selected item was deleted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Deletion error\n" + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public void AddRent(Rent rent)
        {
            var appWindow = new AddingEditingRentWindow(rent);
            appWindow.Show();
            appWindow.Focus();
        }

    }
}
