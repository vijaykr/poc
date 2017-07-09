using System;
using System.Globalization;

namespace ThaiAirways.Utils
{
    public static class CrossPlatformUtils
    {
		public static DateTime GetDeaprtDate()
		{
            var date = DateTime.Now.AddDays(1);
			return date;
		}

		public static DateTime GetReturnDate()
		{
			var date = DateTime.Now.AddDays(5);
			return date;
		}

        public static string GetDayFromDate(DateTime datetime)
		{
			var dateStr = datetime.ToString("dd", CultureInfo.InvariantCulture);
			return dateStr;
		}

		public static string GetDayMonthFromDate(DateTime datetime)
		{
			var dateStr = datetime.ToString("MMM yyyy dddd", CultureInfo.InvariantCulture);
			return dateStr;
		}

		public static string GetDateInString(DateTime datetime)
		{
            //var dateStr = datetime.Year + "-" +datetime.ToString("MM", CultureInfo.InvariantCulture) + "-" + datetime.Day;
            var dateStr = datetime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
			return dateStr;
		}

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

		public static string GetDateInDayDateMonth(DateTime datetime)
		{
			var dateStr = datetime.ToString("ddd dd MMM", CultureInfo.InvariantCulture);
			return dateStr;
		}

		public static string GetCurencyInString(string amount)
        {
            return String.Format("{0:n}", Convert.ToDouble(amount));
        }

		public static string GetDurationFormat(string duration)
		{
            var arr = duration.Split(':');
            int hour = Convert.ToInt16(arr[0]);
            int minute = Convert.ToInt16(arr[1]);

            return hour + "h " + minute + "m";
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
