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
    public class AddingCarColorWindowVM : BaseVM
    {
        private string _color;
        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        private Color _colorOfCarToAdd;
        
        public AddingCarColorWindowVM()
        {
            _colorOfCarToAdd = new Color();
        }

        public void AddColorToDB()
        {
            var entityValidationResult = ValidateEntity();

            if (entityValidationResult.Length > 0)
            {
                MessageBox.Show(entityValidationResult.ToString(), "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                using (var db = new CarRentEntities())
                {
                    db.Color.Add(_colorOfCarToAdd);
                    db.SaveChanges();

                    MessageBox.Show("Data saved succesfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    foreach (var item in App.Current.Windows)
                    {
                        if (item is AddingCarColorWindow) (item as Window).Close();
                        if (item is AddOrEditCarWindow) (item as Window).Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding color\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private StringBuilder ValidateEntity()
        {
            var errors = new StringBuilder();

            if (String.IsNullOrEmpty(Color)) errors.AppendLine("\"Color\" field cannot be empty");
            _colorOfCarToAdd.Value = Color;

            return errors;
        }
    }
}
