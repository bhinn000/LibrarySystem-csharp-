public class BooksController : ControllerBase
{
    //Get all books
    [HttpGet]
    public IEnumerable<Book> GetAllBooks()
    {
        return books; //where is "books"
    }

    //Get books by Id
    [HttpGet("{id}")]
    public Book GetBookById(int id)
    {
        return books.FirstOrDefault(b=>b.Id==id);//where is b 
    }

    //to add new book in a library
    public ActionResult AddBook(Book newBook)
    { //  IsNullOrWhiteSpace , why String was used here , popular response
        if (newBook == null || string.isNullOrWhiteSpace(newBook.Title) {
            return BadRequest("Invalid Book data")
        }
    }
      
    //why has it normally send response , why not data type as in nodejs
    public ActionResult UpdateBook(int id , Book UpdatedBook)
    {
        //to know the detail of the book with that specific id
        var existingBook = GetBookById(id);
        if (existingBook != null) {
            return NotFound();
        }

        existingBook.id=UpdatedBook.Id;
        existingBook.title=UpdatedBook.Title;
        existingBook.author=UpdatedBook.Author;
        return noContent(); //success

    }

    //delete a book
    public ActionResult DeleteBook(int id)
    {
        var toDelete = GetBookById(id);
        if (toDelete != null)
        {
            return NotFound();
        }
        books.Remove(todelete);
        return noContent(); //success
    }

    //search a book
    public IEnumerable<Book> SearchBooks(string searchItem)
    {
        return book.Where(b=>b.Title.Contains(searchItem,StringComparision.OrdinalIgnoreCase) ||
        b.Author.Contains(searchTerm,StringComparision.OrdinalIgnoreCase));
    }
    //what if it is empty

    //issue a book 
    public ActionResult IssueBook(int bookId , int memberId) 
    {
        var book=GetBookById(bookId); //why are we using two functions here
        var member = members.FirstOrDefault(m => m.id == memberId);

        if(book == null || !book.IsAvailable || member = null)
        {
            return BadRequest("Book is not available or member doesn't exist");
        }

        book.IsAvailable = false;
        borrows.Add(new Book(borrows.Count + 1 ,book,member)); //why are we passing complete object here not only parameter
        return Ok(); //why are we not using 
    }

    //returning a book
    public ActionResult ReturnBook(int loanId)
    {
        var bookborrowd=borrows.FindOrDefault(l=>l.id == loanId && !l.ReturnedDate.HasValue);
        if(bookborrowd == null)
        {
            return NotFound();
        }
        borrow.ReturnBook(); //where is ReturnBook()
        return NoContent();


    }

    //give list of book borrowed by a member
    public IEnumerable<Borrow> GetBookBorrowed(int memberId)
    {
        return borrows.Where(b => b.MemberId == memberId);
    }
   



}