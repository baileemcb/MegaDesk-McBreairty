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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnAddNewQuote_Click(object sender, EventArgs e)
        {
            // code block to create form, add reference to Mainmenu, show new form, and hide MainMenu
            var frmAddQuote = new AddQuote();
            frmAddQuote.Tag = this; 
            frmAddQuote.Show();
            this.Hide(); 
        }

        private void btnViewAllQuotes_Click(object sender, EventArgs e)
        {
            // code block to create form, add reference to Mainmenu, show new form, and hide MainMenu
            var frmViewAllQuotes = new ViewAllQuotes();
            frmViewAllQuotes.Tag = this;
            frmViewAllQuotes.Show();
            this.Hide();
        }

        private void btnSearchQuotes_Click(object sender, EventArgs e)
        {
            // code block to create form, add reference to Mainmenu, show new form, and hide MainMenu
            var frmSearchQuotes = new SearchQuotes();
            frmSearchQuotes.Tag = this;
            frmSearchQuotes.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
