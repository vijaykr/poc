using System;

using Foundation;
using UIKit;

namespace ThaiAirways.iOS.View
{
    public partial class FlightCardViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("FlightCardViewCell");
        public static readonly UINib Nib;

        static FlightCardViewCell()
        {
            Nib = UINib.FromName("FlightCardViewCell", NSBundle.MainBundle);
        }

        protected FlightCardViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
