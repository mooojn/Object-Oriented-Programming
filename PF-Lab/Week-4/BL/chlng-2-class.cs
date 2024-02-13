using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg2_new
{
    internal class Member
    {
        public string Name;
        public string MemberID;
        public int Cash;
        public int AmountSpent;
        public Member(string name, string memberID, int cash)
        {
            Name = name;
            MemberID = memberID;
            Cash = cash;
            AmountSpent = 0;
        }
        public void ShowName()
        {
            Console.WriteLine("Name: " + Name);
        }
        public void AddCash(int amount)
        {
            Cash = amount;
        }
        public void SpendCash(int amount)
        {
            Cash -= amount;
            AmountSpent += amount;
        }
    }
}
