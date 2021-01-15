﻿using System;
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
        List<Line> lines = new List<Line>();

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            foreach (var line in lines)
            {
                line.Draw(gr);
            }
        }

        private void OOPDraw_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startOfDrag = lastMousePosition = e.Location;
            lines.Add(new Line(currentPen, e.X, e.Y));
        }

        private void OOPDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                var currentLine = lines.Last();
                currentLine.GrowTo(e.X,e.Y);
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
