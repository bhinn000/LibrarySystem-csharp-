Using Postman, we can perform following functions.

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


