using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace CAP
{
    public partial class TradeRecommendation : Form
    {
        public TradeRecommendation()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }





        public class TradeAI
        {
            public static async Task<string> GetRecommendation(string coinId)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string url = $"https://api.coingecko.com/api/v3/coins/{coinId}/market_chart?vs_currency=usd&days=7";
                        var response = await client.GetStringAsync(url);
                        JObject json = JObject.Parse(response);

                        var priceTokens = json["prices"];
                        if (priceTokens == null || priceTokens.Count() < 51)
                            return "Insufficient data received from API.";

                        var prices = priceTokens.Select(p => (decimal)p[1]).ToList();

                        decimal currentPrice = prices.Last();
                        decimal ma50 = prices.Skip(prices.Count - 50).Average();

                        int n = prices.Count;
                        decimal gains = 0, losses = 0;

                        for (int i = n - 15; i < n - 1; i++)
                        {
                            decimal change = prices[i + 1] - prices[i];
                            if (change > 0) gains += change;
                            else losses -= change;
                        }

                        decimal rs = gains / (losses == 0 ? 1 : losses);
                        decimal rsi = 100 - (100 / (1 + rs));

                        int score = 0;
                        if (currentPrice > ma50) score += 40;
                        if (rsi < 30) score += 30;
                        else if (rsi > 70) score -= 30;

                        string signal;
                        if (score >= 80) signal = "Strong Buy";
                        else if (score >= 60) signal = "Buy";
                        else if (score >= 40) signal = "Hold";
                        else if (score >= 20) signal = "Sell";
                        else signal = "Strong Sell";

                        return $"{coinId.ToUpper()}:\nPrice: ${currentPrice:F2} \nMA50: ${ma50:F2} \nRSI: {rsi:F2} \n\n→ {signal}";
                    }
                }
                catch (HttpRequestException ex)
                {
                    return "Network error: Unable to connect to API.";
                }

                catch (Exception ex)
                {
                    return $"Unexpected error: {ex.Message}";
                }
            }
        }


        private async void button7_Click(object sender, EventArgs e)
        {

            try
            {
                string selectedCoin = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrWhiteSpace(selectedCoin))
                {
                    label1.Text = "Please select a coin.";
                    return;
                }

                label1.Text = "Fetching recommendation...";
                string result = await TradeAI.GetRecommendation(selectedCoin);
                label1.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sentiments SentiForm = new Sentiments();
            SentiForm.Show();
        }
    }
}

