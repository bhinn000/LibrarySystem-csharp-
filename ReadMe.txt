Library System Components : 
Books , Members , BookBorrow , LibraryAdmin

Encapsulation: allow to control the access of the private fields ; get , set ; 

ControllerBase is a specialized base class for building APIs.
It provides essential methods for handling HTTP requests and responses.
It simplifies model binding and validation for incoming data.
It’s preferred for APIs that do not need to render views (HTML pages).

Object Initialization:
new Book { Id = 1, Title = "C# Basics", Author = "John Doe" } uses object initializer syntax,
a shorthand for creating an object and initializing its properties in one step.

Without the initializer, it looks like:

Book myBook = new Book();
myBook.Id = 1;
myBook.Title = "C# Basics";
myBook.Author = "John Doe";

ActionResult<List<Book>>:
ActionResult: This is the return type of the method , represents different kinds of HTTP responses
<List<Book>>: This specifies the type of data the ActionResult contains
In this case, the return will be a list of Book objects (List<Book>)
GetBooks(): This is the name of the method

Use ActionResult<T> when you're returning data (like object / list) along with an HTTP status code. This is very common for APIs.
Use ActionResult when you might return various HTTP status codes (like Ok(), NotFound(), BadRequest(), etc.) without returning data.
Use IActionResult when you're building more abstract or flexible code, like when you need more control over the response format.

readonly:
Purpose: Used to make a field or variable immutable after initialization (in the constructor).
Example: You can assign a value to a readonly field during its declaration or inside the constructor,
but it cannot be reassigned afterward.

public class Example
{
    public readonly int value = 10; // value can be set once here or in constructor.
}

const:
Usage: Can only be applied to primitive data types (e.g., int, string) or values that can be assigned at compile time.
Example: You can't use const with objects or reference types.

public const int MaxValue = 100; // Compile-time constant

static:
Purpose: Makes a member (method, field, property) belong to the class itself rather than to any instance of the class.
Example: A static method or variable is used to share data across instances.

public class Example
{
    public static int counter = 0; // Shared across all instances.
}

volatile:
Purpose: Tells the compiler that the value of a field might change at any time, especially in multi-threaded applications, and ensures that the value is always read from memory rather than a CPU cache.
Usage: Usually applied to simple data types like int, bool, etc.


BooksController is part of a typical ASP.NET MVC application, where it acts as a controller that handles HTTP requests related to books
In ASP.NET, controllers manage the incoming requests, process them (e.g., by interacting with models), and then return responses (e.g., HTML views, JSON data, etc.).

internal class, which means it is only accessible within the same assembly. 

***What is this***
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: H:\.NET Learn\LibrarySystem


ASP.NET Core uses System.Text.Json for serialization by default
fields dont get serialized by default in JSON , but properties does


ReadMe: 
When performing :

1) GetAllBooks https://localhost:53310/api/books
[
    {
        "Id": 1,
        "Title": "The Great Gatsby",
        "Author": "F. Scott Fitzgerald",
        "Pages": 180,
        "IsAvailable": true
    },
    {
        "Id": 2,
        "Title": "1984",
        "Author": "George Orwell",
        "Pages": 328,
        "IsAvailable": true
    },
    {
        "Id": 3,
        "Title": "To Kill a Mockingbird",
        "Author": "Harper Lee",
        "Pages": 281,
        "IsAvailable": true
    },
    {
        "Id": 4,
        "Title": "Moby Dick",
        "Author": "Herman Melville",
        "Pages": 585,
        "IsAvailable": true
    }
]

2)  Get by Id : https://localhost:53310/api/books/2
{
    "Id": 2,
    "Title": "1984",
    "Author": "George Orwell",
    "Pages": 328,
    "IsAvailable": true
}

3) Add books Post https://localhost:53310/api/books
{
    "Id": 3,
    "Title": "New Book Title",
    "Author": "New Author",
    "Pages": 150
}
Book added sucessfully

4) Update book details


