using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl1_new
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // list of books
            List<Book> books = new List<Book>();

            string choice = "";  // choice for menu
            while (true)
            {
                Console.Clear();
                choice = menu();
                if (choice == "1")
                {
                    books.Add(addBook());
                }
                else if (choice == "2")
                {
                    // search for book by Title
                    searchBook(books ,"C#");
                }
                else if (choice == "3")
                {
                    // search for book by ISBN
                    searchBook(books, "123");
                }
                else if (choice == "4")
                {
                    // adding stock
                    books[1].AddStock(5);
                }
                else if (choice == "5")
                {
                    return;  // exit the program 
                }
                Console.ReadKey();
            }
        }
        static void searchBook(List<Book> books, string id)
        {
            // search for book by title
            foreach (Book book in books)
            {
                // searching from title
                if (book.CheckTitle(id))
                {
                    book.DisplayInfo();
                    break;
                }
                // searching from ISBN
                else if (book.CheckISBN(id))
                {
                    book.DisplayInfo();
                    break;
                }
            }
            // error msg
            Console.WriteLine("Book not found");
            Console.ReadKey();
        }
        static Book addBook()
        {
            // input
            Console.WriteLine("Enter title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Enter publisher: ");
            string publisher = Console.ReadLine();

            Console.WriteLine("Enter ISBN: ");
            string isbn = Console.ReadLine();

            Console.WriteLine("Enter price: ");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());
            // return object of book with the input values
            return new Book(title, author, publisher, isbn, price, stock);
        }
        static string menu()
        {
            // menu options
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Search book by title");
            Console.WriteLine("3. Search book by ISBN");
            Console.WriteLine("4. Add stock");
            Console.WriteLine("5. Exit");

            // input
            Console.WriteLine("Enter option: ");
            return Console.ReadLine();
        }
    }
}
