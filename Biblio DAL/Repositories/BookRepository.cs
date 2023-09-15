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
    public class BookRepository : IBookRepository {

        private readonly string _connection;

        public BookRepository() {

            _connection = @"Server=DESKTOP-95QLTBL;Database=BiblioDB;Trusted_Connection=True;";
        }
        private static void GenerateParameter( IDbCommand dbCommand, string parameterName, object? value ) {

            IDataParameter parameter = dbCommand.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value ?? DBNull.Value;
            dbCommand.Parameters.Add( parameter );
        }

        private static Book Convert( IDataRecord dataRecord ) {

            return new Book {
                Isbn = (int)dataRecord["ISBN"],
                BookName = (string)dataRecord["BookName"],
                Description = dataRecord["Description"] == DBNull.Value ? null : (string)dataRecord["Description"],
                Quantity = (int)dataRecord["Quantity"],
                Price = (decimal)dataRecord["Price"],
                Genre = Enum.Parse<Genre>( (string)dataRecord["Genre"] )
            };
        }

        public Book Create( Book book ) {

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


        public bool Delete( int isbn ) {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> ReadAll() {
            using( IDbConnection connection = new SqlConnection( _connection ) ) {

                using( IDbCommand dbCommand = connection.CreateCommand() ) {

                    dbCommand.CommandText = "SELECT * FROM Book";

                    connection.Open();
                    IDataReader reader = dbCommand.ExecuteReader();

                    while( reader.Read() )
                        yield return Convert( reader );
                }
            }
        }

        public Book ReadOne( int isbn ) {

            using( IDbConnection connection = new SqlConnection( _connection ) ) {

                using( IDbCommand dbCommand = connection.CreateCommand() ) {

                    dbCommand.CommandText = "SELECT * FROM Book " +
                                            "WHERE ISBN = @isbn";

                    GenerateParameter( dbCommand, "isbn", isbn );

                    connection.Open();

                    IDataReader reader = dbCommand.ExecuteReader();
                    if(!reader.Read() )
                        throw new Exception( "Error" );

                    Book newBook = Convert( reader );
                    connection.Close();
                    return newBook;
                }
            }
        }

        public bool Update( int isbn, Book book ) {
            throw new NotImplementedException();
        }
    }
}
