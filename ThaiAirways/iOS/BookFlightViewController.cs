using Foundation;
using System;
using UIKit;
using ThaiAirways.Model;
using ThaiAirways.Model.Vo;
using BigTed;
using ThaiAirways.Utils;

namespace ThaiAirways.iOS
{
    public partial class BookFlightViewController : UIViewController
    {

        DateTime departDate;
		DateTime returnDate;

		public BookFlightViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            departDate = CrossPlatformUtils.GetDeaprtDate();
			returnDate = CrossPlatformUtils.GetReturnDate();

			BookFlightButton.TouchUpInside += BookFlightButton_TouchUpInside;
			BackButton.TouchUpInside += BackButton_TouchUpInside;
		}



		public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

			NavigationController.NavigationBar.Hidden = true;

            DepartDateLabel.Text = CrossPlatformUtils.GetDayFromDate(departDate);
            DepartMonthLabel.Text = CrossPlatformUtils.GetDayMonthFromDate(departDate);

            ReturnDateLabel.Text = CrossPlatformUtils.GetDayFromDate(returnDate);
            ReturnMonthLabel.Text = CrossPlatformUtils.GetDayMonthFromDate(returnDate);
		}

		void BookFlightButton_TouchUpInside(object sender, EventArgs e)
		{
            //BTProgressHUD.ForceiOS6LookAndFeel = true;
            BTProgressHUD.Show("Just a moment...", -1, ProgressHUD.MaskType.Gradient);

            InvokeInBackground(() =>
            {
                FlighSearchModel.Instance.GetFlightDetails(1, 0, 0, "ECONOMY", departDate, "BKK", 0, returnDate, "HKG", "en-US", "USD");

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