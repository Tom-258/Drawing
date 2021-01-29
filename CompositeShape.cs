using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Drawing
{
    public class CompositeShape : Shape
    {
        private List<Shape> Components { get; set; }
        public CompositeShape(List<Shape> components)
            : base(new Pen(Color.Black, 1.0F), 0, 0, 0, 0)
        {
            Pen.DashStyle = DashStyle.Dash;
            Components = components;
            CalculateEnclosingRectangle();
        }
        private void CalculateEnclosingRectangle()
        {
            X1 = Components.Min(m => Math.Min((int) m.X1, (int) m.X2));
            Y1 = Components.Min(m => Math.Min(m.Y1, m.Y2));
            X2 = Components.Max(m => Math.Max(m.X1, m.X2));
            Y2 = Components.Max(m => Math.Max(m.Y1, m.Y2));
        }
        public override void Draw(Graphics g)
        {
            foreach (var m in Components)
            {
                m.Draw(g);
            }
            if (Selected) g.DrawRectangle(Pen, X1, Y1, X2 - X1, Y2 - Y1);
        }
        public override void MoveBy(int xDelta, int yDelta)
        {
            foreach (var m in Components)
            {
                m.MoveBy(xDelta, yDelta);
            }

            X1 += xDelta;
            Y1 += yDelta;
            X2 += xDelta;
            Y2 += yDelta;
        }
    }
}