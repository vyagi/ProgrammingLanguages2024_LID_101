using System.Net;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var handler = new HttpClientHandler();

            handler.ClientCertificateOptions = ClientCertificateOption.Manual;

            handler.ServerCertificateCustomValidationCallback +=
                (_, _, _, _) => true;

            var client = new HttpClient(handler);

            //Don't ever call Result if you don't have a task which is completed
            //var result = client.GetStringAsync(textBox1.Text).Result;
            
            var result = await client.GetStringAsync(textBox1.Text);

            textBox2.Text = result;

            //Don't write shit like this (it's synchronous
            //so it block the UI thread

            //ServicePointManager
            //    .ServerCertificateValidationCallback +=
            //    (_, _, _, _) => true;

            //var webClient = new WebClient(); //Don't use this class ever

            //var result = webClient.DownloadString(textBox1.Text);

            //textBox2.Text = result;
        }
    }
}