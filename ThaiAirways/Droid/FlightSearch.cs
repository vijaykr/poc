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

namespace App2
{
    public class FlightSearch
    {
        public string Duration { get; set; }
        public string DestCode { get; set; }
        public string ArrCode { get; set; }
        public string DepartDate { get; set; }
        public string ArrDate { get; set; }
        public string EquipmentType { get; set; }
        public string MarketingAirline { get; set; }
        public string OperatingAirline { get; set; }
        public FareInfo[] FareInfo { get; set; }
    }

     public class FareInfo
    {
        public string ClassType { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
    }

}