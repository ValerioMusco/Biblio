using BiblioDAL.Repositories;
using BiblioDomain.Entities;
using BiblioDomain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio_DAL.Repositories {
    public class BookRepository : GenericRepository<Book, int>, IBookRepository{

        public BookRepository() : base("Book", "ISBN") {

        }

        public override Book Create( Book book ) {

            using( IDbConnection connection = new SqlConnection( _connection ) ) {

                using( IDbCommand dbCommand = connection.CreateCommand() ) {


                    dbCommand.CommandText = "INSERT INTO BOOK " +
                        "OUTPUT INSERTED.* " +
                        "VALUES (@ISBN, " +
                        "@BookName, @Description, @Quantity, @Price, @Genre) ";
                    GenerateParameter( dbCommand, "ISBN", book.Isbn );
                    GenerateParameter( dbCommand, "BookName", book.BookName );
                    GenerateParameter( dbCommand, "Description", book.Description );
                    GenerateParameter( dbCommand, "Quantity", book.Quantity );
                    GenerateParameter( dbCommand, "Price", book.Price );
                    GenerateParameter( dbCommand, "Genre", book.Genre );

                    connection.Open();
                    IDataReader reader = dbCommand.ExecuteReader();

                    if( !reader.Read() )
                        throw new Exception( "Error" );

                    Book newBook = Convert( reader );
                    connection.Close();

                    return newBook;
                }
            }
        }

        public override bool Update( int isbn, Book book ) {

            using(IDbConnection dbConnection = new SqlConnection(_connection)) {

                using(IDbCommand dbCommand = dbConnection.CreateCommand()) {

                    dbCommand.CommandText = @"UPDATE Book " +
                                            "SET ISBN = @newIsbn, " +
                                            "BookName = @newBookName ," +
                                            "Description = @newDescription ," +
                                            "Quantity = @newQuantity ," +
                                            "Price = @newPrice ," +
                                            "Genre = @newGenre " +
                                            "WHERE ISBN = @isbn";

                    GenerateParameter( dbCommand, "isbn", isbn );
                    GenerateParameter( dbCommand, "newIsbn", book.Isbn );
                    GenerateParameter( dbCommand, "newBookName", book.BookName );
                    GenerateParameter( dbCommand, "newDescription", book.Description );
                    GenerateParameter( dbCommand, "newQuantity", book.Quantity );
                    GenerateParameter( dbCommand, "newPrice", book.Price );
                    GenerateParameter( dbCommand, "newGenre", book.Genre );

                    dbConnection.Open();
                    return dbCommand.ExecuteNonQuery() == 1 ?  true : false;
                }
            }
        }

        public override Book Convert( IDataRecord dataRecord ) {
            return new Book {
                Isbn = (int)dataRecord["ISBN"],
                BookName = (string)dataRecord["BookName"],
                Description = dataRecord["Description"] == DBNull.Value ? null : (string)dataRecord["Description"],
                Quantity = (int)dataRecord["Quantity"],
                Price = (decimal)dataRecord["Price"],
                Genre = Enum.Parse<Genre>( (string)dataRecord["Genre"] )
            };
        }
    }
}
