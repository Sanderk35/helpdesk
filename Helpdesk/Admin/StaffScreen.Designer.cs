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
			tableLayoutPanel1 = new TableLayoutPanel();
			staffView = new ListView();
			addButton = new Button();
			editButton = new Button();
			deleteButton = new Button();
			emailColumn = new ColumnHeader();
			firstNameColumn = new ColumnHeader();
			infixColumn = new ColumnHeader();
			lastNameColumn = new ColumnHeader();
			roleColumn = new ColumnHeader();
			specialismColumn = new ColumnHeader();
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
			tableLayoutPanel1.Controls.Add(editButton, 5, 10);
			tableLayoutPanel1.Controls.Add(deleteButton, 9, 10);
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
			tableLayoutPanel1.Size = new Size(800, 450);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// staffView
			// 
			staffView.Columns.AddRange(new ColumnHeader[] { emailColumn, firstNameColumn, infixColumn, lastNameColumn, roleColumn, specialismColumn });
			tableLayoutPanel1.SetColumnSpan(staffView, 12);
			staffView.Dock = DockStyle.Fill;
			staffView.Location = new Point(3, 3);
			staffView.MultiSelect = false;
			staffView.Name = "staffView";
			tableLayoutPanel1.SetRowSpan(staffView, 9);
			staffView.Size = new Size(794, 327);
			staffView.TabIndex = 0;
			staffView.UseCompatibleStateImageBehavior = false;
			staffView.View = View.Details;
			// 
			// addButton
			// 
			tableLayoutPanel1.SetColumnSpan(addButton, 2);
			addButton.Dock = DockStyle.Fill;
			addButton.Location = new Point(69, 359);
			addButton.Name = "addButton";
			addButton.Size = new Size(126, 63);
			addButton.TabIndex = 1;
			addButton.Text = "Toevoegen";
			addButton.UseVisualStyleBackColor = true;
			// 
			// editButton
			// 
			tableLayoutPanel1.SetColumnSpan(editButton, 2);
			editButton.Dock = DockStyle.Fill;
			editButton.Location = new Point(333, 359);
			editButton.Name = "editButton";
			editButton.Size = new Size(126, 63);
			editButton.TabIndex = 2;
			editButton.Text = "Bewerken";
			editButton.UseVisualStyleBackColor = true;
			// 
			// deleteButton
			// 
			tableLayoutPanel1.SetColumnSpan(deleteButton, 2);
			deleteButton.Dock = DockStyle.Fill;
			deleteButton.Location = new Point(597, 359);
			deleteButton.Name = "deleteButton";
			deleteButton.Size = new Size(126, 63);
			deleteButton.TabIndex = 3;
			deleteButton.Text = "Verwijderen";
			deleteButton.UseVisualStyleBackColor = true;
			// 
			// emailColumn
			// 
			emailColumn.Text = "Email";
			// 
			// firstNameColumn
			// 
			firstNameColumn.Text = "Voornaam";
			// 
			// infixColumn
			// 
			infixColumn.Text = "Tussenvoegsel";
			// 
			// lastNameColumn
			// 
			lastNameColumn.Text = "Achternaam";
			// 
			// roleColumn
			// 
			roleColumn.Text = "Baan";
			// 
			// specialismColumn
			// 
			specialismColumn.Text = "Specialisme";
			// 
			// StaffScreen
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(tableLayoutPanel1);
			Name = "StaffScreen";
			Text = "Personeel";
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
	}
}