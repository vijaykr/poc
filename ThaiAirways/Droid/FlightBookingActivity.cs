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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FlightBooking);

            departDate = CrossPlatformUtils.GetDeaprtDate();
            returnDate = CrossPlatformUtils.GetReturnDate();
          
            TextView tvDepartDD= FindViewById <TextView>(Resource.Id.tvDepartDD);
            TextView tvDepartMon = FindViewById<TextView>(Resource.Id.tvDepartMon);
            TextView tvDepartDay = FindViewById<TextView>(Resource.Id.tvDepartDay);
            TextView tvReturnDD = FindViewById<TextView>(Resource.Id.tvReturnDD);
            TextView tvReturnMonth = FindViewById<TextView>(Resource.Id.tvReturnMonth);
            TextView tvReturnDay = FindViewById<TextView>(Resource.Id.tvReturnDay);

            tvDepartDD.Text = departDate.Day.ToString();
            tvDepartMon.Text = departDate.ToString("MMM yyyy");
            tvDepartDay.Text = departDate.DayOfWeek.ToString();

            tvReturnDD.Text = returnDate.Day.ToString();
            tvReturnMonth.Text = returnDate.ToString("MMM yyyy");
            tvReturnDay.Text = returnDate.DayOfWeek.ToString();

            Button buttonSearchFlight = FindViewById<Button>(Resource.Id.SearchFlight);
            buttonSearchFlight.Click += btn_SearchFlightClick;

            ImageView Backbutton = FindViewById<ImageView>(Resource.Id.imageView1);
            Backbutton.Click += delegate {
                Finish();
            };
        }

        void btn_SearchFlightClick(object sender, EventArgs e)
        {
            ProgressBar progressBar = FindViewById<ProgressBar>(Resource.Id.progressbar1);
            progressBar.Visibility = ViewStates.Visible;

            FlighSearchModel.Instance.GetFlightDetails(1, 0, 0, "ECONOMY", departDate, "BKK", 0, returnDate, "HKG", "en-US", "USD");
            StartActivity(typeof(FlightListActivity));
        }
    }
}