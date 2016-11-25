using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using UIKit;
using static System.Console;
using Debug = System.Diagnostics.Debug;

namespace Han.iOS
{
	public partial class MenuViewController : UIViewController
	{

		private User SelectUser { get; set;}

		public MenuViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			ShowTable();//明天要用async await
		}

		private void ShowTable()
		{

			var list = new List<User>
			{
				new User {Name = @"Aa", Description = @"使用者 甲"},
				new User {Name = @"Bb", Description = @"使用者 乙"},
				new User {Name = @"Cc", Description = @"使用者 丙"},
				new User {Name = @"Dd", Description = @"使用者 丁"}
			};

			var tableSource = new UserTableSource(list);
			userTable.Source = tableSource;
			//myTableView.Source = tableSource;

			//who is selected
			tableSource.UserSelected += delegate (object sender, UserSelectedEventArgs e)
			{
				SelectUser = e.SelectedUser;

				WriteLine(e.SelectedUser.Name);//application output看結果（右下角）

				InvokeOnMainThread( () => { 
					PerformSegue("moveToDetailSegue", this);//to detail page
				});

			};

			InvokeOnMainThread( () =>  {
			    userTable.ReloadData();//一定要在invoke on mainthread跑
			});


			//myTableView.ReloadData();


		}

		//下一頁顯示/驗證/傳值
		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if("moveToDetailSegue" == segue.Identifier )
			{
				if (segue.DestinationViewController is DetailViewController)//保證正確的頁面
				{
					var desViewCountroller = segue.DestinationViewController as DetailViewController;

					desViewCountroller.SelectedUser = SelectUser;
				}
			}
		}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public class UserTableSource : UITableViewSource
		{
			// CellView Identifier
			const string UserViewCellIdentifier = @"UserViewCell";

			// ctor. Model

			private List<User> Users { get; set; }

			public UserTableSource(IEnumerable<User> users)
			{
				Users = new List<User>();
				Users.AddRange(users);
			}

			// Model -> Controller -> View

			// Memory
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return (nint)Users.Count;
			}

			// Controller -> View
			public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
			{

				User myClass = Users[indexPath.Row];


				UserViewCell cell = tableView.DequeueReusableCell(UserViewCellIdentifier)
			                                 as UserViewCell;

				cell.UpdateUI(myClass);//UserViewCell

				return cell;

			}

			////不同cell's height怎麼設定
			//public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
			//{


			//	return base.GetHeightForRow(tableView, indexPath);
			//}

			// View -> Controller

			public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				tableView.DeselectRow(indexPath, true);

				User user = Users[indexPath.Row];

				EventHandler<UserSelectedEventArgs> handle = UserSelected;

				if (null != handle)
				{

					var args = new UserSelectedEventArgs { SelectedUser = user };

					handle(this, args);
				}

			}

			/// <summary>
			/// 設計事件，回傳結果給呼叫端
			/// </summary>
			public event EventHandler<UserSelectedEventArgs> UserSelected;

		}

		public class UserSelectedEventArgs : EventArgs
		{

			public User SelectedUser { get; set; }

		}
	}
}

