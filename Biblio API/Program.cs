using BiblioDomain.Entities;
using BiblioDomain.Entities;
using Biblio_API.FakeControllers;
using BiblioDomain.Entities;
using Biblio_Domain.DTOs;
using BiblioDomain.Enums;

BookFakeController bookFakeController = new();

BookFormDTO bookFormDTO = new(){

    Isbn = 222222,
    BookName = "Sherlock Holmes 2",
    Description = "Description",
    Quantity = 10,
    Price = 9.99M,
    Genre = Genre.Policier
};

Book? result = bookFakeController.Add(bookFormDTO);

if(result is not null )
    Console.WriteLine($"{result.Isbn} : {result.BookName}");

result = bookFakeController.GetBook(111111);

if( result is not null )
    Console.WriteLine( $"{result.Isbn} : {result.BookName} - {result.Description} - {result.Genre} - {result.Price} - {result.Quantity}" );

List<Book>? books = bookFakeController.GetBooks();

if( books is not null )
    foreach( Book book in books )
        Console.WriteLine( $"{book.Isbn} : {book.BookName} - {book.Description} - {book.Genre} - {book.Price} - {book.Quantity}" );
