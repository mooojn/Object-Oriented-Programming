
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // stuct
            List<Book> Books = new List<Book>();
        
            // for option
            string option;
            
            // main program loop
            while (true)
            {
                
                Console.Clear();
                option = menu();
                if(option == "1")
                {
                    Book newBook = GetBookDetails();
                    Books.Add(newBook);
                }
                else if (option == "2")
                {
                    Console.WriteLine("Title\tAuthor\tYear\tPrice\tStock");
                    // {book1, book2}
                    foreach (Book book in Books)
                    {
                        book.BookDetails();
                        Console.WriteLine();
                    }
                }
                else if (option == "3")
                {
                    Console.Write("Enter the Title of the Book to get Details of Author: ");
                    string title = Console.ReadLine();
                    
                    foreach(Book book in Books)
                    {
                        if (book.Title == title)
                        {
                            Console.WriteLine("Author: " + book.Author);
                            break;
                        }
                    }
                }
                else if (option == "4")
                {
                    bool status = func(Books, "Sell");
                    if (!status)
                        error("Book not found...");
                }
                else if (option == "5")
                {
                    bool status = func(Books, "Stock");
                    if (!status)
                        error("Book not found...");
                }
                else if (option == "6")
                {
                    Console.WriteLine("Total Books in Stock: " + Books.Count);
                }
                else if (option == "7")
                {
                    break;
                }
                else
                {
                    error("Invalid Option...");
                }
                pressAnyKey();
            }
        }
        static bool func(List<Book> Books, string type)
        {
            Console.Write("Enter the Title of the Book to " + type + ": ");
            string title = Console.ReadLine();

            foreach (Book book in Books)
            {
                if (book.Title == title)
                {
                    Console.WriteLine("Enter Amount to " + type + ": ");
                    int amount = int.Parse(Console.ReadLine());
                    if (type == "Stock")
                        book.Restock(amount);
                    else if (type == "Sell")
                        book.SellCopies(amount);
                    return true;
                }
            }
            return false;
        }
        static Book GetBookDetails()
        {
            Console.Write("Enter the Title of the Book: ");
            string title = Console.ReadLine();
            
            Console.Write("Enter the Author of the Book: ");
            string author = Console.ReadLine();
            
            Console.Write("Enter the Publication Year of the Book: ");
            string publicationYear = Console.ReadLine();
            
            Console.Write("Enter the Price of the Book: ");
            int price = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter the Quantity in Stock of the Book: ");
            int quantityInStock = Convert.ToInt32(Console.ReadLine());
            // return new book object
            return new Book(title, author, publicationYear, price, quantityInStock);
        }
        static string menu()
        {
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. View All the books Information");
            Console.WriteLine("3. Get the Author Details of a Specific Book");
            Console.WriteLine("4. Sell copies of a Specific Book");
            Console.WriteLine("5. Restock a Specific Book");
            Console.WriteLine("6. See the Count of the Books present in your Book List");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        static void error(string message)
        {
            Console.WriteLine(message);
            pressAnyKey();
        }
        static void pressAnyKey()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
