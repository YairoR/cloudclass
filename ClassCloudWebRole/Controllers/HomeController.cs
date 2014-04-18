using ClassCloudWebRole.Models;
using ClientAction;
using Orchestration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassCloudWebRole.Controllers
{
    public class HomeController : Controller
    {
        private static ClientActions m_ClientActions = new ClientActions();
        private static User m_CurrentUser = null;
        private static string m_CurrentCourse = null;

        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                if (m_CurrentUser == null)
                {
                    List<User> usersList = m_ClientActions.GetUsers(User.Identity.Name).ToList<User>();

                    if (usersList.Count == 0)
                    {
                        // No such user, create and store in database
                        m_ClientActions.AddUser(User.Identity.Name, false);
                    }

                    m_CurrentUser = m_ClientActions.GetUsers(User.Identity.Name).ElementAt(0);
                }
                else if (!User.Identity.Name.Equals(m_CurrentUser.UserName))
                {
                    // Different user, change current user
                    m_CurrentUser = m_ClientActions.GetUsers(User.Identity.Name).ElementAt(0);
                }


            }

            ViewBag.userCourses = string.IsNullOrEmpty(User.Identity.Name) ? new List<Course>() : m_ClientActions.GetCourses();

            return View();
        }

        public ActionResult MyCourses()
        {
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                if (m_CurrentUser == null)
                {
                    List<User> usersList = m_ClientActions.GetUsers(User.Identity.Name).ToList<User>();

                    if (usersList.Count == 0)
                    {
                        // No such user, create and store in database
                        m_ClientActions.AddUser(User.Identity.Name, false);
                    }

                    m_CurrentUser = m_ClientActions.GetUsers(User.Identity.Name).ElementAt(0);
                }
                else if (!User.Identity.Name.Equals(m_CurrentUser.UserName))
                {
                    // Different user, change current user
                    m_CurrentUser = m_ClientActions.GetUsers(User.Identity.Name).ElementAt(0);
                }


            }

            ViewBag.userCourses = string.IsNullOrEmpty(User.Identity.Name) ? new List<Course>() : m_ClientActions.GetCourses();

            return View();
        }

        public ActionResult Course()
        {
            ViewBag.isTeacher = m_CurrentUser == null ? false : m_CurrentUser.IsTeacher;
            ViewBag.Message = "Course page.";
            m_CurrentCourse = Request["courseId"];


            ViewBag.courseBlobs = m_CurrentCourse == null ? new List<BlobFileresult>() : m_ClientActions.getAllBlobsUnderCourse(Guid.Parse(m_CurrentCourse));

            return View();
        }

        [HttpPost]
        public ActionResult SaveStudentsToCourse(string[] students)
        {
            foreach(string student in students)
            {
                m_ClientActions.AddCourseForUser(student, Guid.Parse(m_CurrentCourse));
            }

            return RedirectToAction("Index");
        }

        public ActionResult CourseManager()
        {
            ViewBag.Message = "Course Management page.";
            ViewBag.students = m_ClientActions.GetUsers();
            ViewBag.courseId = m_CurrentCourse;

            return View();
        }
    }
}