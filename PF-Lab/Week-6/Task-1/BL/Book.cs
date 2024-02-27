using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class Book
    {
        private string Title;
        private Author BookAuthor;
        public Book(string title, Author author) 
        {
            Title = title;
            BookAuthor = new Author(author.GetName());
        }
        public void SetTitle(string title)
        {
            Title = title;
        }
        public string GetTitle()
        {
            return $"Title: {Title}";
        }
        public string GetAuthorName()
        {
            return $"Name Of Auhtor: {BookAuthor.GetName()}";
        }
    }
}
