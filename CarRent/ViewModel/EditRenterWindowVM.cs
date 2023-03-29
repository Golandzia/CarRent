using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.ViewModel
{
    public class EditRenterWindowVM : BaseVM
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



    }
}
