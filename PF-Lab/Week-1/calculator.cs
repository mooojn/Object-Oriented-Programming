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
            // greeting user
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome back {0}\n This is a simple calculator...", name);

            // getting data
            float n1 = float.Parse(Console.ReadLine());
            float n2 = float.Parse(Console.ReadLine());
            string operation = Console.ReadLine();

            // result calculation
            float result = 0;
            if (operation == "+")
                result = n1 + n2;
            else if (operation == "-")
                result = n1 - n2;
            else if (operation == "*")
                result = n1 * n2;
            else if (operation == "/")
                result = n1 / n2;

            // displaying result
            Console.WriteLine(result);
        }
    }
}