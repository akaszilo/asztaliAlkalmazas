using MySql.Data.MySqlClient;
using System.Data;

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
                    string query = "SELECT p.id, p.name, p.price, p.image_link, p.description, p.howtouse, p.ingredients, b.name AS brand, c.name AS category " +
                                   "FROM products p " +
                                   "JOIN brands b ON p.brand_id = b.id " +
                                   "JOIN categories c ON p.category_Id = c.id";

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
                    string query = "SELECT id FROM brands WHERE name = @brandName";

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
                    string query = "SELECT id FROM categories WHERE name = @categoryName";

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
        private void AddProduct(string name, decimal price, string imageLink, string description, string brandName, string categoryName, string howToUsw, string ingredients)
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
                    string query = "INSERT INTO products (name, price, image_link, description, brand_Id, category_Id, howtouse, ingredients) " +
                                   "VALUES (@name, @price, @imageLink, @description, @brandId, @categoryId, @howtouse, @ingredients)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@imageLink", imageLink);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@brandId", brandId);
                        command.Parameters.AddWithValue("@categoryId", categoryId);
                        command.Parameters.AddWithValue("@howtouse", howToUsw);
                        command.Parameters.AddWithValue("@ingredients", ingredients);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Product added successfully!" : "Failed to add product.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }


            LoadProducts();
        }


        private void UpdateProductByName(string name, decimal price, string imageLink, string description, string brandName, string categoryName, string howtouse, string ingredients)
        {
            int brandId = GetBrandId(brandName);
            int categoryId = GetCategoryId(categoryName);


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
                    string query = "UPDATE products SET price=@price, image_link=@imageLink, description=@description,brand_id=@brandId, category_id=@categoryId howtouse=@howtouse, ingredients=@ingredients, WHERE name=@name";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@imageLink", imageLink);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@ingredients", ingredients);
                        command.Parameters.AddWithValue("@howtouse", howtouse);
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
            string howToUse = cbHowToUse.Text;
            string ingredients = cbIngredients.Text;
            string categoryName = cbCategory.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(imageLink) ||
                string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(brandName) ||
                string.IsNullOrWhiteSpace(categoryName) ||
                string.IsNullOrWhiteSpace(howToUse) ||
                string.IsNullOrWhiteSpace(ingredients))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            AddProduct(name, price, imageLink, description, brandName, categoryName, howToUse, ingredients);
        }


        private void btn_change_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            decimal price = nudPrice.Value;
            string imageLink = txtImage.Text;
            string description = txtDescription.Text;
            string brandName = cbBrand.Text;
            string howtouse = cbHowToUse.Text;
            string ingredients = cbIngredients.Text;
            string categoryName = cbCategory.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(imageLink) ||
                string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(brandName) ||
                string.IsNullOrWhiteSpace(howtouse) ||
                string.IsNullOrWhiteSpace(ingredients) ||
                string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            UpdateProductByName(name, price, imageLink, description, brandName, howtouse, ingredients, categoryName);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtName.Text = row.Cells["name"].Value?.ToString();
                nudPrice.Text = row.Cells["price"].Value?.ToString();
                txtImage.Text = row.Cells["image_link"].Value?.ToString();
                txtDescription.Text = row.Cells["description"].Value?.ToString();
                cbBrand.Text = row.Cells["brand"].Value?.ToString();
                cbCategory.Text = row.Cells["category"].Value?.ToString();
                cbHowToUse.Text = row.Cells["howtouse"].Value?.ToString();
                cbIngredients.Text = row.Cells["ingredients"].Value?.ToString();
            }
        }
    }
}
