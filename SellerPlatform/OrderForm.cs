
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
                    string query = "SELECT o.id, o.total, o.status, u.name " +
                                   "FROM orders o " +
                                   "JOIN users u ON u.id = o.user_id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
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
                    string query = "SELECT i.id, i.quantity, i.price, " +
                                   "FROM order_items " +
                                   "JOIN orders o ON i.order_id = o.id " +
                                   "WHERE o.id = ";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            string current = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label1.Text = current;
            LoadOrderItems(current);
        }
    }
}
