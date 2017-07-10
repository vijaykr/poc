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

            TextView tvDepartDD= FindViewById <TextView>(Resource.Id.tvDepartDD);
            TextView tvDepartMon = FindViewById<TextView>(Resource.Id.tvDepartMon);
            TextView tvDepartDay = FindViewById<TextView>(Resource.Id.tvDepartDay);
            TextView tvReturnDD = FindViewById<TextView>(Resource.Id.tvReturnDD);
            TextView tvReturnMonth = FindViewById<TextView>(Resource.Id.tvReturnMonth);
            TextView tvReturnDay = FindViewById<TextView>(Resource.Id.tvReturnDay);

            tvDepartDD.Text = departDate.Date.ToString();
            tvDepartMon.Text = departDate.Month.ToString();
            tvDepartDay.Text = departDate.Day.ToString();

            tvReturnDD.Text = returnDate.Date.ToString();
            tvReturnMonth.Text = returnDate.Month.ToString();
            tvReturnDay.Text = returnDate.Day.ToString();

            Button buttonSearchFlight = FindViewById<Button>(Resource.Id.SearchFlight);
            buttonSearchFlight.Click += btn_SearchFlightClick;

            StartActivity(typeof(FlightListActivity));
        }

        void btn_SearchFlightClick(object sender, EventArgs e)
        {
            FlighSearchModel.Instance.GetFlightDetails(1, 0, 0, "ECONOMY", departDate, "BKK", 0, returnDate, "HKG", "en-US", "USD");
        }
    }
}