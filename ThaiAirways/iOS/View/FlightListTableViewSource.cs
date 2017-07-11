using System;
using System.Collections.Generic;
using ThaiAirways.Model.Vo;
using UIKit;

namespace ThaiAirways.iOS.View
{
    public class FlightListTableViewSource : UITableViewSource
    {

		private List<FlightSearchEntity> flightList;
		int itemSection = 1;
		int itemCount = 3;

		public static readonly int ViewHeight = 350;

		public FlightListTableViewSource(List<FlightSearchEntity> flightList)
        {
            this.flightList = flightList;
        }

		#region Override methods

		/// <summary>
		/// Number of sections to show in view
		/// </summary>
		/// <returns>number of sections</returns>
		/// <param name="tableView">Table view.</param>
		public override nint NumberOfSections(UITableView tableView)
		{
            return itemSection;
		}

		/// <summary>
		/// Number of Rows to show in section
		/// </summary>
		/// <returns>number of rows</returns>
		/// <param name="tableview">Table view.</param>
		/// <param name="section">Section.</param>
		public override nint RowsInSection(UITableView tableview, nint section)
		{
            return flightList.Count + 1;
		}

        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <returns>The cell.</returns>
        /// <param name="tableView">Table view.</param>
        /// <param name="indexPath">Index path.</param>
        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            if(indexPath.Row == 0)
            {
				FlgihtHeaderViewCell headerCell = tableView.DequeueReusableCell("FlgihtHeaderViewCell", indexPath) as FlgihtHeaderViewCell;
                headerCell.initCell(flightList.Count);
                return headerCell;
			}

			FlightCardViewCell detailsCell = tableView.DequeueReusableCell("FlightCardViewCell", indexPath) as FlightCardViewCell;
			detailsCell.initCell(flightList.ToArray()[indexPath.Row - 1]);
			return detailsCell;
		}

        public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            if(indexPath.Row == 0)
            {
                return 180;    
            }

            return 208;
        }

		#endregion


	}
}
