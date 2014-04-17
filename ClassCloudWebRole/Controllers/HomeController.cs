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

        public ActionResult Index()
        {
            ViewBag.userCourses = new List<Course>();

            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                ViewBag.userCourses = m_ClientActions.GetCourses();
            }

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
            ViewBag.Message = "Course page.";
            string courseId = Request["courseId"];

            return View();
        }
    }
}