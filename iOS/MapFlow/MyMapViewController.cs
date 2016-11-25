using System;

using UIKit;
using MapKit;

using CoreLocation;
using CoreGraphics;

namespace Han.iOS
{
	public partial class MyMapViewController : UIViewController
	{

		public MyLocation DisplayLocation { get; set;}

		public MyMapViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			//星下點
			var mapCenter = new CLLocationCoordinate2D(DisplayLocation.Lat, DisplayLocation.Lng);//25.0787519, 121.5680871
			myMapView.CenterCoordinate = mapCenter;

			//鏡頭多大
			var mapRegion = MKCoordinateRegion.FromDistance(mapCenter, 4000, 4000);
			myMapView.Region = mapRegion;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

