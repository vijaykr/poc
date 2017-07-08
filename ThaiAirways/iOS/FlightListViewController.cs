// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using ThaiAirways.iOS.View;
using ThaiAirways.Model;
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


            FlightListTableView.RegisterNibForCellReuse(FlightCardViewCell.Nib, "FlightCardViewCell");

            FlightListTableView.Source = new FlightListTableViewSource(FlighSearchModel.Instance.FlightList);
            FlightListTableView.ReloadData();

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			NavigationController.NavigationBar.Hidden = true;

            TotalFlightLabel.Text = FlighSearchModel.Instance.FlightList.Count + " Flights";
		}

		void BackButton_TouchUpInside(object sender, EventArgs e)
		{
			NavigationController.PopViewController(true);
		}

	}
}
