using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatV2
{
    public partial class HomePage : Form
    {
        private string currentUsername; // Store the currently logged-in username

        public HomePage(string username)
        {
            InitializeComponent(); 
            currentUsername = username; 
            LoadContacts(); 
            lblCurrentUser.Text = $"Logged in as: {currentUsername}"; // Display current user on the form
        }

        // Load contacts for the current user
        private void LoadContacts()
        {
            List<string> contacts = DataManager.GetContacts(currentUsername); // Retrieve contacts from DataManager
            listContacts.Items.Clear(); 
            foreach (var contact in contacts)
            {
                listContacts.Items.Add(contact); // Add each contact to the list
            }
        }

        // Send message button
        private void sendMessage_Click(object sender, EventArgs e)
        {
            if (listContacts.SelectedItem != null) // Check if a contact is selected
            {
                string receiverUsername = listContacts.SelectedItem.ToString(); // Get the selected contact's username
                string messageText = userMessage.Text.Trim(); // Get the message text that was typed in

                if (string.IsNullOrWhiteSpace(messageText)) // Check if the message is empty
                {
                    MessageBox.Show("Message cannot be empty."); // Show an alert message
                    return;
                }

                // Create a new message object
                Message message = new Message
                {
                    SenderUsername = currentUsername,
                    ReceiverUsername = receiverUsername,
                    Text = messageText,
                    Timestamp = DateTime.Now
                };

                DataManager.AddMessage(message); // Save the message to the database (chat.db --> SQLite)
                LoadMessageHistory(receiverUsername); // Refresh the message history display
                userMessage.Clear(); // Clear the input for message
            }
        }

        // When a contact was clicked/selected
        private void listContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listContacts.SelectedItem != null) // Check if a contact is selected
            {
                string contactUsername = listContacts.SelectedItem.ToString(); 
                LoadMessageHistory(contactUsername); // Load message history
            }
        }

        // Load message history between the current user and a selected contact
        private void LoadMessageHistory(string contactUsername)
        {
            List<Message> messages = DataManager.LoadMessageHistory(contactUsername, currentUsername); 
            listChatHistory.Items.Clear(); 
            foreach (var message in messages)
            {
                // Add each message to the chat history display
                listChatHistory.Items.Add($"{message.Timestamp}: {message.SenderUsername}: {message.Text}");
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
           
        }
    }
}
