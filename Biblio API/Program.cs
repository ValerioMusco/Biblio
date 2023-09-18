using BiblioDomain.Entities;
using Biblio_API.FakeControllers;
using Biblio_Domain.DTOs;
using BiblioDomain.Enums;

BookFakeController bookFakeController = new();

BookFormDTO bookFormDTO = new(){

    Isbn = 333333,
    BookName = "Sherlock Holmes 2",
    Description = "Description",
    Quantity = 10,
    Price = 9.99M,
    Genre = Genre.Policier
};

//Book? result; = bookFakeController.Add(bookFormDTO);

//if(result is not null )
//    Console.WriteLine($"{result.Isbn} : {result.BookName}");

//result = bookFakeController.GetBook( 222222 );

//if( result is not null )
//    Console.WriteLine( $"{result.Isbn} : {result.BookName} - {result.Description} - {result.Genre} - {result.Price} - {result.Quantity}" );

List<BookShortDTO>? books = bookFakeController.GetBooks();

if( books is not null )
    foreach( BookShortDTO book in books )
        Console.WriteLine( $"{book.Isbn} : {book.BookName} - {book.Price}" );

//bool updateReturn = bookFakeController.Update(222222, bookFormDTO);

//if( updateReturn ) {

//    result = bookFakeController.GetBook( 333333 );

//    if( result is not null )
//        Console.WriteLine( $"{result.Isbn} : {result.BookName} - {result.Description} - {result.Genre} - {result.Price} - {result.Quantity}" );
//}
//else
//    Console.WriteLine( "Aucun changement" );

//bool deleteReturn = bookFakeController.Delete(333333);

//if( deleteReturn )
//    Console.WriteLine( "Le livre à été supprimé avec succès" );
//else
//    Console.WriteLine( "Erreur lors de la suppression du livre" );

