using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MountainBike mBike = new MountainBike(5, 10, 20, 30);
            Console.WriteLine("MountainBike Info: ");
            
            Console.WriteLine(mBike.getInfo());

            mBike.setHeight(10);
            
            Console.WriteLine("New Height: " + mBike.getHeight());
            
            Console.ReadLine();
        }
    }
}
