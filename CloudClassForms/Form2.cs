using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudClassForms
{
    public partial class Form2 : Form
    {
        private Bitmap buffer;
        private bool penIsClicked = false;
        private bool penIsDown = false;
        public Form2()
        {
            InitializeComponent();

            panel1_Resize(this, null);
        }

        private void ButtonPen_Click(object sender, EventArgs e)
        {
            if (!penIsClicked)
            {
                //unclickEraser();
                ButtonPen.BackColor = Color.Gray;
                penIsClicked = true;
            }
            else
            {
                unclickPen();
            }

        }

        private void PaintBlueRectangle()
        {
            // Draw blue rectangle into the buffer
            using (Graphics bufferGrph = Graphics.FromImage(buffer))
            {
                bufferGrph.DrawRectangle(new Pen(Color.Blue, 1), 1, 1, 100, 100);
            }

            // Invalidate the panel. This will lead to a call of 'panel1_Paint'
            panel1.Invalidate();
        }

        private void unclickPen()
        {
            penIsClicked = false;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the buffer into the panel
            e.Graphics.DrawImageUnscaled(buffer, Point.Empty);

        }


        private void panel1_Resize(object sender, EventArgs e)
        {
            // Resize the buffer, if it is growing
            if (buffer == null ||
                buffer.Width < panel1.Width ||
                buffer.Height < panel1.Height)
            {
                Bitmap newBuffer = new Bitmap(panel1.Width, panel1.Height);
                if (buffer != null)
                    using (Graphics bufferGrph = Graphics.FromImage(newBuffer))
                        bufferGrph.DrawImageUnscaled(buffer, Point.Empty);
                buffer = newBuffer;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            penIsDown = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            penIsDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (penIsDown)
            {
                using (Graphics bufferGrph = Graphics.FromImage(buffer))
                {
                    bufferGrph.DrawEllipse(new Pen(Color.Blue, 4), e.X, e.Y, 4, 4);
                }
                // Invalidate the panel. This will lead to a call of 'panel1_Paint'
                panel1.Invalidate();
            }
        }


    }
}
