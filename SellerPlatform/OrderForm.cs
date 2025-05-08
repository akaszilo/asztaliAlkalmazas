
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SellerPlatform
{
    public partial class OrderForm : Form

    {
        private string ConnectionString;
        public OrderForm()
        {
            InitializeComponent();
            string server = "127.0.0.1";
            string database = "makeupstorenew";
            string user = "root";
            string password = "";
            string port = "3306";

            ConnectionString = $"server={server};port={port};user id={user};password={password};database={database};SslMode=none";
            LoadOrders();
        }
        private void LoadOrders()
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false;

                    connection.Open();
                    string query = "SELECT o.id, u.id, o.total, o.status, u.name " +
                                   "FROM orders o " +
                                   "JOIN users u ON u.id = o.user_id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    sendMail(id);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void LoadOrderItems(string current)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT i.id, p.name, i.quantity, i.price " +
                                   "FROM order_items i " +
                                   "JOIN orders o ON o.id = i.order_id " +
                                   "JOIN products p ON p.id = i.product_id " +
                                   "WHERE o.id = @current";


                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        command.Parameters.AddWithValue("@current", current);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = null; // Clear previous data
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}, {ex.Number}");
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            public string current = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            LoadOrderItems(current);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null; // Clear previous data
            LoadOrders();
        }

        private void acceptOrder(string id)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE orders SET status = 'shipped' WHERE ID = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Order updated successfully!" : "No product found with the specified name.");
                    }
                    
                }
                catch (MySqlException ex)
                {



                    MessageBox.Show($"MySQL error {ex.Number}: {ex.Message}");


                }
            }
        }
        private void declineOrder(string id)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE orders SET status = 'declined' WHERE ID = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Order updated successfully!" : "No product found with the specified name.");
                    }
                }
                catch (MySqlException ex)
                {



                    MessageBox.Show($"MySQL error {ex.Number}: {ex.Message}");


                }
            }
        }
        private void sendMail(string id)
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {

                connection2.Open();
                string query2 = "SELECT email FROM users WHERE id=@id ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                    }

                }
            }

            string fromAddress = "felado@example.com";
            string toAddress = dataTable;
            string subject = "Teszt e-mail";
            string body = "Ez egy teszt e-mail C#-ból.";

            SmtpClient smtpClient = new SmtpClient("smtp.szerver.hu", 587) // SMTP szerver és port
            {
                Credentials = new NetworkCredential("felado@example.com", "jelszo"),
                EnableSsl = true
            };

            MailMessage mail = new MailMessage(fromAddress, toAddress, subject, body);

            try
            {
                smtpClient.Send(mail);
                Console.WriteLine("E-mail sikeresen elküldve.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt az e-mail küldésekor: " + ex.Message);
            }
        }
        private void btn_Accept_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            acceptOrder(id);
            LoadOrders();

        }

        private void btn_Decline_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            declineOrder(id);
            LoadOrders();


        }
    }
}
