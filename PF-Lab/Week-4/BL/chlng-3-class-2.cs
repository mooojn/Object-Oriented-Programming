using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg3_new
{
    internal class Member
    {
        public string Name;
        public string MemberID;
        public int Cash;
        public int AmountSpent;
        List<Book> BooksPurchased = new List<Book>();
        public Member(string name, string memberID, int cash, int amountSpent)
        {
            Name = name;
            MemberID = memberID;
            Cash = cash;
            if (memberID != "0")
                Cash -= 10;  // 10 is the membership fee
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
        public void UpdateName(string name)
        {
            Name = name;
        }
        public void UpdateId(string id)
        {
            MemberID = id;
        }
        public int TotalAmountSpent()
        {
            return AmountSpent;
        }
        public void DisplayInfo()
        {
            Console.Write(Name + "\t");
            Console.Write(MemberID + "\t");
            Console.Write(Cash + "\t");
            Console.Write(AmountSpent);
        }
        public void BuyBook(int quantityToBuy, Book bookToBuy)
        {
            bookToBuy.Stock -= quantityToBuy;
            Cash -= bookToBuy.Price * quantityToBuy;
            AmountSpent += bookToBuy.Price * quantityToBuy;
            
            BooksPurchased.Add(bookToBuy);
        }
        // change lateer | 
        public void BuyBookMember(int quantityToBuy, Book bookToBuy)
        {
            bookToBuy.Stock -= quantityToBuy;
            Cash -= bookToBuy.Price * quantityToBuy;
            
            double total = bookToBuy.Price * quantityToBuy;
            total = total - (total * 0.05);  // applying 5% discount
            
            AmountSpent += Convert.ToInt32(total);

            BooksPurchased.Add(bookToBuy);
        }
        public bool NonMember()
        {
            if (MemberID == "0")
                return true;
            return false;
        }
    }
}
