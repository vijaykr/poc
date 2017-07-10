using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.Design.Widget;

namespace ThaiAirways.Droid
{
    [Activity(Label = "ThaiAirways", MainLauncher = true, Icon = "@drawable/icon", Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class FlightLandingActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.FlightLanding);

            var bottomNavigaion = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation_view);
            bottomNavigaion.NavigationItemSelected += (s, e) =>
            {
                switch(e.Item.ItemId)
                {
                    case Resource.Id.book_flight:

                        Toast.MakeText(this, "Book Flight Clicked", ToastLength.Short).Show();
                        break;

                    case Resource.Id.timetable:

                        Toast.MakeText(this, "Timetable Clicked", ToastLength.Short).Show();
                        break;

                    case Resource.Id.flight_status:

                        Toast.MakeText(this, "Flight Status Clicked", ToastLength.Short).Show();
                        break;

                    case Resource.Id.my_booking:

                        Toast.MakeText(this, "My Booking Clicked", ToastLength.Short).Show();
                        break;
                }

            };

        }
    }
}

