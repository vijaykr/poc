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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel desc1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel desc2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView img1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView img2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel title1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel title2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel todayDate { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (desc1 != null) {
                desc1.Dispose ();
                desc1 = null;
            }

            if (desc2 != null) {
                desc2.Dispose ();
                desc2 = null;
            }

            if (img1 != null) {
                img1.Dispose ();
                img1 = null;
            }

            if (img2 != null) {
                img2.Dispose ();
                img2 = null;
            }

            if (title1 != null) {
                title1.Dispose ();
                title1 = null;
            }

            if (title2 != null) {
                title2.Dispose ();
                title2 = null;
            }

            if (todayDate != null) {
                todayDate.Dispose ();
                todayDate = null;
            }
        }
    }
}