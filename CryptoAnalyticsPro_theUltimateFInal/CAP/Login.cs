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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb");
        OleDbCommand cmd;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Enter Username and Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                con.Open();
                string query = "SELECT * FROM tbl_users WHERE username=? AND password=?";
                cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("?", textBox5.Text); // Username
                cmd.Parameters.AddWithValue("?", textBox6.Text); // Password

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Dashboard().Show(); // Make sure Dashboard form exists
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Signup signUp = new Signup();
            signUp.Show();
            this.Hide(); // optionally hide login form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox6.PasswordChar == '•')
            {
                textBox6.PasswordChar = '\0'; // Show password
                button4.Text = "Hide Password";
            }
            else
            {
                textBox6.PasswordChar = '•';  // Hide password
                button4.Text = "Show Password";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
