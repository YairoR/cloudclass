using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipelineManagments;
using Orchestration;
using System.IO;

namespace ClientAction
{
    public class ClientActions
    {
        private readonly PipelineManagment m_pipelineManagment = new PipelineManagment();

        public IEnumerable<User> GetUsers(string userName = null)
        {
            return m_pipelineManagment.GetUsers(userName);
        }

        public void AddUser(string userName, bool isTeacher)
        {
            m_pipelineManagment.AddUser(userName, isTeacher);
        }

        public IEnumerable<Course> GetCourses(Guid? courseId = null)
        {
            return m_pipelineManagment.GetCourses(courseId);
        }

        public void AddCourse(Guid courseId, string courseName)
        {
            m_pipelineManagment.AddCourse(courseId, courseName);
        }

        public IEnumerable<Course> GetCoursesForUser(string userName)
        {
            return m_pipelineManagment.GetCoursesForUser(userName);
        }

        public void AddCourseForUser(string userName, Guid courseId)
        {
            m_pipelineManagment.AddCourseForUser(userName, courseId);
        }

        public IEnumerable<Course> GetCoursesForTeacher(string userName)
        {
            return m_pipelineManagment.GetCoursesForTeacher(userName);
        }

        public void AddCourseForTeacher(string userName, Guid courseId)
        {
            m_pipelineManagment.AddCourseForTeacher(userName, courseId);
        }

        public void DeleteCourse(Guid courseId)
        {
            m_pipelineManagment.DeleteCourse(courseId);
        }

        public void uploadToBlob(Guid courseId, string fileName, FileStream fileStream)
        {
            m_pipelineManagment.uploadToBlob(courseId, fileName, fileStream);
        }

        public string getBlobUri(Guid courseId, string blobName)
        {
            return m_pipelineManagment.getBlobUri(courseId, blobName);
        }

        public List<BlobFileresult> getBlobsUris(Guid courseId)
        {
            return m_pipelineManagment.getBlobsUris(courseId);
        }
    }
}
