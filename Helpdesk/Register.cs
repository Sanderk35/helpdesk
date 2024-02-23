using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Helpdesk
{
	public partial class Register : Form
	{
		private readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";
		public Register()
		{
			InitializeComponent();

			birthBox.MaxDate = DateTime.Today;
		}

		private void textUpdate(object sender, EventArgs e)
		{
			if (emailBox.Text.Length > 0 && passwordBox.Text.Length > 0 && 
				confirmBox.Text.Length > 0 && firstNameBox.Text.Length > 0 &&
				lastNameBox.Text.Length > 0 && placeBox.Text.Length > 0 &&
				streetBox.Text.Length > 0 && housenumBox.Text.Length > 0 &&
				postalBox.Text.Length > 0 && phoneBox.Text.Length > 0 &&
				passwordBox.Text == confirmBox.Text && passwordBox.Text.Length > 0)
			{
				registerButton.Enabled = true;
			}
			else
			{
				registerButton.Enabled = false;
			}
		}

		private void registerButton_Click(object sender, EventArgs e)
		{
			string email = emailBox.Text;
			string password = passwordBox.Text;
			string firstName = firstNameBox.Text;
			string infix = infixBox.Text;
			string lastName = lastNameBox.Text;
			string place = placeBox.Text;
			string street = streetBox.Text;
			string housenum = housenumBox.Text;
			string postal = postalBox.Text;
			string phone = phoneBox.Text;
			DateTime birth = birthBox.Value;

			bool hasLowercase = password.Any(char.IsLower);
			bool hasUppercase = password.Any(char.IsUpper);
			bool hasDigit = password.Any(char.IsDigit);
			bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));
			bool hasLength = password.Length >= 8;

			if (hasLowercase && hasUppercase && hasDigit && hasSpecial && hasLength)
			{
				if (birthBox.Value > DateTime.Today.AddYears(-18))
				{
					MessageBox.Show(Translation.minimum_age_message, Translation.minimum_age_caption,
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				string query =
					"INSERT INTO Users (Email, Password, FirstName, Infix, LastName, Place, Street, Housenum, Postal, Phone, Birthday) " +
					"VALUES (@Email, @Password, @FirstName, @Infix, @LastName, @Place, @Street, @Housenumber, @Postal, @Phone, @Birthdate)";

				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						connection.Open();
						command.Parameters.AddWithValue("@Email", email);
						command.Parameters.AddWithValue("@Password", password);
						command.Parameters.AddWithValue("@FirstName", firstName);
						command.Parameters.AddWithValue("@Infix", infix);
						command.Parameters.AddWithValue("@LastName", lastName);
						command.Parameters.AddWithValue("@Place", place);
						command.Parameters.AddWithValue("@Street", street);
						command.Parameters.AddWithValue("@Housenumber", housenum);
						command.Parameters.AddWithValue("@Postal", postal);
						command.Parameters.AddWithValue("@Phone", phone);
						command.Parameters.AddWithValue("@Birthdate", birth);
						try
						{
							command.ExecuteNonQuery();
							MessageBox.Show(Translation.account_created);
							connection.Close();
							this.Close();
						}
						catch (SqlException ex) when (ex.Number == 2601)
						{
							MessageBox.Show(Translation.email_used_message, Translation.error,
								MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						catch (Exception ex)
						{
							MessageBox.Show("Error: " + ex, Translation.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}

						connection.Close();
					}
				}
			}
			else
			{
				string message = "Het wachtwoord moet nog aan de volgende eisen voldoen:\n";
				if (!hasLowercase)
				{
					message = message + "- Minimaal 1 kleine letter\n";
				}
				if (!hasUppercase)
				{
					message = message + "- Minimaal 1 hoofdletter\n";
				}
				if (!hasDigit)
				{
					message = message + "- Minimaal 1 cijfer\n";
				}
				if (!hasSpecial)
				{
					message = message + "- Minimaal 1 speciaal teken\n";
				}
				if (!hasLength)
				{
					message = message + "- Minimaal 8 tekens lang\n";
				}
				
				MessageBox.Show(message, "Wachtwoord voldoet niet", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}
}
