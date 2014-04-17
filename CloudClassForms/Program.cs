using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Repositories;

namespace CloudClassForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UsersRepository userRepo = new UsersRepository();
            CoursesRepository courseRepo = new CoursesRepository();
            UserCoursesEnrollmentRepository ucer = new UserCoursesEnrollmentRepository();
            TeacherCourseEnrollmentRepository tcer = new TeacherCourseEnrollmentRepository();

            // Create new user
            //userRepo.AddUser("yair7", false);
            var user = userRepo.GetUsers("yair4");
            MessageBox.Show(user.First().UserName);

            // Create new course
            var courseId = Guid.NewGuid();
            courseRepo.AddCourse(courseId, "somenewname");
            var course = courseRepo.GetCourse(courseId);
            MessageBox.Show(course.Count().ToString());

            // User course enrollment
            ucer.AddCourseToUser("yair4", courseId);
            var courseForUser = ucer.GetCoursesForUser("yair4");
            MessageBox.Show(courseForUser.Count().ToString());

            // Teacher course enrollment
            tcer.AddCourseToTeacher("yair4", courseId);
            var courseForTeacher = tcer.GetCoursesForTeacher("yair4");
            MessageBox.Show(courseForTeacher.Count().ToString());
            Application.Run(new Form2());
        }
    }
}
