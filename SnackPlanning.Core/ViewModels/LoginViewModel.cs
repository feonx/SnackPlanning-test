using System;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;

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
        private void Login()
        {
            UserDialogs.Instance.ShowLoading("Bezig met inloggen...");

            ShowViewModel<MainViewModel>();

            UserDialogs.Instance.HideLoading();
        }
    }
}
