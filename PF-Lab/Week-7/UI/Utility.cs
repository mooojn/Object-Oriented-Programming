using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class Utility
    {
        public static string MainMenu()
        {
            Console.Clear();
            // input
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Option: ");
            return Console.ReadLine();
        }
        public static void PressAnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
