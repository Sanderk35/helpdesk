using System.Globalization;
using Helpdesk.Tickets;

namespace Helpdesk.Customer
{
	public partial class TicketsOverviewIT : Form
	{
		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";

		private SqlConnection _connection;

		public long _ictId;

		public long _specialism;
		
		private bool _isClosing;

		public TicketsOverviewIT(long id, long specialism)
		{
			InitializeComponent();
			refreshButton.Image = new Bitmap(Properties.Resources.refresh, new Size(32, 32));
			_ictId = id;
			_specialism = specialism;
		}

		private void refresh()
		{
			ticketList.Items.Clear();
			string query = "SELECT T.id, title, description, state, ictId, creationDate, specialism, englishSpecialism FROM Tickets T " +
						   "JOIN Specialism S ON specialismId = S.id " +
						   "WHERE ictId = @staffId OR ictId IS NULL ORDER BY state";

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
					item.SubItems.Add(row["description"].ToString());
					item.SubItems.Add(CultureInfo.CurrentCulture.Name == "nl-NL"
						? row["specialism"].ToString()
						: row["englishSpecialism"].ToString());
					item.SubItems.Add(row["creationDate"].ToString());
					item.ImageKey = "Open.png";
					item.Tag = row["id"].ToString();
					item.Group = ticketList.Groups[1];
					ticketList.Items.Add(item);
				}
				else if ((int)row["state"] == 2)
				{
					ListViewItem item = new ListViewItem(row["title"].ToString());
					item.SubItems.Add(row["description"].ToString());
					item.SubItems.Add(CultureInfo.CurrentCulture.Name == "nl-NL"
						? row["specialism"].ToString()
						: row["englishSpecialism"].ToString());
					item.SubItems.Add(row["creationDate"].ToString());
					item.ImageKey = "Closed.png";
					item.Tag = row["id"].ToString();
					item.Group = ticketList.Groups[2];
					ticketList.Items.Add(item);
				}
				else
				{
					ListViewItem item = new ListViewItem(row["title"].ToString());
					item.SubItems.Add(row["description"].ToString());
					item.SubItems.Add(CultureInfo.CurrentCulture.Name == "nl-NL"
						? row["specialism"].ToString()
						: row["englishSpecialism"].ToString());
					item.SubItems.Add(row["creationDate"].ToString());
					item.ImageKey = (int)row["state"] switch
					{
						0 => "Open.png",
						1 => "Answered.png",
						2 => "Closed.png",
						_ => item.ImageKey
					};
					item.Tag = row["id"].ToString();
					item.Group = ticketList.Groups[0];
					ticketList.Items.Add(item);
				}
			}
			ticketList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			ticketList.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			ticketList.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			ticketList.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		private void openButton_Click(object sender, EventArgs e)
		{
			if (ticketList.SelectedItems[0].Group == ticketList.Groups[0])
			{
				long id = long.Parse(ticketList.SelectedItems[0].Tag.ToString());
				Chat chat = new Chat(id, _ictId, 2);
				this.Hide();
				chat.ShowDialog();
				this.Show(); ;
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
