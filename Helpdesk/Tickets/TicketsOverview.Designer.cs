namespace Helpdesk.Customer
{
	partial class TicketsOverview
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketsOverview));
			createButton = new Button();
			openButton = new Button();
			ticketList = new ListView();
			name = new ColumnHeader();
			imageList = new ImageList(components);
			refreshButton = new Button();
			SuspendLayout();
			// 
			// createButton
			// 
			createButton.Location = new Point(94, 331);
			createButton.Name = "createButton";
			createButton.Size = new Size(112, 40);
			createButton.TabIndex = 0;
			createButton.Text = Translation.create;
			createButton.UseVisualStyleBackColor = true;
			createButton.Click += createButton_Click;
			// 
			// openButton
			// 
			openButton.Enabled = false;
			openButton.Location = new Point(409, 331);
			openButton.Name = "openButton";
			openButton.Size = new Size(112, 40);
			openButton.TabIndex = 1;
			openButton.Text = "Open";
			openButton.UseVisualStyleBackColor = true;
			openButton.Click += openButton_Click;
			// 
			// ticketList
			// 
			ticketList.Columns.AddRange(new ColumnHeader[] { name });
			ticketList.FullRowSelect = true;
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
			refreshButton.Location = new Point(286, 331);
			refreshButton.Name = "refreshButton";
			refreshButton.Size = new Size(46, 43);
			refreshButton.TabIndex = 5;
			refreshButton.UseVisualStyleBackColor = true;
			refreshButton.Click += refreshButton_Click;
			// 
			// TicketsOverview
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(616, 383);
			Controls.Add(refreshButton);
			Controls.Add(ticketList);
			Controls.Add(openButton);
			Controls.Add(createButton);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "TicketsOverview";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Your tickets";
			FormClosed += TicketsOverview_FormClosed;
			Load += TicketsOverview_Load;
			ResumeLayout(false);
		}

		#endregion

		private Button createButton;
		private Button openButton;
		private ListView ticketList;
		private ColumnHeader name;
		private ImageList imageList;
		private Button refreshButton;
	}
}