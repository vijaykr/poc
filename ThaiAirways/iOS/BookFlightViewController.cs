using Foundation;
using System;
using UIKit;
using ThaiAirways.Model;
using ThaiAirways.Model.Vo;
using BigTed;

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
            BTProgressHUD.ForceiOS6LookAndFeel = true;
			BTProgressHUD.Show("Loading...");

            InvokeInBackground(() =>
            {
	            FlighSearchModel.Instance.GetFlightDetails(1, 0, 0, "ECONOMY", "2017-07-09", "BKK", 0, "", "HKG", "en-US", "USD");

	            InvokeOnMainThread(() =>
		        {
					var storyboard = UIStoryboard.FromName("Main", null);
					FlightListViewController flightListViewController = storyboard.InstantiateViewController("FlightListViewController")
									 as FlightListViewController;
					NavigationController.PushViewController(flightListViewController, true);

					BTProgressHUD.Dismiss();
			    });

			});
			
		}

		void BackButton_TouchUpInside(object sender, EventArgs e)
		{
            NavigationController.PopViewController(true);
		}

	}
}