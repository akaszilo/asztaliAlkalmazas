using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SellerPlatform
{
    public partial class LoginForm : Form
    {
        private string connectionString;

        public LoginForm()
        {
            InitializeComponent();


            string server = "localhost";
            string database = "makeupstorenew";
            string user = "root";
            string password = "";
            string port = "3306";

            connectionString = $"server={server};port={port};user id={user};password={password};database={database};SslMode=none";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (ValidateLogin(username, password))
            {
                MessageBox.Show("Login successful!");
                this.Hide();
                Form1 mainForm = new Form1();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        public bool ValidateLogin(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT password FROM users WHERE name = @username";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        //command.Parameters.AddWithValue("@password", password);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {


                            string storedHash = result.ToString();


                            if (BCrypt.Net.BCrypt.Verify(password, storedHash))
                            {
                                return true;
                            }
                            else
                            {
                                // Hibás jelszó
                                return false;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return false;
        }
    }
}
