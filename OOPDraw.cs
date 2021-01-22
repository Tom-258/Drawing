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
            LineWidth.SelectedItem = "Medium";
            Colour.SelectedItem = "Green";
            Shape.SelectedItem = "Line";
        }

        Pen currentPen = new Pen(Color.Red);

        private bool dragging = false;
        Point startOfDrag = Point.Empty;
        Point lastMousePosition = Point.Empty;
        List<Shape> shapes = new List<Shape>();

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            foreach (Shape shape in shapes)
            {
                shape.Draw(gr);
            }
            
        }

        private void OOPDraw_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startOfDrag = lastMousePosition = e.Location;
            switch (Shape.Text)
            {
                case "Line":
                    shapes.Add(new Line(currentPen, e.X, e.Y));
                    break;
                case "Rectangle":
                    shapes.Add(new Rectangle(currentPen, e.X, e.Y));
                    break;
                case "Ellipse":
                    shapes.Add(new Ellipse(currentPen, e.X, e.Y));
                    break;
                case "Circle":
                    shapes.Add(new Circle(currentPen, e.X, e.Y));
                    break;
            }
        }

        private void OOPDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Shape shape = shapes.Last();
                shape.GrowTo(e.X,e.Y);
                lastMousePosition = e.Location;
                Refresh();
            }
        }

        private void OOPDraw_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void LineWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            float width = currentPen.Width;
            switch (LineWidth.Text)
            {
                case "Thin":
                    width = 2.0F;
                    break;
                case "Medium":
                    width = 4.0F;
                    break;
                case "Thick":
                    width = 8.0F;
                    break;
            }
            currentPen = new Pen(currentPen.Color, width);
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color color = currentPen.Color;
            switch (Colour.Text)
            {
                case "Red":
                    color = Color.Red;
                    break;
                case "Blue":
                    color = Color.Blue;
                    break;
                case "Green":
                    color = Color.Green;
                    break;
                case "Black":
                    color = Color.Black;
                    break;
            }
            currentPen = new Pen(color, currentPen.Width);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Shape_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
