using System;
using System.Threading.Tasks;
using ThaiAirways.Model;
using ThaiAirways.Vo;
using UIKit;
using SDWebImage;
using Foundation;
using ThaiAirways.Utils;

namespace ThaiAirways.iOS
{
	public partial class ViewController : UIViewController
	{
        Product product1;
		Product product2;

		public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			var TaskResult = Task.Run(async () =>
			{
				var products = await ContentModel.Instance.GetContensAsync();
				var product_arr = products.ToArray();
				product1 = product_arr[0];
				product2 = product_arr[1];
			});

			Task.WaitAny(TaskResult);
			//img1.setI

			img1.SetImage(
                url: new NSUrl(product1.Image),
                placeholder: UIImage.FromBundle("placeholder")
            );
			title1.Text = product1.Title;
			desc1.Text = product1.Description;

			img2.SetImage(
				url: new NSUrl(product2.Image),
				placeholder: UIImage.FromBundle("placeholder")
			);
			title2.Text = product2.Title;
			desc2.Text = product2.Description;

            todayDate.Text = CrossPlatformUtils.TodayDate();


            BottomTabBar.ItemSelected += BottomTabBar_ItemSelected;

		}

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.NavigationBar.Hidden = true;
        }


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        void BottomTabBar_ItemSelected(object sender, UITabBarItemEventArgs e)
		{
            if(e.Item.Tag == 0)
            {
				var storyboard = UIStoryboard.FromName("Main", null);

				BookFlightViewController bookFlightViewController = storyboard.InstantiateViewController("BookFlightViewController")
								 as BookFlightViewController;
                NavigationController.PushViewController(bookFlightViewController, true);
			}

		}

	}
}
