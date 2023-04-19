using CarRent.dbEntities;
using CarRent.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRent.ViewModel.Windows
{
    public class AddingMakeWindowVM : BaseVM
    {
        private string _makeName;
        public string MakeName
        {
            get => _makeName;
            set
            {
                _makeName = value;
                OnPropertyChanged(nameof(MakeName));
            }
        }
        private Make_of_car _make = new Make_of_car();


        
        public void AddMakeToDB()
        {
            _make.Make = MakeName;
            var validateEntityResult = ValidateEntity();
            if (validateEntityResult.Length > 0)
            {
                MessageBox.Show(validateEntityResult.ToString(), "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                using (var db = new CarRentEntities1())
                {

                    db.Make_of_car.Add(_make);
                    db.SaveChanges();
                    MessageBox.Show("Data saved succesfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    foreach(var item in App.Current.Windows)
                    {
                        if(item is AddingMakeWindow) (item as Window).Close();
                        if(item is AddOrEditCarWindow) (item as Window).Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding mark\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private StringBuilder ValidateEntity()
        {
            var errors = new StringBuilder();
            if (String.IsNullOrEmpty(MakeName))
            {
                errors.AppendLine("\"Make name\" field cannot be empty ");
            }
            return errors;
        }
    }
}
