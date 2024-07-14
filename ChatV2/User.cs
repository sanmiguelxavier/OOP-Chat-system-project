using System.Collections.Generic;

namespace ChatV2
{
    public class User
    {
        // Property to store the username of the user to the chat.db file 
        public string Username { get; set; }

        // Property to store the user's password (consider using secure storage practices ---> encryption, hash, etc)
        public string Password { get; set; }

        // List to hold the usernames of the user's contacts as "Available users" in the HomePage
        public List<string> Contacts { get; set; } = new List<string>();

    }
}
