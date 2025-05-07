namespace CAP
{
    partial class AssetMgmt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetMgmt));
            textBox1 = new TextBox();
            panel1 = new Panel();
            button11 = new Button();
            button10 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            textBox2 = new TextBox();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            textBox3 = new TextBox();
            button7 = new Button();
            button8 = new Button();
            button6 = new Button();
            dataGridViewAssets = new DataGridView();
            dataGridView2 = new DataGridView();
            textBox9 = new TextBox();
            textBox4 = new TextBox();
            button9 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(50, 50, 50);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.Control;
            textBox1.Location = new Point(203, 23);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(275, 32);
            textBox1.TabIndex = 0;
            textBox1.Text = "Asset Management";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 35, 35);
            panel1.Controls.Add(button11);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(183, 458);
            panel1.TabIndex = 1;
            // 
            // button11
            // 
            button11.BackColor = Color.FromArgb(20, 20, 20);
            button11.Cursor = Cursors.Hand;
            button11.FlatStyle = FlatStyle.Popup;
            button11.ForeColor = SystemColors.Control;
            button11.Location = new Point(27, 358);
            button11.Name = "button11";
            button11.Size = new Size(137, 36);
            button11.TabIndex = 10;
            button11.Text = "Sentiment Indicator";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(20, 20, 20);
            button10.Cursor = Cursors.Hand;
            button10.FlatStyle = FlatStyle.Popup;
            button10.ForeColor = SystemColors.Control;
            button10.Location = new Point(27, 312);
            button10.Name = "button10";
            button10.Size = new Size(137, 36);
            button10.TabIndex = 10;
            button10.Text = "Recommend Trade";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Teal;
            button5.Cursor = Cursors.Hand;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.ControlText;
            button5.Location = new Point(53, 421);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 2;
            button5.Text = "Signout";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(20, 20, 20);
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Popup;
            button4.ForeColor = SystemColors.Control;
            button4.Location = new Point(27, 267);
            button4.Name = "button4";
            button4.Size = new Size(137, 36);
            button4.TabIndex = 2;
            button4.Text = "Market Trends";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(20, 20, 20);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.ForeColor = SystemColors.Control;
            button3.Location = new Point(27, 222);
            button3.Name = "button3";
            button3.Size = new Size(137, 36);
            button3.TabIndex = 2;
            button3.Text = "Trade History";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(20, 20, 20);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(27, 133);
            button1.Name = "button1";
            button1.Size = new Size(137, 36);
            button1.TabIndex = 2;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(35, 35, 35);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Enabled = false;
            textBox2.Font = new Font("Agency FB", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.ForeColor = SystemColors.Control;
            textBox2.Location = new Point(36, 87);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(111, 20);
            textBox2.TabIndex = 2;
            textBox2.Text = "Crypto Analytics Pro";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(20, 20, 20);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(27, 178);
            button2.Name = "button2";
            button2.Size = new Size(137, 36);
            button2.TabIndex = 2;
            button2.Text = "Asset Management";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(41, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 82);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(35, 35, 35);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(button7);
            panel2.Location = new Point(203, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(585, 61);
            panel2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(35, 35, 35);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Enabled = false;
            textBox3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic);
            textBox3.ForeColor = SystemColors.Control;
            textBox3.Location = new Point(13, 14);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(281, 33);
            textBox3.TabIndex = 3;
            textBox3.Text = "Portfolio Holdings";
            // 
            // button7
            // 
            button7.BackColor = Color.SlateBlue;
            button7.Cursor = Cursors.Hand;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Microsoft Sans Serif", 8.25F);
            button7.ForeColor = SystemColors.Control;
            button7.Location = new Point(451, 15);
            button7.Name = "button7";
            button7.Size = new Size(122, 23);
            button7.TabIndex = 6;
            button7.Text = "Update Live Prices";
            button7.TextAlign = ContentAlignment.BottomCenter;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.DarkRed;
            button8.Cursor = Cursors.Hand;
            button8.FlatStyle = FlatStyle.Popup;
            button8.Font = new Font("Agency FB", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = SystemColors.Control;
            button8.Location = new Point(432, 147);
            button8.Name = "button8";
            button8.Size = new Size(174, 88);
            button8.TabIndex = 4;
            button8.Text = "- Remove Assets";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.MidnightBlue;
            button6.Cursor = Cursors.Hand;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Agency FB", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.Control;
            button6.Location = new Point(216, 147);
            button6.Name = "button6";
            button6.Size = new Size(174, 88);
            button6.TabIndex = 3;
            button6.Text = "+ Add Assets";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // dataGridViewAssets
            // 
            dataGridViewAssets.BackgroundColor = Color.FromArgb(35, 35, 35);
            dataGridViewAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAssets.Location = new Point(203, 272);
            dataGridViewAssets.Margin = new Padding(3, 2, 3, 2);
            dataGridViewAssets.Name = "dataGridViewAssets";
            dataGridViewAssets.RowHeadersWidth = 51;
            dataGridViewAssets.Size = new Size(421, 167);
            dataGridViewAssets.TabIndex = 0;
            dataGridViewAssets.CellContentClick += dataGridViewAssets_CellContentClick;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.BackgroundColor = Color.FromArgb(35, 35, 35);
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(640, 171);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(136, 270);
            dataGridView2.TabIndex = 5;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // textBox9
            // 
            textBox9.BackColor = Color.FromArgb(50, 50, 50);
            textBox9.BorderStyle = BorderStyle.None;
            textBox9.Enabled = false;
            textBox9.Font = new Font("Agency FB", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox9.ForeColor = SystemColors.Control;
            textBox9.Location = new Point(661, 147);
            textBox9.Name = "textBox9";
            textBox9.ReadOnly = true;
            textBox9.Size = new Size(98, 18);
            textBox9.TabIndex = 7;
            textBox9.Text = "Live Market Prices";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(50, 50, 50);
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.Font = new Font("Agency FB", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox4.ForeColor = SystemColors.Control;
            textBox4.Location = new Point(203, 249);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(98, 18);
            textBox4.TabIndex = 8;
            textBox4.Text = "Assets";
            // 
            // button9
            // 
            button9.BackColor = SystemColors.MenuHighlight;
            button9.Cursor = Cursors.Hand;
            button9.FlatStyle = FlatStyle.Popup;
            button9.ForeColor = SystemColors.Control;
            button9.Location = new Point(679, 27);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 9;
            button9.Text = "Refresh";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // AssetMgmt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(800, 450);
            Controls.Add(button9);
            Controls.Add(textBox4);
            Controls.Add(button8);
            Controls.Add(textBox9);
            Controls.Add(button6);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridViewAssets);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AssetMgmt";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Panel panel1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button1;
        private TextBox textBox2;
        private Button button2;
        private PictureBox pictureBox1;
        private Panel panel2;
        private TextBox textBox3;
        private Button button6;
        private DataGridView dataGridViewAssets;
        private DataGridView dataGridView2;
        private Button button7;
        private Button button8;
        private TextBox textBox9;
        private TextBox textBox4;
        private Button button9;
        private Button button10;
        private Button button11;
    }
}