using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientAction;

namespace rectangle
{
    public partial class LoginForm : Form
    {
        private ClientActions m_clientActions = new ClientActions();

        public LoginForm()
        {
            InitializeComponent();
        }

        private bool ValidateUserName()
        {
            if (string.IsNullOrEmpty(TextboxUserName.Text))
            {
                MessageBox.Show("אנא מלא שם משתמש");
                return false;
            }

            return true;
        }

        private bool CheckUserNameExistAndIsTeacher()
        {
            
            // Try to get user
            var user = m_clientActions.GetUsers(TextboxUserName.Text).First();

            if (user == null)
            {
                MessageBox.Show("שם משתמש לא קיים!", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return false;
            }

            if (!user.IsTeacher)
            {
                MessageBox.Show("עליך להיות מרצה על מנת להיכנס!", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return false;
            }
            
            return true;
        }

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            // Check we got user name
            if (!ValidateUserName())
            {
                return;
            }

            // Check user name
            if (!CheckUserNameExistAndIsTeacher())
            {
                return;
            }

            // Get all teacher courses
            var courses = m_clientActions.GetCoursesForTeacher(TextboxUserName.Text);
            var chooseCourseForm = new ChooseCourseForm(courses);

            this.Hide();
            chooseCourseForm.ShowDialog();

            // Load the white board
            WhiteBoard whiteBoardForm = new WhiteBoard();
            this.Hide();
            whiteBoardForm.ShowDialog();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
