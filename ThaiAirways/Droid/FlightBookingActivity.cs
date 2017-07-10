using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ThaiAirways.Droid
{
  
    [Activity(Theme = "@android:style/Theme.Material.Light", Label = "BookFlight", MainLauncher = false)]
    public class FlightBookingActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FlightBooking);
        }

        public void getData()
        {

        }
    }
}