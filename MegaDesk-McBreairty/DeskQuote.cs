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

            // 3 add on the drawers

            var drawerPrice = this.Desk.NumberOfDrawers * 50;

            quoteTotal = quoteTotal + drawerPrice;

            // 4 add rush costs

            //read in
            decimal[,] rushOrderPrices;

            rushOrderPrices = GetRushOrder();


            decimal rushCost = (decimal)Shipping;
            if (area < 1000)
            {
                switch (rushCost)
                {
                    case 0:
                        break;
                    case 1:
                        quoteTotal = quoteTotal + rushOrderPrices[0,0];
                        break;
                    case 2:
                        quoteTotal = quoteTotal + rushOrderPrices[0, 1];
                        break;
                    case 3:
                        quoteTotal = quoteTotal + rushOrderPrices[0, 2];
                        break;
                }
            }
            else if (area < 2000)
            {
                switch (rushCost)
                {
                    case 0:
                        break;
                    case 1:
                        quoteTotal = quoteTotal + rushOrderPrices[1, 0];
                        break;
                    case 2:
                        quoteTotal = quoteTotal + rushOrderPrices[1, 1];
                        break;
                    case 3:
                        quoteTotal = quoteTotal + rushOrderPrices[1, 2];
                        break;
                }
            }
            else
            {
                switch (rushCost)
                {
                    case 0:
                        break;
                    case 1:
                        quoteTotal = quoteTotal + rushOrderPrices[2, 0];
                        break;
                    case 2:
                        quoteTotal = quoteTotal + rushOrderPrices[2, 1];
                        break;
                    case 3:
                        quoteTotal = quoteTotal + rushOrderPrices[2, 2];
                        break;
                }
            }

            //5 add surface material cost


            if (this.Desk.SurfaceMaterial == SurfaceMaterial.Oak) 
            {
                quoteTotal = quoteTotal + 200;
            }

            else if (this.Desk.SurfaceMaterial == SurfaceMaterial.Laminate)
            {
                quoteTotal = quoteTotal + 200;
            }

            else if (this.Desk.SurfaceMaterial == SurfaceMaterial.Pine)
            {
                quoteTotal = quoteTotal + 200;
            }

            else if (this.Desk.SurfaceMaterial == SurfaceMaterial.Rosewood)
            {
                quoteTotal = quoteTotal + 200;
            }

            else if (this.Desk.SurfaceMaterial == SurfaceMaterial.Veneer)
            {
                quoteTotal = quoteTotal + 200;
            }


            return quoteTotal;

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
