using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chlg3_b
{
    internal class userData
    {
        // objs
        public string user_names;
        public string user_passwords;
        public int cash_holdings;
        public void signedUp()
        {
            Console.Clear();
            // getting input
            Console.Write("Enter your name: ");
            user_names = Console.ReadLine();
            Console.Write("Set password: ");
            user_passwords = Console.ReadLine();
        }
    }
}
