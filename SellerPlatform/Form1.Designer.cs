namespace SellerPlatform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btn_add = new Button();
            orders = new Button();
            btn_change = new Button();
            button4 = new Button();
            btn_delete = new Button();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtImage = new TextBox();
            nudPrice = new NumericUpDown();
            txtDescription = new TextBox();
            cbCategory = new ComboBox();
            cbBrand = new ComboBox();
            txtName = new TextBox();
            label8 = new Label();
            label9 = new Label();
            cbIngredients = new TextBox();
            cbHowToUse = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(193, 34);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // btn_add
            // 
            btn_add.Location = new Point(28, 48);
            btn_add.Margin = new Padding(3, 2, 3, 2);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(82, 22);
            btn_add.TabIndex = 1;
            btn_add.Text = "Add product";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // orders
            // 
            orders.Location = new Point(68, 431);
            orders.Margin = new Padding(3, 2, 3, 2);
            orders.Name = "orders";
            orders.Size = new Size(82, 22);
            orders.TabIndex = 2;
            orders.Text = "Edit orders";
            orders.UseVisualStyleBackColor = true;
            orders.Click += orders_Click;
            // 
            // btn_change
            // 
            btn_change.Location = new Point(28, 74);
            btn_change.Margin = new Padding(3, 2, 3, 2);
            btn_change.Name = "btn_change";
            btn_change.Size = new Size(106, 22);
            btn_change.TabIndex = 3;
            btn_change.Text = "Change product";
            btn_change.UseVisualStyleBackColor = true;
            btn_change.Click += btn_change_Click;
            // 
            // button4
            // 
            button4.Location = new Point(216, 431);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(82, 22);
            button4.TabIndex = 4;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(28, 100);
            btn_delete.Margin = new Padding(3, 2, 3, 2);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(82, 22);
            btn_delete.TabIndex = 6;
            btn_delete.Text = "Delete product";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(539, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(539, 483);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(195, 96);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 8;
            label2.Text = "Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(183, 150);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 9;
            label3.Text = "Image link";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(183, 194);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 10;
            label4.Text = "Description";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(190, 282);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 11;
            label5.Text = "Category";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(195, 238);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 12;
            label6.Text = "Brand";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 8);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 13;
            label7.Text = "label7";
            // 
            // txtImage
            // 
            txtImage.Location = new Point(159, 168);
            txtImage.Name = "txtImage";
            txtImage.Size = new Size(245, 23);
            txtImage.TabIndex = 15;
            // 
            // nudPrice
            // 
            nudPrice.Location = new Point(157, 124);
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(247, 23);
            nudPrice.TabIndex = 16;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(157, 212);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(244, 23);
            txtDescription.TabIndex = 17;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Items.AddRange(new object[] { "Foundation", "Concealer", "Powder", "Blush", "Bronzer", "Contour", "Lipstick", "Lip Liner", "Lip Gloss", "Lip Oil", "Eyeliner", "Eyeshadow Palette", "Mascara", "Eyebrow Pencil" });
            cbCategory.Location = new Point(157, 300);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(246, 23);
            cbCategory.TabIndex = 19;
            // 
            // cbBrand
            // 
            cbBrand.FormattingEnabled = true;
            cbBrand.Items.AddRange(new object[] { "Estée Lauder  ", "Clinique  ", "Guerlain  ", "Maybelline New York  ", "L'Oréal Paris  ", "Lancôme  ", "MAC Cosmetics  ", "NARS  ", "Urban Decay  ", "Benefit Cosmetics  ", "Bobbi Brown  ", "Shiseido  ", "Dior Beauty  ", "Chanel  ", "Charlotte Tilbury  ", "Fenty Beauty  ", "Glossier  ", "Anastasia Beverly Hills  ", "Tarte Cosmetics  ", "Too Faced  ", "Huda Beauty  ", "Pat McGrath Labs  ", "Milk Makeup  ", "Kylie Cosmetics  ", "ColourPop  ", "Revlon  ", "NYX Professional Makeup  ", "Smashbox  ", "BareMinerals  ", "La Mer  ", "Drunk Elephant  ", "The Ordinary  ", "Paula’s Choice  ", "CeraVe  ", "E.l.f. Cosmetics  ", "Josie Maran  ", "Pixi Beauty  ", "Cover FX  ", "IT Cosmetics  ", "Almay  ", "Elizabeth Arden  ", "Lush  ", "Origins  ", "Fresh  ", "Caudalie  ", "Kiehl's  ", "Burt’s Bees  ", "Tatcha  ", "Herbivore Botanicals  ", "Mario Badescu  " });
            cbBrand.Location = new Point(160, 256);
            cbBrand.Name = "cbBrand";
            cbBrand.Size = new Size(245, 23);
            cbBrand.TabIndex = 20;
            // 
            // txtName
            // 
            txtName.Location = new Point(160, 70);
            txtName.Name = "txtName";
            txtName.Size = new Size(244, 23);
            txtName.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(193, 368);
            label8.Name = "label8";
            label8.Size = new Size(66, 15);
            label8.TabIndex = 24;
            label8.Text = "Ingredients";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(190, 324);
            label9.Name = "label9";
            label9.Size = new Size(67, 15);
            label9.TabIndex = 25;
            label9.Text = "How to use";
            // 
            // cbIngredients
            // 
            cbIngredients.Location = new Point(150, 386);
            cbIngredients.Name = "cbIngredients";
            cbIngredients.Size = new Size(256, 23);
            cbIngredients.TabIndex = 27;
            // 
            // cbHowToUse
            // 
            cbHowToUse.Location = new Point(150, 342);
            cbHowToUse.Name = "cbHowToUse";
            cbHowToUse.Size = new Size(255, 23);
            cbHowToUse.TabIndex = 28;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 520);
            Controls.Add(cbHowToUse);
            Controls.Add(cbIngredients);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txtName);
            Controls.Add(cbBrand);
            Controls.Add(cbCategory);
            Controls.Add(txtDescription);
            Controls.Add(nudPrice);
            Controls.Add(txtImage);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(btn_delete);
            Controls.Add(button4);
            Controls.Add(btn_change);
            Controls.Add(orders);
            Controls.Add(btn_add);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_add;
        private Button orders;
        private Button btn_change;
        private Button button4;
        private Button btn_delete;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtImage;
        private NumericUpDown nudPrice;
        private TextBox txtDescription;
        private ComboBox cbCategory;
        private ComboBox cbBrand;
        private TextBox txtName;
        private Label label8;
        private Label label9;
        private TextBox cbIngredients;
        private TextBox cbHowToUse;
    }
}
