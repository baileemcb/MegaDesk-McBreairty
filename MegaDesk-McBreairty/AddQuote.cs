using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_McBreairty
{
    public partial class AddQuote : Form
    {
        public AddQuote()
        {
            InitializeComponent();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveQuote_Click(object sender, EventArgs e)
        {
            // when clicking Save Quote button, will create a new desk using the 
            // new Desk() method 
            var desk = new Desk();
            
            //assign desk properties
            desk.Width = numericUpDownWidth.Value;
            desk.Depth = numericUpDownDepth.Value;
            desk.NumberOfDrawers = numericUpDownDrawers.Value;

            // create a desk quote
            var deskQuote = new DeskQuote();

            // set desk quote properties
            deskQuote.CustomerName = txtCustomerName.Text;

            // set quote price
            deskQuote.QuotePrice = deskQuote.GetQuotePrice();

        }
    }
}
