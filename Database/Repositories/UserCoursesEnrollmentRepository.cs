using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchestration;

namespace Database.Repositories
{
    public class UserCoursesEnrollmentRepository : Repository
    {
        public IEnumerable<Course> GetCoursesForUser(string userName)
        {
            using (var conn = CreateConnection())
            {
                using (var command = conn.CreateCommand())
                {
                    // Create query
                    StringBuilder query = new StringBuilder(@"SELECT c.course_id, c.course_name FROM USERS u, COURSES c, 
USER_COURSE_ENROLLMENT uce where u.user_name = uce.user_name AND c.course_id = uce.course_id AND u.user_name = '" + userName + "'");

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

        public void AddCourseToUser(string userName, Guid courseId)
        {
            using (var conn = CreateConnection())
            {
                using (var command = conn.CreateCommand())
                {
                    // Create query
                    StringBuilder query = new StringBuilder(string.Format("INSERT INTO USER_COURSE_ENROLLMENT VALUES ('{0}', '{1}')", courseId, userName));

                    // Create the sample database
                    command.CommandText = query.ToString();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (InvalidOperationException)
                    {
                        throw new DatabaseException("Failed on adding new course to user");
                    }

                    conn.Close();
                }
            }
        }
    }
}
