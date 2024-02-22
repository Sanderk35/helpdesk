namespace Helpdesk
{
	partial class Register
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
			emailBox = new TextBox();
			firstNameBox = new TextBox();
			infixBox = new TextBox();
			lastNameBox = new TextBox();
			placeBox = new TextBox();
			streetBox = new TextBox();
			housenumBox = new TextBox();
			postalBox = new TextBox();
			phoneBox = new TextBox();
			birthBox = new DateTimePicker();
			passwordBox = new TextBox();
			confirmBox = new TextBox();
			registerButton = new Button();
			birthLabel = new Label();
			SuspendLayout();
			// 
			// emailBox
			// 
			emailBox.Location = new Point(37, 32);
			emailBox.Name = "emailBox";
			emailBox.PlaceholderText = "Email";
			emailBox.Size = new Size(321, 27);
			emailBox.TabIndex = 0;
			emailBox.TextChanged += textUpdate;
			// 
			// firstNameBox
			// 
			firstNameBox.Location = new Point(37, 83);
			firstNameBox.Name = "firstNameBox";
			firstNameBox.PlaceholderText = "Voornaam";
			firstNameBox.Size = new Size(104, 27);
			firstNameBox.TabIndex = 1;
			firstNameBox.TextChanged += textUpdate;
			// 
			// infixBox
			// 
			infixBox.Location = new Point(162, 83);
			infixBox.Name = "infixBox";
			infixBox.PlaceholderText = "Tussenvoegsel";
			infixBox.Size = new Size(73, 27);
			infixBox.TabIndex = 2;
			infixBox.TextChanged += textUpdate;
			// 
			// lastNameBox
			// 
			lastNameBox.Location = new Point(254, 83);
			lastNameBox.Name = "lastNameBox";
			lastNameBox.PlaceholderText = "Achternaam";
			lastNameBox.Size = new Size(104, 27);
			lastNameBox.TabIndex = 3;
			lastNameBox.TextChanged += textUpdate;
			// 
			// placeBox
			// 
			placeBox.Location = new Point(37, 137);
			placeBox.Name = "placeBox";
			placeBox.PlaceholderText = "Woonplaats";
			placeBox.Size = new Size(91, 27);
			placeBox.TabIndex = 4;
			placeBox.TextChanged += textUpdate;
			// 
			// streetBox
			// 
			streetBox.Location = new Point(134, 137);
			streetBox.Name = "streetBox";
			streetBox.PlaceholderText = "Straat";
			streetBox.Size = new Size(95, 27);
			streetBox.TabIndex = 5;
			streetBox.TextChanged += textUpdate;
			// 
			// housenumBox
			// 
			housenumBox.Location = new Point(235, 137);
			housenumBox.Name = "housenumBox";
			housenumBox.PlaceholderText = "Huisnr.";
			housenumBox.Size = new Size(55, 27);
			housenumBox.TabIndex = 6;
			housenumBox.TextChanged += textUpdate;
			// 
			// postalBox
			// 
			postalBox.Location = new Point(296, 137);
			postalBox.Name = "postalBox";
			postalBox.PlaceholderText = "Postcode";
			postalBox.Size = new Size(62, 27);
			postalBox.TabIndex = 7;
			postalBox.TextChanged += textUpdate;
			// 
			// phoneBox
			// 
			phoneBox.Location = new Point(37, 189);
			phoneBox.Name = "phoneBox";
			phoneBox.PlaceholderText = "Telefoonnummer";
			phoneBox.Size = new Size(192, 27);
			phoneBox.TabIndex = 8;
			phoneBox.TextChanged += textUpdate;
			// 
			// birthBox
			// 
			birthBox.CustomFormat = "dd-MM-yyyy";
			birthBox.Format = DateTimePickerFormat.Custom;
			birthBox.Location = new Point(235, 189);
			birthBox.MinDate = new DateTime(1920, 1, 1, 0, 0, 0, 0);
			birthBox.Name = "birthBox";
			birthBox.Size = new Size(123, 27);
			birthBox.TabIndex = 9;
			// 
			// passwordBox
			// 
			passwordBox.Location = new Point(37, 245);
			passwordBox.Name = "passwordBox";
			passwordBox.PasswordChar = '•';
			passwordBox.PlaceholderText = "Wachtwoord";
			passwordBox.Size = new Size(152, 27);
			passwordBox.TabIndex = 10;
			passwordBox.TextChanged += textUpdate;
			// 
			// confirmBox
			// 
			confirmBox.Location = new Point(206, 245);
			confirmBox.Name = "confirmBox";
			confirmBox.PasswordChar = '•';
			confirmBox.PlaceholderText = "Herhaal";
			confirmBox.Size = new Size(152, 27);
			confirmBox.TabIndex = 11;
			confirmBox.TextChanged += textUpdate;
			// 
			// registerButton
			// 
			registerButton.BackColor = Color.Lime;
			registerButton.FlatStyle = FlatStyle.System;
			registerButton.Location = new Point(235, 298);
			registerButton.Name = "registerButton";
			registerButton.Size = new Size(123, 39);
			registerButton.TabIndex = 12;
			registerButton.Text = "Registreer";
			registerButton.UseVisualStyleBackColor = false;
			registerButton.Click += registerButton_Click;
			// 
			// birthLabel
			// 
			birthLabel.AutoSize = true;
			birthLabel.Location = new Point(235, 168);
			birthLabel.Name = "birthLabel";
			birthLabel.Size = new Size(115, 20);
			birthLabel.TabIndex = 13;
			birthLabel.Text = "Geboortedatum";
			// 
			// Register
			// 
			AcceptButton = registerButton;
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(400, 365);
			Controls.Add(birthLabel);
			Controls.Add(registerButton);
			Controls.Add(confirmBox);
			Controls.Add(passwordBox);
			Controls.Add(birthBox);
			Controls.Add(phoneBox);
			Controls.Add(postalBox);
			Controls.Add(housenumBox);
			Controls.Add(streetBox);
			Controls.Add(placeBox);
			Controls.Add(lastNameBox);
			Controls.Add(infixBox);
			Controls.Add(firstNameBox);
			Controls.Add(emailBox);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "Register";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Register";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox emailBox;
		private TextBox firstNameBox;
		private TextBox infixBox;
		private TextBox lastNameBox;
		private TextBox placeBox;
		private TextBox streetBox;
		private TextBox housenumBox;
		private TextBox postalBox;
		private TextBox phoneBox;
		private DateTimePicker birthBox;
		private TextBox passwordBox;
		private TextBox confirmBox;
		private Button registerButton;
		private Label birthLabel;
	}
}