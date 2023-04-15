using CarRent.dbEntities;
using System;
using System.Collections.Generic;
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
        

        private string _stateRegistrationPlate;
        private int _makeOfCar;
        private int _modelOfCar;
        private int _powerOfCar;
        private DateTime _lastMaintance;
        private int _mileage;
        private List<Color> _colors;
        private decimal _luxuryCoefficient;
        private SqlMoney _pricePerHour;
        private SqlMoney _pricePerDay;
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
        public SqlMoney PricePerHour
        {
            get => _pricePerHour;
            set
            {
                _pricePerHour = value;
                OnPropertyChanged(nameof(PricePerHour));
            }
        }
        public SqlMoney PricePerDay
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

            if (car is null)
            {
                FillingComboBoxes();
                _car = car = new Car();
                HeaderDescription = "Adding car";
            }
            else
            {
                //_car = car;
                //HeaderDescription = "Editing car";

                //StateRegistrationPlate = car.State_registration_plate;
                //MakeOfCar = car.Make;

            }
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

    }
}
