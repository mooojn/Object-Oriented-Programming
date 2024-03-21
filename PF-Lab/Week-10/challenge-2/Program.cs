using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cylinder cylinder = new Cylinder(2.0, 3.0, "black");

            Console.WriteLine(cylinder.toString());

            Console.WriteLine("Volume: " + cylinder.getVolume());
            Console.WriteLine("Area: " + cylinder.getArea());

            Console.ReadKey();
        }
    }
}
