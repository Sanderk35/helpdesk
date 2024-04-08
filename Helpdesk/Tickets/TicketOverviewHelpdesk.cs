using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpdesk.Tickets;

namespace Helpdesk.Customer
{
	public partial class TicketsOverviewHelpdesk : Form
	{
		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";

		private SqlConnection _connection;

		public long _helpdeskId;
		
		private bool _isClosing;

		public TicketsOverviewHelpdesk(long id)
		{
			InitializeComponent();
			refreshButton.Image = new Bitmap(Properties.Resources.refresh, new Size(32, 32));
			_helpdeskId = id;
		}

		private void refresh()
		{
			ticketList.Items.Clear();
			string query = "SELECT id, title, pendingClosure FROM Tickets WHERE helpdeskId = @userId";

			DataTable dataTable = new DataTable();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
				adapter.SelectCommand.Parameters.AddWithValue("@userId", _helpdeskId);
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
						using SqlConnection connection = new SqlConnection(_connectionString);
						connection.Open();
						SqlCommand command = new SqlCommand(query, connection);
						command.Parameters.AddWithValue("@id", (long)row["id"]);
						command.ExecuteNonQuery();
					}
				}
			}
			
			ticketList.Items.Clear();
			query = "IF @number IS NOT NULL AND @number != '' " +
			        "BEGIN " +
					"SELECT id, title, state, customerNumber FROM Tickets " +
			        "WHERE helpdeskId = @helpdeskId AND (customerNumber LIKE '%' + @number + '%' OR @number IS NULL) " +
			        "END " +
			        "ELSE " +
			        "BEGIN " +
			        "SELECT id, title, state, customerNumber FROM Tickets " +
			        "WHERE helpdeskId = @helpdeskId " +
			        "END";
			string search = searchBox.Text;

			dataTable = new DataTable();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
				adapter.SelectCommand.Parameters.AddWithValue("@helpdeskId", _helpdeskId);
				adapter.SelectCommand.Parameters.AddWithValue("@number", search);
				adapter.Fill(dataTable);
			}

			foreach (DataRow row in dataTable.Rows)
			{
				ListViewItem item = new ListViewItem(row["title"].ToString());
				if ((int)row["state"] == 0)
					item.ImageKey = "Open.png";
				else if ((int)row["state"] == 1)
					item.ImageKey = "Answered.png";
				else if ((int)row["state"] == 2)
					item.ImageKey = "Closed.png";
				item.SubItems.Add(row["customerNumber"].ToString());
				item.Tag = row["id"];
				ticketList.Items.Add(item);
			}
			ticketList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.None);
			ticketList.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
		}


		private void createButton_Click(object sender, EventArgs e)
		{
			PopUp.TicketCreation ticketCreation = new PopUp.TicketCreation(_helpdeskId, true);
			ticketCreation.ShowDialog();
			refresh();
		}

		private void openButton_Click(object sender, EventArgs e)
		{
			long id = long.Parse(ticketList.SelectedItems[0].Tag.ToString());
			Chat chat = new Chat(id, _helpdeskId, 1);
			this.Hide();
			chat.ShowDialog();
			this.Show();
		}

		private void TicketsOverview_FormClosed(object sender, FormClosingEventArgs e)
		{
			if (!_isClosing)
			{
				DialogResult result = MessageBox.Show(Translation.close_the_app, Translation.close_the_app_caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

				if (result == DialogResult.Yes)
				{
					_isClosing = true;
					Application.Exit();
				}
				else if (result == DialogResult.No)
				{
					Login login = new();
					login.Show();
					Hide();
				}
				else if (result == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
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

		private void searchBox_TextChanged(object sender, EventArgs e)
		{
			refresh();
		}

		private void ticketList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
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
	}
}
