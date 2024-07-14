namespace ChatV2
{
    partial class HomePage
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.ListBox listContacts;
        private System.Windows.Forms.TextBox userMessage;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.ListBox listChatHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.listContacts = new System.Windows.Forms.ListBox();
            this.userMessage = new System.Windows.Forms.TextBox();
            this.sendMessage = new System.Windows.Forms.Button();
            this.listChatHistory = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(12, 9);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(71, 13);
            this.lblCurrentUser.TabIndex = 0;
            this.lblCurrentUser.Text = "Logged in as:";
            // 
            // listContacts
            // 
            this.listContacts.FormattingEnabled = true;
            this.listContacts.Location = new System.Drawing.Point(12, 87);
            this.listContacts.Name = "listContacts";
            this.listContacts.Size = new System.Drawing.Size(200, 147);
            this.listContacts.TabIndex = 1;
            this.listContacts.SelectedIndexChanged += new System.EventHandler(this.listContacts_SelectedIndexChanged);
            // 
            // userMessage
            // 
            this.userMessage.Location = new System.Drawing.Point(353, 255);
            this.userMessage.Name = "userMessage";
            this.userMessage.Size = new System.Drawing.Size(335, 20);
            this.userMessage.TabIndex = 2;
            // 
            // sendMessage
            // 
            this.sendMessage.Location = new System.Drawing.Point(694, 253);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(75, 23);
            this.sendMessage.TabIndex = 3;
            this.sendMessage.Text = "Send";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // listChatHistory
            // 
            this.listChatHistory.FormattingEnabled = true;
            this.listChatHistory.Location = new System.Drawing.Point(353, 61);
            this.listChatHistory.Name = "listChatHistory";
            this.listChatHistory.Size = new System.Drawing.Size(416, 173);
            this.listChatHistory.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Available users";
            // 
            // HomePage
            // 
            this.ClientSize = new System.Drawing.Size(781, 330);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.listContacts);
            this.Controls.Add(this.userMessage);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.listChatHistory);
            this.Name = "HomePage";
            this.Text = "Home Page";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
    }
}
