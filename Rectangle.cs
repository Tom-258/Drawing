﻿using System;
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
            var (x, y, w, h) = EnclosingRectangle();
            g.DrawRectangle(Pen, x, y, w, h);
        }
        public bool FullySurrounds(Shape s)
        {
            var (x, y, w, h) = this.EnclosingRectangle();
            var (xs, ys, ws, hs) = s.EnclosingRectangle();
            return x < xs && y < ys && x + w > xs + ws && y + h > ys + hs;
        }

    }
}