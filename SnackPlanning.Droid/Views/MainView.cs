using Android.App;
using Android.OS;

using MvvmCross.Droid.Support.V7.AppCompat;

using Android.Support.V4.Widget;

using Android.Support.V7.Widget;
using Android.Support.Design.Widget;

namespace SnackPlanning.Droid.Views
{
    [Activity()]
    public class MainView : MvxAppCompatActivity
    {
        DrawerLayout _drawerLayout;
        NavigationView _navigationView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainView);

            SetSupportActionBar(FindViewById<Toolbar>(Resource.Id.toolbar));

            SupportActionBar.SetDisplayShowTitleEnabled(false);

            _navigationView = FindViewById<NavigationView>(Resource.Id.navigationView);
            _navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

            var drawerToggle = FindViewById<AppCompatButton>(Resource.Id.drawerToggle);
            drawerToggle.Click += DrawerToggle_Click;

        }

        void DrawerToggle_Click(object sender, System.EventArgs e)
        {
            _drawerLayout.OpenDrawer(_navigationView);
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
