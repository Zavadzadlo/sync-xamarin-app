﻿using System;

using UIKit;
using Foundation;
using System.Collections.Generic;
using FHSDK;
using FHSDK.Sync;

namespace sync.model
{
	public partial class RootViewController : UITableViewController
	{
		public const string DatasetId = "myShoppingList";
		private List<ShoppingItem> _items = new List<ShoppingItem>();
		public RootViewController (IntPtr handle) : base (handle)
		{
		}

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			EditButtonItem.Enabled = false;

			await FHClient.Init ();
			var client = FHSyncClient.GetInstance();
			var config = new FHSyncConfig();
			client.Initialise(config);
			client.SyncCompleted += async (sender, args) =>
			{
				UIApplication.SharedApplication.InvokeOnMainThread(delegate {
					_items = client.List<ShoppingItem>(DatasetId);
					TableView.ReloadData();
				});
			};
			client.Manage<ShoppingItem>(DatasetId, config, null);
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return _items.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var item = _items [indexPath.Row];
			var cell = tableView.DequeueReusableCell ("Cell");
			cell.TextLabel.Text = item.Name;
			cell.DetailTextLabel.Text = item.GetCreatedTime();

			return cell;
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			var dest = segue.DestinationViewController as DetailsViewController;
			if (segue.Identifier.Equals("showExistingItemDetails")) {
				var item = _items [TableView.IndexPathForCell ((UITableViewCell)sender).Row];
				dest.Item = item;

			} else if (segue.Identifier == "showNewItemDetails") {
				dest.Item = null;
			}
		}

		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete) {
				FHSyncClient.GetInstance().Delete<ShoppingItem>(DatasetId, _items[indexPath.Row].UID);
				_items.RemoveAt (indexPath.Row);
				tableView.ReloadData ();
			}
		}
	}
}


