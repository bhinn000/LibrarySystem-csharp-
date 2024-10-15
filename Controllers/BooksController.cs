using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly List<Book> books = new List<Book>();
        private readonly List<Member> members = new List<Member>();
        private readonly List<Borrow> borrows = new List<Borrow>();

        //controller
        public BooksController()
        {
            
            books.Add(new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", 180));
            books.Add(new Book(2, "1984", "George Orwell", 328));
            books.Add(new Book(3, "To Kill a Mockingbird", "Harper Lee", 281));
            books.Add(new Book(4, "Moby Dick", "Herman Melville", 585));
        }


        ////Get all books ,{HttpGet] , an attribute
        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            Console.WriteLine($"Number of books: {books.Count}");
            foreach (var book in books)
            {
                Console.WriteLine($"Book: {book.Id}, Title: {book.Title}, Author: {book.Author}, Pages: {book.Pages}");
            }

            return books; //where is "books" , ans : books come from the list mentioned above
        }

        //[HttpGet]
        //public ActionResult<string> GetAllBooks()
        //{
        //    return "API is working"; // Test to see if you get this response
        //}

        //Get books by Id
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);//where is b 
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //to add new book in a library
        [HttpPost]
        public ActionResult AddBook(Book newBook)
        { //  IsNullOrWhiteSpace , why String was used here , popular response
            if (newBook == null || string.IsNullOrWhiteSpace(newBook.Title))
            {
                return BadRequest("Invalid Book data");
            }
            books.Add(newBook);
            return Ok("Book added sucessfully");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book UpdatedBook)
        {
            if (UpdatedBook == null)
            {
                return BadRequest("Updated book data is required.");
            }

            //// Get the existing book details by ID
            //var existingBook = books.FirstOrDefault(b => b.Id == id);

            //if (existingBook == null)
            //{
            //    return NotFound($"Book with ID {id} not found.");
            //}

            //// Update the book details
            //existingBook.Title = UpdatedBook.Title;
            //existingBook.Author = UpdatedBook.Author;
            //existingBook.Pages = UpdatedBook.Pages;
 
            // Return the updated book as a response
            return Ok("HI"); 
        }



        //delete a book
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var bookResult = GetBookById(id); //GetBookById method can either return a Book object or a NotFound result
            // Check if the book was found
            if (bookResult.Result is NotFoundResult)
            {
                return NotFound();
            }

            // Extract the Book object from the ActionResult
            var toDelete = bookResult.Value;

            if (toDelete == null)
            {
                return NotFound();
            }

            // Remove the book from the list
            books.Remove(toDelete);
            Console.WriteLine($"Book with ID {id} deleted successfully.");
            return NoContent();

        }

        //search a book
        public IEnumerable<Book> SearchBooks(string searchItem)
        {
            var results = books.Where(b => b.Title.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(searchItem, StringComparison.OrdinalIgnoreCase));
            if (!results.Any())
            {
                return Enumerable.Empty<Book>(); // Returning empty list if no matches found
            }
            return results;
        }


        //issue a book 
        public ActionResult IssueBook(int bookId, string memberId)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            var member = members.FirstOrDefault(m => m.MemId == memberId);

            if (book == null || !book.IsAvailable || member == null)
            {
                return BadRequest("Book is not available or member doesn't exist");
            }

            book.IsAvailable = false;
            borrows.Add(new Borrow(borrows.Count + 1, book, member)); //why are we passing complete object here not only parameter
            return Ok(); //why are we not using 
        }

       
       
    }
}
