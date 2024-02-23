using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_4_new_PD
{
    internal class Boundary
    {
        public Point TopLeft;
        public Point TopRight;
        public Point BottomLeft;
        public Point BottomRight;
        public Boundary()
        {
            // default vals
            TopLeft = new Point(0, 0);
            TopRight = new Point(0, 90);
            BottomLeft = new Point(90, 0);
            BottomRight = new Point(90, 90);
        }
    }
}