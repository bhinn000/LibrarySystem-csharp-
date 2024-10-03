using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Admin
    {
        public List<Book> books = new List<Book>();
        public List<Member> members = new List<Member>();
        public List<Borrow> borrows = new List<Borrow>();
        public void AddBook(Book book) => books.Add(book);
        public void RegisterMember(Member member) => members.Add(member);

        // Issues a book to a member, if available
        public bool IssueBook(int bookId, string memberId)
        {
            //if there is it is object otherwise null
            var book = books.FirstOrDefault(b => b.Id == bookId && b.IsAvailable);  // Finds the book by ID if available
            var member = members.FirstOrDefault(m => m.MemId == memberId);  // Finds the member by ID  //LINQ method

            if (book != null && member != null) 
            {
                book.IsAvailable = false;  
                //Count is in built function
                borrows.Add(new Borrow(borrows.Count + 1, book, member));  // Creates a new borrow
                return true;  // Returns success if the loan was created
            }
            return false;  // Returns failure if the loan could not be created
        }

        // Returns a book based on the loan ID
        public bool ReturnBook(int loanId)
        {
            var loan = borrows.FirstOrDefault(l => l.LoanId == loanId && !l.ReturnedTime.HasValue);  // Finds the loan if not already returned
            if (loan != null)  // Checks if the loan exists
            {
                loan.ReturnBook();  // Calls the method to return the book
                return true;  // Returns success if the book was returned
            }
            return false;  // Returns failure if the book could not be returned
        }
    }
}
