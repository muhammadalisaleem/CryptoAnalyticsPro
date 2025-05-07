using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CAP
{
    public partial class Signup : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb");
        OleDbCommand cmd;

        public Signup()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox8.Text.Trim();
            string username = textBox9.Text.Trim();
            string password = textBox10.Text.Trim();
            string confirmPassword = textBox11.Text.Trim();

            if (username == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                con.Open();


                string checkQuery = "SELECT COUNT(*) FROM tbl_users WHERE username = ?";
                cmd = new OleDbCommand(checkQuery, con);
                cmd.Parameters.AddWithValue("?", username);
                int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (userCount > 0)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string insertQuery = "INSERT INTO tbl_users ([name], [username], [password]) VALUES (?, ?, ?)";
                cmd = new OleDbCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("?", name);
                cmd.Parameters.AddWithValue("?", username);
                cmd.Parameters.AddWithValue("?", password);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Registration Successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();  // create a new instance of your Login form
            loginForm.Show();               // show the login form
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox10.PasswordChar == '•' && textBox11.PasswordChar == '•')
            {
                textBox10.PasswordChar = '\0'; // Show password
                textBox11.PasswordChar = '\0'; 
                button3.Text = "Hide Password";
            }
            else
            {
                textBox10.PasswordChar = '•';  // Hide password
                textBox11.PasswordChar = '•';
                button3.Text = "Show Password";
            }
        }
    }
}
