// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ThaiAirways.iOS
{
    [Register ("BookFlightViewController")]
    partial class BookFlightViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AdultLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BookFlightButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ChildrenLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ClassLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DepartDateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DepartMonthLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel InfantsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ReturnDateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ReturnMonthLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AdultLabel != null) {
                AdultLabel.Dispose ();
                AdultLabel = null;
            }

            if (BackButton != null) {
                BackButton.Dispose ();
                BackButton = null;
            }

            if (BookFlightButton != null) {
                BookFlightButton.Dispose ();
                BookFlightButton = null;
            }

            if (ChildrenLabel != null) {
                ChildrenLabel.Dispose ();
                ChildrenLabel = null;
            }

            if (ClassLabel != null) {
                ClassLabel.Dispose ();
                ClassLabel = null;
            }

            if (DepartDateLabel != null) {
                DepartDateLabel.Dispose ();
                DepartDateLabel = null;
            }

            if (DepartMonthLabel != null) {
                DepartMonthLabel.Dispose ();
                DepartMonthLabel = null;
            }

            if (InfantsLabel != null) {
                InfantsLabel.Dispose ();
                InfantsLabel = null;
            }

            if (ReturnDateLabel != null) {
                ReturnDateLabel.Dispose ();
                ReturnDateLabel = null;
            }

            if (ReturnMonthLabel != null) {
                ReturnMonthLabel.Dispose ();
                ReturnMonthLabel = null;
            }
        }
    }
}