// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace ThaiAirways.iOS
{
	public partial class FlightListViewController : UIViewController
	{
		public FlightListViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			BackButton.TouchUpInside += BackButton_TouchUpInside;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			NavigationController.NavigationBar.Hidden = true;
		}

		void BackButton_TouchUpInside(object sender, EventArgs e)
		{
			NavigationController.PopViewController(true);
		}

	}
}
