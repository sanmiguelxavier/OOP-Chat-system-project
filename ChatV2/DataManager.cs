using System.Collections.Generic;
using System.Data.SQLite; 
using System.IO; 
using System.Linq; 

namespace ChatV2
{
    public static class DataManager
    {
        private const string dbFilePath = "chat.db"; // Where the database file is...

        
        static DataManager()
        {
            InitializeDatabase();
        }

        // Initialize the database and create tables if they don't exist
        private static void InitializeDatabase()
        {
            // Check if the database file exists
            if (!File.Exists(dbFilePath))
            {
                
                using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
                {
                    connection.Open();

                    // SQL command to create the Users table
                    string createUsersTable = "CREATE TABLE Users (Username TEXT PRIMARY KEY, Password TEXT)";
                    // SQL command to create the Messages table
                    string createMessagesTable = "CREATE TABLE Messages (Id INTEGER PRIMARY KEY AUTOINCREMENT, SenderUsername TEXT, ReceiverUsername TEXT, Text TEXT, Timestamp DATETIME)";

                    // Execute the commands to create the tables
                    using (var command = new SQLiteCommand(createUsersTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    using (var command = new SQLiteCommand(createMessagesTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        // Save users to the database
        public static void SaveUsers(List<User> users)
        {
            // Connection to the database
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();

                // Insert or replace each user in the Users table
                foreach (var user in users)
                {
                    string insertUser = "INSERT OR REPLACE INTO Users (Username, Password) VALUES (@Username, @Password)";
                    using (var command = new SQLiteCommand(insertUser, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        // Load all users from the database
        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                string selectUsers = "SELECT Username, Password FROM Users"; 
                using (var command = new SQLiteCommand(selectUsers, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Create a new User object for each row in the result set
                        users.Add(new User { Username = reader.GetString(0), Password = reader.GetString(1) });
                    }
                }
            }
            return users; // Return the list of users
        }

        // Add a new message to the database
        public static void AddMessage(Message message)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                string insertMessage = "INSERT INTO Messages (SenderUsername, ReceiverUsername, Text, Timestamp) VALUES (@Sender, @Receiver, @Text, @Timestamp)";
                using (var command = new SQLiteCommand(insertMessage, connection))
                {
                    command.Parameters.AddWithValue("@Sender", message.SenderUsername);
                    command.Parameters.AddWithValue("@Receiver", message.ReceiverUsername);
                    command.Parameters.AddWithValue("@Text", message.Text);
                    command.Parameters.AddWithValue("@Timestamp", message.Timestamp);
                    command.ExecuteNonQuery(); // Execute the insert command
                }
            }
        }

        // Load the message history between two users
        public static List<Message> LoadMessageHistory(string contactUsername, string currentUsername)
        {
            List<Message> messages = new List<Message>();
            using (var connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();
                string selectMessages = "SELECT SenderUsername, ReceiverUsername, Text, Timestamp FROM Messages WHERE (SenderUsername = @CurrentUser AND ReceiverUsername = @ContactUser) OR (SenderUsername = @ContactUser AND ReceiverUsername = @CurrentUser)";
                using (var command = new SQLiteCommand(selectMessages, connection))
                {
                    command.Parameters.AddWithValue("@CurrentUser", currentUsername);
                    command.Parameters.AddWithValue("@ContactUser", contactUsername);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add each message to the list
                            messages.Add(new Message
                            {
                                SenderUsername = reader.GetString(0),
                                ReceiverUsername = reader.GetString(1),
                                Text = reader.GetString(2),
                                Timestamp = reader.GetDateTime(3)
                            });
                        }
                    }
                }
            }
            return messages; // Return the list of messages
        }

        // Get the contacts for a user
        public static List<string> GetContacts(string username)
        {
            // For simplicity, returning all users as contacts, excluding the current user; adjust as necessary.
            return LoadUsers().Where(u => u.Username != username).Select(u => u.Username).ToList();
        }
    }
}
