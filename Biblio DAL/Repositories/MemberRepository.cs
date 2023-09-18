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
    public class MemberRepository : GenericRepository<Member, int> ,IMemberRepository {

        public MemberRepository() : base("Member", "Id") {
        }

        public override Member Create( Member member ) {

            using( IDbConnection connection = new SqlConnection( _connection ) ) {

                using( IDbCommand dbCommand = connection.CreateCommand() ) {

                    dbCommand.CommandText = "INSERT INTO Member " +
                        "OUTPUT INSERTED.* " +
                        "VALUES (@UserName, @Password, @Privilege) ";

                    GenerateParameter( dbCommand, "UserName", member.UserName );
                    GenerateParameter( dbCommand, "Password", member.Password );
                    GenerateParameter( dbCommand, "Privilege", member.Privileges );

                    connection.Open();
                    IDataReader reader = dbCommand.ExecuteReader();

                    if( !reader.Read() )
                        throw new Exception( "Error" );

                    Member newMember = Convert( reader );
                    connection.Close();

                    return newMember;
                }
            }
        }

        public override bool Update( int id, Member member ) {

            using( IDbConnection dbConnection = new SqlConnection( _connection ) ) {

                using( IDbCommand dbCommand = dbConnection.CreateCommand() ) {

                    dbCommand.CommandText = "UPDATE Member SET " +
                                            "UserName = @newUserName ," +
                                            "Password = @newPassword ," +
                                            "Privilege = @newPrivilege " +
                                            "WHERE Id = @id";

                    GenerateParameter( dbCommand, "newUserName", member.UserName );
                    GenerateParameter( dbCommand, "id", id );
                    GenerateParameter( dbCommand, "newPassword", member.Password );
                    GenerateParameter( dbCommand, "newPrivilege", member.Privileges );

                    dbConnection.Open();
                    return dbCommand.ExecuteNonQuery() == 1 ? true : false;
                }
            }
        }

        public override Member Convert( IDataRecord dataRecord ) {

            return new Member {

                Id = (int)dataRecord["Id"],
                UserName = (string)dataRecord["UserName"],
                Password = (string)dataRecord["Password"],
                Privileges = (Privileges)(int)dataRecord["Privilege"]
            };
        }
    }
}
