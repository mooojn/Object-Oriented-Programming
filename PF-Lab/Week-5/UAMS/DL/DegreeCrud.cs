using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new.DL
{
    internal class DegreeCrud
    {
        public static List<Degree> Degrees = new List<Degree>();
        public static void AddDegree(Degree NewDegree)
        {
            Degrees.Add(NewDegree);
        }
        public static void ShowDegrees()
        {
            int index = 0;
            Console.WriteLine("Available Degrees");
            Console.WriteLine("Index, Title, Duration, Seat");
            foreach (Degree D in Degrees)
            {
                Console.WriteLine($"{index}, {D.ShowInfo()}");
                index++;
            }
        }
        public static void RegisteredStd(int index)
        {
            Degrees[index].Registered();
        }
    }
}
