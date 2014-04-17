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
        private ClientActions m_ClientActions = new ClientActions();

        private User m_CurrentUser = null;

        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(User.Identity.Name) && m_CurrentUser == null)
            {
                List<User> usersList = m_ClientActions.GetUsers(User.Identity.Name).ToList<User>();

                if (usersList.Count == 0)
                {
                    // No such user, create and store in database
                    m_ClientActions.AddUser(User.Identity.Name, false);
                }

                m_CurrentUser = m_ClientActions.GetUsers(User.Identity.Name).ElementAt(0);
            }

            ViewBag.userCourses = string.IsNullOrEmpty(User.Identity.Name) ? new List<Course>() : m_ClientActions.GetCourses();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Course()
        {
            ViewBag.isTeacher = m_CurrentUser == null ? false : m_CurrentUser.IsTeacher;
            ViewBag.Message = "Course page.";
            ViewBag.courseBlobs = m_ClientActions.getAllBlobsUnderCourse(Guid.Parse(Request["courseId"]));

            return View();
        }
    }
}