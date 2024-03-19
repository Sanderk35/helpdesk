namespace Helpdesk.PopUp
{
	partial class ChangePassword
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
			newPasswordBox = new TextBox();
			confirmPasswordBox = new TextBox();
			changePasswordButton = new Button();
			SuspendLayout();
			// 
			// newPasswordBox
			// 
			newPasswordBox.Location = new Point(12, 31);
			newPasswordBox.Name = "newPasswordBox";
			newPasswordBox.PasswordChar = '•';
			newPasswordBox.PlaceholderText = Translation.new_password;
			newPasswordBox.Size = new Size(201, 27);
			newPasswordBox.TabIndex = 0;
			newPasswordBox.TextChanged += newPasswordBox_TextChanged;
			// 
			// confirmPasswordBox
			// 
			confirmPasswordBox.Location = new Point(236, 31);
			confirmPasswordBox.Name = "confirmPasswordBox";
			confirmPasswordBox.PasswordChar = '•';
			confirmPasswordBox.PlaceholderText = Translation.confirm_text;
			confirmPasswordBox.Size = new Size(201, 27);
			confirmPasswordBox.TabIndex = 1;
			confirmPasswordBox.TextChanged += newPasswordBox_TextChanged;
			// 
			// changePasswordButton
			// 
			changePasswordButton.Location = new Point(177, 84);
			changePasswordButton.Name = "changePasswordButton";
			changePasswordButton.Size = new Size(94, 29);
			changePasswordButton.TabIndex = 2;
			changePasswordButton.Text = Translation.change_button;
			changePasswordButton.UseVisualStyleBackColor = true;
			changePasswordButton.Click += changePasswordButton_Click;
			// 
			// ChangePassword
			// 
			AcceptButton = changePasswordButton;
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(441, 117);
			ControlBox = false;
			Controls.Add(changePasswordButton);
			Controls.Add(confirmPasswordBox);
			Controls.Add(newPasswordBox);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "ChangePassword";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "First login";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox newPasswordBox;
		private TextBox confirmPasswordBox;
		private Button changePasswordButton;
	}
}