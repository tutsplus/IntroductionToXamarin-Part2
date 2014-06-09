
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Feeder
{
	public class FeedItemCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("FeedItemViewControllerCell");

		public FeedItemCell () : base (UITableViewCellStyle.Subtitle, Key)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			TextLabel.Text = "TextLabel";
		}
	}
}

