
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Net.Http;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Feeder
{
	public class FeedItemController : UITableViewController
	{
		private List<RssItem> _items;
		public FeedItemController () : base ()
		{
			using (var client = new HttpClient ()) {
				var xmlFeed = client.GetStringAsync ("http://blog.xamarin.com/feed").Result;
				var doc = XDocument.Parse (xmlFeed);

				XNamespace dc = "http://purl.org/dc/elements/1.1/";
				_items = (from item in doc.Descendants ("item")
					select new RssItem {
						Title = item.Element ("title").Value,
						PubDate = DateTime.Parse (item.Element ("pubDate").Value),
						Creator = item.Element (dc + "creator").Value,
						Link = item.Element ("link").Value
					}).ToList();
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Register the TableView's data source
			TableView.Source = new FeedItemSource (_items);


		}
	}
}

