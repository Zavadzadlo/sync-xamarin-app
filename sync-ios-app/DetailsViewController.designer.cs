// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace sync.model
{
	[Register ("DetailsViewController")]
	partial class DetailsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField createdField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel createLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField nameField { get; set; }

		[Action ("Cancel:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void Cancel (UIBarButtonItem sender);

		[Action ("SaveItem:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SaveItem (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (createdField != null) {
				createdField.Dispose ();
				createdField = null;
			}
			if (createLabel != null) {
				createLabel.Dispose ();
				createLabel = null;
			}
			if (nameField != null) {
				nameField.Dispose ();
				nameField = null;
			}
		}
	}
}
