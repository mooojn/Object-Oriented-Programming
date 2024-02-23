using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_4_new_PD
{
    internal class Point
    {
        public int X;
        public int Y;
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void SetXY(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
