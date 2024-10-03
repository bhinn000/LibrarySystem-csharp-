using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Book
    {
        //first write all of the attributes that will be in Book class
        //why it has to be public
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public bool IsAvailable { get; set; }

        //by default access is private
        public Book(int id, String title, String author, int pages)
        {
            this.Id = id;
            this.Title= title;
            this.Author= author;
            this.Pages= pages;
            this.IsAvailable= true;
        }

       
    }
}
