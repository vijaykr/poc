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
using ThaiAirways.Model;
using ThaiAirways.Utils;

namespace ThaiAirways.Droid
{
  
    [Activity(Theme = "@android:style/Theme.Material.Light", Label = "BookFlight", MainLauncher = false)]
    public class FlightBookingActivity : Activity
    {
        DateTime departDate;
        DateTime returnDate;


        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);


            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FlightBooking);

            departDate = CrossPlatformUtils.GetDeaprtDate();
            returnDate = CrossPlatformUtils.GetReturnDate();

            FlighSearchModel.Instance.GetFlightDetails(1, 0, 0, "ECONOMY", departDate, "BKK", 0, returnDate, "HKG", "en-US", "USD");
        }


        public void getData()
        {

        }
    }
}