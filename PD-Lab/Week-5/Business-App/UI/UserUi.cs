using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buscompe_conv.UI
{
    internal class UserUi
    {
        public static string GetName()
        {
            Console.Write("Enter Name: ");
            return Console.ReadLine();
        }
        public static string GetPass()
        {
            Console.Write("Enter Password: ");
            return Console.ReadLine();
        }
        public static int GetDepositAmount()
        {
            Console.Write("Enter amount you want to deposit: $");
            return int.Parse(Console.ReadLine());
        }
        public static int GetWithdrawAmount()
        {
            Console.Write("Enter the amount you want to withdraw: $");
            return int.Parse(Console.ReadLine());
        }
    }
}
