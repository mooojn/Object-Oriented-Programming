using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl2
{
    internal class Cylinder : Circle
    {
        private double height;
        public Cylinder()
        {
            height = 1.0;
        }
        public Cylinder(double radius) : base(radius)
        {
            height = 1.0;
        }
        public Cylinder(double height, double radius) : base(radius)
        {
            this.height = height;
        }
        public Cylinder(double height, double radius, string color): base(radius, color)
        {
            this.height = height;
        }
        public double getHeight()
        {
            return height;
        }
        public void setHeight(double val)
        {
            height = val;
        }
        public double getVolume()
        {
            return getArea() * height;
        }
    }
}
