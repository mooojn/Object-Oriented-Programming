using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace chlng_4_new_PD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] triangle = GameUi.GetShape();
            
            Boundary B = new Boundary();

            GameObject G1 = new GameObject(triangle, new Point(5,5));

            while (true)
            {
                G1.Erase();
                //Console.ReadKey();
                
                G1.Move();
                //Console.ReadKey();
                
                G1.Draw();
                //Console.ReadKey();
                Thread.Sleep(100);
            }
        }
    }
}