using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpdesk.Customer
{
	public partial class TicketsOverviewHelpdesk : Form
	{
		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";

		private SqlConnection _connection;

		public long _helpdeskId;

		public TicketsOverviewHelpdesk(long id)
		{
			InitializeComponent();
			this.refreshButton.Image = (Image)(new Bitmap(Properties.Resources.refresh, new Size(32, 32)));
			_helpdeskId = id;
		}

		private void refresh()
		{
			ticketList.Items.Clear();
			string query = "IF @number IS NOT NULL AND @number != '' " +
						   "BEGIN " +
						   "SELECT title, state, customerNumber FROM Tickets " +
						   "WHERE helpdeskId = @helpdeskId AND (customerNumber LIKE '%' + @number + '%' OR @number IS NULL) " +
						   "END " +
						   "ELSE " +
						   "BEGIN " +
						   "SELECT title, state, customerNumber FROM Tickets " +
						   "WHERE helpdeskId = @helpdeskId " +
						   "END";
			string search = searchBox.Text;

			DataTable dataTable = new DataTable();
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

		private void searchBox_TextChanged(object sender, EventArgs e)
		{
			refresh();
		}

		private void ticketList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (ticketList.SelectedItems.Count > 0)
			{
				openButton.Enabled = true;
			}
			else
			{
				openButton.Enabled = false;
			}
		}
	}
}
