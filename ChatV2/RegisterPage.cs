using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChatV2
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            List<User> users = DataManager.LoadUsers();

            // Check if username already exists
            if (users.Any(u => u.Username == username))
            {
                MessageBox.Show("Username already exists. Please choose another.");
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Create new user
            User newUser = new User { Username = username, Password = password };
            users.Add(newUser);
            DataManager.SaveUsers(users); // Save to user list (saved in chat.db)

            MessageBox.Show("Registration successful! You can now log in.");
            this.Close(); // Close the registration page (just open the .exe again or run start debugging again)
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.Hide(); // Hide the RegisterPage
            loginPage.ShowDialog(); 
            this.Close(); // Close RegisterPage when LoginPage is closed
        }

        private void RegisterPage_Load(object sender, EventArgs e) 
        {

        }
    }
}
