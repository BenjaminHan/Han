using System;

using UIKit;

namespace Han.iOS
{
	public partial class DetailViewController : UIViewController
	{
		public Restaurant SelectedUser { get;  set; }
		public DetailViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			Title = SelectedUser.Name;//只要選擇show detail就會顯示title

			lbDescription.Text = SelectedUser.Description;
			lbAddress.Text = SelectedUser.Address;
			btnWeb.SetTitle(SelectedUser.Url, forState: UIControlState.Normal);

			btnMap.TouchUpInside += (sender, e) => {
				PerformSegue("moveToWebMapSegue", this);
			};


			btnWeb.TouchUpInside += (sender, e) =>
			{
				PerformSegue("moveToWebViewSegue", this);
			};

		}

		//下一頁顯示/驗證/傳值
		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if ("moveToWebMapSegue" == segue.Identifier)
			{
				if (segue.DestinationViewController is MyMapViewController)//保證正確的頁面
				{
					var desViewCountroller = segue.DestinationViewController as MyMapViewController;

					//var loc = new MyLocation { Lat = 25.0787519, Lng = 121.5680871 };
					desViewCountroller.DisplayLocation = SelectedUser.DisplayLocation;
				}
			}

			if ("moveToWebViewSegue" == segue.Identifier)
			{
				if (segue.DestinationViewController is MyWebViewController)//保證正確的頁面
				{
					var desViewCountroller = segue.DestinationViewController as MyWebViewController;
					desViewCountroller.Url = SelectedUser.Url;
					desViewCountroller.Name = SelectedUser.Name;
				}
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

