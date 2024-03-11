namespace Helpdesk.Admin
{
	partial class StaffScreen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffScreen));
			tableLayoutPanel1 = new TableLayoutPanel();
			staffView = new ListView();
			emailColumn = new ColumnHeader();
			firstNameColumn = new ColumnHeader();
			infixColumn = new ColumnHeader();
			lastNameColumn = new ColumnHeader();
			roleColumn = new ColumnHeader();
			specialismColumn = new ColumnHeader();
			idColumn = new ColumnHeader();
			addButton = new Button();
			editButton = new Button();
			deleteButton = new Button();
			refreshButton = new Button();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 12;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.Controls.Add(staffView, 0, 0);
			tableLayoutPanel1.Controls.Add(addButton, 1, 10);
			tableLayoutPanel1.Controls.Add(editButton, 4, 10);
			tableLayoutPanel1.Controls.Add(deleteButton, 7, 10);
			tableLayoutPanel1.Controls.Add(refreshButton, 10, 10);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 12;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.111111F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.333333F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 4.44444466F));
			tableLayoutPanel1.Size = new Size(633, 324);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// staffView
			// 
			staffView.Columns.AddRange(new ColumnHeader[] { emailColumn, firstNameColumn, infixColumn, lastNameColumn, roleColumn, specialismColumn, idColumn });
			tableLayoutPanel1.SetColumnSpan(staffView, 12);
			staffView.Dock = DockStyle.Fill;
			staffView.FullRowSelect = true;
			staffView.Location = new Point(3, 3);
			staffView.MultiSelect = false;
			staffView.Name = "staffView";
			tableLayoutPanel1.SetRowSpan(staffView, 9);
			staffView.Size = new Size(627, 237);
			staffView.TabIndex = 0;
			staffView.UseCompatibleStateImageBehavior = false;
			staffView.View = View.Details;
			staffView.ItemSelectionChanged += staffView_ItemSelectionChanged;
			// 
			// emailColumn
			// 
			emailColumn.Text = Translation.email_text;
			// 
			// firstNameColumn
			// 
			firstNameColumn.Text = Translation.firstName_text;
			// 
			// infixColumn
			// 
			infixColumn.Text = Translation.infix_text;
			// 
			// lastNameColumn
			// 
			lastNameColumn.Text = Translation.lastName_text;
			// 
			// roleColumn
			// 
			roleColumn.Text = Translation.role_text;
			// 
			// specialismColumn
			// 
			specialismColumn.Text = Translation.specialism_text;
			// 
			// idColumn
			// 
			idColumn.Text = "Id";
			idColumn.Width = 0;
			// 
			// addButton
			// 
			tableLayoutPanel1.SetColumnSpan(addButton, 2);
			addButton.Dock = DockStyle.Fill;
			addButton.Location = new Point(55, 262);
			addButton.Name = "addButton";
			addButton.Size = new Size(98, 43);
			addButton.TabIndex = 1;
			addButton.Text = Translation.add_text;
			addButton.UseVisualStyleBackColor = true;
			addButton.Click += addButton_Click;
			// 
			// editButton
			// 
			tableLayoutPanel1.SetColumnSpan(editButton, 2);
			editButton.Dock = DockStyle.Fill;
			editButton.Enabled = false;
			editButton.Location = new Point(211, 262);
			editButton.Name = "editButton";
			editButton.Size = new Size(98, 43);
			editButton.TabIndex = 2;
			editButton.Text = Translation.edit_text;
			editButton.UseVisualStyleBackColor = true;
			editButton.Click += editButton_Click;
			// 
			// deleteButton
			// 
			tableLayoutPanel1.SetColumnSpan(deleteButton, 2);
			deleteButton.Dock = DockStyle.Fill;
			deleteButton.Enabled = false;
			deleteButton.Location = new Point(367, 262);
			deleteButton.Name = "deleteButton";
			deleteButton.Size = new Size(98, 43);
			deleteButton.TabIndex = 3;
			deleteButton.Text = Translation.delete_text;
			deleteButton.UseVisualStyleBackColor = true;
			deleteButton.Click += deleteButton_Click;
			// 
			// refreshButton
			// 
			refreshButton.Dock = DockStyle.Fill;
			refreshButton.Font = new Font("Segoe UI", 7F);
			refreshButton.Image = Properties.Resources.refresh;
			refreshButton.Location = new Point(523, 262);
			refreshButton.Name = "refreshButton";
			refreshButton.Size = new Size(46, 43);
			refreshButton.TabIndex = 4;
			refreshButton.UseVisualStyleBackColor = true;
			refreshButton.Click += refreshButton_Click;
			// 
			// StaffScreen
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(633, 324);
			Controls.Add(tableLayoutPanel1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MinimumSize = new Size(651, 371);
			Name = "StaffScreen";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Staff";
			FormClosed += StaffScreen_FormClosed;
			tableLayoutPanel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private ListView staffView;
		private Button addButton;
		private Button editButton;
		private Button deleteButton;
		private ColumnHeader emailColumn;
		private ColumnHeader firstNameColumn;
		private ColumnHeader infixColumn;
		private ColumnHeader lastNameColumn;
		private ColumnHeader roleColumn;
		private ColumnHeader specialismColumn;
		private Button refreshButton;
		private ColumnHeader idColumn;
	}
}