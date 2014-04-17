using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientAction;
using Microsoft.Expression.Encoder.ScreenCapture;

namespace rectangle
{
    public partial class WhiteBoard : Form
    {
        private Bitmap bitmap;
        private Graphics m_graphic;//this class contains methods for drawing shapes and other stuff such as drawLine etc
        private Pen myPen = new Pen(Color.Black, 1);
        private Point ep = new Point(0, 0);
        private Point sp = new Point(0, 0);
        private int k = 0;
        private Guid m_courseId;
        private string m_userName;
        private string m_FolderName;
        private int m_FileNumber;
        private readonly ClientActions m_clientActions = new ClientActions();
        private bool m_isRecord = false;
        private ScreenCaptureJob screenCaptureJob = new ScreenCaptureJob();
        private int m_RecourdCount = 0;

        // Contains the saves files
        private List<string> m_filesPath = new List<string>();

        public WhiteBoard(Guid courseId, string userName)
        {
            InitializeComponent();
            bitmap = new Bitmap(this.Width, this.Height);
            m_courseId = courseId;
            m_userName = userName;
            m_FileNumber = 0;
            m_FolderName = string.Format(@"c:\TempClass\{0}", DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss"));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            sp = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                k = 1;
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (k == 1)
            {
                ep = e.Location;
                // DrawToBitmap(bitmap, new Rectangle())
                m_graphic = this.CreateGraphics();
                m_graphic.DrawLine(myPen, sp, ep);
                //m_graphic.DrawEllipse(myPen, sp.X, sp.Y, Math.Abs(sp.X - ep.X), myPen.Width);
            }
            sp = ep;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            k = 0;
        }

        private void red_Click(object sender, EventArgs e)
        {
            myPen.Color = red.BackColor;
            pictureBox1.BackColor = red.BackColor;
        }

        private void green_Click(object sender, EventArgs e)
        {
            myPen.Color = green.BackColor;
            pictureBox1.BackColor = green.BackColor;
        }

        private void yellow_Click(object sender, EventArgs e)
        {
            myPen.Color = yellow.BackColor;
            pictureBox1.BackColor = yellow.BackColor;
        }

        private void blue_Click(object sender, EventArgs e)
        {
            myPen.Color = blue.BackColor;
            pictureBox1.BackColor = blue.BackColor;
        }

        private void white_Click(object sender, EventArgs e)
        {
            myPen.Color = white.BackColor;
            pictureBox1.BackColor = white.BackColor;
        }

        private void black_Click(object sender, EventArgs e)
        {
            myPen.Color = black.BackColor;
            pictureBox1.BackColor = black.BackColor;
        }

        private void orange_Click(object sender, EventArgs e)
        {
            myPen.Color = orange.BackColor;
            pictureBox1.BackColor = orange.BackColor;
        }

        private void pink_Click(object sender, EventArgs e)
        {
            myPen.Color = pink.BackColor;
            pictureBox1.BackColor = pink.BackColor;
        }

        private void purple_Click(object sender, EventArgs e)
        {
            myPen.Color = purple.BackColor;
            pictureBox1.BackColor = purple.BackColor;
        }

        private void maroon_Click(object sender, EventArgs e)
        {
            myPen.Color = maroon.BackColor;
            pictureBox1.BackColor = maroon.BackColor;
        }

        private void brown_Click(object sender, EventArgs e)
        {
            myPen.Color = brown.BackColor;
            pictureBox1.BackColor = brown.BackColor;
        }

        private void rubber_Click(object sender, EventArgs e)
        {
            myPen.Color = cyan.BackColor;
            pictureBox1.BackColor = cyan.BackColor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = rectangle.Properties.Resources.cross2;
        }

        private void pictureBox2_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox2.Image = rectangle.Properties.Resources.cross;
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {
            myPen.Color = eraserButton.BackColor;
            pictureBox1.BackColor = eraserButton.BackColor;
        }

        private void buttonGrid_Click(object sender, EventArgs e)
        {
            /*
                 for (int y = 0; y < this.Width; ++y)
                 {
                     g.DrawLine(myPen, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
                 }

                 for (int x = 0; x < numOfCells; ++x)
                 {
                     g.DrawLine(myPenf, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            
             * */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            myPen.Width = e.NewValue;
        }

        private void toolStripContainer1_ContentPanel_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
            Cursor = Cursors.Hand;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            //Cursor.Hide();
        }

        private void toolStripContainer1_ContentPanel_MouseLeave(object sender, EventArgs e)
        {
            //Cursor.Hide();
        }

