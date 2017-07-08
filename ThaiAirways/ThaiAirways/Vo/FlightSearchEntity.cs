using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThaiAirways.Model.Vo
{ 
    public class FlightSearchEntity
    {     
        public string Duration { get; set; }
        public string DestCode { get; set; }
        public string ArrCode { get; set; }
        public string DepartDate { get; set; }
		public string DepartTime { get; set; }
		public string ArrDate { get; set; }
		public string ArrTime { get; set; }
		public string EquipmentType { get; set; }
        public string MarketingAirline { get; set; }
        public string OperatingAirline { get; set; }
        public List<FareInfoEntity> FareInfo { get; set; }
    }

    public class FareInfoEntity
    {
        public string ClassType { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
    }
}
