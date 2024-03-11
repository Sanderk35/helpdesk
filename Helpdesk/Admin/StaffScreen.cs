using System.ComponentModel.Design.Serialization;
using System.Windows.Forms.VisualStyles;

namespace Helpdesk.Admin
{
	public partial class StaffScreen : Form
	{
		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";

		private SqlConnection _connection;
		public StaffScreen()
		{
			InitializeComponent();
			_connection = new SqlConnection(_connectionString);
			LoadData();
			this.refreshButton.Image = (Image)(new Bitmap(Properties.Resources.refresh, new Size(32, 32)));
		}

		public void LoadData()
		{
			staffView.Items.Clear();
			SqlConnection connection = new SqlConnection(_connectionString);
			string query = "SELECT * FROM Staff WHERE Role != 2";

			SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
			DataTable dataTable = new DataTable();
			adapter.Fill(dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				ListViewItem item = new ListViewItem(row["Email"].ToString());
				item.SubItems.Add(row["FirstName"].ToString());
				item.SubItems.Add(row["Infix"].ToString());
				item.SubItems.Add(row["LastName"].ToString());

				if ((int)row["Role"] == 2)
					item.SubItems.Add("Admin");
				else if ((int)row["Role"] == 1)
					item.SubItems.Add(Translation.IT_staff);
				else
					item.SubItems.Add(Translation.helpdesk_staff);

				if ((int)row["Specialism"] == 0)
					item.SubItems.Add(Translation.none);
				else if ((int)row["Specialism"] == 1)
					item.SubItems.Add("Tv");
				else if ((int)row["Specialism"] == 2)
					item.SubItems.Add("Internet");
				else if ((int)row["Specialism"] == 3)
					item.SubItems.Add(Translation.fixed_telephony);
				else if ((int)row["Specialism"] == 4)
					item.SubItems.Add(Translation.mobile_telephony);
				else if ((int)row["Specialism"] == 5)
					item.SubItems.Add(Translation.invoices);
				else if ((int)row["Specialism"] == 6)
					item.SubItems.Add(Translation.prices);
				else if ((int)row["Specialism"] == 7)
					item.SubItems.Add(Translation.other);
				item.SubItems.Add(row["ID"].ToString());
				staffView.Items.Add(item);
			}
			connection.Close();
			staffView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			staffView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			staffView.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			staffView.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			staffView.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			staffView.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private void StaffScreen_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			AddEditStaff addEditStaff = new AddEditStaff(false, 0);
			addEditStaff.ShowDialog();
			LoadData();
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			AddEditStaff addEditStaff = new AddEditStaff(true, int.Parse(staffView.SelectedItems[0].SubItems[6].Text));
			addEditStaff.ShowDialog();
			LoadData();
		}

		private void staffView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (staffView.SelectedItems.Count > 0)
			{
				editButton.Enabled = true;
				deleteButton.Enabled = true;
			}
			else
			{
				editButton.Enabled = false;
				deleteButton.Enabled = false;
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show(Translation.staff_delete_message, Translation.staff_delete_caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.Yes)
			{
				SqlConnection connection = new SqlConnection(_connectionString);
				SqlCommand command = new SqlCommand("DELETE FROM Staff WHERE ID = @id", connection);
				command.Parameters.AddWithValue("@id", int.Parse(staffView.SelectedItems[0].SubItems[6].Text));
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
				staffView.Items.Clear();
				LoadData();
			}
		}
	}
}
