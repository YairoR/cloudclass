using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orchestration;

namespace rectangle
{
    public partial class ChooseCourseForm : Form
    {
        private string m_userName;

        public ChooseCourseForm(IEnumerable<Course> coursesList, string userName)
        {
            InitializeComponent();
            ListCourses.DataSource = coursesList.ToArray();
            ListCourses.DisplayMember = "Name";
            m_userName = userName;
        }

        private void ListCourses_DoubleClick(object sender, EventArgs e)
        {
            var selectedCourse = ListCourses.SelectedItem as Course;
            if (selectedCourse != null)
            {
                var whiteBoardForm = new WhiteBoard(selectedCourse.Id, m_userName);
                this.Hide();
                whiteBoardForm.ShowDialog();
            }
        }
    }
}
