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
        public ChooseCourseForm(IEnumerable<Course> coursesList)
        {
            InitializeComponent();
            ListCourses.DataSource = coursesList.ToArray();
            ListCourses.DisplayMember = "Name";
        }
    }
}
