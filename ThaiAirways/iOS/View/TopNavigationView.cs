using Foundation;
using System;
using System.ComponentModel;
using UIKit;

namespace ThaiAirways.iOS
{
    [DesignTimeVisible(true)]
    public partial class TopNavigationView : UIView, IComponent
    {
        public TopNavigationView (IntPtr handle) : base (handle)
        {
        }

		#region IComponent implementation

		public ISite Site { get; set; }
		public event EventHandler Disposed;

		#endregion

		[Export("NavTitle"), Browsable(true)]
		public string NavTitle { get; set; }

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			if ((Site != null) && Site.DesignMode)
			{
				// Bundle resources aren't available in DesignMode
				return;
			}

			NSBundle.MainBundle.LoadNib("TopNavigationView", this, null);

			// At this point all of the code-behind properties should be set, specifically rootView which must be added as a subview of this view
			this.AddSubview(this.rootView);

			//this.nameLabel.Text = Name;  // ...and here's how you can use custom properties to set values on the code-behind properties
		}


	}
}