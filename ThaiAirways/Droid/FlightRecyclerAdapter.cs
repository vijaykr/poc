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
using Android.Support.V7;
using Android.Support.V7.Widget;
namespace App2
{
    class FlightRecyclerAdapter : RecyclerView.Adapter
    {
        public List<FlightSearch> flights;
        public FlightRecyclerAdapter(List<FlightSearch> flightsList)
        {
            flights = flightsList;
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.FlightRow, parent, false);
            FlightViewHolder vh = new FlightViewHolder(itemView);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            FlightViewHolder vh = holder as FlightViewHolder;
            vh.FlightNumber.Text = flights[position].MarketingAirline + " " + flights[position].EquipmentType;

            vh.OperatedBy.Text = "Operated by " + flights[position].OperatingAirline;
            vh.DepartureTime.Text = Convert.ToDateTime(flights[position].DepartDate).Hour.ToString()+":"+ Convert.ToDateTime(flights[position].DepartDate).Minute.ToString();
            vh.DeparturePlace.Text = flights[position].DestCode.ToUpper();

            if(flights[position].Duration.LastIndexOf(":")>4)
                vh.Duration.Text = flights[position].Duration.Substring(0,5);
            else
                vh.Duration.Text = flights[position].Duration;

            vh.ArrivalTime.Text = Convert.ToDateTime(flights[position].ArrDate).Hour.ToString() + ":" + Convert.ToDateTime(flights[position].ArrDate).Minute.ToString();
            vh.ArrivalPlace.Text = flights[position].ArrCode.ToUpper();
           

            vh.Class1.Text = flights[position].FareInfo[0].ClassType;
            vh.Class2.Text = flights[position].FareInfo[1].ClassType;
            vh.Class3.Text = flights[position].FareInfo[2].ClassType;
            vh.CurrencyCode1.Text = flights[position].FareInfo[0].Currency;
            vh.CurrencyCode2.Text = flights[position].FareInfo[1].Currency;
            vh.CurrencyCode3.Text = flights[position].FareInfo[2].Currency;
            vh.Amount1.Text = flights[position].FareInfo[0].Amount;
            vh.Amount2.Text = flights[position].FareInfo[1].Amount;
            vh.Amount3.Text = flights[position].FareInfo[2].Amount;

        }

        public override int ItemCount
        {
            get { return flights.Count; }
        }
    }
    public class FlightViewHolder : RecyclerView.ViewHolder
    {
        public TextView FlightNumber { get; private set; }
        public TextView OperatedBy { get; private set; }
        public TextView DepartureTime { get; private set; }
        public TextView DeparturePlace { get; private set; }
        public TextView Duration { get; private set; }
        public TextView ArrivalTime { get; private set; }
        public TextView ArrivalPlace { get; private set; }
        public TextView Class1 { get; private set; }
        public TextView Class2 { get; private set; }
        public TextView Class3 { get; private set; }
        public TextView CurrencyCode1 { get; private set; }
        public TextView CurrencyCode2 { get; private set; }
        public TextView CurrencyCode3 { get; private set; }
        public TextView Amount1 { get; private set; }
        public TextView Amount2 { get; private set; }
        public TextView Amount3 { get; private set; }

        public FlightViewHolder(View itemView) : base(itemView)
        {
            // Locate and cache view references:
            FlightNumber = itemView.FindViewById<TextView>(Resource.Id.txtFlightNumber);
            OperatedBy = itemView.FindViewById<TextView>(Resource.Id.txtOperatedBy);
            DepartureTime = itemView.FindViewById<TextView>(Resource.Id.txtDepartureTime);
            DeparturePlace = itemView.FindViewById<TextView>(Resource.Id.txtDeparturePlace);
            Duration = itemView.FindViewById<TextView>(Resource.Id.txtDuration);
            ArrivalTime = itemView.FindViewById<TextView>(Resource.Id.txtArrivalTime);
            ArrivalPlace = itemView.FindViewById<TextView>(Resource.Id.txtArrivalPlace);
            Class1 = itemView.FindViewById<TextView>(Resource.Id.txtClass1);
            Class2 = itemView.FindViewById<TextView>(Resource.Id.txtClass2);
            Class3 = itemView.FindViewById<TextView>(Resource.Id.txtClass3);
            CurrencyCode1 = itemView.FindViewById<TextView>(Resource.Id.txtCurrencyCode1);
            CurrencyCode2 = itemView.FindViewById<TextView>(Resource.Id.txtCurrencyCode1);
            CurrencyCode3 = itemView.FindViewById<TextView>(Resource.Id.txtCurrencyCode1);
            Amount1 = itemView.FindViewById<TextView>(Resource.Id.txtAmount1);
            Amount2 = itemView.FindViewById<TextView>(Resource.Id.txtAmount2);
            Amount3 = itemView.FindViewById<TextView>(Resource.Id.txtAmount3);
        }
    }


}