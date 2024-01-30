using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chlg3
{
    internal class userData
    {
        // objs
        public string user_names;
        public string user_passwords;
        public int cash_holdings;
        // constructor for initializing
        public userData(string userName, string userPass)
        {
            user_names = userName;
            user_passwords = userPass;
            cash_holdings = 0;  // default val
        }
        public void addCash(int cash)
        {
            cash_holdings += cash;
        }
        public void withdrawCash(int cash)
        {
            cash_holdings -= cash;
        }
        public void showCash()
        {
            Console.Write($"Your total cash holdings holding: ${cash_holdings}");
        }
    }
}