        private void toolStripContainer1_TopToolStripPanel_MouseLeave(object sender, EventArgs e)
        {
            //  Cursor.Hide();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void red_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void green_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void yellow_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void blue_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void black_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void orange_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void pink_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void purple_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void maroon_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if we need to create temp file
            if (!Directory.Exists(m_FolderName))
            {
                Directory.CreateDirectory(m_FolderName);
            }

            string fileName = Path.Combine(m_FolderName, m_FileNumber + ".jpg");

            // Get file name
            using (Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // Remove all unnecessary items from screen
                    HideComponents();
                    g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                    ShowComponents();
                }

                bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("Screen saved!", "Operations succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Add this file path to list
            m_filesPath.Add(fileName);

            // Increase the file name
            m_FileNumber++;

            button2.Enabled = true;
        }

        private void HideComponents()
        {
            this.button1.Hide();
            this.toolStripContainer1.Hide();
            this.purple.Hide();
            this.pink.Hide();
            this.red.Hide();
            this.white.Hide();
            this.green.Hide();
            this.yellow.Hide();
            this.pictureBox1.Hide();
            this.pictureBox2.Hide();
        }

        private void ShowComponents()
        {
            this.button1.Show();
            this.toolStripContainer1.Show();
            this.purple.Show();
            this.pink.Show();
            this.red.Show();
            this.white.Show();
            this.green.Show();
            this.yellow.Show();
            this.pictureBox1.Show();
            this.pictureBox2.Show();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }

        private void ConvertImagesToPdf()
        {
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();
            v.PageStyle.PageSize.Auto();
            ArrayList arImageBytes = new ArrayList();

            foreach (var filePath in m_filesPath)
            {
                byte[] imageBytes = null;
                imageBytes = ReadByteArrayFromFile(filePath);
                if (imageBytes != null)
                    arImageBytes.Add(imageBytes);
            }

            string pdfFile = null;

            //Now the arImageBytes contains byte streams of each image
            //Lets convert it to PDF stream in memory
            byte[] pdf = v.ConvertImageStreamArrayToPDFStream(arImageBytes);
            if (pdf != null)
            {
                //Save PDF stream to a file
                pdfFile = Path.Combine(m_FolderName, "hardcopy.pdf");
                File.Delete(pdfFile);
                FileStream fs = File.OpenWrite(pdfFile);
                fs.Write(pdf, 0, pdf.Length);
                fs.Close();
            }

            // Open lesson name form
            LessonNameForm lessonNameForm = new LessonNameForm(pdfFile, m_userName, m_courseId);
            this.Hide();
            lessonNameForm.ShowDialog();

            this.Close();
        }

        public static byte[] ReadByteArrayFromFile(string fileName)
        {
            byte[] buff = null;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(fileName).Length;
                buff = br.ReadBytes((int)numBytes);
            }
            catch { }
            return buff;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create PDF file
            ConvertImagesToPdf();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var recordFullPath = new StringBuilder(m_FolderName + @"\\SessionRecord-" + m_RecourdCount + ".wmv");
            // Check if we recording or not
            if (m_isRecord)
            {
                RecordTimer.Stop();
                screenCaptureJob.Stop();
                var chooseLessonNameForm = new LessonNameForm(recordFullPath.ToString(), m_userName, m_courseId);
                this.Hide();
                chooseLessonNameForm.ShowDialog();
                this.Show();
                button2.Enabled = true;
                button1.Enabled = true;
                m_isRecord = false;
                button3.Text = "Start Recording!";
                pictureBox3.Visible = false;
                m_RecourdCount++;
                return;
            }
            else
            {
                button2.Enabled = false;
                button1.Enabled = false;
                m_isRecord = true;
                button3.Text = "Stop Recording!";
                RecordTimer.Start();
            }
            
            try
            {
                Rectangle _screenRectangle = Screen.PrimaryScreen.Bounds;
                screenCaptureJob.CaptureRectangle = _screenRectangle;
                screenCaptureJob.ShowFlashingBoundary = true;
                screenCaptureJob.ScreenCaptureVideoProfile.FrameRate = 20;
                screenCaptureJob.CaptureMouseCursor = true;

                screenCaptureJob.OutputScreenCaptureFileName = recordFullPath.ToString();
                if (File.Exists(screenCaptureJob.OutputScreenCaptureFileName))
                {
                    File.Delete(screenCaptureJob.OutputScreenCaptureFileName);
                }
                screenCaptureJob.Start();
            }
            catch (Exception) { }
        }

        private void RecordTimer_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
            }
            else
            {
                pictureBox3.Visible = true;
            }
        }
    }
}
