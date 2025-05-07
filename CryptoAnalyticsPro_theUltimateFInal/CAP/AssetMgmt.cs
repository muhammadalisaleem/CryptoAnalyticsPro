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
using System.Net.Http;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace CAP
{
    public partial class AssetMgmt : Form
    {
        public AssetMgmt()
        {
            InitializeComponent();
            this.Load += AssetMgmt_Load;
            this.Load += LoadCurrPrices;
        }

        private void AssetMgmt_Load(object sender, EventArgs e)
        {
            LoadAssetData();
        }

        private void LoadCurrPrices(object sender, EventArgs e)
        {
            LoadLiveMarketPrices();
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
                        dataGridViewAssets.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading asset data:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLiveMarketPrices()
        {
            try
            {
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
                using (OleDbConnection con = new OleDbConnection(connStr))
                {
                    string query = "SELECT CoinName, PriceUSD FROM CryptoPrices";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, con))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView2.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading asset data:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new Login().Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TradeHistory().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MarketTrends().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddAsset panelAddAsset = new AddAsset
            {
                Visible = true
            };
            panelAddAsset.BringToFront();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private async void button7_Click(object sender, EventArgs e)
        {
            string apiUrl = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum,tether,pepe,ethena,solana,tron,dogecoin,cardano,litecoin&vs_currencies=usd";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string result = await client.GetStringAsync(apiUrl);
                    JObject data = JObject.Parse(result);

                    var prices = new List<(string CoinName, decimal PriceUSD)>
            {
                ("Bitcoin", data["bitcoin"]?["usd"]?.Value<decimal>() ?? 0),
                ("Ethereum", data["ethereum"]?["usd"]?.Value<decimal>() ?? 0),
                ("Tether", data["tether"]?["usd"]?.Value<decimal>() ?? 0),
                ("Pepe", data["pepe"]?["usd"]?.Value<decimal>() ?? 0),
                ("Ethena", data["ethena"]?["usd"]?.Value<decimal>() ?? 0),
                ("Solana", data["solana"]?["usd"]?.Value<decimal>() ?? 0),
                ("Tron", data["tron"]?["usd"]?.Value<decimal>() ?? 0),
                ("Dogecoin", data["dogecoin"]?["usd"]?.Value<decimal>() ?? 0),
                ("Cardano", data["cardano"]?["usd"]?.Value<decimal>() ?? 0),
                ("Litecoin", data["litecoin"]?["usd"]?.Value<decimal>() ?? 0)
            };

                    string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb;";
                    using (OleDbConnection conn = new OleDbConnection(connStr))
                    {
                        conn.Open();

                        // Check existing row count
                        int rowCount = 0;
                        using (OleDbCommand countCmd = new OleDbCommand("SELECT COUNT(*) FROM CryptoPrices", conn))
                        {
                            rowCount = (int)countCmd.ExecuteScalar();
                        }

                        if (rowCount >= 10)
                        {
                            // UPDATE first 10 rows (assuming there's an AutoNumber ID column)
                            for (int i = 0; i < 10; i++)
                            {
                                string updateQuery = "UPDATE CryptoPrices SET CoinName = ?, PriceUSD = ? WHERE ID = ?";
                                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("?", prices[i].CoinName);
                                    cmd.Parameters.AddWithValue("?", prices[i].PriceUSD);
                                    cmd.Parameters.AddWithValue("?", i + 1); // Assuming IDs are 1 to 10
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // DELETE all and insert fresh 10
                            using (OleDbCommand deleteCmd = new OleDbCommand("DELETE FROM CryptoPrices", conn))
                            {
                                deleteCmd.ExecuteNonQuery();
                            }

                            string insertQuery = "INSERT INTO CryptoPrices (CoinName, PriceUSD) VALUES (?, ?)";
                            foreach (var item in prices)
                            {
                                using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("?", item.CoinName);
                                    cmd.Parameters.AddWithValue("?", item.PriceUSD);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        MessageBox.Show("Crypto prices updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching or saving crypto prices:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewAssets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string inputSymbol = Microsoft.VisualBasic.Interaction.InputBox(
        "Enter the symbol of the asset you want to delete:",
        "Delete Asset",
        ""
    );

            if (!string.IsNullOrWhiteSpace(inputSymbol))
            {
                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to delete the asset with symbol '{inputSymbol}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
                        using (OleDbConnection con = new OleDbConnection(connStr))
                        {
                            con.Open();
                            string query = "DELETE FROM tbl_assets WHERE Symbol = ?";
                            using (OleDbCommand cmd = new OleDbCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("?", inputSymbol);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Asset deleted successfully.");
                                    LoadAssetData(); // Refresh the table
                                }
                                else
                                {
                                    MessageBox.Show("No asset found with the given symbol.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting asset: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Deletion cancelled or no symbol entered.");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadAssetData();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            TradeRecommendation RecForm = new TradeRecommendation();
            RecForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sentiments SentiForm = new Sentiments();
            SentiForm.Show();
        }
    }
}

