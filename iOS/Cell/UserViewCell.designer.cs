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
	[Register ("UserViewCell")]
	partial class UserViewCell
	{
		[Outlet]
		UIKit.UIImageView _userImage { get; set; }

		[Outlet]
		UIKit.UILabel lbDescription { get; set; }

		[Outlet]
		UIKit.UILabel lbName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_userImage != null) {
				_userImage.Dispose ();
				_userImage = null;
			}

			if (lbDescription != null) {
				lbDescription.Dispose ();
				lbDescription = null;
			}

			if (lbName != null) {
				lbName.Dispose ();
				lbName = null;
			}
		}
	}
}
