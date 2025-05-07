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
using System.Net.Http;
using System.Threading.Tasks;

namespace CAP
{
    public partial class Sentiments : Form
    {
        public Sentiments()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already on this tab.", "Notice");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            TradeRecommendation RecForm = new TradeRecommendation();
            RecForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private async void button8_Click(object sender, EventArgs e)
        {
            label1.Text = "Loading sentiment...";
            label1.Text = await Sentiments.GetCryptoSentimentAsync();
        }

        public static async Task<string> GetCryptoSentimentAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://api.alternative.me/fng/";
                    string response = await client.GetStringAsync(url);
                    JObject json = JObject.Parse(response);

                    string value = json["data"]?[0]?["value"]?.ToString();
                    string classification = json["data"]?[0]?["value_classification"]?.ToString();
                    string timestampStr = json["data"]?[0]?["timestamp"]?.ToString();

                    DateTime timestamp = DateTimeOffset.FromUnixTimeSeconds(long.Parse(timestampStr)).DateTime;

                    string explanation = classification switch
                    {
                        "Extreme Fear" => "Market is very fearful. Could be a buying opportunity.",
                        "Fear" => "Market shows fear. Investors may be cautious.",
                        "Neutral" => "Market is balanced. No strong momentum.",
                        "Greed" => "Market shows greed. Be cautious of bubbles.",
                        "Extreme Greed" => "Market is overheated. Consider taking profits.",
                        _ => "Sentiment classification unknown."
                    };

                    return $"📊 Sentiment: {classification} ({value}/100)\n \n🕒 Last Updated: {timestamp}\n \n💡 Insight: {explanation}";
                }
            }
            catch
            {
                return "⚠️ Unable to load sentiment data. Please try again.";
            }
        }

        private void Sentiments_Load(object sender, EventArgs e)
        {

        }
    }

}


