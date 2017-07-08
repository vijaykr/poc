using Foundation;
using System;
using UIKit;

namespace ThaiAirways.iOS
{
    public partial class BookFlightViewController : UIViewController
    {
        public BookFlightViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			BookFlightButton.TouchUpInside += BookFlightButton_TouchUpInside;
			BackButton.TouchUpInside += BackButton_TouchUpInside;
		}



		public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

			NavigationController.NavigationBar.Hidden = true;
		}

		void BookFlightButton_TouchUpInside(object sender, EventArgs e)
		{
			var storyboard = UIStoryboard.FromName("Main", null);
			FlightListViewController flightListViewController = storyboard.InstantiateViewController("FlightListViewController")
							 as FlightListViewController;
			NavigationController.PushViewController(flightListViewController, true);
		}

		void BackButton_TouchUpInside(object sender, EventArgs e)
		{
            NavigationController.PopViewController(true);
		}

	}
}