using System;
using System.Drawing;

namespace Drawing
{
    public class Circle : Shape
    {
        public Circle(Pen p, int x1, int y1) : base(p, x1, y1)
        {

        }
        public Circle(Pen p, int x1, int y1, int x2, int y2) : base(p, x1, y1, x2, y2)
        {
            GrowTo(x2, y2);
        }

        

        public override void Draw(Graphics graphics)
        {
            int x = Math.Min(X1, X2);
            int y = Math.Min(Y1, Y2);
            int w = Math.Max(X1, X2) - x;
            int h = Math.Max(Y1, Y2) - y;
            if (w > 0 && h > 0)
                graphics.DrawArc(Pen, x, y, w, h, 0F, 360F);
        }

        public override void GrowTo(int x2, int y2)
        {
            X2 = x2;
            Y2 = y2;

            int diameter = Math.Max(x2 - X1, y2 - Y1);

            X2 = X1 + diameter;
            Y2 = Y1 + diameter;
        }
    }
}