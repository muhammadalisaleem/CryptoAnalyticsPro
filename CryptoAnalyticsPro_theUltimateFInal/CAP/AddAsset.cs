using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAP
{
    public partial class AddAsset : Form
    {
        public AddAsset()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(comboBox1.Text) ||   // Symbol
                string.IsNullOrWhiteSpace(comboBox2.Text) ||   // Name
                string.IsNullOrWhiteSpace(comboBox3.Text) ||  // Type
                string.IsNullOrWhiteSpace(textBox11.Text) ||  // Invested Amount
                string.IsNullOrWhiteSpace(textBox12.Text) ||  // Purchase Price
                string.IsNullOrWhiteSpace(dateTimePicker1.Text))    // Date
            {
                MessageBox.Show("Please fill all fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Convert numeric fields
                double investedAmount, purchasePrice;
                DateTime purchaseDate;

                if (!double.TryParse(textBox11.Text, out investedAmount))
                {
                    MessageBox.Show("Invested Amount must be a number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(textBox12.Text, out purchasePrice) || purchasePrice <= 0)
                {
                    MessageBox.Show("Purchase Price must be a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DateTime.TryParse(dateTimePicker1.Text, out purchaseDate))
                {
                    MessageBox.Show("Invalid date format. Use YYYY-MM-DD format.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calculate quantity
                double quantity = investedAmount / purchasePrice;

                // DB logic
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
                using (OleDbConnection con = new OleDbConnection(connStr))
                {
                    string query = "INSERT INTO tbl_assets ([Symbol], [NameOfAsset], [Type], [Quantity], [PurchasePrice], [PurchaseDate]) " +
                                   "VALUES (?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", comboBox1.Text.Trim());  // Symbol
                        cmd.Parameters.AddWithValue("?", comboBox2.Text.Trim());  // Name
                        cmd.Parameters.AddWithValue("?", comboBox3.Text.Trim()); // Type
                        cmd.Parameters.AddWithValue("?", quantity);              // Calculated Quantity
                        cmd.Parameters.AddWithValue("?", purchasePrice);         // Price per coin
                        cmd.Parameters.AddWithValue("?", purchaseDate);          // Date

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Asset saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving asset: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
