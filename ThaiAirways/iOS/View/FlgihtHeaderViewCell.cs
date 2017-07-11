using System;

using Foundation;
using UIKit;

namespace ThaiAirways.iOS.View
{
    public partial class FlgihtHeaderViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("FlgihtHeaderViewCell");
        public static readonly UINib Nib;

        static FlgihtHeaderViewCell()
        {
            Nib = UINib.FromName("FlgihtHeaderViewCell", NSBundle.MainBundle);
        }

        protected FlgihtHeaderViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
