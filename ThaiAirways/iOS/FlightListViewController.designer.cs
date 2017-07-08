// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ThaiAirways.iOS
{
    [Register ("FlightListViewController")]
    partial class FlightListViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DepartDateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView FlightListTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ReturnDateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TotalFlightLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BackButton != null) {
                BackButton.Dispose ();
                BackButton = null;
            }

            if (DepartDateLabel != null) {
                DepartDateLabel.Dispose ();
                DepartDateLabel = null;
            }

            if (FlightListTableView != null) {
                FlightListTableView.Dispose ();
                FlightListTableView = null;
            }

            if (ReturnDateLabel != null) {
                ReturnDateLabel.Dispose ();
                ReturnDateLabel = null;
            }

            if (TotalFlightLabel != null) {
                TotalFlightLabel.Dispose ();
                TotalFlightLabel = null;
            }
        }
    }
}