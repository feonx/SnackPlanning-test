using System;
using Acr.UserDialogs;
using Android.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace SnackPlanning.Droid.Views
{
    public class BaseActivity<TViewModel> : MvxAppCompatActivity<TViewModel> where TViewModel : class, IMvxViewModel
    {
        public BaseActivity()
        {
        }

        public void Initialize()
        {
            UserDialogs.Init(this);
        }
    }
}
