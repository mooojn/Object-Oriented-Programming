using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_t2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATM a = new ATM(1000);
            Console.WriteLine(a.ShowBalance());
            
            a.Deposit(200);
            a.Deposit(400);
            Console.WriteLine(a.ShowBalance());
            
            a.Withdraw(100);
            a.Withdraw(300);
            Console.WriteLine(a.ShowBalance());
            
            a.TransactionHistory();
            
            Console.ReadKey();
        }
    }
}
