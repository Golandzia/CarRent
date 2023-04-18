using CarRent.dbEntities;
using CarRent.View.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace CarRent.ViewModel
{
    public class AddOrEditCarWindowVM : BaseVM
    {
        private string _headerDescription;
        private List<Make_of_car> _allMakes;
        private List<Car_status> _allStatuses;
        private List<Model_of_car> _modelsOfSelectedMake;// Марки выбранной модели
        private Make_of_car _selectedCarMake;
        private Model_of_car _selectedCarModel;
        private Color _selectedCarColor;
        private Car_status _selectedCarStatus;
        private int _selectedCarMakeForComboBox;
        

        private string _stateRegistrationPlate;
        private int _makeOfCar;
        private int _modelOfCar;
        private int _powerOfCar;
        private DateTime _lastMaintance;
        private int _mileage;
        private List<Color> _colors;
        private decimal _luxuryCoefficient;
        private decimal _pricePerHour;
        private decimal _pricePerDay;
        private int _carStatus;

        public string HeaderDescription
        {
            get => _headerDescription;
            set
            {
                _headerDescription = value;
                OnPropertyChanged(nameof(HeaderDescription));
            }
        }
        public List<Make_of_car> AllMakes 
        {
            get => _allMakes;
            set
            {
                _allMakes = value;
                OnPropertyChanged(nameof(AllMakes));
            }
        }
        public List<Car_status> AllStatuses
        {
            get => _allStatuses;
            set
            {
                _allStatuses = value;
                OnPropertyChanged(nameof(AllStatuses));
            }
        }
        public List<Model_of_car> ModelsOfSelectedMake
        {
            get => _modelsOfSelectedMake;
            set
            {
                _modelsOfSelectedMake = value;
                OnPropertyChanged(nameof(ModelsOfSelectedMake));
            }
        }
        public Make_of_car SelectedCarMake
        {
            get { return _selectedCarMake; }
            set
            {
                _selectedCarMake = value;
                OnPropertyChanged(nameof(SelectedCarMake));

                FillingModelsOfCar(value.ID);
            }
        }
        public Model_of_car SelectedCarModel
        {
            get => _selectedCarModel;
            set
            {
                _selectedCarModel = value;
                OnPropertyChanged(nameof(SelectedCarModel));
            }
        }
        public Color SelectedCarColor
        {
            get => _selectedCarColor;
            set
            {
                _selectedCarColor = value;
                OnPropertyChanged(nameof(SelectedCarColor));
            }
        }
        public Car_status SelectedCarStatus
        {
            get => _selectedCarStatus;
            set
            {
                _selectedCarStatus = value;
                OnPropertyChanged(nameof(SelectedCarStatus));
            }
        }
        public int SelectedCarMakeForComboBox
        {
            get => _selectedCarMakeForComboBox;
            set
            {
                _selectedCarMakeForComboBox = value;
                OnPropertyChanged(nameof(SelectedCarMakeForComboBox));
            }
        }

        public string StateRegistrationPlate
        {
            get => _stateRegistrationPlate;
            set
            {
                _stateRegistrationPlate = value;
                OnPropertyChanged(nameof(StateRegistrationPlate));
            }
        }
        public int MakeOfCar
        {
            get => _makeOfCar;
            set
            {
                _makeOfCar = value;
                OnPropertyChanged(nameof(MakeOfCar));
            }
        }
        public int ModelOfCar
        {
            get => _modelOfCar;
            set
            {
                _modelOfCar = value;
                OnPropertyChanged(nameof(ModelOfCar));
            }
        }
        public int PowerOfCar
        {
            get => _powerOfCar;
            set
            {
                _powerOfCar = value;
                OnPropertyChanged(nameof(PowerOfCar));
            }
        }
        public DateTime LastMaintance
        {
            get => _lastMaintance;
            set
            {
                _lastMaintance = value;
                OnPropertyChanged(nameof(LastMaintance));
            }
        }
        public int Milage
        {
            get => _mileage;
            set
            {
                _mileage = value;
                OnPropertyChanged(nameof(Milage));
            }
        }
        public List<Color> Colors
        {
            get => _colors;
            set
            {
                _colors = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        public decimal LuxaryCoeficient
        {
            get => _luxuryCoefficient;
            set
            {
                _luxuryCoefficient = value;
                OnPropertyChanged(nameof(LuxaryCoeficient));
            }
        }
        public decimal PricePerHour
        {
            get => _pricePerHour;
            set
            {
                _pricePerHour = value;
                OnPropertyChanged(nameof(PricePerHour));
            }
        }
        public decimal PricePerDay
        {
            get => _pricePerDay;
            set
            {
                _pricePerDay = value;
                OnPropertyChanged(nameof(PricePerDay));
            }
        }
        public int CarStatus
        {
            get => _carStatus;
            set
            {
                _carStatus = value;
                OnPropertyChanged(nameof(CarStatus));
            }
        }

        public Car _car = new Car();

        public AddOrEditCarWindowVM(Car car)
        {
            FillingComboBoxes();
            if (car is null)
            {
                _car = car = new Car();
                HeaderDescription = "Adding car";
            }
            else
            {
                _car = car;
                HeaderDescription = "Editing car";

                StateRegistrationPlate = car.State_registration_plate;

                Make_of_car _make = new Make_of_car();
                _make.Make = car.Make_of_car.Make;
                _make.ID = car.Color;
                SelectedCarMake = _make;

                Model_of_car _model = new Model_of_car();
                _model.Model = car.Model_of_car.Model;
                _model.ID = car.Model;
                _model.Make = car.Make;
                SelectedCarModel = _model;

                Color _color = new Color();
                _color.Value = car.Color1.Value;
                _color.ID = car.Color;
                SelectedCarColor = _color;

                PowerOfCar = car.Power;
                LastMaintance = car.Last_maintance;
                Milage = car.Mileage;
                LuxaryCoeficient = car.Luxury_coefficient;
                PricePerHour = car.Price_per_hour;
                PricePerDay = car.Price_per_day;

                Car_status _status = new Car_status();
                _status.Value = car.Car_status.Value;
                SelectedCarStatus = _status;

            }
        }

        public void AddOrEditCar()
        {
            var validateEntityResult = ValidateEntity();

            using (var db = new CarRentEntities())
            {
                try
                {
                    if (validateEntityResult.Length > 0)
                    {
                        MessageBox.Show(validateEntityResult.ToString(), "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    _car.State_registration_plate = StateRegistrationPlate;
                    _car.Make = SelectedCarMake.ID;
                    _car.Model = SelectedCarModel.ID;
                    _car.Color = SelectedCarColor.ID;
                    _car.Power = PowerOfCar;
                    _car.Last_maintance = LastMaintance;
                    _car.Mileage = Milage;
                    _car.Luxury_coefficient = LuxaryCoeficient;
                    _car.Price_per_day = PricePerDay;
                    _car.Price_per_hour = PricePerHour;
                    _car.Status = SelectedCarStatus.ID;

                    db.Car.AddOrUpdate(_car);
                    db.SaveChanges();
                    MessageBox.Show("Data saved succesfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error of saving data\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private StringBuilder ValidateEntity()
        {
            var errors = new StringBuilder();

            if (String.IsNullOrEmpty(StateRegistrationPlate)) errors.AppendLine("\"State registration plate\" field cannot be empty");
            if (SelectedCarMake is null) errors.AppendLine("\"Mark\" field cannot be empty");
            if (SelectedCarModel is null) errors.AppendLine("\"Model\" field cannot be empty");
            if (SelectedCarColor is null) errors.AppendLine("\"Color\" field cannot be empty");
            if (PowerOfCar <= 0) errors.AppendLine("\"Car power\" field cannot be empty");
            if (LastMaintance == null) errors.AppendLine("\"Last maintance\" field cannot be empty");
            if (Milage <= 0) errors.AppendLine("\"Milage\" field cannot be empty");
            if (LuxaryCoeficient <= 0) errors.AppendLine("\"Luxary coefficient\" field cannot be empty");
            if (PricePerDay <= 0) errors.AppendLine("\"Price per day\" field cannot be empty");
            if (PricePerHour <= 0) errors.AppendLine("\"Price per hour\" field cannot be empty");
            if (SelectedCarStatus is null) errors.AppendLine("\"Status\" field cannot be empty");

            

            return errors;
        }

        private void FillingComboBoxes()
        {
            AllMakes = DBStorage.DB_s.Make_of_car.ToList();
            AllStatuses = DBStorage.DB_s.Car_status.ToList();
            Colors = DBStorage.DB_s.Color.ToList();
        }

        private void FillingModelsOfCar(int MakeSelected)
        {
            try
            {
                ModelsOfSelectedMake = DBStorage.DB_s.Model_of_car.Where(item => item.Make == MakeSelected).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex, "Non-existent Make selected", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            
        }

        public void AddMake()
        {
            var appWindow = new AddingMakeWindow();
            appWindow.Show();
            appWindow.Focus();
        }
        public void AddModel()
        {
            var appWindow = new AddingModelWindow();
            appWindow.Show();
            appWindow.Focus();
        }
        public void AddColor()
        {
            var appWindow = new AddingCarColorWindow();
            appWindow.Show();
            appWindow.Focus();
        }

    }
}
