using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchestration;
using Database.Repositories;

namespace PipelineManagments
{
    public class PipelineManagment
    {
        // Repositories
        private readonly UsersRepository m_userRepository = new UsersRepository();
        private readonly CoursesRepository m_CoursesRepository = new CoursesRepository();
        private readonly TeacherCourseEnrollmentRepository m_teacherCourseEnrollmentRepository = new TeacherCourseEnrollmentRepository();
        private readonly UserCoursesEnrollmentRepository m_userCourseEnrollmentRepository = new UserCoursesEnrollmentRepository();

        public IEnumerable<User> GetUsers(string userName)
        {
            return m_userRepository.GetUsers(userName);
        }

        public void AddUser(string userName, bool isTeacher)
        {
            m_userRepository.AddUser(userName, isTeacher);
        }

        public IEnumerable<Course> GetCourses(Guid? courseId)
        {
            return m_CoursesRepository.GetCourse(courseId);
        }

        public void AddCourse(Guid courseId, string courseName)
        {
            m_CoursesRepository.AddCourse(courseId, courseName);
        }

        public IEnumerable<Course> GetCoursesForUser(string userName)
        {
            return m_userCourseEnrollmentRepository.GetCoursesForUser(userName);
        }

        public void AddCourseForUser(string userName, Guid courseId)
        {
            m_userCourseEnrollmentRepository.AddCourseToUser(userName, courseId);
        }

        public IEnumerable<Course> GetCoursesForTeacher(string userName)
        {
            return m_teacherCourseEnrollmentRepository.GetCoursesForTeacher(userName);
        }
        
        public void AddCourseForTeacher(string userName, Guid courseId)
        {
            m_teacherCourseEnrollmentRepository.AddCourseToTeacher(userName, courseId);
        }

        public void DeleteCourse(Guid courseId)
        {
            m_CoursesRepository.DeleteCourse(courseId);
        }
    }
}
