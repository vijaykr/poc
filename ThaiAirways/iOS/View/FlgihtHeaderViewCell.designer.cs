// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ThaiAirways.iOS.View
{
    [Register ("FlgihtHeaderViewCell")]
    partial class FlgihtHeaderViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FlightNumberLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FlightNumberLabel != null) {
                FlightNumberLabel.Dispose ();
                FlightNumberLabel = null;
            }
        }
    }
}