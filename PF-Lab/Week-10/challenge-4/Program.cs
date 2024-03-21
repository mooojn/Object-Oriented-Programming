using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Saving savingAcc = new Saving("saving-Arc10", 2000, 0.05f);
            Checking checkingAcc = new Checking("checking-Arc20", 1000, 5);

            Console.WriteLine(savingAcc.ToString());
            
            savingAcc.CalculateInterest();
            Console.WriteLine("Balance after interest: " + savingAcc.getBalance());

            savingAcc.DeductTax();
            Console.WriteLine("Balance after tax: " + savingAcc.getBalance());

            Console.WriteLine(checkingAcc.ToString());
            
            checkingAcc.DeductFee();
            Console.WriteLine("Balance after fee: " + checkingAcc.getBalance());

            exit();
        }
        static void exit()
        {
            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
