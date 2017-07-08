using System;

using Foundation;
using ThaiAirways.Model.Vo;
using ThaiAirways.Utils;
using UIKit;

namespace ThaiAirways.iOS.View
{
    public partial class FlightCardViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("FlightCardViewCell");
        public static readonly UINib Nib;

        static FlightCardViewCell()
        {
            Nib = UINib.FromName("FlightCardViewCell", NSBundle.MainBundle);
        }

        protected FlightCardViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void initCell(FlightSearchEntity flightSearchEntity)
        {
            FlightNumberLabel.Text = flightSearchEntity.OperatingAirline + " " + flightSearchEntity.EquipmentType;
            AirlineLabel.Text = "|  " + CrossPlatformUtils.GetAirlineNameByCode(flightSearchEntity.MarketingAirline);
            FromLabel.Text = flightSearchEntity.DepartTime + " " + flightSearchEntity.DestCode;
			ToLabel.Text = flightSearchEntity.ArrCode + " " + flightSearchEntity.ArrTime;
            DurationLabel.Text = flightSearchEntity.Duration;

            FareInfoEntity fareInfoEntity = flightSearchEntity.FareInfo.ToArray()[0];
            FlexiSaverCurrencyLabel.Text = fareInfoEntity.Currency;
            FlexSavePriceLabel.Text = fareInfoEntity.Amount;

            FlexiCurrencyLabel.Text = "";
            FullFlexCurrencyLabel.Text = "";


		}
    }
}
