using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl4
{
    internal class Account
    {
        private string accountNumber;
        private double balance;
        public Account(string accountNumber, double balance)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
        }
        public string getAccNum()
        {
            return accountNumber;
        }
        public void setAccNum(string val)
        {
            accountNumber = val;
        }
        public double getBalance()
        {
            return balance;
        }
        public void setBalance(double val)
        {
            balance = val;
        }
        public bool Deposit(double amount)
        {
            if (amount < 0) {
                return false;
            }
            balance += amount;
            return true;
        }
        public bool Withdraw(double amount)
        {
            if (amount < 0 || amount >= balance) {
                return false;
            }
            balance -= amount;
            return true;
        }
        public override string ToString()
        {
            return $"Account Number: [{accountNumber}], Balance: [{balance}]";
        }
    }
}
