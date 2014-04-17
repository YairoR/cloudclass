using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientAction;
using System.IO;

namespace rectangle
{
    public partial class LessonNameForm : Form
    {
        private readonly ClientActions m_clientActions = new ClientActions();
        private string m_filePath;
        private string m_userName;
        private Guid m_courseId;

        public LessonNameForm(string filePath, string userName, Guid courseId)
        {
            InitializeComponent();
            m_filePath = filePath;
            m_userName = userName;
            m_courseId = courseId;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // Upload to blob storage
            m_clientActions.uploadToBlob(m_courseId, TextBoxLessonName.Text, m_userName, new FileStream(m_filePath, FileMode.Open));

            this.Cursor = Cursors.Default;

            MessageBox.Show("Lecture saved", "Saved", MessageBoxButtons.OK);

            this.Close();
        }
    }
}
