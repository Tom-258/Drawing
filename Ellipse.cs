using System;
using System.Drawing;

namespace Drawing
{
    public class Ellipse : Shape
    {
        public Ellipse(Pen p, int x1, int y1, int x2, int y2) : base(p, x1, y1, x2, y2)
        {
        }

        public Ellipse(Pen p, int x1, int y1) : base(p, x1, y1)
        {
        }

        public override void Draw(Graphics graphics)
        {
            DrawingFunctions.DrawClosedArc(graphics, this);
        }
    }
}