using System.Data.OleDb;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CAP
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already on Dashboard.", "Notice");
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MarketTrends trendsForm = new MarketTrends();
            trendsForm.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            await Task.Delay(100); // small delay to ensure form load
            ShowPortfolioPurchaseValue();
            ShowProfitLoss();
            LoadTotalAssets();
            LoadHoldingsChart();
            LoadProfitLossChart();
        }


        private async void ShowPortfolioPurchaseValue()
        {
            try
            {
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
                decimal totalValue = 0;

                using (OleDbConnection con = new OleDbConnection(connStr))
                {
                    con.Open();
                    string query = "SELECT Quantity, PurchasePrice FROM tbl_assets";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal quantity = Convert.ToDecimal(reader["Quantity"]);
                            decimal purchasePrice = Convert.ToDecimal(reader["PurchasePrice"]);
                            totalValue += quantity * purchasePrice;
                        }
                    }
                }

                label1.Text = $"${totalValue:N2}";

                // Convert to EUR and PKR
                var rates = await FetchExchangeRatesAsync();
                if (rates != null)
                {
                    decimal eur = totalValue * rates["EUR"];
                    decimal pkr = totalValue * rates["PKR"];

                    label4.Text = $"EUR: €{eur:N2}";
                    label5.Text = $"PKR: Rs{pkr:N2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading portfolio value:\n" + ex.Message);
            }
        }

        private void ShowProfitLoss()
        {
            try
            {
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
                decimal totalProfitLoss = 0;

                using (OleDbConnection con = new OleDbConnection(connStr))
                {
                    con.Open();
                    string query = @"
                SELECT a.Symbol, a.Quantity, a.PurchasePrice, c.PriceUSD 
                FROM tbl_assets a 
                INNER JOIN CryptoPrices c ON a.Symbol = c.CoinName";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal quantity = Convert.ToDecimal(reader["Quantity"]);
                            decimal purchasePrice = Convert.ToDecimal(reader["PurchasePrice"]);
                            decimal currentPrice = Convert.ToDecimal(reader["PriceUSD"]);

                            decimal profitLoss = (currentPrice - purchasePrice) * quantity;
                            totalProfitLoss += profitLoss;
                        }
                    }
                }

                string formatted = totalProfitLoss >= 0 ? $"+${totalProfitLoss:N2}" : $"-${Math.Abs(totalProfitLoss):N2}";
                label2.Text = formatted;
                label2.ForeColor = totalProfitLoss >= 0 ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating profit/loss:\n" + ex.Message);
            }
        }

        private void LoadTotalAssets()
        {
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
            using (OleDbConnection con = new OleDbConnection(connStr))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM tbl_assets";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    int totalAssets = Convert.ToInt32(cmd.ExecuteScalar());
                    label3.Text = " " + totalAssets;
                }
            }
        }

        private decimal GetCurrentPrice(string symbol)
        {
            string nameMap = symbol.ToUpper() switch
            {
                "BTC" => "Bitcoin",
                "ETH" => "Ethereum",
                "USDT" => "Tether",
                "PEPE" => "PEPE",
                "ENA" => "ETHENA",
                "SOL" => "Solana",
                "TRX" => "Tron",
                "DOGE" => "Dogecoin",
                "ADA" => "Cardano",
                "LTC" => "Litecoin",
                _ => null
            };

            if (nameMap == null) return 0;

            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
            using (OleDbConnection con = new OleDbConnection(connStr))
            {
                con.Open();
                string query = "SELECT TOP 1 PriceUSD FROM CryptoPrices WHERE CoinName = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", nameMap);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        private void LoadHoldingsChart()
        {
            try
            {
                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.Titles.Add("Portfolio Holdings");

                var series = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "Coins",
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
                };

                chart1.Series.Add(series);

                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
                using (OleDbConnection con = new OleDbConnection(connStr))
                {
                    con.Open();
                    string query = "SELECT Symbol, SUM(Quantity * PurchasePrice) AS TotalInvestment FROM tbl_assets GROUP BY Symbol";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string symbol = reader["Symbol"].ToString();
                            decimal value = Convert.ToDecimal(reader["TotalInvestment"]);
                            series.Points.AddXY(symbol, value);
                        }
                    }
                }

                chart1.Legends[0].Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading holdings chart:\n" + ex.Message);
            }
        }

        private void LoadProfitLossChart()
        {
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.Titles.Clear();
            chart2.Titles.Add("Profit & Loss Per Asset");

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "Assets";
            chartArea.AxisY.Title = "Profit / Loss (USD)";
            chart2.ChartAreas.Add(chartArea);

            Series pnlSeries = new Series("Profit/Loss");
            pnlSeries.ChartType = SeriesChartType.Column;
            pnlSeries.BorderWidth = 2;
            pnlSeries.Color = Color.Blue;

            decimal totalPnL = 0;

            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db_users.mdb";
            using (OleDbConnection con = new OleDbConnection(connStr))
            {
                con.Open();
                string query = "SELECT Symbol, Quantity, PurchasePrice FROM tbl_assets";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string symbol = reader["Symbol"].ToString();
                        decimal quantity = Convert.ToDecimal(reader["Quantity"]);
                        decimal purchasePrice = Convert.ToDecimal(reader["PurchasePrice"]);

                        decimal currentPrice = GetCurrentPrice(symbol);
                        if (currentPrice == 0)
                            continue;

                        decimal pnl = (currentPrice - purchasePrice) * quantity;
                        totalPnL += pnl;

                        pnlSeries.Points.AddXY(symbol, pnl);
                    }
                }
            }

            chart2.Series.Add(pnlSeries);
            chart2.Invalidate();

            // ✅ Update label with total PnL
            label2.Text = $"{totalPnL:C}"; // e.g., "$123.45"
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
        private async Task<Dictionary<string, decimal>> FetchExchangeRatesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://api.exchangerate-api.com/v4/latest/USD";
                    string response = await client.GetStringAsync(url);
                    var data = JsonSerializer.Deserialize<ExchangeRateResponse>(response);
                    return data.rates;
                }
            }
            catch
            {
                MessageBox.Show("Failed to fetch exchange rates.");
                return null;
            }
        }
        public class ExchangeRateResponse
        {
            public Dictionary<string, decimal> rates { get; set; }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}



