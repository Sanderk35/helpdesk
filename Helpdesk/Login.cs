using System;
using System.Data.SqlClient;

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
						MessageBox.Show("Ingelogd als klant");
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
							MessageBox.Show("Ingelogd als medewerker");
						}
						else
						{
							MessageBox.Show("Login failed");
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
