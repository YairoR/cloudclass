using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class SqlManager
    {
        SqlConnection m_SQLConnection;

        public SqlManager(string dataSource, string userId, string password)
        {
            m_SQLConnection = new SqlConnection()
            {
                ConnectionString = string.Format(
                "Data Source={0};User ID={1};Password={2}",
                dataSource, 
                userId, 
                password)
            };
        }

        public string fetchUsersCourses(string userName)
        {
            if (userName == null)
            {
                return null;
            }

            string sqlString = 
                "SELECT c.course_name " +
                "FROM USERS u, COURSES c, USER_COURSE_ENROLLMENT uce " +
                "WHERE u.user_name = uce.user_name AND c.course_id = uce.course_id AND u.user_name = userName";

            SqlCommand sqlCommand = new SqlCommand(sqlString, m_SQLConnection);
            sqlCommand.Parameters.AddWithValue("@userName", userName);

            List<string> userCourses = new List<string>();

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    userCourses.Add((reader["course_name"].ToString()));
                }
            }

            return null;
        }
    }
}