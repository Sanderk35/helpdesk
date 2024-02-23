namespace Helpdesk
{
	partial class Login
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			kpnLogo = new PictureBox();
			emailBox = new TextBox();
			passwordBox = new TextBox();
			loginButton = new Button();
			registerLabel = new Label();
			registerButton = new Button();
			((System.ComponentModel.ISupportInitialize)kpnLogo).BeginInit();
			SuspendLayout();
			// 
			// kpnLogo
			// 
			kpnLogo.Image = Properties.Resources.KPN;
			kpnLogo.Location = new Point(63, 326);
			kpnLogo.Name = "kpnLogo";
			kpnLogo.Size = new Size(182, 112);
			kpnLogo.SizeMode = PictureBoxSizeMode.Zoom;
			kpnLogo.TabIndex = 0;
			kpnLogo.TabStop = false;
			// 
			// emailBox
			// 
			emailBox.Location = new Point(63, 78);
			emailBox.Name = "emailBox";
			emailBox.PlaceholderText = Translation.email_text;
			emailBox.Size = new Size(182, 27);
			emailBox.TabIndex = 1;
			// 
			// passwordBox
			// 
			passwordBox.Location = new Point(63, 129);
			passwordBox.Name = "passwordBox";
			passwordBox.PasswordChar = '•';
			passwordBox.PlaceholderText = Translation.password_text;
			passwordBox.Size = new Size(182, 27);
			passwordBox.TabIndex = 2;
			// 
			// loginButton
			// 
			loginButton.BackColor = SystemColors.ButtonFace;
			loginButton.FlatAppearance.BorderColor = Color.Lime;
			loginButton.FlatAppearance.MouseDownBackColor = Color.Lime;
			loginButton.FlatAppearance.MouseOverBackColor = Color.Lime;
			loginButton.FlatStyle = FlatStyle.System;
			loginButton.Location = new Point(63, 176);
			loginButton.Name = "loginButton";
			loginButton.Size = new Size(94, 29);
			loginButton.TabIndex = 3;
			loginButton.Text = Translation.login_button;
			loginButton.UseVisualStyleBackColor = false;
			loginButton.Click += loginButton_Click;
			// 
			// registerLabel
			// 
			registerLabel.AutoSize = true;
			registerLabel.Font = new Font("Segoe UI", 12F);
			registerLabel.Location = new Point(63, 228);
			registerLabel.Name = "registerLabel";
			registerLabel.Size = new Size(182, 28);
			registerLabel.TabIndex = 4;
			registerLabel.Text = Translation.no_account_question;
			// 
			// registerButton
			// 
			registerButton.BackColor = SystemColors.Control;
			registerButton.FlatAppearance.BorderColor = Color.Lime;
			registerButton.FlatAppearance.MouseDownBackColor = Color.Lime;
			registerButton.FlatAppearance.MouseOverBackColor = Color.Lime;
			registerButton.FlatStyle = FlatStyle.System;
			registerButton.Location = new Point(63, 269);
			registerButton.Name = "registerButton";
			registerButton.Size = new Size(94, 29);
			registerButton.TabIndex = 0;
			registerButton.Text = Translation.registerButton;
			registerButton.UseVisualStyleBackColor = false;
			registerButton.Click += registerButton_Click;
			// 
			// Login
			// 
			AcceptButton = loginButton;
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(306, 450);
			Controls.Add(registerButton);
			Controls.Add(registerLabel);
			Controls.Add(loginButton);
			Controls.Add(passwordBox);
			Controls.Add(emailBox);
			Controls.Add(kpnLogo);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "Login";
			StartPosition = FormStartPosition.CenterScreen;
			Text = Translation.login_page;
			((System.ComponentModel.ISupportInitialize)kpnLogo).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox kpnLogo;
		private TextBox emailBox;
		private TextBox passwordBox;
		private Button loginButton;
		private Label registerLabel;
		private Button registerButton;
	}
}
