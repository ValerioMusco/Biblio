using BiblioDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioDomain.Enums;

namespace Biblio_DAL.Repositories {
    public abstract class GenericRepository<T, U> : IGenericRepository<T, U> where T : class {

        protected readonly string _connection;
        private readonly string _table;
        private readonly string _tableId;

        public GenericRepository(string table, string tableId) {

            _connection = @"Server=DESKTOP-95QLTBL;Database=BiblioDB;Trusted_Connection=True;";
            _table = table;
            _tableId = tableId;
        }

        public void GenerateParameter( IDbCommand dbCommand, string parameterName, object? value ) {

            IDataParameter parameter = dbCommand.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value ?? DBNull.Value;
            dbCommand.Parameters.Add( parameter );
        }
        
        public abstract T Convert( IDataRecord dataRecord );

        public abstract T Create( T t );

        public abstract bool Update( int id, T t );

        public IEnumerable<T> ReadAll() {

            using( IDbConnection connection = new SqlConnection( _connection ) ) {

                using( IDbCommand dbCommand = connection.CreateCommand() ) {

                    dbCommand.CommandText = $"SELECT * FROM {_table}";

                    connection.Open();
                    IDataReader reader = dbCommand.ExecuteReader();

                    while( reader.Read() )
                        yield return Convert( reader );
                }
            }
        }

        public T ReadOne(U id) {

            using( IDbConnection connection = new SqlConnection( _connection ) ) {

                using( IDbCommand dbCommand = connection.CreateCommand() ) {

                    dbCommand.CommandText = $"SELECT * FROM {_table} " +
                                            $"WHERE {_tableId} = @id";

                    GenerateParameter( dbCommand, "id", id );

                    connection.Open();

                    IDataReader reader = dbCommand.ExecuteReader();
                    if( !reader.Read() )
                        throw new Exception( "Error" );

                    T newT = Convert( reader );
                    connection.Close();
                    return newT;
                }
            }
        }
        
        public bool Delete(U id) {

            using( IDbConnection dbConnection = new SqlConnection( _connection ) ) {

                using( IDbCommand dbCommand = dbConnection.CreateCommand() ) {

                    dbCommand.CommandText = $"DELETE FROM {_table} " +
                                            $"WHERE {_tableId} = @id";

                    GenerateParameter(dbCommand, "id", id );

                    dbConnection.Open();
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
                }
            }
        }
    }
}
