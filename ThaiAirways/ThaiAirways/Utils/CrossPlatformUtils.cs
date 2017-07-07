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

	}
}
