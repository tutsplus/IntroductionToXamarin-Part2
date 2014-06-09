
using System;
using System.Collections.Generic;

using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Feeder
{
	public class FeedItemSource : UITableViewSource
	{
		private List<RssItem> _items;

		public FeedItemSource (List<RssItem> items)
		{
			_items = items;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			// TODO: return the actual number of sections
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			// TODO: return the actual number of items in the section
			return _items.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (FeedItemCell.Key) as FeedItemCell;
			if (cell == null)
				cell = new FeedItemCell ();
			
			// TODO: populate the cell with the appropriate data based on the indexPath

			cell.TextLabel.Text = _items[indexPath.Row].Title;
			cell.DetailTextLabel.Text = string.Format ("{0} on {1}", _items [indexPath.Row].Creator, _items [indexPath.Row].PubDate);
			
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var item = _items [indexPath.Row];

			var url = new NSUrl (item.Link);
			UIApplication.SharedApplication.OpenUrl (url);
		}
	}
}

