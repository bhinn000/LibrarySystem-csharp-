using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    internal class Borrow
    {
        public int LoanId { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedTime { get; set;}


        public Borrow(int loanId, Book book, Member member)
        {
            LoanId = loanId;  
            Book = book; 
            Member = member; 
            BorrowedDate = DateTime.Now;  // Records the current date as the borrowed date
        }

        public void ReturnBook()
        {
            ReturnedTime = DateTime.Now;
            Book.IsAvailable=true;
        }

    }
} 
 



