using CarRent.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace CarRent.ViewModel
{
    public class AddOrEditRenterWindowVM : BaseVM
    {
        private string _firstName;
        private string _secondName;
        private string _patronymic;
        private string _passportNum;
        private string _country;
        private string _drivingLicenseNum;
        private int _expOfDriving;
        private int _age;
        private string _phoneNumber;
        private string _email;
        private string _headerDescription;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string SecondName
        {
            get => _secondName;
            set
            {
                _secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }
        public string PassportNum
        {
            get => _passportNum;
            set
            {
                _passportNum = value;
                OnPropertyChanged(nameof(PassportNum));
            }
        }
        public string Country
        {
            get => _country;
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }
        public string DrivingLicenseNum
        {
            get => _drivingLicenseNum;
            set
            {
                _drivingLicenseNum = value;
                OnPropertyChanged(nameof(DrivingLicenseNum));
            }
        }
        public int ExpOfDriving
        {
            get => _expOfDriving;
            set
            {
                _expOfDriving = value;
                OnPropertyChanged(nameof(ExpOfDriving));
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string HeaderDescription
        {
            get => _headerDescription;
            set
            {
                _headerDescription = value;
                OnPropertyChanged(nameof(HeaderDescription));
            }
        }

        public Renter _renter = new Renter();

        public AddOrEditRenterWindowVM(Renter renter)
        {
            if(renter is null)
            {
                _renter = renter = new Renter();
                HeaderDescription = "Adding renter";
            }
            else
            {
                _renter = renter;
                HeaderDescription = "Editing renter";

                FirstName = renter.First_name;
                SecondName = renter.Second_name;
                Patronymic = renter.Patronymic;
                PassportNum = renter.Passport_num;
                Country = renter.Country;
                DrivingLicenseNum = renter.Driver_license_num;
                ExpOfDriving = renter.Expirence_of_driving;
                Age = renter.Age;
                PhoneNumber = renter.Phone_number;
                Email = renter.Email;

            }
        }

        public void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var validateEntityResult = ValidateEntity();

            using (var db = new CarRentEntities1())
            {
                if (validateEntityResult.Length > 0)
                {
                    MessageBox.Show(validateEntityResult.ToString(), "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                db.Renter.AddOrUpdate(_renter);
                db.SaveChanges();
                
                MessageBox.Show("Data saved succesfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }

        private StringBuilder ValidateEntity()
        {
            
            var errors = new StringBuilder();
            //errors = null;
            
            if(String.IsNullOrEmpty(FirstName))
            {
                errors.AppendLine("The field \"First Name\" cannot be empty");
            }
            if (String.IsNullOrEmpty(SecondName))
            {
                errors.AppendLine("The field \"Second name\" cannot be empty");
            }
            if (String.IsNullOrEmpty(PassportNum))
            {
                errors.AppendLine("The field \"Passport number\" cannot be empty");
            }
            if (String.IsNullOrEmpty(Country))
            {
                errors.AppendLine("The field \"Country\" cannot be empty");
            }
            if (String.IsNullOrEmpty(DrivingLicenseNum))
            {
                errors.AppendLine("The field \"Driving license number\" cannot be empty");
            }
            if (ExpOfDriving<= 0)
            {
                errors.AppendLine("The field \"Expirience of driving\" cannot be empty");
            }
            if(Age <=0)
            {
                errors.AppendLine("The field \"Age\" cannot be empty");
            }
            if (String.IsNullOrEmpty(PhoneNumber))
            {
                errors.AppendLine("The field \"Phone number\" cannot be empty");
            }
            if (String.IsNullOrEmpty(Email))
            {
                errors.AppendLine("The field \"Email\" cannot be empty");
            }

            _renter.First_name = FirstName;
            _renter.Second_name = SecondName;
            _renter.Patronymic = Patronymic;
            _renter.Passport_num = PassportNum;
            _renter.Country = Country;
            _renter.Driver_license_num = DrivingLicenseNum;
            _renter.Expirence_of_driving = ExpOfDriving;
            _renter.Age = Age;
            _renter.Email = Email;
            _renter.Phone_number = PhoneNumber;

            return errors;
        }
    }
}
