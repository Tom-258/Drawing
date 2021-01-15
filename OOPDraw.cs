using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public partial class OOPDraw : Form
    {
        public OOPDraw()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        Pen currentPen = new Pen(Color.Red);

        private bool dragging = false;
        Point startOfDrag = Point.Empty;
        Point lastMousePosition = Point.Empty;

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            gr.DrawLine(currentPen,startOfDrag,lastMousePosition);
        }

        private void OOPDraw_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startOfDrag = lastMousePosition = e.Location;
        }

        private void OOPDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                lastMousePosition = e.Location;
                Refresh();
            }
        }

        private void OOPDraw_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
