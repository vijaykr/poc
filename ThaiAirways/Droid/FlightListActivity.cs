using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7;
using Android.Support.V7.Widget;
using Android.OS;
using System.Collections.Generic;
using ThaiAirways.Model.Vo;
using ThaiAirways.Model;
using ThaiAirways.Utils;
using System.Threading.Tasks;

namespace ThaiAirways.Droid
{
   
    [Activity(Theme = "@style/MyCustomTheme", MainLauncher = false, Icon = "@drawable/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class FlightListActivity : Activity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        FlightRecyclerAdapter mAdapter;

        DateTime departDate;
        DateTime returnDate;
        protected override void OnResume()
        {

            base.OnResume();
            
            List<FlightSearchEntity> flightsData = new List<FlightSearchEntity>();
            flightsData = FlighSearchModel.Instance.FlightList;
                        
            if (flightsData != null)
            {
               // FindViewById<TextView>(Resource.Id.txtNumberOfFlights).Text = flightsData.Count.ToString();


                FindViewById<TextView>(Resource.Id.txtOriginToDestPlaceTop).Text = "Bangkok to Hong Kong";
                FindViewById<TextView>(Resource.Id.txtDepDateTop).Text = CrossPlatformUtils.GetDateInDayDateMonth(departDate);
                FindViewById<TextView>(Resource.Id.txtRetDateTop).Text = CrossPlatformUtils.GetDateInDayDateMonth(returnDate);

                flightsData = FlighSearchModel.Instance.FlightList;

                mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

                // Plug in the linear layout manager:
                mLayoutManager = new LinearLayoutManager(this);
                mRecyclerView.SetLayoutManager(mLayoutManager);
                //mRecyclerView.GetLayoutManager().ScrollToPosition(200);

                // Plug in my adapter:
                mAdapter = new FlightRecyclerAdapter(flightsData);
              
                mRecyclerView.SetAdapter(mAdapter);
            }
            else
            {
               // FindViewById<TextView>(Resource.Id.txtNumberOfFlights).Text = "";
                FindViewById<TextView>(Resource.Id.textView10).Text = "No flight found";
            }           
        }

        
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            departDate = CrossPlatformUtils.GetDeaprtDate();
            returnDate = CrossPlatformUtils.GetReturnDate();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.FlightList);

            ImageView Backbutton = FindViewById<ImageView>(Resource.Id.imgBackArrowTop);
            Backbutton.Click += delegate {
                Finish();
            };
        
        }
    }
    
}

