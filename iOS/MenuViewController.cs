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

		private BestFood SelectUser { get; set;}

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

			var list = new List<BestFood>
			{
				new BestFood {Name = @"雞腿飯", Description = @"還沒吃到呢", Address = "墾丁大街1999999號", Url = "https://www.google.com.tw", DisplayLocation = new MyLocation{Lat = 25.0787519, Lng = 121.5680871}},
				new BestFood {Name = @"Just Sleep", Description = @"商務旅館", Address = "墾丁大街1999999號", Url = "https://www.google.com.tw", DisplayLocation = new MyLocation{Lat = 25.0787519, Lng = 121.5680871}},
				new BestFood {Name = @"摩絲漢堡", Description = @"到處都有", Address = "墾丁大街1999999號", Url = "https://www.google.com.tw", DisplayLocation = new MyLocation{Lat = 25.0787519, Lng = 121.5680871}},
				new BestFood {Name = @"七十一", Description = @"很方便", Address = "墾丁大街1999999號", Url = "https://www.google.com.tw", DisplayLocation = new MyLocation{Lat = 25.0787519, Lng = 121.5680871}}
			};

			var tableSource = new UserTableSource(list);
			userTable.Source = tableSource;
			//myTableView.Source = tableSource;

			//who is selected
			tableSource.UserSelected += delegate (object sender, UserSelectedEventArgs e)
			{
				SelectUser = e.SelectedUser;

				WriteLine(SelectUser.Address);//application output看結果（右下角）

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

			private List<BestFood> Users { get; set; }

			public UserTableSource(IEnumerable<BestFood> users)
			{
				Users = new List<BestFood>();
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

				BestFood myClass = Users[indexPath.Row];


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

				BestFood user = Users[indexPath.Row];

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

			public BestFood SelectedUser { get; set; }

		}
	}
}

