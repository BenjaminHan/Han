using System;

using UIKit;

using System.Threading.Tasks;

namespace Han.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Task.Run(() =>
			{

				Task.Delay(2000);

				InvokeOnMainThread(() =>
				{

					PerformSegue("moveToLoginViewSegue", this);
				});

			});

//			// Code to start the Xamarin Test Cloud Agent
//#if ENABLE_TEST_CLOUD
//			Xamarin.Calabash.Start ();
//#endif

//			// Perform any additional setup after loading the view, typically from a nib.
//			Button.AccessibilityIdentifier = "myButton";
//			Button.TouchUpInside += delegate
//			{
//				var title = string.Format("{0} clicks!", count++);
//				Button.SetTitle(title, UIControlState.Normal);
//			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
