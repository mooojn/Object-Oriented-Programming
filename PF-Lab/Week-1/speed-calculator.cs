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
            // greeting
            Console.WriteLine("welcome back..");
            
            // input from user
            Console.Write("Enter Distance in km: ");
            double kilometers = double.Parse(Console.ReadLine());
            Console.Write("Enter time in hours: ");
            double hours = double.Parse(Console.ReadLine());
            
            // validation
            if (hours <= 0)
            {
                Console.WriteLine("Error");
                return;
            }
            // calculation
            double speed = kilometers / hours;

            // output
            Console.WriteLine($"Distance is: {kilometers}km");
            Console.WriteLine($"Time is: {hours}h");
            Console.WriteLine($"Speed is: {speed}km/h");
        }
    }
}