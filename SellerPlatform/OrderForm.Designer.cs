namespace SellerPlatform
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btn_Accept = new Button();
            btn_Decline = new Button();
            btnGoBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(463, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(296, 266);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // btn_Accept
            // 
            btn_Accept.Location = new Point(39, 199);
            btn_Accept.Name = "btn_Accept";
            btn_Accept.Size = new Size(75, 23);
            btn_Accept.TabIndex = 4;
            btn_Accept.Text = "Accept";
            btn_Accept.UseVisualStyleBackColor = true;
            btn_Accept.Click += btn_Accept_Click;
            // 
            // btn_Decline
            // 
            btn_Decline.Location = new Point(210, 199);
            btn_Decline.Name = "btn_Decline";
            btn_Decline.Size = new Size(75, 23);
            btn_Decline.TabIndex = 5;
            btn_Decline.Text = "Decline";
            btn_Decline.UseVisualStyleBackColor = true;
            btn_Decline.Click += btn_Decline_Click;
            // 
            // btnGoBack
            // 
            btnGoBack.Location = new Point(463, 368);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(296, 23);
            btnGoBack.TabIndex = 6;
            btnGoBack.Text = "Go back";
            btnGoBack.UseVisualStyleBackColor = true;
            btnGoBack.Click += btnGoBack_Click;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGoBack);
            Controls.Add(btn_Decline);
            Controls.Add(btn_Accept);
            Controls.Add(dataGridView1);
            Name = "OrderForm";
            Text = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_Accept;
        private Button btn_Decline;
        private Button btnGoBack;
    }
}
