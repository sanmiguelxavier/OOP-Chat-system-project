using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace ChatV2
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent(); 
        }


        // Login button
        private void loginButton_Click(object sender, EventArgs e)
        {

            // Retrieve the username and password entered by the user (stored in chat.db by ---> SQLite)
            string username = usernameLogin.Text;
            string password = passwordLogin.Text;

            List<User> users = DataManager.LoadUsers(); // Load user


            // Check if the entered username and password match any user
            User user = users.FirstOrDefault(u => u.Username == username && u.Password == password);


            // If a matching user is found
            if (user != null)
            {


                // Create an instance of the MainPage and pass the username
                HomePage mainPage = new HomePage(username);
                this.Hide(); 
                mainPage.ShowDialog(); 
                this.Close(); // Close the login page


            }
            else
            {


                MessageBox.Show("Invalid username or password.");

            }
        }



        // Empty label click event (can be removed if not used :p)
        private void label1_Click(object sender, EventArgs e)
        {

        }



        // When loading LoginPage first (if needed)
        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
