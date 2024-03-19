namespace Helpdesk.Customer
{
	partial class TicketsOverviewIT
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			ListViewGroup listViewGroup1 = new ListViewGroup("Your claimed tickets", HorizontalAlignment.Left);
			ListViewGroup listViewGroup2 = new ListViewGroup("Open tickets", HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketsOverviewIT));
			openButton = new Button();
			ticketList = new ListView();
			name = new ColumnHeader();
			imageList = new ImageList(components);
			refreshButton = new Button();
			SuspendLayout();
			// 
			// openButton
			// 
			openButton.Enabled = false;
			openButton.Location = new Point(259, 334);
			openButton.Name = "openButton";
			openButton.Size = new Size(98, 40);
			openButton.TabIndex = 1;
			openButton.Text = "Open";
			openButton.UseVisualStyleBackColor = true;
			openButton.Click += openButton_Click;
			// 
			// ticketList
			// 
			ticketList.Columns.AddRange(new ColumnHeader[] { name });
			ticketList.FullRowSelect = true;
			listViewGroup1.Header = "Your claimed tickets";
			listViewGroup1.Name = "claimedGroup";
			listViewGroup2.Header = "Open tickets";
			listViewGroup2.Name = "openGroup";
			ticketList.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2 });
			ticketList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			ticketList.HideSelection = true;
			ticketList.LargeImageList = imageList;
			ticketList.Location = new Point(12, 12);
			ticketList.MultiSelect = false;
			ticketList.Name = "ticketList";
			ticketList.Size = new Size(592, 313);
			ticketList.SmallImageList = imageList;
			ticketList.TabIndex = 2;
			ticketList.TileSize = new Size(2, 2);
			ticketList.UseCompatibleStateImageBehavior = false;
			ticketList.View = View.Details;
			ticketList.DrawItem += ticketList_DrawItem;
			ticketList.ItemSelectionChanged += ticketList_ItemSelectionChanged;
			// 
			// name
			// 
			name.Text = "Ticket";
			name.Width = 480;
			// 
			// imageList
			// 
			imageList.ColorDepth = ColorDepth.Depth32Bit;
			imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
			imageList.TransparentColor = Color.Transparent;
			imageList.Images.SetKeyName(0, "Answered.png");
			imageList.Images.SetKeyName(1, "Closed.png");
			imageList.Images.SetKeyName(2, "Open.png");
			// 
			// refreshButton
			// 
			refreshButton.Font = new Font("Segoe UI", 7F);
			refreshButton.Image = Properties.Resources.refresh;
			refreshButton.Location = new Point(540, 331);
			refreshButton.Name = "refreshButton";
			refreshButton.Size = new Size(46, 43);
			refreshButton.TabIndex = 5;
			refreshButton.UseVisualStyleBackColor = true;
			refreshButton.Click += refreshButton_Click;
			// 
			// TicketsOverviewIT
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(616, 383);
			Controls.Add(refreshButton);
			Controls.Add(ticketList);
			Controls.Add(openButton);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "TicketsOverviewIT";
			Text = "Tickets";
			FormClosed += TicketsOverview_FormClosed;
			Load += TicketsOverview_Load;
			ResumeLayout(false);
		}

		#endregion
		private Button openButton;
		private ListView ticketList;
		private ColumnHeader name;
		private ImageList imageList;
		private Button refreshButton;
	}
}