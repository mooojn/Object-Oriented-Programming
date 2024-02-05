using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    internal class Book
    {
        public string Title;
        public string Author;
        public string PublicationYear;
        public int Price;
        public int QuantityInStock;
        public Book(string title, string author, string publicationYear, int price, int quantityInStock)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Price = price;
            QuantityInStock = quantityInStock;
        }
        public string GetTitle()
        {
            return "Title: " + Title;
        }
        public string GetAuthor()
        {
            return "Author: " + Author;
        }
        public string GetPublicationYear()
        {
            return "Publication Year: " + PublicationYear;
        }
        public string GetPrice()
        {
            return "Price: " + Price;
        }
        public void SellCopies(int numberOfCopies)
        {
            if (numberOfCopies <= QuantityInStock)
                QuantityInStock -= numberOfCopies;
            else
                Console.WriteLine("Not enough copies in stock");
        }
        public void Restock(int numberOfCopies)
        {
            QuantityInStock += numberOfCopies;
        }
        public void BookDetails()
        {
            // display book details in single line
            Console.Write(Title + "\t");
            Console.Write(Author + "\t");
            Console.Write(PublicationYear + "\t");
            Console.Write(Price + "\t");
            Console.Write(QuantityInStock);
        }
    }
}
