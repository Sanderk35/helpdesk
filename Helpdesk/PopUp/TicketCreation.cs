using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpdesk.PopUp
{
	public partial class TicketCreation : Form
	{
		public long _id;

		public bool _isHelpdesk;

		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";

		private SqlConnection _connection;
		public TicketCreation(long id, bool isHelpdesk)
		{
			InitializeComponent();
			this._id = id;
			_connection = new SqlConnection(_connectionString);
			_isHelpdesk = isHelpdesk;

			if (isHelpdesk)
			{
				customerNumberList.Visible = true;
			}
			else
			{
				Width = 298;
			}
		}

		private void TicketCreation_Load(object sender, EventArgs e)
		{
			if (_isHelpdesk)
			{
				string query = "SELECT id, firstName, infix, lastName, place, street, housenum FROM Users";
				SqlCommand command = new SqlCommand(query, _connection);
				command.Connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					ListViewItem item;
					if (reader["infix"].ToString() == "")
					{
						item = new ListViewItem(reader["firstName"].ToString() + " " + reader["lastName"].ToString());
					}
					else
					{
						item = new ListViewItem(reader["firstName"].ToString() + " " + reader["infix"].ToString() + " " + reader["lastName"].ToString());
					}
					item.SubItems.Add(reader["street"].ToString() + " " + reader["housenum"].ToString() + ", " + reader["place"].ToString());
					item.Tag = reader["id"].ToString();
					customerNumberList.Items.Add(item);
				}
				customerNumberList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
				command.Connection.Close();
			}
		}

		private void createButton_Click(object sender, EventArgs e)
		{
			string title = titleBox.Text;
			string description = descriptionBox.Text;
			string customerNumber;
			long categoryId = categoryBox.SelectedIndex;

			if (customerNumberList.SelectedItems.Count != 0)
			{
				customerNumber = customerNumberList.SelectedItems[0].Tag.ToString();
				string query =
					"INSERT INTO Tickets (title, description, helpdeskId, specialismId, customerNumber) " +
					"VALUES (@title, @description, @helpdeskId, @specialismId, @customerNumber)";
				SqlCommand command = new SqlCommand(query, _connection);

				command.Parameters.AddWithValue("@title", title);
				command.Parameters.AddWithValue("@description", description);
				command.Parameters.AddWithValue("@helpdeskId", _id);
				command.Parameters.AddWithValue("@specialismId", categoryId + 1);
				command.Parameters.AddWithValue("@customerNumber", customerNumber);

				command.Connection.Open();
				command.ExecuteNonQuery();
				command.Connection.Close();
			}
			else
			{
				string query =
					"INSERT INTO Tickets (title, description, userId, specialismId) " +
					"VALUES (@title, @description, @userId, @specialismId)";
				SqlCommand command = new SqlCommand(query, _connection);

				command.Parameters.AddWithValue("@title", title);
				command.Parameters.AddWithValue("@description", description);
				command.Parameters.AddWithValue("@userId", _id);
				command.Parameters.AddWithValue("@specialismId", categoryId + 1);

				command.Connection.Open();
				command.ExecuteNonQuery();
				command.Connection.Close();
			}

			MessageBox.Show(Translation.ticket_created);
			Close();
		}

		private void Update(object sender, EventArgs e)
		{
			if (titleBox.Text != "" && descriptionBox.Text != "" && categoryBox.SelectedIndex != -1 && !_isHelpdesk)
			{
				createButton.Enabled = true;
			}
			else if (titleBox.Text != "" && descriptionBox.Text != "" && categoryBox.SelectedIndex != -1 && customerNumberList.SelectedItems.Count > 0 && _isHelpdesk)
			{
				createButton.Enabled = true;
			}
			else
			{
				createButton.Enabled = false;
			}
		}
	}
}
