namespace Helpdesk.PopUp
{
	public partial class ChangePassword : Form
	{
		public int id;
		public ChangePassword(int id)
		{
			InitializeComponent();
			this.id = id;
		}

		private void changePasswordButton_Click(object sender, EventArgs e)
		{
			string newPassword = newPasswordBox.Text;
			string confirmPassword = confirmPasswordBox.Text;

			if (newPassword == confirmPassword)
			{
				bool hasLowercase = newPassword.Any(char.IsLower);
				bool hasUppercase = newPassword.Any(char.IsUpper);
				bool hasDigit = newPassword.Any(char.IsDigit);
				bool hasSpecial = newPassword.Any(ch => !char.IsLetterOrDigit(ch));
				bool hasLength = newPassword.Length >= 8;

				if (hasLowercase && hasUppercase && hasDigit && hasSpecial && hasLength)
				{
					try
					{
						SqlConnection connection =
							new SqlConnection(
								"Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;");
						SqlCommand command =
							new SqlCommand("UPDATE Staff SET Password = @newPassword, firstTime = 0 WHERE Id = @id",
								connection);

						command.Parameters.AddWithValue("@newPassword", newPassword);
						command.Parameters.AddWithValue("@id", id);

						connection.Open();
						command.ExecuteNonQuery();
						connection.Close();

						MessageBox.Show(Translation.password_changed_caption);
						this.Close();
					}
					catch (SqlException ex) when (ex.Number == 2628)
					{
						MessageBox.Show("Password too long, maximum length is 50 characters", "Password too long",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					string message = Translation.password_strong_message + "\n";
					if (!hasLowercase)
					{
						message = message + Translation.password_one_lower + "\n";
					}
					if (!hasUppercase)
					{
						message = message + Translation.password_one_upper + "\n";
					}
					if (!hasDigit)
					{
						message = message + Translation.password_one_digit + "\n";
					}
					if (!hasSpecial)
					{
						message = message + Translation.password_one_special + "\n";
					}
					if (!hasLength)
					{
						message = message + Translation.password_eight_characters + "\n";
					}
				
					MessageBox.Show(message, Translation.password_doesnt_meet, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			else
			{
				MessageBox.Show(Translation.password_no_match);
			}
		}
	}
}
