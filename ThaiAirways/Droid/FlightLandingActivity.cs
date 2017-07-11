using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using System;
using ThaiAirways.Model;
using ThaiAirways.Utils;
using ThaiAirways.Vo;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Square.Picasso;
using Android.Support.Design.Internal;
using Android.Util;

namespace ThaiAirways.Droid
{
    [Activity(Label = "ThaiAirways", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class FlightLandingActivity : AppCompatActivity
    {
        String currentDate;

        private Product product1;
        private Product product2;
        private BottomNavigationView bottomNavigaion;

        protected override void OnCreate(Bundle bundle)
        {
            this.RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.FlightLanding);

            currentDate = CrossPlatformUtils.TodayDate();
            TextView currentdateview = FindViewById<TextView>(Resource.Id.textView8);
            currentdateview.Text = currentDate;

            if (CrossConnectivity.Current.IsConnected)
            {
                var TaskResult = Task.Run(async () =>
                {
                    var products = await ContentModel.Instance.GetContensAsync();
                    var product_arr = products.ToArray();
                    product1 = product_arr[0];
                    product2 = product_arr[1];
                });

                Task.WaitAny(TaskResult);

                FindViewById<TextView>(Resource.Id.promotion1_title_text_view).Text = product1.Title;
                FindViewById<TextView>(Resource.Id.promotion1_desc_text_view).Text = product1.Description;

                Picasso.With(this)
                       .Load(product1.Image)
                       .Into(FindViewById<ImageView>(Resource.Id.promotion1_image_view));

                FindViewById<TextView>(Resource.Id.promotion2_title_text_view).Text = product2.Title;
                FindViewById<TextView>(Resource.Id.promotion2_desc_text_view).Text = product2.Description;

                Picasso.With(this)
                       .Load(product2.Image)
                       .Into(FindViewById<ImageView>(Resource.Id.promotion2_image_view));
            }
            else
            {

                FindViewById<TextView>(Resource.Id.promotion1_title_text_view).Text = "";
                FindViewById<TextView>(Resource.Id.promotion1_desc_text_view).Text = "";

                FindViewById<TextView>(Resource.Id.promotion2_title_text_view).Text = "";
                FindViewById<TextView>(Resource.Id.promotion2_desc_text_view).Text = "";
            }


            bottomNavigaion = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation_view);
            bottomNavigaion.NavigationItemSelected += (s, e) =>
            {
                switch (e.Item.ItemId)
                {
                    case Resource.Id.book_flight:
                        StartActivity(typeof(FlightBookingActivity));
                        break;

                    case Resource.Id.timetable:

                        Toast.MakeText(this, "Timetable Clicked", ToastLength.Short).Show();
                        break;

                    case Resource.Id.flight_status:

                        Toast.MakeText(this, "Flight Status Clicked", ToastLength.Short).Show();
                        break;

                    case Resource.Id.my_booking:

                        Toast.MakeText(this, "My Booking Clicked", ToastLength.Short).Show();
                        break;
                }

            };
            SetIconSize();

        }

        private void SetIconSize()
        {
            BottomNavigationView navigationView = bottomNavigaion;
            BottomNavigationMenuView menuView = (BottomNavigationMenuView)navigationView.GetChildAt(0);

            for (int i = 0; i < menuView.ChildCount; i++)
            {
                BottomNavigationItemView item = (BottomNavigationItemView)menuView.GetChildAt(i);
                item.SetShiftingMode(false);

                TextView smallText = (TextView)menuView.GetChildAt(i).FindViewById(Resource.Id.smallLabel);
                smallText.Visibility = ViewStates.Gone;

                ImageView icon = (ImageView)menuView.GetChildAt(i).FindViewById(Resource.Id.icon);

                var prm = icon.LayoutParameters;
                var dsm = Resources.DisplayMetrics;

                prm.Height = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 40, dsm);
                prm.Width = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 40, dsm);

                icon.LayoutParameters = prm;
                ////Implement Accessibility
                //if (i == 0)
                //{
                //	icon.ContentDescription = GetString(Resource.String.);
                //}
                //if (i == 1)
                //{
                //	icon.ContentDescription = GetString(Resource.String.saving);
                //}
                //if (i == 2)
                //{
                //	icon.ContentDescription = GetString(Resource.String.profile);
                //}
            }
        }
    }
}

