using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace MegaDesk_McBreairty
{
    public partial class AddQuote : Form
    {
        Form _mainMenu;
        public AddQuote()
        {
            InitializeComponent();

            // this code will make a list of materials from the Enum SurfaceMaterial, then Cast it to the list
            // then use DataSource to populate the dropdown 

            List<SurfaceMaterial> materials = Enum.GetValues(typeof(SurfaceMaterial)).Cast<SurfaceMaterial>().ToList();

            comboBoxMaterial.DataSource = materials;

            // same but for ShippingPrices

            List<Shipping> shippingValues = Enum.GetValues(typeof(Shipping)).Cast<Shipping>().ToList();

            comboBoxShipping.DataSource = shippingValues;

        }

        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainMenu = (MainMenu)this.Tag;
            mainMenu.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void AddQuoteToFile(DeskQuote deskQuote)
        {
            var quotesFile = @"quotes.json";
            List<DeskQuote> deskQuotes = new List<DeskQuote>();

            if (File.Exists(quotesFile))
            {
                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    string quotes = reader.ReadToEnd();

                    if (quotes.Length > 0)
                    {
                        deskQuotes = System.Text.Json.JsonSerializer.Deserialize<List<DeskQuote>>(quotes);
                    }
                }
            }
            deskQuotes.Add(deskQuote);

            SaveQuotes(deskQuotes);
        }
     

        private void SaveQuotes(List<DeskQuote> quotes)
        {
            var quotesFile = @"quotes.json";

            var serializedQuotes = System.Text.Json.JsonSerializer.Serialize(quotes);

            File.WriteAllText(quotesFile, serializedQuotes);
        }


        private void btnSaveQuote_Click(object sender, EventArgs e)
        {

            // when clicking Save Quote button, will create a new desk using the 
            // new Desk() method 
            var desk = new Desk
            {
                Depth = numericUpDownDepth.Value,
                Width = numericUpDownWidth.Value,
                NumberOfDrawers = (int)numericUpDownDrawers.Value,
                SurfaceMaterial = (SurfaceMaterial)comboBoxMaterial.SelectedValue
            };

            // create a desk quote
            var deskQuote = new DeskQuote
            {
                Desk = desk,
                CustomerName = txtCustomerName.Text,
                QuoteDate = DateTime.Now,
                Shipping = (Shipping)comboBoxShipping.SelectedValue
            };

            var price = deskQuote.GetQuotePrice();

            // set quote price
            deskQuote.QuotePrice = deskQuote.GetQuotePrice();

            // add to quote 
            deskQuote.QuotePrice = price;

            AddQuoteToFile(deskQuote);

            //code block to create form, add reference to AddQuote, show new form, and hide AddQuote
            DisplayQuote frmDisplayQuote = new DisplayQuote(deskQuote);
            frmDisplayQuote.Show();
            this.Hide();



        }
    }
}
