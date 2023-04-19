using CarRent.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRent.ViewModel.Windows
{
    public class AddingEditingRentWindowVM : BaseVM
    {
        private string _headerDescription;

        private DateTime _rentStartTime;
        private DateTime _rentEndTime;
        private DateTime _rentExtentionTime;
        private Car _car;
        private Renter _renter;
        private Rent_type _rentType;
        private Agent _agent;

        private Make_of_car _selectedCarMake;
        private Model_of_car _selectedCarModel;

        private List<Make_of_car> _allMakes;
        private List<Renter> _allRenters;
        private List<Rent_type> _allRentTypes;
        private List<Model_of_car> _modelsOfSelectedMake;// Марки выбранной модели
        private List<Car> _carsOfSelectedMakeAndModel;


        public string HeaderDescription
        {
            get => _headerDescription;
            set
            {
                _headerDescription = value;
                OnPropertyChanged(nameof(HeaderDescription));
            }
        }

        public DateTime RentStartTime
        {
            get => _rentStartTime;
            set
            {
                _rentStartTime = value;
                OnPropertyChanged(nameof(RentStartTime));
            }
        }
        public DateTime RentEndTime
        {
            get => _rentEndTime;
            set
            {
                _rentEndTime = value;
                OnPropertyChanged(nameof(RentEndTime));
            }
        }
        public DateTime RentExtentionTime
        {
            get => _rentExtentionTime; 
            set
            {
                _rentExtentionTime = value;
                OnPropertyChanged(nameof(RentExtentionTime));
            }
        }
        public Car Car
        {
            get => _car;
            set
            {
                _car = value;
                OnPropertyChanged(nameof(Car));
            }
        }
        public Renter Renter
        {
            get => _renter;
            set
            {
                _renter = value;
                OnPropertyChanged(nameof(Renter));
            }
        }
        public Rent_type Rent_Type
        {
            get => _rentType;
            set
            {
                _rentType = value;
                OnPropertyChanged(nameof(Rent_Type));
            }
        }
        public Agent Agent
        {
            get => _agent;
            set
            {
                _agent = value;
                OnPropertyChanged(nameof(Agent));
            }
        }

        public Make_of_car SelectedCarMake
        {
            get => _selectedCarMake;
            set
            {
                _selectedCarMake = value;
                OnPropertyChanged(nameof(SelectedCarMake));
                FillingModelsOfSelectedMake(value.ID);
            }
        }
        public Model_of_car SelectedCarModel
        {
            get => _selectedCarModel;
            set
            {
                _selectedCarModel = value;
                OnPropertyChanged(nameof(SelectedCarModel));
                FillingCarsOfSelectedMakeAndModel(value);
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
        public List<Renter> AllRenters
        {
            get => _allRenters;
            set
            {
                _allRenters = value;
                OnPropertyChanged(nameof(AllRenters));
            }
        }
        public List<Rent_type> AllRentTypes
        {
            get => _allRentTypes;
            set
            {
                _allRentTypes = value;
                OnPropertyChanged(nameof(AllRentTypes));
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
        public List<Car> CarsOfSelectedMakeAndModel
        {
            get => _carsOfSelectedMakeAndModel;
            set
            {
                _carsOfSelectedMakeAndModel = value;
                OnPropertyChanged(nameof(CarsOfSelectedMakeAndModel));
            }
        }


        private Rent _rent;
        public AddingEditingRentWindowVM(Rent rent)
        {
            FillingComboBoxes();
            if(rent == null)
            {
                _rent = rent = new Rent();
                HeaderDescription = "Adding new rent";
            }
            else
            {
                _rent = rent;
            }
        }

        public void AddOrEditRentToDB()
        {
            var ValidateEntityResult = ValidateEntity();
            if (ValidateEntityResult.Length > 0)
            {
                MessageBox.Show(ValidateEntityResult.ToString(), "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _rent.Start = RentStartTime;
            _rent.End = RentEndTime;
            _rent.Car = Car.ID;
            _rent.Renter = Renter.ID;
            _rent.Rent_type = Rent_Type.ID;
            _rent.Extention = RentExtentionTime;
            _rent.Agent = 5;

            try
            {
                using (var db = new CarRentEntities1())
                {
                    db.Rent.AddOrUpdate(_rent);
                    db.SaveChanges();
                    MessageBox.Show("Data saved succesfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error of saving data\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private StringBuilder ValidateEntity()
        {
            var errors = new StringBuilder();

            if (RentStartTime == null) errors.AppendLine("\"Rent start time field\" cannot be empty");
            if (RentEndTime == null) errors.AppendLine("\"Rent end time field\" cannot be empty");
            if (RentExtentionTime == null) errors.AppendLine("\"Extention field\" cannot be empty");
            if (SelectedCarMake is null) errors.AppendLine("\"Mark\" field cannot be empty");
            if (SelectedCarModel is null) errors.AppendLine("\"Model\" field cannot be empty");
            if (Car is null) errors.AppendLine("\"Car registration plate\" field cannot be empty");
            if (Renter is null) errors.AppendLine("\"Renter passport number\" field cannot be empty");
            if (Rent_Type is null) errors.AppendLine("\"Rent type\" field cannot be empty");

            return errors;
        }

        private void FillingComboBoxes()
        {
            AllMakes = DBStorage.DB_s.Make_of_car.ToList();
            AllRenters = DBStorage.DB_s.Renter.ToList();
            AllRentTypes = DBStorage.DB_s.Rent_type.ToList();
        }
        private void FillingModelsOfSelectedMake(int MakeSelected)
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
        private void FillingCarsOfSelectedMakeAndModel(Model_of_car CarModel)
        {
            try
            {
                CarsOfSelectedMakeAndModel = DBStorage.DB_s.Car.Where(item => item.Make == CarModel.Make && item.Model_of_car.Model == CarModel.Model).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex, "Non-existent mark or model selected", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }


        

    }
}
