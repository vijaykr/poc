using Foundation;
using System;
using UIKit;
using System.ComponentModel;

namespace ThaiAirways.iOS
{
	[DesignTimeVisible(true)]
	public partial class NavBarView : UIView, IComponent
    {
		#region IComponent implementation

		public ISite Site { get; set; }
		public event EventHandler Disposed;

		#endregion

		[Export("NavTitle"), Browsable(true)]
		public string NavTitle { get; set; }

		public NavBarView (IntPtr handle) : base (handle)
        {
            
        }

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			if ((Site != null) && Site.DesignMode)
			{
				// Bundle resources aren't available in DesignMode
				return;
			}

			NSBundle.MainBundle.LoadNib("NavBarView", this, null);

			// At this point all of the code-behind properties should be set, specifically rootView which must be added as a subview of this view
			this.AddSubview(this.rootView);
		}
    }
}