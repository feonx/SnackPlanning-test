using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace SnackPlanning.Droid.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class MainView : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
    }
}
