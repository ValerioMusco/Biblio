using BiblioDomain.Entities;
using Biblio_API.FakeControllers;
using Biblio_Domain.DTOs;
using BiblioDomain.Enums;

//BookFakeController bookFakeController = new();

//BookFormDTO bookFormDTO = new(){

//    Isbn = 333333,
//    BookName = "Sherlock Holmes 2",
//    Description = "Description",
//    Quantity = 10,
//    Price = 9.99M,
//    Genre = Genre.Policier
//};

//Book? result; //= bookFakeController.Add(bookFormDTO);

//if(result is not null )
//    Console.WriteLine($"{result.Isbn} : {result.BookName}");

//result = bookFakeController.GetBook( 111111 );

//if( result is not null )
//    Console.WriteLine( $"{result.Isbn} : {result.BookName} - {result.Description} - {result.Genre} - {result.Price} - {result.Quantity}" );

//List<BookShortDTO>? books = bookFakeController.GetBooks();

//if( books is not null )
//    foreach( BookShortDTO book in books )
//        Console.WriteLine( $"{book.Isbn} : {book.BookName} - {book.Price}" );

//bool updateReturn = bookFakeController.Update(222222, bookFormDTO);

//if( updateReturn ) {

//    result = bookFakeController.GetBook( 333333 );

//    if( result is not null )
//        Console.WriteLine( $"{result.Isbn} : {result.BookName} - {result.Description} - {result.Genre} - {result.Price} - {result.Quantity}" );
//}
//else
//    Console.WriteLine( "Aucun changement" );

//bool deleteReturn = bookFakeController.Delete(321321);

//if( deleteReturn )
//    Console.WriteLine( "Le livre à été supprimé avec succès" );
//else
//    Console.WriteLine( "Erreur lors de la suppression du livre" );

MemberFakeController memberFakeController = new();

MemberFormDTO memberFormDTO = new (){

    UserName = "user",
    Password = "user",
    Privileges = Privileges.Member
};

//Member? result = memberFakeController.Add(memberFormDTO);
//if( result is not null )
//    Console.WriteLine( $"{result.Id}, {result.UserName}, {result.Password}, {result.Privileges}" );

bool deleteReturn = memberFakeController.Delete(4);
bool updateReturn = memberFakeController.Update(2, memberFormDTO);
List<Member>? results = memberFakeController.GetMembers();
Member? result = memberFakeController.GetMember(5);

if( deleteReturn )
    Console.WriteLine( "User 3 delete" );

if( updateReturn )
    Console.WriteLine( "User 2 modif" );

if(result != null )
    Console.WriteLine($"User 5 {result.Id}, {result.UserName}, {result.Password}, {result.Privileges}");

if( results != null )
    foreach( Member member in results ) Console.WriteLine( $"User {member.Id}, {member.UserName}, {member.Password}, {member.Privileges}" );
