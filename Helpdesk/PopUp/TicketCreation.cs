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
		public long id;
		
		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";

		private SqlConnection _connection;
		public TicketCreation(long id, bool isHelpdesk)
		{
			InitializeComponent();
			this.id = id;
			_connection = new SqlConnection(_connectionString);

			if (isHelpdesk)
			{
				customerNumberBox.Visible = true;
				customerNumberBox.Enabled = true;
			}
			else
			{
				Width = 298;
			}
		}

		private void createButton_Click(object sender, EventArgs e)
		{
			string title = titleBox.Text;
			string description = descriptionBox.Text;
			string customerNumber;
			long categoryId = categoryBox.SelectedIndex;

			if (customerNumberBox.Text != "")
			{
				customerNumber = customerNumberBox.Text;
				string query =
					"INSERT INTO Tickets (title, description, helpdeskId, specialismId, customerNumber) " +
					"VALUES (@title, @description, @helpdeskId, @specialismId, @customerNumber)";
				SqlCommand command = new SqlCommand(query, _connection);
				
				command.Parameters.AddWithValue("@title", title);
				command.Parameters.AddWithValue("@description", description);
				command.Parameters.AddWithValue("@helpdeskId", id);
				command.Parameters.AddWithValue("@specialismId", categoryId);
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
				command.Parameters.AddWithValue("@userId", id);
				command.Parameters.AddWithValue("@specialismId", categoryId);
				
				command.Connection.Open();
				command.ExecuteNonQuery();
				command.Connection.Close();
			}
			
			MessageBox.Show("Ticket created");
			Close();
		}
	}
}
