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
    public partial class CloudClassPainter : Form
    {

        private IList<Point> _pointList = new List<Point>();

        private bool penIsClicked = false;
        private bool eraserIsClicked = false;
        private bool mouseIsDown = false;
        private int penWidth = 22;
        private Pen pen;
        private Pen eraserPen;
        
        public CloudClassPainter()
        {
            InitializeComponent();
            pen  = new Pen(Color.Black, penWidth);
            eraserPen = new Pen(Color.White, penWidth);
        }

        private void ButtonPen_Click(object sender, PaintEventArgs e)
        {
            if(!penIsClicked) {
                unclickEraser();
                ButtonPen.BackColor = Color.Gray;
                penIsClicked = true;
            }
            else
            {
                unclickPen();
            }
        }

        private void unclickPen()
        {
            ButtonPen.BackColor = Color.LightGray;
            penIsClicked = false;
        }



        private void CloudClassPainter_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;
        }

        private void CloudClassPainter_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked() && mouseIsDown)
            {

                Graphics graphic = CreateGraphics();
                PointF point1 = new PointF(e.X, e.Y);
                if (eraserIsClicked)
                {
                    PointF point2 = new PointF(e.X, e.Y);
                    graphic.DrawLine(eraserPen, point1, point2);
                }
                else
                {
                    PointF point2 = new PointF(e.X, e.Y);
                    graphic.DrawLine(pen, point1, point2);

                }
            }
        }

        private bool isClicked()
        {
            return penIsClicked || eraserIsClicked;
        }

        private void CloudClassPainter_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }

        private void ButtonEraser_Click(object sender, PaintEventArgs e)
        {
            if (!eraserIsClicked)
            {
                unclickPen();

                ButtonEraser.BackColor = Color.Gray;
                eraserIsClicked = true;
            }
            else
            {
                unclickEraser();
            }
        }

        private void unclickEraser()
        {
            ButtonEraser.BackColor = Color.LightGray;
            eraserIsClicked = false;
        }

        private void ButtonColors_Click(object sender, EventArgs e)
        {
            unclickEraser();

            ColorDialog colorDialog = new ColorDialog();

            DialogResult result = colorDialog.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                pen.Color = colorDialog.Color;
            } 
        }

        private void ButtonSize_Click(object sender, EventArgs e)
        {

        }

        private void CloudClassPainter_Click(object sender, PaintEventArgs e)
        {
            if (isClicked() && mouseIsDown)
            {
                Graphics graphic = CreateGraphics();
                //graphic.DrawLines
                PointF point1 = new PointF(1, 1);
                if (eraserIsClicked)
                {
                    PointF point2 = new PointF(1, 1);
                    graphic.DrawLine(eraserPen, point1, point2);
                }
                else
                {
                    PointF point2 = new PointF(1, 1);
                    graphic.DrawLine(pen, point1, point2);

                }
            }
        }
    }
}
