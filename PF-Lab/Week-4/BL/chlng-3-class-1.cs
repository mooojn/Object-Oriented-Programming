using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace chlg3_new
{
    internal class Book
    {
        public string Title;
        public string Author;
        public string Publisher;
        public string ISBN;
        public int Price;
        public int Stock;
        // constructor to initialize the fields
        public Book(string title, string author, string publisher, string isbn, int price, int stock)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            ISBN = isbn;
            Price = price;
            Stock = stock;
        }
        public void ShowTitle()
        {
            Console.WriteLine("Title: " + Title);
        }
        public bool CheckTitle(string title)
        {
            return Title == title;
        }
        public bool CheckISBN(string isbn)
        {
            return ISBN == isbn;
        }
        public void ShowStock()
        {
            Console.WriteLine("Stock: " + Stock);
        }
        public void AddStock(int amount)
        {
            Stock += amount;
        }
        public int Buy()
        {
            return Price;
        }
        public void DisplayInfo()
        {
            Console.Write(Title + "\t");
            Console.Write(Author + "\t");
            Console.Write(Publisher + "\t");
            Console.Write(ISBN + "\t");
            Console.Write(Price + "\t");
            Console.WriteLine(Stock); 
        } 
    }
}
