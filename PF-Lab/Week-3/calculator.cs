using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_t1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator(10, 5);
            Console.WriteLine("Sum: " + calc.Sum());
            Console.WriteLine("Subraction: " + calc.Sub());
            Console.WriteLine("Multiplication: " + calc.Mul());
            Console.WriteLine("Division: " + calc.Div());
            Console.ReadKey();
        }
    }
}
