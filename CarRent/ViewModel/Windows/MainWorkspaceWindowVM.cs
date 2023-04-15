using CarRent.dbEntities;
using CarRent.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarRent.ViewModel
{
    public class MainWorkspaceWindowVM : BaseVM
    {
        private string _fullName;
        private Page _page;
        private string _currentRentsBtnColor = "#FF8D93A3";
        private string _rentersBtnColor = "#FF8D93A3";
        private string _carsBtnColor = "#FF8D93A3";
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        public Page Page
        {
            get => _page;
            set
            {
                _page = value;
                OnPropertyChanged(nameof(Page));
            }
        }
        public string CurrentRentsBtnColor
        {
            get => _currentRentsBtnColor;
            set
            {
                _currentRentsBtnColor = value;
                OnPropertyChanged(nameof(CurrentRentsBtnColor));
            }
        }
        public string RentersBtnColor
        {
            get => _rentersBtnColor;
            set
            {
                _rentersBtnColor = value;
                OnPropertyChanged(nameof(RentersBtnColor));
            }
        }
        public string CarsBtnColor
        {
            get => _carsBtnColor;
            set
            {
                _carsBtnColor = value;
                OnPropertyChanged(nameof(CarsBtnColor));
            }
        }


        public MainWorkspaceWindowVM(Agent agent)
        {
            FullName = agent.First_name + " " + agent.Second_name + " " + agent.Patronymic;
        }


        public void RentersNavigationBtn_Click(Agent agent)
        {
            Page = new RentersPage(agent);
            RentersBtnColor = "#FF9AB0BB";
            CurrentRentsBtnColor = "#FF8D93A3";
            CarsBtnColor = "#FF8D93A3";
        }

        public void CurrentRentsNavigationBtn_Click(Agent agent)
        {
            Page = new RentsPage(agent);
            CurrentRentsBtnColor = "#FF9AB0BB";
            CarsBtnColor = "#FF8D93A3";
            RentersBtnColor = "#FF8D93A3";
        }

        public void CarsNavigationBtn_Click(Agent agent)
        {
            Page = new CarsPage(agent);
            CarsBtnColor = "#FF9AB0BB";
            RentersBtnColor = "#FF8D93A3";
            CurrentRentsBtnColor = "#FF8D93A3";
        }
    }
}
