using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ThaiAirways.Model.Vo
{

    public class FlightSearchContent
        {

            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("results")]
            public List<Result> resultlist { get; set; }

            [JsonProperty("flightLegs")]
            public List<FlightLeg> FlightLegList { get; set; }
        }

        public class Result
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("direction")]
            public string Direction { get; set; }

            [JsonProperty("flightBounds")]
            public List<FlightBound> FlightBoundList { get; set; }

            [JsonProperty("flightPrices")]
            public List<FlightPrice> FlightPriceList { get; set; }
        }

        public class FlightBound
        {
            [JsonProperty("duration")]
            public string Duration { get; set; }

            //[JsonProperty("flightLegs")]
            //public List<FlightLeg> FlightLegList { get; set; }
        }

        public class FlightPrice
        {
            [JsonProperty("flightPriceId")]
            public string FlightPriceId { get; set; }

            [JsonProperty("totalPrice")]
            public TotalPrice TotalPrice { get; set; }

            [JsonProperty("taxes")]
            public List<Tax> TaxList { get; set; }

            [JsonProperty("fareInfos")]
            public List<FareInfo> FareInfoList { get; set; }

            [JsonProperty("fareBreakdowns")]
            public List<FareBreakdown> FareBreakdownList { get; set; }

        }

        public class FareBreakdown
        {
            [JsonProperty("passengerType")]
            public string PassengerType { get; set; }

            [JsonProperty("quantity")]
            public string Quantity { get; set; }

            [JsonProperty("amount")]
            public string Amount { get; set; }

            [JsonProperty("currencyCode")]
            public string CurrencyCode { get; set; }

            [JsonProperty("taxes")]
            public List<Tax> TaxList { get; set; }

        }

        public class FareInfo
        {
            [JsonProperty("fareFamilyCode")]
            public string FareFamilyCode { get; set; }


            [JsonProperty("flightLeg")]
            public string FlightLeg { get; set; }

        }

        public class Tax
        {
            [JsonProperty("amount")]
            public string Amount { get; set; }

            [JsonProperty("currencyCode")]
            public string CurrencyCode { get; set; }

            [JsonProperty("taxCode")]
            public string TaxCode { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }
        }

        public class TotalPrice
        {
            public string Amount { get; set; }
            public string CurrencyCode { get; set; }
        }

        public class FlightLeg
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("flightNumber")]
            public string FlightNumber { get; set; }

            [JsonProperty("duration")]
            public string Duration { get; set; }

            [JsonProperty("stops")]
            public string Stops { get; set; }

            [JsonProperty("departure")]
            public Arivaldeparture DepartureFlight { get; set; }

            [JsonProperty("arrival")]
            public Arivaldeparture ArrivalFligth { get; set; }

            [JsonProperty("marketingAirline")]
            public string MarketingAirline { get; set; }

            [JsonProperty("operatingAirline")]
            public string OperatingAirline { get; set; }

            [JsonProperty("equipmentType")]
            public string EquipmentType { get; set; }

        }

        public class Arivaldeparture
        {
            [JsonProperty("iataCode")]
            public string IataCode { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("terminal")]
            public string Terminal { get; set; }

            [JsonProperty("dateTime")]
            public string DateTime { get; set; }

        }


    
}
