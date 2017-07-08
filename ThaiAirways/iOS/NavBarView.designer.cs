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
    [Register ("NavBarView")]
    partial class NavBarView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView LeftImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        ThaiAirways.iOS.NavBarView rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LeftImage != null) {
                LeftImage.Dispose ();
                LeftImage = null;
            }

            if (rootView != null) {
                rootView.Dispose ();
                rootView = null;
            }

            if (TitleLable != null) {
                TitleLable.Dispose ();
                TitleLable = null;
            }
        }
    }
}