namespace Helpdesk.PopUp
{
	partial class TicketCreation
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
			titleBox = new TextBox();
			categoryBox = new ComboBox();
			createButton = new Button();
			descriptionBox = new TextBox();
			customerNumberList = new ListView();
			nameHeader = new ColumnHeader();
			placeHeader = new ColumnHeader();
			SuspendLayout();
			// 
			// titleBox
			// 
			titleBox.Location = new Point(12, 33);
			titleBox.MaxLength = 50;
			titleBox.Name = "titleBox";
			titleBox.PlaceholderText = Translation.title;
			titleBox.Size = new Size(253, 27);
			titleBox.TabIndex = 0;
			titleBox.TextChanged += Update;
			// 
			// categoryBox
			// 
			categoryBox.DropDownStyle = ComboBoxStyle.DropDownList;
			categoryBox.FormattingEnabled = true;
			categoryBox.Items.AddRange(new object[] { "Tv", "Internet", Translation.fixed_telephony, Translation.mobile_telephony, Translation.invoices, Translation.prices, Translation.other });
			categoryBox.Location = new Point(12, 242);
			categoryBox.Name = "categoryBox";
			categoryBox.Size = new Size(218, 28);
			categoryBox.TabIndex = 2;
			categoryBox.SelectedIndexChanged += Update;
			// 
			// createButton
			// 
			createButton.Enabled = false;
			createButton.Location = new Point(12, 292);
			createButton.Name = "createButton";
			createButton.Size = new Size(94, 29);
			createButton.TabIndex = 3;
			createButton.Text = Translation.create;
			createButton.UseVisualStyleBackColor = true;
			createButton.Click += createButton_Click;
			// 
			// descriptionBox
			// 
			descriptionBox.AcceptsReturn = true;
			descriptionBox.Location = new Point(12, 85);
			descriptionBox.MaxLength = 300;
			descriptionBox.Multiline = true;
			descriptionBox.Name = "descriptionBox";
			descriptionBox.PlaceholderText = Translation.description;
			descriptionBox.Size = new Size(253, 136);
			descriptionBox.TabIndex = 4;
			descriptionBox.TextChanged += Update;
			// 
			// customerNumberList
			// 
			customerNumberList.Columns.AddRange(new ColumnHeader[] { nameHeader, placeHeader });
			customerNumberList.FullRowSelect = true;
			customerNumberList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			customerNumberList.Location = new Point(271, 33);
			customerNumberList.Name = "customerNumberList";
			customerNumberList.Size = new Size(455, 237);
			customerNumberList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			customerNumberList.TabIndex = 5;
			customerNumberList.UseCompatibleStateImageBehavior = false;
			customerNumberList.View = View.Details;
			customerNumberList.Visible = false;
			customerNumberList.SelectedIndexChanged += Update;
			// 
			// nameHeader
			// 
			nameHeader.Text = Translation.name;
			// 
			// placeHeader
			// 
			placeHeader.Text = Translation.place_text;
			// 
			// TicketCreation
			// 
			AcceptButton = createButton;
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(738, 348);
			Controls.Add(customerNumberList);
			Controls.Add(descriptionBox);
			Controls.Add(createButton);
			Controls.Add(categoryBox);
			Controls.Add(titleBox);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "TicketCreation";
			StartPosition = FormStartPosition.CenterParent;
			Text = Translation.create_title;
			Load += TicketCreation_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox titleBox;
		private ComboBox categoryBox;
		private Button createButton;
		private TextBox descriptionBox;
		private ListView customerNumberList;
		private ColumnHeader nameHeader;
		private ColumnHeader placeHeader;
	}
}