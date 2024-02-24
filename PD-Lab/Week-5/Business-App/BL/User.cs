using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chlg3
{
    internal class User
    {
        // objs
        public string user_names;
        public string user_passwords;
        public int cash_holdings;
        // constructor for initializing
        public User(string userName, string userPass)
        {
            user_names = userName;
            user_passwords = userPass;
            cash_holdings = 0;  // default val
        }
        public bool AddCash(int deposit_amount)
        {
            // error encountered so returning
            if (deposit_amount < 0)
                return false;
            // adding cash
            cash_holdings += deposit_amount;
            return true;
        }
        public bool WithdrawCash(int withdraw_amount)
        {
            // error encountered so returning
            if (withdraw_amount < 0 || withdraw_amount > cash_holdings)
                return false;
            // withdrawing cash
            cash_holdings -= withdraw_amount;
            return true;
        }
        public void ShowCash()
        {
            Console.Write($"Your total cash holdings holding: ${cash_holdings}");
        }
    }
}
