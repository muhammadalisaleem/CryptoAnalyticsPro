namespace CAP
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel1 = new Panel();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            textBox2 = new TextBox();
            panel3 = new Panel();
            label5 = new Label();
            label1 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            panel4 = new Panel();
            label2 = new Label();
            textBox4 = new TextBox();
            panel5 = new Panel();
            label3 = new Label();
            textBox5 = new TextBox();
            panel6 = new Panel();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            textBox6 = new TextBox();
            panel7 = new Panel();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            textBox7 = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 35, 35);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-15, -6);
            panel1.Name = "panel1";
            panel1.Size = new Size(183, 458);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint_1;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(20, 20, 20);
            button7.Cursor = Cursors.Hand;
            button7.FlatStyle = FlatStyle.Popup;
            button7.ForeColor = SystemColors.Control;
            button7.Location = new Point(27, 352);
            button7.Name = "button7";
            button7.Size = new Size(137, 36);
            button7.TabIndex = 9;
            button7.Text = "Sentiment Indicator";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(20, 20, 20);
            button6.Cursor = Cursors.Hand;
            button6.FlatStyle = FlatStyle.Popup;
            button6.ForeColor = SystemColors.Control;
            button6.Location = new Point(27, 307);
            button6.Name = "button6";
            button6.Size = new Size(137, 36);
            button6.TabIndex = 8;
            button6.Text = "Recommend Trade";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
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
            button4.Location = new Point(27, 263);
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
            button3.Location = new Point(27, 218);
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
            button1.Location = new Point(27, 128);
            button1.Name = "button1";
            button1.Size = new Size(137, 36);
            button1.TabIndex = 2;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(35, 35, 35);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Font = new Font("Agency FB", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.Control;
            textBox1.Location = new Point(36, 87);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(111, 20);
            textBox1.TabIndex = 2;
            textBox1.Text = "Crypto Analytics Pro";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(20, 20, 20);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(27, 174);
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
            panel2.Location = new Point(164, -3);
            panel2.Name = "panel2";
            panel2.Size = new Size(645, 35);
            panel2.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(50, 50, 50);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Enabled = false;
            textBox2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.ForeColor = SystemColors.Menu;
            textBox2.Location = new Point(192, 38);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(164, 32);
            textBox2.TabIndex = 2;
            textBox2.Text = "Dashboard";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(35, 35, 35);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(textBox3);
            panel3.Location = new Point(192, 90);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 92);
            panel3.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(7, 71);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 9;
            label5.Text = "label5";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(45, 32);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(116, 71);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 8;
            label4.Text = "label4";
            label4.Click += label4_Click;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(35, 35, 35);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Enabled = false;
            textBox3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.ForeColor = SystemColors.Control;
            textBox3.Location = new Point(13, 8);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(169, 22);
            textBox3.TabIndex = 0;
            textBox3.Text = "Total Portfolio Value";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(35, 35, 35);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(textBox4);
            panel4.Location = new Point(418, 90);
            panel4.Name = "panel4";
            panel4.Size = new Size(182, 92);
            panel4.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(31, 39);
            label2.Name = "label2";
            label2.Size = new Size(80, 32);
            label2.TabIndex = 1;
            label2.Text = "label2";
            label2.Click += label2_Click;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(35, 35, 35);
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox4.ForeColor = SystemColors.Control;
            textBox4.Location = new Point(10, 8);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(114, 22);
            textBox4.TabIndex = 0;
            textBox4.Text = "Profit / Loss";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(35, 35, 35);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(textBox5);
            panel5.Location = new Point(606, 90);
            panel5.Name = "panel5";
            panel5.Size = new Size(182, 92);
            panel5.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(28, 39);
            label3.Name = "label3";
            label3.Size = new Size(80, 32);
            label3.TabIndex = 1;
            label3.Text = "label3";
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(35, 35, 35);
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Enabled = false;
            textBox5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox5.ForeColor = SystemColors.Control;
            textBox5.Location = new Point(8, 8);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(171, 22);
            textBox5.TabIndex = 0;
            textBox5.Text = "Total Assets Purchased";
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(35, 35, 35);
            panel6.Controls.Add(chart2);
            panel6.Controls.Add(textBox6);
            panel6.Location = new Point(192, 200);
            panel6.Name = "panel6";
            panel6.Size = new Size(369, 238);
            panel6.TabIndex = 6;
            // 
            // chart2
            // 
            chart2.BorderlineColor = Color.FromArgb(35, 35, 35);
            chartArea1.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart2.Legends.Add(legend1);
            chart2.Location = new Point(7, 38);
            chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart2.Series.Add(series1);
            chart2.Size = new Size(350, 183);
            chart2.TabIndex = 1;
            chart2.Text = "chart2";
            chart2.Click += chart2_Click;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(35, 35, 35);
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Enabled = false;
            textBox6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox6.ForeColor = SystemColors.Control;
            textBox6.Location = new Point(7, 10);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(175, 22);
            textBox6.TabIndex = 0;
            textBox6.Text = "Portfolio Performance";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(35, 35, 35);
            panel7.Controls.Add(chart1);
            panel7.Controls.Add(textBox7);
            panel7.Location = new Point(567, 200);
            panel7.Name = "panel7";
            panel7.Size = new Size(221, 238);
            panel7.TabIndex = 7;
            // 
            // chart1
            // 
            chart1.BackColor = Color.FromArgb(35, 35, 35);
            chart1.BorderlineColor = Color.FromArgb(35, 35, 35);
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(-12, 31);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(334, 197);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click;
            // 
            // textBox7
            // 
            textBox7.BackColor = Color.FromArgb(35, 35, 35);
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Enabled = false;
            textBox7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox7.ForeColor = SystemColors.Control;
            textBox7.Location = new Point(5, 10);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(132, 22);
            textBox7.TabIndex = 0;
            textBox7.Text = "Asset Allocation";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(800, 450);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(textBox2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button5;
        private TextBox textBox2;
        private Panel panel3;
        private Panel panel4;
        private TextBox textBox3;
        private TextBox textBox4;
        private Panel panel5;
        private TextBox textBox5;
        private Panel panel6;
        private TextBox textBox6;
        private Panel panel7;
        private TextBox textBox7;
        private Label label1;
        private Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Label label3;
        private Button button6;
        private Button button7;
        private Label label4;
        private Label label5;
    }
}
