using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                BACK:   // back from advanced func
                    Console.Clear();
                    choice = menuWithoutOption1();
                    if (choice == "1")
                    {
                        getNumbersInput(ref calculator.num1, ref calculator.num2);
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine(calculator.Add());
                    }
                    else if (choice == "3")
                    {
                        Console.WriteLine(calculator.Subtract());
                    }
                    else if (choice == "4")
                    {
                        Console.WriteLine(calculator.Multiply());
                    }
                    else if (choice == "5")
                    {
                        try
                        {
                            Console.WriteLine(calculator.Divide());
                        }
                        catch (DivideByZeroException)
                        {
                            error("Divide by zero exception...");
                        }
                    }
                    else if (choice == "6")
                    {
                        Console.WriteLine(calculator.Modulus());
                    }
                    else if (choice == "7")
                    {
                        double result;  // stores the result of advanced calculations
                        string option;
                        while (true)
                        {
                            Console.Clear();
                            option = advancedFuncMenu();
                            result = 0;
                            if (option == "1")
                            {
                                calculator.ChangeValue(int.Parse(Console.ReadLine()));
                            }
                            else if (option == "2")
                            {
                                result = calculator.SquareRoot();
                                Console.WriteLine(result);
                            }
                            else if (option == "3")
                            {
                                result = calculator.Exponential();
                                Console.WriteLine(result);
                            }
                            else if (option == "4")
                            {
                                result = calculator.Logarithm();
                                Console.WriteLine(result);
                            }
                            else if (option == "5")
                            {
                                string trignoFunc = getTypeOfTrigFunc();
                                result = calculator.Tringnometric(trignoFunc);
                                Console.WriteLine(result);
                            }
                            else if (option == "6")
                            {
                                goto BACK;    // returning to simple calculations
                            }
                            else
                            {
                                error("Invalid Choice...");
                            }
                            Console.ReadKey();
                        }
                    }
                    else if (choice == "8")
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
            Console.WriteLine("7. Advanced Function");
            Console.WriteLine("8. Exit");
            // input
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        static string advancedFuncMenu()
        {
            Console.WriteLine("1. Change value of attribute");
            Console.WriteLine("2. Square Root");
            Console.WriteLine("3. Exponential Function");
            Console.WriteLine("4. Logarithmic");
            Console.WriteLine("5. Trignometric");
            Console.WriteLine("6. Back");
            // input
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        static string getTypeOfTrigFunc()
        {
            Console.WriteLine("Enter the Trignometric Function(sin, cos, tan): ");
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
