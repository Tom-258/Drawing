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

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            currentPen.Width = 5;
            var gr = e.Graphics;
            var a = new Point(20,30);
            var b = new Point(400,500);
            var c = new Point(700, 500);
            gr.DrawLine(currentPen,a,b);
            gr.DrawLine(currentPen, b,c);
            gr.DrawLine(currentPen,c,a);
        }
    }
}
