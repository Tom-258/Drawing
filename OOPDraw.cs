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
            LineWidth.SelectedItem = "Medium";
            Colour.SelectedItem = "Green";
            Shape.SelectedItem = "Line";
            Action.SelectedItem = "Draw";
        }
        Pen currentPen = new Pen(Color.Red);
        private Rectangle selectionBox;

        private bool _dragging = false;
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
            if (selectionBox != null) selectionBox.Draw(gr);
        }

        private void OOPDraw_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            startOfDrag = lastMousePosition = e.Location;
            switch (Action.Text)
            {
                case "Draw":
                    AddShape(e);
                    break;
                case "Select":
                    var p = new Pen(Color.Black, 1.0F);
                    selectionBox = new Rectangle(p, startOfDrag.X, startOfDrag.Y);
                    break;
            }
        }

        private void AddShape(MouseEventArgs e)
        {
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
            if (_dragging)
            {
                {
                    
                    switch (Action.Text)
                    {
                        case "Move":
                            MoveSelectedShapes(e);
                            break;
                        case "Draw":
                            var shape = shapes.Last();
                            shape.GrowTo(e.X, e.Y);
                            break;
                        case "Select":
                            selectionBox.GrowTo(e.X, e.Y);
                            SelectShapes();
                            break;
                    }

                    lastMousePosition = e.Location;
                    Refresh();
                }
            }
        }

        private void OOPDraw_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
            lastMousePosition = Point.Empty;
            selectionBox = null;
            Refresh();
        }

        private void LineWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var width = currentPen.Width;
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
            var color = currentPen.Color;
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

        private void Action_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Action.Text)
            {
                case "Group":
                    GroupSelectedShapes();
                    break;
            }
        }
        private void DeselectAll()
        {
            
            foreach (Shape s in shapes)
            {
                s.Deselect();
            }
            
        }

        private void SelectShapes()
        {
            DeselectAll();
            foreach (Shape s in shapes)
            {
                if (selectionBox.FullySurrounds(s)) s.Select();
            }
        }
        private List<Shape> GetSelectedShapes()
        {
            return shapes.Where(s => s.Selected).ToList();
        }
        private void MoveSelectedShapes(MouseEventArgs e)
        {
            foreach (Shape s in GetSelectedShapes())
            {
                s.MoveBy(e.X - lastMousePosition.X, e.Y - lastMousePosition.Y);
            }
        }
        private void GroupSelectedShapes()
        {
            var members = GetSelectedShapes();
            if (members.Count < 2) return; //Group has no effect
            CompositeShape compS = new CompositeShape(members);
            compS.Select();
            shapes.Add(compS);
            foreach (Shape m in members)
            {
                shapes.Remove(m);
                m.Deselect();
            }
            Refresh();
        }
    }
}
