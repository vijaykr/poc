using System;
using System.Globalization;

namespace ThaiAirways.Utils
{
    public static class CrossPlatformUtils
    {

		public static string TodayDate()
		{
			var dateStr = DateTime.Now.ToString("ddd dd MMM yyyy", CultureInfo.InvariantCulture);
			return dateStr;
		}

        public static string GetTimeFromDate(string datetime)
		{

            var currDate = Convert.ToDateTime(datetime);
            var dateStr = currDate.ToString("HH:mm", CultureInfo.InvariantCulture);
			return dateStr;
		}


		public static string GetAirlineNameByCode(string code)
        {
			switch (code)
			{
				case "AR":
                    return "Aerolineas";
				case "FQ":
					return "Air Aruba";
				case "QF":
					return "Qantas Airways";
				case "AI":
					return "Air India";
				case "BA":
					return "British Airways";
				case "TG":
					return "Thai Airways";
				case "U2":
					return "easyJet";
				case "UA":
					return "easyJet";
				case "IB":
					return "United Airlines";
			}

            return code;
        }

	}
}
