// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Han.iOS
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UIKit.UIButton _GoToWebView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_GoToWebView != null) {
				_GoToWebView.Dispose ();
				_GoToWebView = null;
			}
		}
	}
}
