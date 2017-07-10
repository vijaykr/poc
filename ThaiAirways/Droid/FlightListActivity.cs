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
    [Activity(Theme = "@style/MyCustomTheme", MainLauncher = true, Icon = "@drawable/icon")]
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
            FindViewById<TextView>(Resource.Id.txtOriginToDestPlaceTop).Text = flightsData[0].DestCode.ToUpper() +" to "+ flightsData[0].ArrCode.ToUpper();

            FindViewById<TextView>(Resource.Id.txtDepDateTop).Text = Convert.ToDateTime( flightsData[0].DepartDate).ToString("ddd")+" "+ Convert.ToDateTime(flightsData[0].DepartDate).Day+" "+ Convert.ToDateTime(flightsData[0].DepartDate).ToString("MMM");



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

        //public List<FlightSearchEntity> GetFlightsData()
        //{
        //    List<FlightSearchEntity> flights = new List<FlightSearchEntity>();
        //    FlightSearchEntity flight = new FlightSearchEntity();       
            

        //    for (int i = 0; i < 7; i++)
        //    {
                


        //        flight.Duration = "03:10:00";
        //        flight.DestCode = "del";
        //        flight.ArrCode = "LHR";
        //        flight.DepartDate = "2017-07-09T11:15:00";
        //        flight.ArrDate = "2017-07-09T14:25:00";
        //        flight.EquipmentType = "600";
        //        flight.MarketingAirline = "TG";
        //        flight.OperatingAirline = "TG";
        //        flight.FareInfo = new FareInfo[3];


        //        FareInfo finfo1 = new FareInfo();
        //        finfo1.ClassType = "ECOPRO" + i.ToString();
        //        finfo1.Currency = "USD";
        //        finfo1.Amount = "5,200";
        //        FareInfo finfo2 = new FareInfo();
        //        finfo2.ClassType = "ECOPRO" + (i + 1).ToString();
        //        finfo2.Currency = "USD";
        //        finfo2.Amount = "5,200";
        //        FareInfo finfo3 = new FareInfo();
        //        finfo3.ClassType = "ECOPRO" + (i + 2).ToString(); ;
        //        finfo3.Currency = "USD";
        //        finfo3.Amount = "5,200";
                
             
        //        flight.FareInfo[0] = finfo1;
        //        flight.FareInfo[1] = finfo2;
        //        flight.FareInfo[2] = finfo3;

        //        flights.Add(flight);
        //    }

           
        //    return flights;
        //} 
    }
    
}

