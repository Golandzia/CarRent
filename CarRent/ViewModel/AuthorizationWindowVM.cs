using CarRent.dbEntities;
using CarRent.View.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRent.ViewModel
{
    public class AuthorizationWindowVM : BaseVM
    {
        private string _buttonDesc = "Login";

        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ButtonDescription
        {
            get => _buttonDesc;
            set
            {
                _buttonDesc = value;
                OnPropertyChanged(nameof(ButtonDescription));
            }
        }

        public Agent _agent;
        public async Task<bool> Authorize(string login, string password)
        {
            try
            {
                var result = await DbStorage.DB_s.Agent.FirstOrDefaultAsync(_agent => _agent.Login == login &&
                            _agent.Password == password);

                _agent = result;

                if (result != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Authentefication error",
                        MessageBoxButton.OK, MessageBoxImage.Stop);

                return false;
            }
        }


        public async void AuthinApp()
        {
            ButtonDescription = "Authorization...";

            if(await Authorize(Login, Password))
            {
                var appWindow = new MainWorkspaceWindow(_agent);
                appWindow.Show();
                foreach (var item in App.Current.Windows)
                {
                    if (item is MainWindow)
                    {
                        (item as Window).Hide();
                    }
                }
                ButtonDescription = "Login";
                return;
            }

            MessageBox.Show("Invalid login or password", "Authorization", MessageBoxButton.OK, MessageBoxImage.Error);
            ButtonDescription = "Login";
        }
    }
}
