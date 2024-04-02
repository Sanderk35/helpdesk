using System.Net;
using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

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
			string apiKey = "7eaea3f09faf460f86f4205c19119b10";
			string email = emailBox.Text.ToLower();
			
			string url = $"https://api.zerobounce.net/v2/validate?api_key={apiKey}&email={email}";
			
			WebClient client = new WebClient();
			string response = client.DownloadString(url);
			
			JObject jsonResponse = JObject.Parse(response);
			
			string result = jsonResponse.Value<string>("status");

			// if (result == "valid")
			{
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
							catch (SqlException ex) when (ex.Number == 2627)
							{
								MessageBox.Show(Translation.email_used_message, Translation.error,
									MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							catch (SqlException ex) when (ex.Number == 2628)
							{
								MessageBox.Show(Translation.too_long_password, Translation.too_long_caption,
									MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							catch (Exception ex)
							{
								MessageBox.Show(Translation.error + Translation.semicolon + ex, Translation.error,
									MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			// else
			// {
			// 	MessageBox.Show(Translation.email_invalid_message, Translation.email_invalid_caption,
			// 		MessageBoxButtons.OK, MessageBoxIcon.Error);
			// }
		}
		private void housenumBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsDigit(e.KeyChar) || e.KeyChar == ' ' || char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar)))
			{
				e.Handled = true;
			}

			string currentText = housenumBox.Text;
			if (!char.IsControl(e.KeyChar))
			{
				if (e.KeyChar == (char)Keys.Back)
				{
					if (currentText.Length > 0)
					{
						currentText = currentText.Substring(0, currentText.Length - 1);
					}
				}
				else
				{
					currentText += e.KeyChar.ToString();
				}
			}

			if (currentText != housenumBox.Text)
			{
				if (!Regex.IsMatch(currentText, @"^\d+[a-zA-Z]?$"))
				{
					e.Handled = true;
				}
			}
		}
	}
}
