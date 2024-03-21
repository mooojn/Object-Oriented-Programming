using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace chl4
{
    internal class Saving : Account
    {
        private float interestRate;
        private float taxRate = 0.04f;
        public Saving(string accNum, double balance): base(accNum, balance)
        {
            interestRate = 0.05f;  // 5% interest
        }
        public Saving(string accNum, double balance, float interestRate) : base(accNum, balance)
        {
            this.interestRate = interestRate;  
        }

        public void CalculateInterest()
        {
            double profit = getBalance() * interestRate;  // 5% interest
            Deposit(profit);       // addding profit to balance
        }
        public void DeductTax()
        {
            double tax = getBalance() * taxRate;
            Withdraw(tax);
        }
    }
}
