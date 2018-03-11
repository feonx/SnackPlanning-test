using System;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using SnackPlanning.Core.Services.SnackAPI;
using System.Threading.Tasks;

namespace SnackPlanning.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        
        public LoginViewModel()
        {
        }

        private string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        public IMvxCommand LoginCommand => new MvxCommand(Login);
        private async void Login()
        {
            UserDialogs.Instance.ShowLoading("Bezig met inloggen...");

            var snackAPIClient = new Client();

            var userExists = snackAPIClient.UserExists(Username);

            await userExists.ContinueWith(httpRequest =>
            {
                UserDialogs.Instance.HideLoading();

                if(httpRequest.Status == TaskStatus.RanToCompletion)
                {
                    if (httpRequest.Result == true)
                    {
                        ShowViewModel<MainViewModel>();
                    }
                    else
                    {
                        UserDialogs.Instance.AlertAsync(AlertConfig.DefaultOkText, "De ingevoerde login gegevens zijn incorrect.");
                    }
                }
                else
                {
                    UserDialogs.Instance.AlertAsync(AlertConfig.DefaultOkText, "Er is een technische fout opgetreden.");
   
                }
            });

            userExists.Wait();

        }

        public IMvxCommand RegisterCommand => new MvxCommand(ShowRegisterView);
        private void ShowRegisterView()
        {
            ShowViewModel<RegisterViewModel>();
        }

    }
}
