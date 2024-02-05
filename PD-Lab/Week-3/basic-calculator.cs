using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Math;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        AGAIN:
            Console.Clear();
            string choice = menuWithOption1();
            if (choice == "1")
            {
                Calculator calculator = new Calculator();
                while (true)
                {
                    Console.Clear();
                    choice = menuWithoutOption1();
                    if (choice == "1")
                    {
                        // changing values
                        getNumbersInput(ref calculator.number1, ref calculator.number2);
                    }
                    else if(choice == "2")
                    {
                        Console.WriteLine(calculator.Add());
                    }
                    else if(choice == "3")
                    {
                        Console.WriteLine(calculator.Subtract());
                    }
                    else if(choice == "4")
                    {
                        Console.WriteLine(calculator.Multiply());
                    }
                    else if(choice == "5")
                    {
                        try
                        {
                            Console.WriteLine(calculator.Divide());
                        }
                        catch(DivideByZeroException)
                        {
                            error("Divide by zero exception...");
                        }
                    }
                    else if(choice == "6")
                    {
                        Console.WriteLine(calculator.Modulus());
                    }
                    else if(choice == "7")
                    {
                        break;   // exit
                    }
                    else
                    {
                        error("Invalid Choice...");
                    }
                    Console.ReadKey();
                }
            }
            // invalid case
            else
            {
                error("First create object of Calculator class...");
                goto AGAIN;
            }
        }
        static void getNumbersInput(ref int num1, ref int num2)
        {
            Console.Write("Enter the value of 1st number: ");
            num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the value of 2nd number: ");
            num2 = int.Parse(Console.ReadLine());
        }
        static string menuWithOption1()
        {
            // menu option
            Console.WriteLine("1. Create single object of Calculator");
            // input
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        static string menuWithoutOption1()
        {
            Console.WriteLine("1. Change values of attribute");
            Console.WriteLine("2. Add");
            Console.WriteLine("3. Subtract");
            Console.WriteLine("4. Multiply");
            Console.WriteLine("5. Divide");
            Console.WriteLine("6. Modulo");
            Console.WriteLine("7. Exit");
            // input
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        static void pressAnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        static void error(string msg)
        {
            Console.WriteLine(msg);
            Thread.Sleep(600);
        }
    }
}
