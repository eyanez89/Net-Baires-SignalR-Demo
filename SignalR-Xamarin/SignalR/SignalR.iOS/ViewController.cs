using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace SignalR.iOS
{
	public partial class ViewController : UIViewController
	{
        private readonly Client _client;
        static NSString messageCellId = new NSString("MessageCell");

        public List<string> MessagesList { get; set; }

        public ViewController (IntPtr handle) : base (handle)
		{
            _client = new Client("iOS");

            MessagesList = new List<string>();
        }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            Messages.RegisterClassForCellReuse(typeof(UITableViewCell), messageCellId);
            Messages.Source = new CallHistoryDataSource(this);
            Message.Hidden = Send.Hidden = true;
            
            Enter.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (string.IsNullOrEmpty(UserName.Text))
                    return;

                UserName.Hidden = Enter.Hidden = true;

                _client.UserName = UserName.Text;

                Message.Hidden = Send.Hidden = false;

                UserName.Text = "";
            };

            Send.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (string.IsNullOrEmpty(Message.Text))
                    return;
                
                _client.Send(Message.Text);

                Message.Text = "";
            };


        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        class CallHistoryDataSource : UITableViewSource
        {
            ViewController controller;

            public CallHistoryDataSource(ViewController controller)
            {
                this.controller = controller;
            }

            // Returns the number of rows in each section of the table
            public override nint RowsInSection(UITableView tableView, nint section)
            {
                return controller.MessagesList.Count;
            }
            //
            // Returns a table cell for the row indicated by row property of the NSIndexPath
            // This method is called multiple times to populate each row of the table.
            // The method automatically uses cells that have scrolled off the screen or creates new ones as necessary.
            //
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(ViewController.messageCellId);

                var row = indexPath.Row;
                cell.TextLabel.Text = controller.MessagesList[row];
                return cell;
            }
        }
    }
}

