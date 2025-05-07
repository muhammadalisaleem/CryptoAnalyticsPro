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
    public partial class TradeHistory : Form
    {
        public TradeHistory()
        {
            InitializeComponent();
            this.Load += AssetMgmt_Load;

        }

        private void AssetMgmt_Load(object sender, EventArgs e)
        {
            LoadAssetData();

        }

        private void LoadAssetData()
        {
            try
            {
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
                using (OleDbConnection con = new OleDbConnection(connStr))
                {
                    string query = "SELECT Symbol, [NameOfAsset], Type, Quantity, PurchasePrice, PurchaseDate FROM tbl_assets";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, con))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading asset data:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashForm = new Dashboard();
            dashForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AssetMgmt assetForm = new AssetMgmt();
            assetForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MarketTrends trendsForm = new MarketTrends();
            trendsForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login loginForm = new Login();
                loginForm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already on this tab.", "Notice");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            TradeRecommendation RecForm = new TradeRecommendation();
            RecForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sentiments SentiForm = new Sentiments();
            SentiForm.Show();
        }
    }
}
