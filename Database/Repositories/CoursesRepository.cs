using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchestration;

namespace Database.Repositories
{
    public class CoursesRepository : Repository
    {
        /// <summary>
        /// Get user from the users table.
        /// </summary>
        /// <param name="userName">Filter by user name.</param>
        /// <returns>The users.</returns>
        public IEnumerable<Course> GetCourse(Guid? courseId)
        {
            using (var conn = CreateConnection())
            {
                using (var command = conn.CreateCommand())
                {
                    // Create query
                    StringBuilder query = new StringBuilder("SELECT * FROM COURSES");

                    // Check if we to filter by user name
                    if (courseId != null)
                    {
                        query.Append(" WHERE course_id = '" + courseId + "'");
                    }

                    // Create the sample database
                    command.CommandText = query.ToString();
                    using (var reader = command.ExecuteReader())
                    {
                        // Loop over the results
                        while (reader.Read())
                        {
                            yield return new Course()
                            {
                                Id = Guid.Parse(reader["course_id"].ToString()),
                                Name = reader["course_name"].ToString().Trim(),
                            };
                        }
                    }

                    conn.Close();
                }
            }
        }

        public void AddCourse(Guid courseId, string courseName)
        {
            using (var conn = CreateConnection())
            {
                using (var command = conn.CreateCommand())
                {
                    // Create query
                    StringBuilder query = new StringBuilder(string.Format("INSERT INTO COURSES VALUES ('{0}', '{1}')", courseId, courseName));

                    // Create the sample database
                    command.CommandText = query.ToString();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (InvalidOperationException)
                    {
                        throw new DatabaseException("Failed on creating new course");
                    }

                    conn.Close();
                }
            }
        }
    }
}
