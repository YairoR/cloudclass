using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rectangle
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics m_graphic;//this class contains methods for drawing shapes and other stuff such as drawLine etc
        Pen myPen = new Pen(Color.Black, 1);
        Point ep = new Point(0, 0);
        Point sp = new Point(0, 0);
        int k = 0;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(this.Width, this.Height);
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
                m_graphic.DrawEllipse(myPen, sp.X, sp.Y, Math.Abs(sp.X-ep.X), myPen.Width);
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
            //Cursor.Hide();
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
            for (int i = 0; i < 10; i++)
            {
                m_graphic.DrawLine(myPen, i * 20, 0, i * 20, 10 * 20);
                m_graphic.DrawLine(myPen, 0, i * 20, 10 * 20, i * 20);
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }
    }
}
