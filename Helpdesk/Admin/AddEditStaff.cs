using Translation = Helpdesk.Translation;

namespace Helpdesk.Admin
{
	public partial class AddEditStaff : Form
	{
		public bool isEdit;
		public int staffId;
		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";
		public AddEditStaff(bool isEdit, int staffId)
		{
			InitializeComponent();
			if (isEdit)
			{
				this.Text = Translation.edit_staff;
				saveButton.Text = Translation.save;
				
				string query = "SELECT * FROM Staff WHERE Id = @Id";

				SqlConnection connection = new SqlConnection(_connectionString);
				SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
				
				adapter.SelectCommand.Parameters.AddWithValue("@Id", staffId);
				
				DataTable dataTable = new DataTable();
				adapter.Fill(dataTable);
				DataRow row = dataTable.Rows[0];
				
				emailBox.Text = row["Email"].ToString();
				firstNameBox.Text = row["FirstName"].ToString();
				infixBox.Text = row["Infix"].ToString();
				lastNameBox.Text = row["LastName"].ToString();
				jobBox.SelectedIndex = (int)row["Role"];
				specialismBox.SelectedIndex = (int)row["Specialism"];
			}
			else
			{
				this.Text = Translation.add_staff;
				saveButton.Text = Translation.add_text;
			}

			this.isEdit = isEdit;
			this.staffId = staffId;
		}

		private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!";
            const int length = 12;
            Random random = new Random();
            string password = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }

		private void saveButton_Click(object sender, EventArgs e)
		{
			string email = emailBox.Text;
			string firstName = firstNameBox.Text;
			string infix = infixBox.Text;
			string lastName = lastNameBox.Text;
			int role = jobBox.SelectedIndex;
			int specialism;
			
			if (role == 1)
			{
				specialism = specialismBox.SelectedIndex;
			}
			else
			{
				specialism = 0;
			}
			
			if (!isEdit)
			{
				string query = "INSERT INTO Staff (Email, FirstName, Infix, LastName, Role, Specialism, Password) " +
				               "VALUES (@Email, @FirstName, @Infix, @LastName, @Role, @Specialism, @Password)";
				
				SqlConnection connection = new SqlConnection(_connectionString);
				SqlCommand command = new SqlCommand(query, connection);
				
				command.Parameters.AddWithValue("@Email", email);
				command.Parameters.AddWithValue("@FirstName", firstName);
				command.Parameters.AddWithValue("@Infix", infix);
				command.Parameters.AddWithValue("@LastName", lastName);
				command.Parameters.AddWithValue("@Role", role);
				command.Parameters.AddWithValue("@Specialism", specialism);
				string password = GenerateRandomPassword();
				command.Parameters.AddWithValue("@Password", password);
				
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
				
				MessageBox.Show(Translation.staff_added_1 + password + Translation.staff_added_2, Translation.staff_added_header, MessageBoxButtons.OK, MessageBoxIcon.Information);
				Clipboard.SetText(password);
				this.Close();
			}
			else
			{
				string query = "UPDATE Staff SET Email = @Email, FirstName = @FirstName, Infix = @Infix, " +
				               "LastName = @LastName, Role = @Role, Specialism = @Specialism WHERE Id = @Id";
				
				SqlConnection connection = new SqlConnection(_connectionString);
				
				SqlCommand command = new SqlCommand(query, connection);
				
				command.Parameters.AddWithValue("@Email", email);
				command.Parameters.AddWithValue("@FirstName", firstName);
				command.Parameters.AddWithValue("@Infix", infix);
				command.Parameters.AddWithValue("@LastName", lastName);
				command.Parameters.AddWithValue("@Role", role);
				command.Parameters.AddWithValue("@Specialism", specialism);
				command.Parameters.AddWithValue("@Id", staffId);
				
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
				
				MessageBox.Show(Translation.changes_saved);
				this.Close();
			}
		}

		private void jobBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (jobBox.SelectedIndex == 1)
			{
				specialismBox.Visible = true;
			}
			else
			{
				specialismBox.Visible = false;
			}
		}
	}
}
