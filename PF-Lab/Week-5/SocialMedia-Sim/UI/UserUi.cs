using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace chlng_2_new_pf
{
    internal class UserUi
    {
        public static string Operations()
        {
            Console.Clear();

            Console.WriteLine("User Operations:");
            Console.WriteLine("1.Create a new user");
            Console.WriteLine("2.Log in (existing user)");
            Console.WriteLine("3.Exit");

            Console.Write("Enter choice: ");
            return Console.ReadLine();
        }
        public static string Menu()
        {
            Console.Clear();

            Console.WriteLine("User Menu:");
            Console.WriteLine("1. View Profile");
            Console.WriteLine("2. Encrypt Password");
            Console.WriteLine("3. Check Password");
            Console.WriteLine("4. Change Password");
            Console.WriteLine("5. Get Password");
            Console.WriteLine("6. Log Out");

            Console.Write("Enter choice: ");
            return Console.ReadLine();
        }
        public static User TakeInput()
        {
            Console.Clear();
            
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            
            return new User(name, pass);
        }
    }
}
