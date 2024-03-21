using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std = new Student("Sheri", "1234", "Computer Science", 2020, 1000);
            
            Staff stf = new Staff("Sher", "5678", "Computer Engineering", 1000);

            Console.WriteLine($"Student: {std.toString()}");

            Console.WriteLine($"Staff: {stf.toString()}");

            Console.ReadKey();
        }
    }
}
