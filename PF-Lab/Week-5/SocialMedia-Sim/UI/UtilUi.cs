using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_2_new_pf
{
    internal class UtilUi
    {
        public static string MainMenu()
        {
            Console.Clear();

            Console.WriteLine("Welcome to Social Media Simulator!");
            Console.WriteLine("1. User Operations");
            Console.WriteLine("2. Twitter Operations");
            Console.WriteLine("3. Facebook Operations");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            return Console.ReadLine();
        }
        public static string GetNameToSearch()
        {
            Console.Write("Enter name of user to find: ");
            return Console.ReadLine();
        }
        public static string GetPass()
        {
            Console.Write("Enter password: ");
            return Console.ReadLine();
        }
        public static string GetMessageToSend(string type)
        {
            Console.Write($"Enter {type}: ");
            return Console.ReadLine();
        }
        public static string GetEncryptor()
        {
            Console.Write("Enter text to encrypt Password with: ");
            return Console.ReadLine();
        }
        public static void PressAnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
