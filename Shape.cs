﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Drawing
{
    public abstract class Shape
    {
        public Pen Pen { get; protected set; }

        public int X1 { get; protected set; }

        public int X2 { get; protected set; }

        public int Y1 { get; protected set; }

        public int Y2 { get; protected set; }
        public bool Selected { get; private set; }

        public Shape(Pen p, int x1, int y1, int x2, int y2)
        {
            Pen = new Pen(p.Color, p.Width);
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public Shape(Pen p, int x1, int y1) : this(p, x1, y1, x1, y1)
        {
            
        }

        public (int, int, int, int) EnclosingRectangle()
        {
            var x = Math.Min(X1, X2);
            var y = Math.Min(Y1, Y2);
            var w = Math.Max(X1, X2) - x;
            var h = Math.Max(Y1, Y2) - y;
            return (x, y, w, h);
        }
        public abstract void Draw(Graphics graphics);

        public virtual void GrowTo(int x2, int y2)
        {
            X2 = x2;
            Y2 = y2;
        }

        public virtual void MoveBy(int deltaX, int deltaY)
        {
            X1 += deltaX;
            X2 += deltaX;
            Y1 += deltaY;
            Y2 += deltaY;
        }
        public void Select()
        {
            Selected = true;
            Pen.DashStyle = DashStyle.Dash;
        }
        public void Deselect()
        {
            Selected = false;
            Pen.DashStyle = DashStyle.Solid;
        }
    }

}