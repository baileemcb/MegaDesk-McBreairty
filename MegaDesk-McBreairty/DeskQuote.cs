using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public DateTime QuoteDate { get; set; }

        public decimal QuotePrice { get; set; }

        public Shipping Shipping { get; set; }

        public Desk Desk { get; set; }

        public decimal GetQuotePrice()
        {
            // TEMP return change this later
            decimal quoteTotal = 0;

            // 1 add base price
            quoteTotal = 200;

            // 2 calculate area 
            var area = this.Desk.Width * this.Desk.Depth; 

            if (area > 1000)
            {
                var extra = area - 1000;

                quoteTotal = quoteTotal + extra; 
            }

            // 3 add on the desks

            var drawerPrice = this.Desk.NumberOfDrawers * 50;

            quoteTotal = quoteTotal + drawerPrice; 

            return 0;
            
        }

        public static decimal[,] GetRushOrder()
        {
            decimal[,] rushOrderPrices = new decimal[3, 3];

            string file = @"rushOrderPrices.txt";

            string[] lines = File.ReadAllLines(file);

            int a = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    rushOrderPrices[x, y] = decimal.Parse(lines[a]);
                    a++;
                }
            }

            return rushOrderPrices; 
        }
    }
}
