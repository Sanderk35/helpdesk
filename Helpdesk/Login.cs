using Helpdesk.Admin;
using Helpdesk.PopUp;

namespace Helpdesk
{
	public partial class Login : Form
	{
		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";

		private SqlConnection _connection;

		public Login()
		{
			InitializeComponent();
			
			_connection = new SqlConnection(_connectionString);
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			string email = emailBox.Text;
			string password = passwordBox.Text;
			
			string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
			
			using (SqlCommand userSearchCommand = new SqlCommand(query, _connection))
			{
				_connection.Open();
				userSearchCommand.Parameters.AddWithValue("@Email", email);
				userSearchCommand.Parameters.AddWithValue("@Password", password);
				try
				{
					SqlDataReader userReader = userSearchCommand.ExecuteReader();
					if (userReader.HasRows)
					{
						MessageBox.Show(Translation.logged_in_customer);
					}
					else
					{
						userReader.Close();
						query = "SELECT * FROM Staff WHERE Email = @Email AND Password = @Password";
						
						SqlCommand staffSearchCommand = new SqlCommand(query, _connection);
						
						staffSearchCommand.Parameters.AddWithValue("@Email", email);
						staffSearchCommand.Parameters.AddWithValue("@Password", password);
						
						SqlDataReader staffReader = staffSearchCommand.ExecuteReader();

						if (staffReader.HasRows)
						{
							staffReader.Close();
							SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);

							adapter.SelectCommand.Parameters.AddWithValue("@Email", email);
							adapter.SelectCommand.Parameters.AddWithValue("@Password", password);

							DataTable dataTable = new DataTable();
							adapter.Fill(dataTable);

							int role = 0;
							int id = 0;
							int firstTime = 0;

							foreach (DataRow row in dataTable.Rows)
							{
								role = (int)row["role"];
								id = (int)row["id"];
								firstTime = (int)row["firstTime"];
							}

							if (role == 2)
							{
								StaffScreen staffScreen = new StaffScreen();
								staffScreen.Show();
								this.Hide();
							}
							else if (role == 1)
							{
								MessageBox.Show(Translation.logged_in_ict);
								if (firstTime == 1)
								{
									ChangePassword changePassword = new ChangePassword(id);
									changePassword.ShowDialog();
								}
							}
							else
							{
								MessageBox.Show(Translation.logged_in_staff);
								if (firstTime == 1)
								{
									ChangePassword changePassword = new ChangePassword(id);
									changePassword.ShowDialog();
								}
							}
						}
						else
						{
							MessageBox.Show(Translation.login_failed_message, Translation.login_failed);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(Translation.error + Translation.semicolon + ex, Translation.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				_connection.Close();
			}
		}

		private void registerButton_Click(object sender, EventArgs e)
		{
			Register register = new Register();
			register.ShowDialog();
		}
	}
}
