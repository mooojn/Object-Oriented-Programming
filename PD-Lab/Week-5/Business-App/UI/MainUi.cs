using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg3
{
    internal class MainUi
    {
        public static string Menu()
        {
            Console.WriteLine("1. Sign In As Admin...");
            Console.WriteLine("2. Sign In As User...");
            Console.WriteLine("3. Sign Up...");
            Console.WriteLine("4. Exit......");

            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        public static string user_menu()
        {
            // menu
            Console.WriteLine("1. Check Portfolio");
            Console.WriteLine("2. Deposit Cash");
            Console.WriteLine("3. Withdraw Cash");
            Console.WriteLine("4. Block Transactions");
            Console.WriteLine("5. Delete Account");

            Console.WriteLine("6. Logout");

            // getting input
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        public static string admin_menu()
        {
            // menu
            Console.WriteLine("1. Add New User");
            Console.WriteLine("2. View Users");
            Console.WriteLine("3. Change User Name");
            Console.WriteLine("4. Delete User");
            Console.WriteLine("5. Logout");

            // getting input
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
    }
}
