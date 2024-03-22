using chl3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person per = new Person("moon", "1234");
            Student std = new Student("saliq", "1234", "Computer Science", 2020, 1000);
            Staff stf = new Staff("meeral", "1234", "Computer Engineering", 1000);
            
            Console.WriteLine(per.toString());
            Console.WriteLine(std.toString());
            Console.WriteLine(stf.toString());

            Console.ReadKey();
        }
    }
}
