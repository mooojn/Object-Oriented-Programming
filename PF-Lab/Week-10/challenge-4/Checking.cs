using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl4
{
    internal class Checking : Account
    {
        double fee;
        
        public Checking(string accNum, double balance, double fee) : base(accNum, balance)
        {
            this.fee = fee;
        }
        public void DeductFee()
        {
            Withdraw(fee);
        }

    }
}
