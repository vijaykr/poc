using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System.Threading.Tasks;
using System.Linq;
using ThaiAirways.Model.Vo;
using ThaiAirways.Utils;
using System.Globalization;

namespace ThaiAirways.Model
{
    public class FlighSearchModel
    {

        public List<FlightSearchEntity> FlightList { get; set; }

        private static FlighSearchModel instance;


        public static FlighSearchModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FlighSearchModel();
                }
                return instance;
            }
        }

        public async Task<FlightSearchContent> GetFlight(int AdultsCount, int ChildrenCount, int InfantCount, string CabinClass, DateTime DepartureDate, string DepartFrom, int MaxStops, DateTime? ReturnDate, string DepartTo, string lang, string currency)
        {
            var client = new RestClient("http://ux.openjawtech.com");
            var request = new RestRequest("swagger/flight/search", Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Language", lang);
            request.AddHeader("Currency-Code", currency);

            string departureDateStr = CrossPlatformUtils.GetDateInString(DepartureDate);

            string returnDateStr = "";
            if(ReturnDate != null)
            {
                returnDateStr = CrossPlatformUtils.GetDateInString(ReturnDate.Value);
			}

			request.AddBody(new { adults = AdultsCount, cabinClass = CabinClass, children = ChildrenCount, departureDate = departureDateStr, from = DepartFrom, infants = InfantCount, maxStops = MaxStops, returnDate = returnDateStr, to = DepartTo });

            var response = await client.Execute(request);

            FlightSearchContent content = null;
            if (response.IsSuccess)
            {
                content = JsonConvert.DeserializeObject<FlightSearchContent>(response.Content);
            }

            return content;
        }

        public void GetFlightDetails(int AdultsCount, int ChildrenCount, int InfantCount, string CabinClass, DateTime DepartureDate, string DepartFrom, int MaxStops, DateTime? ReturnDate, string DepartTo, string lang, string currency)
        {
            FlightSearchContent fsc;
            List<FlightSearchEntity> FlightSearchEntitylist = new List<FlightSearchEntity>();

            var TaskResult = Task.Run(async () =>
            {
                fsc = await FlighSearchModel.Instance.GetFlight(AdultsCount, ChildrenCount, InfantCount, CabinClass, DepartureDate, DepartFrom, MaxStops, ReturnDate, DepartTo, lang, currency);

                FlightSearchEntity flight = new FlightSearchEntity();
                string flightLeg = "";



                foreach (Result rs in fsc.resultlist)
                {
                    FlightSearchEntity flightSearchEntity = new FlightSearchEntity();
                    int i = 0;
                    List<FareInfoEntity> FareInfoEntitylist = new List<FareInfoEntity>();

                    bool isReturnFlight = false;
                    if(rs.Direction == "return")
                    {
                        isReturnFlight = true;
                    }

                    foreach (FlightPrice flightPrice in rs.FlightPriceList)
                    {
                        FareInfoEntity fareInfoEnt = new FareInfoEntity();

                        //To Change USD currency to THB & also convert the amount for the same.
                        double TotalPriceAmount = Convert.ToDouble(flightPrice.TotalPrice.Amount);
                        if (flightPrice.TotalPrice.CurrencyCode == "USD")
                        {
                            TotalPriceAmount = TotalPriceAmount * 34;
                            fareInfoEnt.Currency = "THB";
                        }
                        else
                        {
                            fareInfoEnt.Currency = flightPrice.TotalPrice.CurrencyCode;
                        }

                        if (isReturnFlight)
                        {
                            double price = TotalPriceAmount / 2;
                            fareInfoEnt.Amount = price.ToString(CultureInfo.InvariantCulture);
						}
                        else
                        {
							fareInfoEnt.Amount = TotalPriceAmount.ToString();
						}

                        
                        fareInfoEnt.ClassType = flightPrice.FareInfoList[i].FareFamilyCode;
                        FareInfoEntitylist.Add(fareInfoEnt);
                        //add fli

                        flightLeg = flightPrice.FareInfoList[i].FlightLeg;
                    }

                    flightSearchEntity.FareInfo = FareInfoEntitylist;


                    var flightdetails = fsc.FlightLegList.Where(flightleg => flightleg.Id == flightLeg);

                    flightSearchEntity.Duration = flightdetails.First().Duration;
                    flightSearchEntity.DestCode = flightdetails.First().DepartureFlight.IataCode;
                    flightSearchEntity.ArrCode = flightdetails.First().ArrivalFligth.IataCode;
                    flightSearchEntity.DepartDate = flightdetails.First().DepartureFlight.DateTime;
                    flightSearchEntity.DepartTime = CrossPlatformUtils.GetTimeFromDate(flightdetails.First().DepartureFlight.DateTime);
                    flightSearchEntity.ArrDate = flightdetails.First().ArrivalFligth.DateTime;
                    flightSearchEntity.ArrTime = CrossPlatformUtils.GetTimeFromDate(flightdetails.First().ArrivalFligth.DateTime);
					flightSearchEntity.EquipmentType = flightdetails.First().EquipmentType;
                    flightSearchEntity.MarketingAirline = flightdetails.First().MarketingAirline;
                    flightSearchEntity.OperatingAirline = flightdetails.First().OperatingAirline;

                    FlightSearchEntitylist.Add(flightSearchEntity);
                }
            });
            Task.WaitAny(TaskResult);

            FlightList = FlightSearchEntitylist;
        }
    }
}
