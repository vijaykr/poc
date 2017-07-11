using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        Android.App.ProgressDialog progress;

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

            RunOnUiThread(() =>
			{
				ShowLoader(true);
			});

			Task.Run(() =>
			{
				
                FlighSearchModel.Instance.GetFlightDetails(1, 0, 0, "ECONOMY", departDate, "BKK", 0, returnDate, "HKG", "en-US", "USD");

				RunOnUiThread(() =>
				{
					ShowLoader(false);
					StartActivity(typeof(FlightListActivity));
				});
			});
           
        }


		/// <summary>
		/// BusyIndicator.
		/// </summary>
		public void CreateBusyIndicator()
		{
			progress = new ProgressDialog(this);
			progress.SetProgressStyle(ProgressDialogStyle.Spinner);
			progress.SetMessage("Just a moment...");
			progress.SetCancelable(false);
		}

		/// <summary>
		/// Show Loader
		/// </summary>
		/// <param name="isBusy">isBusy indicater, either true or false as input parameter.</param>
		public void ShowLoader(bool isBusy)
		{
			if (progress == null)
			{
				CreateBusyIndicator();
			}

			progress.Indeterminate = isBusy;
			if (isBusy)
			{
				progress.Show();
			}
			else
			{
				progress.Hide();
			}
		}


	}
}