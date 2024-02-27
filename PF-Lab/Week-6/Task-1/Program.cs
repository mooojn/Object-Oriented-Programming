using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Author Authr = new Author("Author1");
            Book NewBook = new Book("Book1", Authr);

            Console.WriteLine(NewBook.GetTitle());
            Console.WriteLine(NewBook.GetAuthorName());

            Console.ReadKey();
        }
    }
}
