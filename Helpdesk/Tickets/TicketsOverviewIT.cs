namespace Helpdesk.Customer
{
	public partial class TicketsOverviewIT : Form
	{
		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";

		private SqlConnection _connection;

		public long _ictId;

		public long _specialism;

		public TicketsOverviewIT(long id, long specialism)
		{
			InitializeComponent();
			this.refreshButton.Image = (Image)(new Bitmap(Properties.Resources.refresh, new Size(32, 32)));
			_ictId = id;
			_specialism = specialism;
		}

		private void refresh()
		{
			ticketList.Items.Clear();
			string query = "SELECT id, title, state, ictId FROM Tickets WHERE ictId = @staffId AND specialismId = @specialism OR ictId IS NULL AND specialismId = @specialism ORDER BY state";

			DataTable dataTable = new DataTable();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
				adapter.SelectCommand.Parameters.AddWithValue("@staffId", _ictId);
				adapter.SelectCommand.Parameters.AddWithValue("@specialism", _specialism);
				adapter.Fill(dataTable);
			}

			foreach (DataRow row in dataTable.Rows)
			{
				if (row["ictId"] == DBNull.Value)
				{
					ListViewItem item = new ListViewItem(row["title"].ToString());
					item.ImageKey = "Open.png";
					item.Tag = row["id"].ToString();
					item.Group = ticketList.Groups[1];
					ticketList.Items.Add(item);
				}
				else
				{
					ListViewItem item = new ListViewItem(row["title"].ToString());
					if ((int)row["state"] == 0)
						item.ImageKey = "Open.png";
					else if ((int)row["state"] == 1)
						item.ImageKey = "Answered.png";
					else if ((int)row["state"] == 2)
						item.ImageKey = "Closed.png";
					item.Tag = row["id"].ToString();
					item.Group = ticketList.Groups[0];
					ticketList.Items.Add(item);
				}
			}
			ticketList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.None);
		}

		private void openButton_Click(object sender, EventArgs e)
		{
			if (ticketList.SelectedItems[0].Group == ticketList.Groups[0])
			{
				// Ticket ticket = new Ticket(long.Parse(ticketList.SelectedItems[0].Tag.ToString()));
				// ticket.Show();
				// this.Hide();
				MessageBox.Show("Nu zou de chat openen, maar die functie is nog niet geïmplementeerd.");
			}
			else
			{
				string query = "UPDATE Tickets SET ictId = @ictId WHERE id = @ticketId;";
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@ictId", _ictId);
					command.Parameters.AddWithValue("@ticketId", long.Parse(ticketList.SelectedItems[0].Tag.ToString()));
					command.ExecuteNonQuery();
				}
				refresh();
			}
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
				openButton.Enabled = true;
				closeButton.Enabled = true;
				if (ticketList.SelectedItems[0].Group == ticketList.Groups[0])
				{
					openButton.Text = "Open";
				}
				else
				{
					openButton.Text = "Claim";
				}
			}
			else
			{
				openButton.Enabled = false;
				closeButton.Enabled = false;
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			long id = long.Parse(ticketList.SelectedItems[0].Tag.ToString());
			DialogResult result = MessageBox.Show(Translation.ticket_closing_desc, Translation.ticket_closing_title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Yes)
			{
				string query = "UPDATE Tickets SET pendingClosure = 1 WHERE id = @ticketId;";
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ticketId", id);
						try
						{
							connection.Open();
							command.ExecuteNonQuery();
						}
						catch (SqlException ex)
						{
							
						}
						finally
						{
							connection.Close();
						}
					}
				}
			}
		}

	}
}
