using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_McBreairty
{

    public enum SurfaceMaterial
    {
        Laminate,
        Oak,
        Rosewood,
        Veneer, 
        Pine
    }
    public class Desk
    {
        // prop tab tab to do that thing
        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public decimal NumberOfDrawers { get; set; }

        public SurfaceMaterial SurfaceMaterial { get; set; }
    }
}
