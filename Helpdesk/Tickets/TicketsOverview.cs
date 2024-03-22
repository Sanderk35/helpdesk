using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Helpdesk.Customer
{
	public partial class TicketsOverview : Form
	{
		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";

		private SqlConnection _connection;

		public long _userId;

		public TicketsOverview(long id)
		{
			InitializeComponent();
			this.refreshButton.Image = (Image)(new Bitmap(Properties.Resources.refresh, new Size(32, 32)));
			_userId = id;
		}

		private void refresh()
		{
			ticketList.Items.Clear();
			string query = "SELECT id, title, pendingClosure FROM Tickets WHERE userId = @userId";

			DataTable dataTable = new DataTable();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
				adapter.SelectCommand.Parameters.AddWithValue("@userId", _userId);
				adapter.Fill(dataTable);
			}

			foreach (DataRow row in dataTable.Rows)
			{
				if ((bool)row["pendingClosure"])
				{
					DialogResult result = MessageBox.Show(string.Format(Translation.pending_closure, row["title"]), Translation.pending_closure_title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
					if (result == DialogResult.Yes)
					{
						query = "UPDATE Tickets SET state = 2, pendingClosure = 0 WHERE id = @id";
						using (SqlConnection connection = new SqlConnection(_connectionString))
						{
							connection.Open();
							SqlCommand command = new SqlCommand(query, connection);
							command.Parameters.AddWithValue("@id", (long)row["id"]);
							command.ExecuteNonQuery();
						}
					}
				}
			}
			
			query = "SELECT title, state FROM Tickets WHERE userId = @userId ORDER BY state";

			dataTable = new DataTable();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
				adapter.SelectCommand.Parameters.AddWithValue("@userId", _userId);
				adapter.Fill(dataTable);
			}

			foreach (DataRow row in dataTable.Rows)
			{
				ListViewItem item = new ListViewItem(row["title"].ToString());
				if ((int)row["state"] == 1)
					item.ImageKey = "Open.png";
				else if ((int)row["state"] == 0)
					item.ImageKey = "Answered.png";
				else if ((int)row["state"] == 2)
					item.ImageKey = "Closed.png";
				ticketList.Items.Add(item);
			}
			ticketList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
		}


		private void createButton_Click(object sender, EventArgs e)
		{
			PopUp.TicketCreation ticketCreation = new PopUp.TicketCreation(_userId, false);
			ticketCreation.ShowDialog();
			refresh();
		}

		private void openButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Nu zou de chat openen, maar die functie is nog niet geïmplementeerd.");
		}

		private void TicketsOverview_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void ticketList_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			e.DrawDefault = true;
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			refresh();
		}

		private void TicketsOverview_Load(object sender, EventArgs e)
		{
			refresh();
		}

		private void ticketList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (ticketList.SelectedItems.Count > 0)
			{
				if (ticketList.SelectedItems[0].ImageKey == "Closed.png")
				{
					openButton.Enabled = false;
				}
				else
				{
					openButton.Enabled = true;
				}
			}
			else
			{
				openButton.Enabled = false;
			}
		}
	}
}
