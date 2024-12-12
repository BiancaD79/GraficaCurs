using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPalette
{

    internal class Palette
    {
        public static Random random = new Random();
        public PointF location;
        public Color color;
        public int pound;
        public Palette(int maxX, int maxY)
        {
            pound = 1;
            location = new PointF(random.Next(maxX),random.Next(maxY));
            color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        public void Draw(Graphics handler)
        {
            handler.FillEllipse(new SolidBrush(color)
                , location.X - 2, location.Y - 2, 5, 5); ;
            handler.DrawEllipse(Pens.Black
                , location.X - 2, location.Y - 2, 5, 5); ;
        }
    }
}
