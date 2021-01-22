using System;
using System.Drawing;

namespace Drawing
{
    public class Rectangle : Shape
    {
        public Rectangle(Pen p, int x1, int y1, int x2, int y2) : base(p, x1, y1, x2, y2)
        {
        }
        public Rectangle(Pen p, int x1, int y1) : base(p, x1, y1)
        {
        }
        public override void Draw(Graphics g)
        {
            int x = Math.Min(X1, X2);
            int y = Math.Min(Y1, Y2);
            int w = Math.Max(X1, X2) - x;
            int h = Math.Max(Y1, Y2) - y;
            g.DrawRectangle(Pen, x, y, w, h);
        }
       
    }
}