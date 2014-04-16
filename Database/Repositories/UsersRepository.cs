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
                        query.Append("AND user_name = " + userName);
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
                                Name = reader["user_name"].ToString().Trim(),
                                IsTeacher = reader["is_teacher"].ToString().Equals("0") ? false : true
                            };
                        }
                    }

                    conn.Close();
                }
            }
        }

        public void AddUser(string userName)
        {
            using (var conn = CreateConnection())
            {
                using (var command = conn.CreateCommand())
                {
                    // Create query
                    StringBuilder query = new StringBuilder("INSERT INTO USERS VALUES ('yair', 'yair2', 1)");

                    // Create the sample database
                    command.CommandText = query.ToString();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
