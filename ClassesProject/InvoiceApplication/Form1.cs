using InvoiceApplication.BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace InvoiceApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            var path = pathTextBox.Text;
            
            try
            {
                var wholeText = File.ReadAllText(path);

                wholeText = wholeText.Replace(";", "\t");

                resultTextBox.Text = wholeText;
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred. Sorry");
            }
        }

        private void categoryButton_Click(object sender, EventArgs e)
        {
            var path = pathTextBox.Text;
            var lines = File.ReadAllLines(path);

            var processor = new InvoiceProcessor();

            var entries = processor.GroupByCategories(lines);

            resultTextBox.Clear();
            resultTextBox.Text += "Category\tAmount\r\n";

            foreach (var item in entries)
            {
                resultTextBox.Text += $"{item.Category}\t{item.Amount}{Environment.NewLine}";
            }

        }
    }
}
