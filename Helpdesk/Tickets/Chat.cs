namespace Helpdesk.Tickets
{
	public partial class Chat : Form
	{
		public readonly string _connectionString = "Data Source=SANDERSLAPTOP\\SQLEXPRESS;Initial Catalog=Helpdesk;Integrated Security=True;";
		public long _ticketId;
		public long _userId;
		public int _userType;

		public Chat(long ticketId, long userId, int userType)
		{
			InitializeComponent();
			_ticketId = ticketId;
			_userId = userId;
			_userType = userType;
		}

		private void Chat_Load(object sender, EventArgs e)
		{
			FetchNewMessagesFromDatabase();
			System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
			timer.Interval = 5000;
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			FetchNewMessagesFromDatabase();
		}

		private void FetchNewMessagesFromDatabase()
		{
			chatView.Items.Clear();
			string connectionString = _connectionString;
			string query = "SELECT message, U.infix Uinfix, U.lastname Ulastname, U.firstname Ufirstname, S1.infix Hinfix, S1.lastname Hlastname, S1.firstname Hfirstname, S2.infix Iinfix, S2.lastname Ilastname, S2.firstname Ifirstname, time, userId, helpdeskId, ictId FROM Messages M LEFT JOIN Staff S1 ON M.helpdeskId = S1.id LEFT JOIN Staff S2 ON M.ictId = S2.id LEFT JOIN Users U ON M.userId = U.id " +
			   "WHERE ticketId = @Id ORDER BY time DESC";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataTable dataTable = new DataTable();
				command.Parameters.AddWithValue("@Id", _ticketId);

				try
				{
					connection.Open();
					adapter.Fill(dataTable);

					foreach (DataRow row in dataTable.Rows)
					{
						ListViewItem item = new ListViewItem(row["Message"].ToString());

						if (row["userId"] is not DBNull)
						{
							if (row["Uinfix"] is not DBNull)
							{
								item.SubItems.Add(row["Uinfix"].ToString() + " " + row["UlastName"].ToString() + ", " + row["UfirstName"].ToString());
							}
							else
							{
								item.SubItems.Add(row["UlastName"].ToString() + ", " + row["UfirstName"].ToString());
							}
						}
						else if (row["helpdeskId"] is not DBNull)
						{
							if (row["Hinfix"] is not DBNull)
							{
								item.SubItems.Add(row["Hinfix"].ToString() + " " + row["HlastName"].ToString() + ", " + row["HfirstName"].ToString());
							}
							else
							{
								item.SubItems.Add(row["HlastName"].ToString() + ", " + row["HfirstName"].ToString());

							}
						}
						else if (row["ictId"] is not DBNull)
						{
							if (row["Iinfix"] is not DBNull)
							{
								item.SubItems.Add(row["Iinfix"].ToString() + " " + row["IlastName"].ToString() + ", " + row["IfirstName"].ToString());
							}
							else
							{
								item.SubItems.Add(row["IlastName"].ToString() + ", " + row["IfirstName"].ToString());

							}
						}
						else
						{
							item.SubItems.Add("Unknown");
						}
						item.SubItems.Add(row["time"].ToString());
						chatView.Items.Add(item);
					}
					chatView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
					chatView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
					chatView.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error fetching data: " + ex.Message);
				}
			}
		}

		private void sendButton_Click(object sender, EventArgs e)
		{
			string message = messageBox.Text;
			string connectionString = _connectionString;
			string query = "INSERT INTO Messages (ticketId, message, userId, helpdeskId, ictId) VALUES (@ticketId, @message, @userId, @helpdeskId, @ictId)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@ticketId", _ticketId);
				command.Parameters.AddWithValue("@message", message);
				if (_userType == 0)
				{
					command.Parameters.AddWithValue("@userId", _userId);
					command.Parameters.AddWithValue("@helpdeskId", DBNull.Value);
					command.Parameters.AddWithValue("@ictId", DBNull.Value);
				}
				else if (_userType == 1)
				{
					command.Parameters.AddWithValue("@userId", DBNull.Value);
					command.Parameters.AddWithValue("@helpdeskId", _userId);
					command.Parameters.AddWithValue("@ictId", DBNull.Value);
				}
				else if (_userType == 2)
				{
					command.Parameters.AddWithValue("@userId", DBNull.Value);
					command.Parameters.AddWithValue("@helpdeskId", DBNull.Value);
					command.Parameters.AddWithValue("@ictId", _userId);
				}

				try
				{
					connection.Open();
					command.ExecuteNonQuery();
					messageBox.Text = "";
					FetchNewMessagesFromDatabase();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error sending message: " + ex.Message);
				}
			}
		}

		private void messageBox_TextChanged(object sender, EventArgs e)
		{
			if (messageBox.Text != "")
			{
				sendButton.Enabled = true;
			}
			else
			{
				sendButton.Enabled = false;
			}
		}
	}
}
