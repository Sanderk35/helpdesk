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
				
				SqlConnection connection = new SqlConnection("Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;");
				SqlCommand command = new SqlCommand("UPDATE Staff SET Password = @newPassword, firstTime = 0 WHERE Id = @id", connection);
				
				command.Parameters.AddWithValue("@newPassword", newPassword);
				command.Parameters.AddWithValue("@id", id);

				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();

				MessageBox.Show(Translation.password_changed_caption);
				this.Close();
			}
			else
			{
				MessageBox.Show(Translation.password_no_match);
			}
		}
	}
}
