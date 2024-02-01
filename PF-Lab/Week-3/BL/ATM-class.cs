using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ATM_t2
{
    internal class ATM
    {
        // var
        public int balance;
        public string[] transactionHistories = new string[100];
        public int index = 0;
        // cons
        public ATM(int balance)
        {
            this.balance = balance;
        }
        // funcs
        public void Deposit(int amount) 
        {
            balance += amount;
            maintainHistory("Deposit", amount);
        }
        public void Withdraw(int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                maintainHistory("Withdraw", amount);
            }
        }
        public int ShowBalance()
        {
            return balance;
        }
        public void maintainHistory(string type, int amount)
        {
            transactionHistories[index] = type;
            transactionHistories[index+1] = amount.ToString();
            index += 2;
        }
        public void TransactionHistory()
        {
            Console.WriteLine("Type,Amount");
            for (int i = 0;i < index; i+=2)
            {
                Console.WriteLine($"{transactionHistories[i]},{transactionHistories[i + 1]}");
            }
        }   
        public bool ValidateCard(string cardCompany)
        {
            if (cardCompany == "visa")
                return true;
            return false;
        }
        public bool ValidatePin(string pin)
        {
            if (pin.Length == 4)
                return true;
            return false;
        }
    }
}
