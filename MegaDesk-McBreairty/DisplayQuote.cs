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
    public partial class DisplayQuote : Form
    {
        DeskQuote _deskQuote;
        public DisplayQuote(DeskQuote deskQuote)
        {
            InitializeComponent();

            _deskQuote = deskQuote;

            quotePriceLabel.Value = _deskQuote.QuotePrice;
        }

        private void DisplayQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainMenu = (MainMenu)this.Tag;
            mainMenu.Show();
        }

    }
}
