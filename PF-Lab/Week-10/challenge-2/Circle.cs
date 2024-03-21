using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl2
{
    internal class Circle
    {
        private double radius;
        private string color;
        public Circle()
        {
            radius = 1.0;
            color = "red";
        }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }
        public double getRadius()
        {
            return radius;
        }
        public void setRadius(int val)
        {
            radius = val;
        }
        public string getColor()
        {
            return color;
        }
        public void setColor(string val)
        {
            color = val;
        }
        public double getArea()
        {
            return Math.PI * radius * radius;
        }
        public string toString()
        {
            return $"Circle[radius = {radius}, color = {color}]";
        }   
    }
}
