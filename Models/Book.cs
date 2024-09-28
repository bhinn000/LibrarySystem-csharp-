using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    internal class Book
    {
        //first write all of the attributes that will be in Book class
        //why it has to be public
        public String Title;
        public int Pages;
        public String Author;
        public bool IsAvailable;

        Book(String title, String author, int pages)
        {
            this.Title= title;
            this.Author= author;
            this.Pages= pages;
            this.IsAvailable= true;
        }

    }
}
