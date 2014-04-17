using Orchestration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class UsersRepository : Repository
    {
        /// <summary>
        /// Get user from the users table.
        /// </summary>
        /// <param name="userName">Filter by user name.</param>
        /// <returns>The users.</returns>
        public IEnumerable<User> GetUsers(string userName)
        {
            using (var conn = CreateConnection())
            {
                using (var command = conn.CreateCommand())
                {
                    // Create query
                    StringBuilder query = new StringBuilder("SELECT * FROM USERS");
                    
                    // Check if we to filter by user name
                    if (userName != null)
                    {
                        query.Append(" WHERE user_name = '" + userName + "'");
                    }

                    // Create the sample database
                    command.CommandText = query.ToString();
                    using (var reader = command.ExecuteReader())
                    {
                        // Loop over the results
                        while (reader.Read())
                        {
                            yield return new User()
                            {
                                UserName = reader["user_name"].ToString().Trim(),
                                IsTeacher = reader["IsTeacher"].ToString().Equals("0") ? false : true
                            };
                        }
                    }

                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Add new user to Users table.
        /// </summary>
        /// <param name="userName">The user name - unique.</param>
        /// <param name="isTeacher">Is this user is teacher.</param>
        public void AddUser(string userName, bool isTeacher)
        {
            using (var conn = CreateConnection())
            {
                using (var command = conn.CreateCommand())
                {
                    // Create query
                    StringBuilder query = new StringBuilder(string.Format("INSERT INTO USERS VALUES ('{0}', {1})", userName, isTeacher ? "1" : "0"));

                    // Create the sample database
                    command.CommandText = query.ToString();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (InvalidOperationException)
                    {
                        throw new DatabaseException("Failed on adding new user");
                    }

                    conn.Close();
                }
            }
        }
    }
}
