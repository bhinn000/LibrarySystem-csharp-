using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Member
    {   
        public string MemId { get; set; }
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; } //list of object of Book class

        public Member(string memId, string name)
        {
            MemId = memId;
            Name = name;
            BorrowedBooks = new List<Book>();
        } 
    }
}
