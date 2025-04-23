using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SellerPlatform
{
    public partial class Form1 : Form
    {
        private string connectionString;

        public Form1()
        {
            InitializeComponent();

            
            string server = "localhost"; 
            string database = "makeupstorenew";
            string user = "root";
            string password = ""; 
            string port = "3306";

            connectionString = $"server={server};port={port};user id={user};password={password};database={database};SslMode=none";

            LoadProducts();
        }

        private void LoadProducts()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT p.ID, p.Name, p.Price, p.Image_Link, p.Description, b.Brand AS Brand, c.Category AS Category " +
                                   "FROM products p " +
                                   "JOIN brands b ON p.Brand_Id = b.ID " +
                                   "JOIN categories c ON p.Category_Id = c.ID";

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

        private int GetBrandId(string brandName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id FROM brands WHERE brand = @brandName";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@brandName", brandName);
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int brandId))
                        {
                            return brandId;
                        }
                        else
                        {
                            MessageBox.Show($"Brand '{brandName}' not found.");
                            return -1; 
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    return -1; 
                }
            }
        }

        
        private int GetCategoryId(string categoryName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id FROM categories WHERE category = @categoryName";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@categoryName", categoryName);
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int categoryId))
                        {
                            return categoryId;
                        }
                        else
                        {
                            MessageBox.Show($"Category '{categoryName}' not found.");
                            return -1; 
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    return -1; 
                }
            }
        }


        // Method to add a product to the database
        private void AddProduct(string name, decimal price, string imageLink, string description, string brandName, string categoryName)
        {
            int brandId = GetBrandId(brandName);
            int categoryId = GetCategoryId(categoryName);

            // Ensure both IDs are valid before proceeding
            if (brandId == -1 || categoryId == -1)
            {
                MessageBox.Show("Failed to retrieve Brand ID or Category ID. Product not added.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO products (name, Price, Image_Link, Description, Brand_Id, Category_Id) " +
                                   "VALUES (@name, @price, @imageLink, @description, @brandId, @categoryId)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@imageLink", imageLink);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@brandId", brandId);
                        command.Parameters.AddWithValue("@categoryId", categoryId);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Product added successfully!" : "Failed to add product.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            // Reload the products into the DataGridView
            LoadProducts();
        }

        // Method to update a product by Name
        private void UpdateProductByName(string name, decimal price, string imageLink, string description, string brandName, string categoryName)
        {
            int brandId = GetBrandId(brandName);
            int categoryId = GetCategoryId(categoryName);

            // Ensure both IDs are valid before proceeding
            if (brandId == -1 || categoryId == -1)
            {
                MessageBox.Show("Failed to retrieve Brand ID or Category ID. Product not updated.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE products SET Price=@price, Image_Link=@imageLink, Description=@description, " +
                                   "Brand_Id=@brandId, Category_Id=@categoryId WHERE Name=@name";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@imageLink", imageLink);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@brandId", brandId);
                        command.Parameters.AddWithValue("@categoryId", categoryId);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Product updated successfully!" : "No product found with the specified name.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            // Reload the products into the DataGridView
            LoadProducts();
        }


        private void DeleteProductByName(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM products WHERE Name=@name";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Product deleted successfully!" : "No product found with the specified name.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            
            LoadProducts();
        }

        
        private void btn_add_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            decimal price = nudPrice.Value;
            string imageLink = txtImage.Text;
            string description = txtDescription.Text;
            string brandName = cbBrand.Text;
            string categoryName = cbCategory.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(imageLink) ||
                string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(brandName) ||
                string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            AddProduct(name, price, imageLink, description, brandName, categoryName);
        }

        
        private void btn_change_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            decimal price = nudPrice.Value;
            string imageLink = txtImage.Text;
            string description = txtDescription.Text;
            string brandName = cbBrand.Text;
            string categoryName = cbCategory.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(imageLink) ||
                string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(brandName) ||
                string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            UpdateProductByName(name, price, imageLink, description, brandName, categoryName);
        }

        
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the name of the product to delete.");
                return;
            }

            DeleteProductByName(name);
        }
    }
}