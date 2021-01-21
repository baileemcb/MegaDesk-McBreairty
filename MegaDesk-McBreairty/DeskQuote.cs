using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_McBreairty
{

    public enum Shipping
    {
        NoRush,
        Rush3Day, 
        Rush5Day, 
        Rush7Day
    }

    public class DeskQuote
    {
        public string CustomerName { get; set; }

        public int QuoteDate { get; set; }

        public decimal QuotePrice { get; set; }

        public Shipping Shipping { get; set; }

        public Desk Desk { get; set; }

        public decimal GetQuotePrice()
        {
            // TEMP return change this later
            return 0;
        }
    }
}
