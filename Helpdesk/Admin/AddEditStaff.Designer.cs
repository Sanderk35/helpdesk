namespace Helpdesk.Admin
{
	partial class AddEditStaff
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
			tableLayoutPanel1 = new TableLayoutPanel();
			firstNameBox = new TextBox();
			infixBox = new TextBox();
			lastNameBox = new TextBox();
			emailBox = new TextBox();
			jobBox = new ComboBox();
			specialismBox = new ComboBox();
			saveButton = new Button();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 13;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.69254446F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.689468F));
			tableLayoutPanel1.Controls.Add(firstNameBox, 1, 1);
			tableLayoutPanel1.Controls.Add(infixBox, 5, 1);
			tableLayoutPanel1.Controls.Add(lastNameBox, 9, 1);
			tableLayoutPanel1.Controls.Add(emailBox, 1, 3);
			tableLayoutPanel1.Controls.Add(jobBox, 1, 5);
			tableLayoutPanel1.Controls.Add(specialismBox, 6, 5);
			tableLayoutPanel1.Controls.Add(saveButton, 9, 7);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 9;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1103687F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1103716F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1103716F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1103716F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1103716F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1103716F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1103716F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1137047F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1137047F));
			tableLayoutPanel1.Size = new Size(384, 274);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// firstNameBox
			// 
			tableLayoutPanel1.SetColumnSpan(firstNameBox, 3);
			firstNameBox.Dock = DockStyle.Top;
			firstNameBox.Location = new Point(32, 33);
			firstNameBox.Name = "firstNameBox";
			firstNameBox.PlaceholderText = Translation.firstName_text;
			firstNameBox.Size = new Size(81, 27);
			firstNameBox.TabIndex = 0;
			// 
			// infixBox
			// 
			tableLayoutPanel1.SetColumnSpan(infixBox, 3);
			infixBox.Dock = DockStyle.Top;
			infixBox.Location = new Point(148, 33);
			infixBox.Name = "infixBox";
			infixBox.PlaceholderText = Translation.infix_text;
			infixBox.Size = new Size(81, 27);
			infixBox.TabIndex = 1;
			// 
			// lastNameBox
			// 
			tableLayoutPanel1.SetColumnSpan(lastNameBox, 3);
			lastNameBox.Dock = DockStyle.Top;
			lastNameBox.Location = new Point(264, 33);
			lastNameBox.Name = "lastNameBox";
			lastNameBox.PlaceholderText = Translation.lastName_text;
			lastNameBox.Size = new Size(81, 27);
			lastNameBox.TabIndex = 2;
			// 
			// emailBox
			// 
			tableLayoutPanel1.SetColumnSpan(emailBox, 7);
			emailBox.Dock = DockStyle.Top;
			emailBox.Location = new Point(32, 93);
			emailBox.Name = "emailBox";
			emailBox.PlaceholderText = Translation.email_text;
			emailBox.Size = new Size(197, 27);
			emailBox.TabIndex = 3;
			// 
			// jobBox
			// 
			tableLayoutPanel1.SetColumnSpan(jobBox, 4);
			jobBox.Dock = DockStyle.Top;
			jobBox.DropDownWidth = 160;
			jobBox.FormattingEnabled = true;
			jobBox.Items.AddRange(new object[] { Translation.helpdesk_staff, Translation.IT_staff });
			jobBox.Location = new Point(32, 153);
			jobBox.Name = "jobBox";
			jobBox.Size = new Size(110, 28);
			jobBox.TabIndex = 4;
			jobBox.SelectedIndexChanged += jobBox_SelectedIndexChanged;
			// 
			// specialismBox
			// 
			tableLayoutPanel1.SetColumnSpan(specialismBox, 4);
			specialismBox.Dock = DockStyle.Top;
			specialismBox.FormattingEnabled = true;
			specialismBox.Items.AddRange(new object[] { Translation.none, "Tv", "Internet", Translation.fixed_telephony, Translation.mobile_telephony, Translation.invoices, Translation.prices, Translation.other });
			specialismBox.Location = new Point(177, 153);
			specialismBox.Name = "specialismBox";
			specialismBox.Size = new Size(110, 28);
			specialismBox.TabIndex = 5;
			specialismBox.Visible = false;
			// 
			// saveButton
			// 
			tableLayoutPanel1.SetColumnSpan(saveButton, 3);
			saveButton.Dock = DockStyle.Fill;
			saveButton.Location = new Point(264, 213);
			saveButton.Name = "saveButton";
			saveButton.Size = new Size(81, 24);
			saveButton.TabIndex = 6;
			saveButton.UseVisualStyleBackColor = true;
			saveButton.Click += saveButton_Click;
			// 
			// AddEditStaff
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(384, 274);
			Controls.Add(tableLayoutPanel1);
			MinimumSize = new Size(402, 321);
			Name = "AddEditStaff";
			StartPosition = FormStartPosition.CenterParent;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private TextBox firstNameBox;
		private TextBox infixBox;
		private TextBox lastNameBox;
		private TextBox emailBox;
		private ComboBox jobBox;
		private ComboBox specialismBox;
		private Button saveButton;
	}
}