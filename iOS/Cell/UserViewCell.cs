using System;

using Foundation;
using UIKit;

namespace Han.iOS
{
	public partial class UserViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("UserViewCell");
		public static readonly UINib Nib;

		static UserViewCell()
		{
			Nib = UINib.FromName("UserViewCell", NSBundle.MainBundle);
		}

		protected UserViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateUI(BestFood user){

			lbName.Text = user.Name;
			lbDescription.Text = user.Description;
			_userImage.Image = UIImage.FromFile("");

		}
	}
}
