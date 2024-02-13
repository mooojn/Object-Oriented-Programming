using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg2_new
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = new List<Member>();
            string choice = menu();
            while (true)
            {
                Console.Clear();
                if (choice == "1")
                {
                    members.Add(createMember());
                }
                else if (choice == "2")
                {
                    showMember(members, "1");
                }
                else if (choice == "3")
                {
                    addCash(members, "1", 500);
                }
                else if (choice == "4")
                {
                    removeCash(members, "1", 200);
                }
                else if (choice == "5")
                {
                    return;
                }
                Console.ReadKey();
            }
        }
        static void addCash(List<Member> members, string memberID, int amount)
        {
            foreach (Member member in members)
            {
                if (member.MemberID == memberID)
                {
                    member.AddCash(amount);
                }
            }
        }
        static void removeCash(List<Member> members, string memberID, int amount)
        {
            foreach (Member member in members)
            {
                if (member.MemberID == memberID)
                {
                    member.SpendCash(amount);
                }
            }
        }
        static void showMember(List<Member> members, string memberID)
        {
            foreach (Member member in members)
            {
                if (member.MemberID == memberID)
                {
                    member.ShowName();
                }
            }
        }
        static Member createMember()
        {
            // input 
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter member ID: ");
            string memberID = Console.ReadLine();

            Console.WriteLine("Enter cash: ");
            int cash = int.Parse(Console.ReadLine());
            
            // object with these fields
            return new Member(name, memberID, cash);
        }
        static string menu()
        {
            // menu choices
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. Show Member");
            Console.WriteLine("3. Add Cash");
            Console.WriteLine("4. Spend Cash");
            Console.WriteLine("6. Exit");

            // user choice
            Console.WriteLine("Enter your choice: ");
            return Console.ReadLine();
        }
    }
}
