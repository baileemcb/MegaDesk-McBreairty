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

            lblCustomerName.Text = deskQuote.CustomerName;
            lblWidth.Text = deskQuote.Desk.Width.ToString();
            lblDepth.Text = deskQuote.Desk.Depth.ToString();
            lblDrawers.Text = deskQuote.Desk.NumberOfDrawers.ToString();
            lblMaterial.Text = deskQuote.Desk.SurfaceMaterial.ToString();
            lblShipping.Text = deskQuote.Shipping.ToString();
            quotePriceLabel.Text = _deskQuote.QuotePrice.ToString();
        }

        private void DisplayQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainMenu = (MainMenu)this.Tag;
            mainMenu.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)this.Tag;
            mainMenu.Show();
            this.Close();
        }
    }
}
