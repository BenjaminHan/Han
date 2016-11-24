using System;

using UIKit;

namespace Han.iOS
{
	public partial class DetailViewController : UIViewController
	{
		public User SelectedUser { get;  set; }
		public DetailViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			Title = SelectedUser.Name;//只要選擇show detail就會顯示title

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

