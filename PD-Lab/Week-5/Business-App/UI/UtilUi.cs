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
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
        public static void Error(string type)
        {
            Console.WriteLine(type);
            PressAnyKey();
        }
        public static void Success(string msg)
        {
            Console.WriteLine(msg);
            PressAnyKey();
        }
        public static void InvalidChoice()
        {
            Console.WriteLine("Invalid Choice...");
            Thread.Sleep(500);
        }
        public static void Process()
        {
            Console.WriteLine("Processing please wait...");
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
