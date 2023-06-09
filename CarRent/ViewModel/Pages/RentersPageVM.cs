﻿using CarRent.dbEntities;
using CarRent.View.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CarRent.ViewModel
{
    public class RentersPageVM : BaseVM
    {
        private ObservableCollection<Renter> _renters;
        private bool _isDeleteFunctionAvaliable;
        private Renter _selectedItem;
        public bool IsDeleteFunctionAvaliable
        {
            get => _isDeleteFunctionAvaliable;
            set
            {
                _isDeleteFunctionAvaliable = value;
                OnPropertyChanged(nameof(IsDeleteFunctionAvaliable));
            }
        }
        public ObservableCollection<Renter> Renters
        {
            get => _renters;
            set
            {
                _renters = value;
                OnPropertyChanged(nameof(Renters));
            }
        }

        
        public Renter SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public RentersPageVM(Agent agent)
        {
            Renters = new ObservableCollection<Renter>();//Обязательно инициализировать!

            if(agent.Post == 2)
            {
                IsDeleteFunctionAvaliable = true;
            }
            else
            {
                IsDeleteFunctionAvaliable = false;
            }

            LoadDataFromDB();
        }

        public void LoadDataFromDB()
        {
            Renters.Clear();
            var result = DBStorage.DB_s.Renter.ToList();

            result.ForEach(elem => Renters?.Add(elem));
        }


        public void AddButton_Click(Renter renter)
        {
            var appWindow = new AddRenterWindow(renter);
            appWindow.Show();
        }

        public void DeleteButton_Click()
        {
            var messageBoxResult = MessageBox.Show("The selected object will be permanently deleted.\nContinue?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            using (var db = new CarRentEntities1())
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    try
                    {
                        var entityForDelete = db.Renter.Where(elem => elem.ID == SelectedItem.ID).FirstOrDefault();

                        db.Renter.Remove(entityForDelete);
                        db.SaveChanges();

                        LoadDataFromDB();
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
