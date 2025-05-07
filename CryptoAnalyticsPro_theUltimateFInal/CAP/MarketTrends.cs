using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAP
{
    public partial class MarketTrends : Form
    {
        public MarketTrends()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already on this tab.", "Notice");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AssetMgmt assetForm = new AssetMgmt();
            assetForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TradeHistory tradeForm = new TradeHistory();
            tradeForm.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashForm = new Dashboard();
            dashForm.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void MarketTrends_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT CoinName FROM CryptoPrices";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["CoinName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading coins: " + ex.Message);
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string coin = comboBox1.SelectedItem.ToString();
                decimal entryPrice = decimal.Parse(textBox3.Text);
                decimal stopLossPct = decimal.Parse(textBox9.Text);
                decimal takeProfitPct = decimal.Parse(textBox11.Text);
                decimal investment = decimal.Parse(textBox12.Text);



                // Stop-loss and Take-profit Price
                decimal stopLossPrice = entryPrice - (entryPrice * stopLossPct / 100);
                decimal takeProfitPrice = entryPrice + (entryPrice * takeProfitPct / 100);

                // Quantity purchased
                decimal quantity = investment / entryPrice;

                // Potential P&L
                decimal potentialLoss = (entryPrice - stopLossPrice) * quantity;
                decimal potentialProfit = (takeProfitPrice - entryPrice) * quantity;

                string riskReward = potentialLoss > 0
                    ? $"{(potentialProfit / potentialLoss):0.00} : 1"
                    : "N/A";

                // Show results
                label1.Text = $"Stop-Loss Price: ${stopLossPrice:F2}";
                label2.Text = $"Take-Profit Price: ${takeProfitPrice:F2}";
                label3.Text = $"Potential Loss: ${potentialLoss:F2}";
                label4.Text = $"Potential Profit: ${potentialProfit:F2}";
                label6.Text = $"Risk/Reward Ratio: {riskReward}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            string coinNameInput = textBox15.Text.Trim().ToLower();
            decimal targetPrice = numericUpDown1.Value;
            string condition = comboBox2.SelectedItem.ToString(); // "Above" or "Below"

            if (string.IsNullOrEmpty(coinNameInput) || targetPrice <= 0 || string.IsNullOrEmpty(condition))
            {
                MessageBox.Show("Please fill all fields correctly.");
                return;
            }

            try
            {
                // Map full name to CoinGecko ID
                Dictionary<string, string> coinMap = new Dictionary<string, string>
        {
            { "bitcoin", "bitcoin" },
            { "ethereum", "ethereum" },
            { "tether", "tether" },
            { "pepe", "pepe" },
            { "ethena", "ethena" },
            { "solana", "solana" },
            { "tron", "tron" },
            { "dogecoin", "dogecoin" },
            { "cardano", "cardano" },
            { "litecoin", "litecoin" }
        };

                if (!coinMap.ContainsKey(coinNameInput))
                {
                    MessageBox.Show("Coin not supported. Try another.");
                    return;
                }

                string coinId = coinMap[coinNameInput];
                string url = $"https://api.coingecko.com/api/v3/simple/price?ids={coinId}&vs_currencies=usd";

                using (HttpClient client = new HttpClient())
                {
                    string result = await client.GetStringAsync(url);
                    JObject data = JObject.Parse(result);
                    decimal currentPrice = data[coinId]["usd"].Value<decimal>();

                    bool alertTriggered = (condition == "Above" && currentPrice > targetPrice)
                                       || (condition == "Below" && currentPrice < targetPrice);

                    if (alertTriggered)
                    {
                        MessageBox.Show($"⚠ Alert!\n{coinNameInput.ToUpper()} is {condition} your target of {targetPrice:C}.\nCurrent Price: {currentPrice:C}", "Price Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"{coinNameInput.ToUpper()} is NOT {condition} {targetPrice:C} yet.\nCurrent Price: {currentPrice:C}", "No Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking price:\n" + ex.Message);
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedCoin = comboBox1.SelectedItem.ToString();
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";

                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 PriceUSD FROM CryptoPrices WHERE CoinName = ? ORDER BY ID DESC";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", selectedCoin);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            decimal price = Convert.ToDecimal(result);
                            label5.Text = $"Current Price: ${price:F2}";
                            label5.Tag = price; // Store in Tag for reuse
                        }
                        else
                        {
                            label5.Text = "Current Price: N/A";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching current price: " + ex.Message);
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            TradeRecommendation RecForm = new TradeRecommendation();
            RecForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sentiments SentiForm = new Sentiments();
            SentiForm.Show();
        }
    }
}
