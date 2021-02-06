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

namespace MegaDesk_McBreairty
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();

            loadGrid();
        }

        private void ViewAllQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainMenu = (MainMenu)this.Tag;
            mainMenu.Show();
        }

        private void loadGrid()
        {
            var quotesFile = @"quotes.json";

            using (StreamReader reader = new StreamReader(quotesFile))
            {
                string quotes = reader.ReadToEnd();

                List<DeskQuote> deskQuotes = System.Text.Json.JsonSerializer.Deserialize<List<DeskQuote>>(quotes);

                dataGridView1.DataSource = deskQuotes
                     .Select(d => new
                     {
                         Date = d.QuoteDate,
                         Customer = d.CustomerName,
                         Depth = d.Desk.Depth,
                         Width = d.Desk.Width,
                         Drawers = d.Desk.NumberOfDrawers,
                         SurfaceMaterial = d.Desk.SurfaceMaterial,
                         DeliveryType = d.Shipping,
                         QuoteAmount = d.QuotePrice.ToString("c")
                     }
                  )
                     .ToList();
            }
        }

    }
}
