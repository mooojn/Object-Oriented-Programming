using chlg3_new;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg3_new
{
    internal class Program
    {
        public static int bookIndex = 0;   // for searching operation on books
        public static int memberIndex = 0;   // for searching operation on members
        static void Main(string[] args)
        {
            // struct for objects
            List<Book> books = new List<Book>();
            List<Member> members = new List<Member>();

            string choice = "";  // choice for menu
            while (true)
            {
                Console.Clear();
                
                choice = menu();   

                Console.Clear();
                if (choice == "1")
                {
                    books.Add(addBook());
                }
                else if (choice == "2")
                {
                    // search for book by Title
                    Console.Write("Enter Title of Book: ");
                    string title = Console.ReadLine();

                    bookIndex = 0;  // reset val before search
                    if (searchBook(books, title))
                    {
                        books[bookIndex].DisplayInfo();
                    }
                    else
                    {
                        errorMessage("Book Not Found...");
                    }
                }
                else if (choice == "3")
                {
                    // search for book by ISBN
                    Console.Write("Enter ISBN of Book: ");
                    string isbn = Console.ReadLine();

                    bookIndex = 0;  // reset val before search
                    if (searchBook(books, isbn))
                    {
                        books[bookIndex].DisplayInfo();
                    }
                    else
                    {
                        errorMessage("Book Not Found...");
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("Enter Title or ISBN of the book: ");
                    string id = Console.ReadLine();

                    Console.Write("Do you want to add(1) or remove(2) from stock: ");
                    string type = Console.ReadLine();

                    Console.Write("Enter the amount: ");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    
                    bookIndex = 0;  // reset val before search
                    if (searchBook(books, id))
                    {
                        if (type == "1")
                        {
                            books[bookIndex].AddStock(amount);
                        }
                        else 
                        {
                            books[bookIndex].AddStock(-amount);
                        }
                    }
                    else
                    {
                        errorMessage("Book Not Found...");
                    }
                }
                else if (choice == "5")
                {
                    members.Add(createMember());
                }
                else if (choice == "6")
                {
                    Console.WriteLine("Enter member ID or name(if not member) to search for: ");
                    string idOfMember = Console.ReadLine();

                    memberIndex = 0; // reset val before search
                    if (searchMember(members, idOfMember))
                    {
                        members[memberIndex].DisplayInfo();
                    }
                    else
                    {
                        errorMessage("Member Not Found...");
                    }
                }
                else if (choice == "7")
                {
                    Console.WriteLine("Enter member ID or name(if not member) to update: ");
                    string idOfMember = Console.ReadLine();

                    memberIndex = 0; // reset val before search
                    if (searchMember(members, idOfMember))
                    {
                        Console.Write("Do you want to change Name(1), ID(2), or both(3): ");
                        string type = Console.ReadLine();
                        if (type == "1")
                        {
                            Console.Write("Enter new Name: ");
                            members[memberIndex].UpdateName(Console.ReadLine());
                        }
                        else if (type == "2")
                        {
                            Console.Write("Enter new ID: ");
                            members[memberIndex].UpdateId(Console.ReadLine());
                        }
                        else
                        {
                            Console.Write("Enter new Name: ");
                            members[memberIndex].UpdateName(Console.ReadLine());
                            
                            Console.Write("Enter new ID: ");
                            members[memberIndex].UpdateId(Console.ReadLine());
                        }
                    }
                    else
                    {
                        errorMessage("Member Not Found...");
                    }
                }
                else if (choice == "8")
                {
                    string nameOfNonMember = "";

                    Console.WriteLine("Enter member ID, or if non-member(0): ");
                    string idOfMember = Console.ReadLine();

                    if (idOfMember == "0")
                    {
                        Console.WriteLine("Enter your name: ");
                        nameOfNonMember = Console.ReadLine();
                    }
                    showAllBooks(books);
                    
                    Console.Write("Enter ISBN of the book to purchase: ");
                    string isbn = Console.ReadLine();
                    
                    bookIndex = 0; // reset val before search
                    if (searchBook(books, isbn))
                    {
                        Console.WriteLine("Enter Quantity: ");
                        int quantityToBuy = Convert.ToInt32(Console.ReadLine());

                        books[bookIndex].AddStock(-quantityToBuy);  // reducing stock

                        memberIndex = 0; // reset val before search
                        if (idOfMember == "0")
                        {
                            searchMember(members, nameOfNonMember);

                            members[memberIndex].BuyBook(quantityToBuy, books[bookIndex]);
                        }
                        else
                        {
                            searchMember(members, idOfMember);

                            members[memberIndex].BuyBookMember(quantityToBuy, books[bookIndex]);
                        }
                    }
                    else
                    {
                        errorMessage("Book not found...");
                    }

                }
                else if (choice == "9")
                {
                    int totalSales = 0;
                    int memberCount = 0;
                    int memberShipFeeCollected = 0;
                    foreach (Member member in members)
                    {
                        totalSales += member.TotalAmountSpent();
                        memberCount++;
                        if(!member.NonMember())   // if member is a "member"
                        {
                            memberShipFeeCollected += 10;
                        }
                    }
                    Console.WriteLine($"Total sales: ${totalSales}");
                    Console.WriteLine($"Total members: {memberCount}");
                    Console.WriteLine($"Total membership fee collected: ${memberShipFeeCollected}");
                }
                else if (choice == "10")
                {
                    return;  // exit the program 
                }
                pressAnyKey();
            }
        }
        static void showAllBooks(List<Book> books)
        {
            Console.WriteLine("Title\tAuthor\tPublisher\tISBN\tPrice\tStock");

            foreach (Book book in books)
            {
                book.DisplayInfo();
            }
        }
        static bool searchMember(List<Member> members, string memberID)
        {
            foreach (Member member in members)
            {
                if (member.MemberID == memberID || member.Name == memberID)
                {
                    return true;
                }
                memberIndex++;
            }
            return false;
        }
        static Member createMember()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter member ID: ");
            string memberID = Console.ReadLine();

            Console.Write("Enter cash: ");
            int cash = int.Parse(Console.ReadLine());

            return new Member(name, memberID, cash, 0);
        }
        static void addBookStock(List<Book> books, string isbn, int amount)
        {
            foreach (Book book in books)
            {
                if (book.CheckISBN(isbn))
                {
                    book.AddStock(amount);
                    break;
                }
            }
        }
        static bool searchBook(List<Book> books, string name)
        {
            // search for book by title
            foreach (Book book in books)
            {
                if (book.CheckISBN(name) || book.CheckTitle(name))
                {
                    return true;
                }
                bookIndex++;   // if not found, increment bookIndex 
            }
            return false;
        }
        static Book addBook()
        {
            // input
            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            Console.Write("Enter publisher: ");
            string publisher = Console.ReadLine();

            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();

            Console.Write("Enter price: ");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            // return object of book with the input values
            return new Book(title, author, publisher, isbn, price, stock);
        }
        static string menu()
        {
            // menu options
            Console.WriteLine("1. Add a new Book");
            Console.WriteLine("2. Search Book by Title");
            Console.WriteLine("3. Search Book by ISBN");
            Console.WriteLine("4. Add Stock for a Book");
            Console.WriteLine("5. Add a new Member");
            Console.WriteLine("6. Search Member by ID or Name");
            Console.WriteLine("7. Update Member Information");
            Console.WriteLine("8. Purchase a Book");
            Console.WriteLine("9. Display Sale and Membership Stats");
            Console.WriteLine("10. Exit");

            // input
            Console.Write("\nEnter option: ");
            return Console.ReadLine();
        }
        static void errorMessage(string msg)
        {
            Console.WriteLine(msg);
            pressAnyKey();
        }
        static void pressAnyKey()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
