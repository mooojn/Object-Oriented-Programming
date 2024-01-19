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
            Console.Write("Enter the temprature: ");
            float temperature = float.Parse(Console.ReadLine());

            Console.Write("Enter its unit: ");
            string unit = Console.ReadLine();

            float converted_temperature = 0;
            string converted_unit = "";
            if (unit == "F" || unit == "f") // unit is F convert to C
            {
                converted_temperature = (temperature - 32) * 5 / 9; // converted to C
                converted_unit = "C";
            }
            else
            {
                converted_temperature = temperature * (9 / 5) + 32; // converted to F
                converted_unit = "F";
            }

            // output
            Console.WriteLine($"Converted {temperature} {unit} to {converted_temperature} {converted_unit}");
            Console.Read();
        }
    }
}