using System.ComponentModel;

namespace Helpdesk.Tickets;

partial class Chat
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		ComponentResourceManager resources = new ComponentResourceManager(typeof(Chat));
		chatView = new ListView();
		chatHeader = new ColumnHeader();
		sendHeader = new ColumnHeader();
		timeHeader = new ColumnHeader();
		messageBox = new TextBox();
		sendButton = new Button();
		SuspendLayout();
		// 
		// chatView
		// 
		chatView.Columns.AddRange(new ColumnHeader[] { chatHeader, sendHeader, timeHeader });
		chatView.FullRowSelect = true;
		chatView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		chatView.HideSelection = true;
		chatView.Location = new Point(12, 12);
		chatView.MultiSelect = false;
		chatView.Name = "chatView";
		chatView.Size = new Size(776, 392);
		chatView.TabIndex = 0;
		chatView.UseCompatibleStateImageBehavior = false;
		chatView.View = View.Details;
		// 
		// chatHeader
		// 
		chatHeader.Text = Translation.message;
		// 
		// sendHeader
		// 
		sendHeader.Text = Translation.sender;
		// 
		// timeHeader
		// 
		timeHeader.Text = Translation.time;
		// 
		// messageBox
		// 
		messageBox.Location = new Point(12, 411);
		messageBox.MaxLength = 400;
		messageBox.Name = "messageBox";
		messageBox.PlaceholderText = Translation.chat;
		messageBox.Size = new Size(676, 27);
		messageBox.TabIndex = 1;
		messageBox.TextChanged += messageBox_TextChanged;
		// 
		// sendButton
		// 
		sendButton.Location = new Point(694, 410);
		sendButton.Name = "sendButton";
		sendButton.Size = new Size(94, 29);
		sendButton.TabIndex = 2;
		sendButton.Text = Translation.send;
		sendButton.Enabled = false;
		sendButton.UseVisualStyleBackColor = true;
		sendButton.Click += sendButton_Click;
		// 
		// Chat
		// 
		AutoScaleDimensions = new SizeF(8F, 20F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
		Controls.Add(sendButton);
		Controls.Add(messageBox);
		Controls.Add(chatView);
		Icon = (Icon)resources.GetObject("$this.Icon");
		Name = "Chat";
		StartPosition = FormStartPosition.CenterParent;
		Text = "Chat";
		Load += Chat_Load;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private ListView chatView;
	private TextBox messageBox;
	private Button sendButton;
	private ColumnHeader chatHeader;
	private ColumnHeader sendHeader;
	private ColumnHeader timeHeader;
}