using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace chlg3
{
    internal class UtilUi
    {
        public static void PressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
        public static void Error(string type)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(type);
            Console.ResetColor();
            PressAnyKey();
        }
        public static void Success(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
            PressAnyKey();
        }
        public static void InvalidChoice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Choice...");
            Console.ResetColor();
            Thread.Sleep(500);
        }
        public static void Process()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Processing please wait...");
            Console.ResetColor();
            Thread.Sleep(800);
        }
        public static void ShowMSG(bool status)
        {
            Process();
            if (status)
                Success("Successfull...");
            else
                Error("Invalid amount");
        }
    }
}
