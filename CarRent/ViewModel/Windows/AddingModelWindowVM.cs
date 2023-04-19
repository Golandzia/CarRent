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
    public class AddingModelWindowVM : BaseVM
    {
        private List<Make_of_car> _makesOfCars;
        private Make_of_car _selectedMake;
        private string _modelName;

        public List<Make_of_car> MakesOfCar
        {
            get => _makesOfCars;
            set
            {
                _makesOfCars = value;
                OnPropertyChanged(nameof(MakesOfCar));
            }
        }
        public Make_of_car SelectedMake
        {
            get => _selectedMake;
            set
            {
                _selectedMake = value;
                OnPropertyChanged(nameof(SelectedMake));
            }
        }
        public string ModelName
        {
            get => _modelName;
            set
            {
                _modelName = value;
                OnPropertyChanged(nameof(ModelName));
            }
        }

        private Model_of_car _modelOfCarToAdd;

        public AddingModelWindowVM()
        {
            _modelOfCarToAdd = new Model_of_car();
            FillingMakes();
        }

        public void SaveModelToDB()
        {
            try
            {
                var entityValidationResult = ValidateEntity();
                if (entityValidationResult.Length>0) 
                {
                    MessageBox.Show(entityValidationResult.ToString(), "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                using(var db = new CarRentEntities1())
                {
                    db.Model_of_car.Add(_modelOfCarToAdd);
                    db.SaveChanges();

                    foreach (var item in App.Current.Windows)
                    {
                        if (item is AddingModelWindow) (item as Window).Close();
                        if (item is AddOrEditCarWindow) (item as Window).Close();
                    }

                    MessageBox.Show("Data saved succesfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data base error occurved\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private StringBuilder ValidateEntity()
        {
            var errors = new StringBuilder();

            if (SelectedMake == null) errors.AppendLine("\"Make\" field cannot be empty");
            if (String.IsNullOrEmpty(ModelName)) errors.AppendLine("\"Model name\" field cannot be empty");

            _modelOfCarToAdd.Model = ModelName;
            _modelOfCarToAdd.Make = SelectedMake.ID;

            return errors;
        }
        private void FillingMakes()
        {
            MakesOfCar = DBStorage.DB_s.Make_of_car.ToList();
        }
    }
}
