using System.Drawing;

namespace Drawing
{
    public static class DrawingFunctions
    {
        public static void DrawClosedArc(Graphics graphics, Shape shape)
        {
            var (x,y,w,h) = shape.EnclosingRectangle();
            if (w > 0 && h > 0)
            {
                graphics.DrawArc(shape.Pen, x, y, w, h, 0F, 360F);
            }
        }
    }
}