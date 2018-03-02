using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;

namespace SnackPlanning.Droid.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class MainView : MvxAppCompatActivity
    {
        DrawerLayout _drawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var navigationView = FindViewById<NavigationView>(Resource.Id.navigationView);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

            var drawerToggle = new MvxActionBarDrawerToggle(this, _drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);

            _drawerLayout.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();

        }

        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch(e.MenuItem.ItemId)
            {
                case Resource.Id.nav_home:

                    break;
            }

            _drawerLayout.CloseDrawers();
        }
           
    }
}
