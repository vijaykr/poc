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

namespace ThaiAirways.Droid
{
    [Activity(Theme = "@style/MyCustomTheme", MainLauncher = false, Icon = "@drawable/icon")]
    public class FlightListActivity : Activity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        FlightRecyclerAdapter mAdapter;

        DateTime departDate;
        DateTime returnDate;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            departDate = CrossPlatformUtils.GetDeaprtDate();
            returnDate = CrossPlatformUtils.GetReturnDate();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.FlightList);
            
            
            List<FlightSearchEntity> flightsData = new List<FlightSearchEntity>();


            flightsData = FlighSearchModel.Instance.FlightList;
            

           
            FindViewById<TextView>(Resource.Id.txtNumberOfFlights).Text = flightsData.Count.ToString();
            // FindViewById<TextView>(Resource.Id.txtOriginToDestPlaceTop).Text = flightsData[0].DestCode.ToUpper() +" to "+ flightsData[0].ArrCode.ToUpper();
            FindViewById<TextView>(Resource.Id.txtOriginToDestPlaceTop).Text = "Bangkok to Hong Kong";
            FindViewById<TextView>(Resource.Id.txtDepDateTop).Text = CrossPlatformUtils.GetDateInDayDateMonth(departDate);
            FindViewById<TextView>(Resource.Id.txtRetDateTop).Text = CrossPlatformUtils.GetDateInDayDateMonth(returnDate);

			ImageView Backbutton = FindViewById<ImageView>(Resource.Id.imgBackArrowTop);
            Backbutton.Click += delegate {
                Finish();
            };

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // Plug in the linear layout manager:
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            //mRecyclerView.GetLayoutManager().ScrollToPosition(200);
           
            // Plug in my adapter:
            mAdapter = new FlightRecyclerAdapter(flightsData);
            mRecyclerView.SetAdapter(mAdapter);
        }
    }
    
}

