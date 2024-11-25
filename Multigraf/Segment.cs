using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Multigraf
{
    internal class Segment
    {
        PointF A, B;
        int k;
        List<PointF> points;
        public Segment(PointF A, PointF B, int k)
        {
            this.A = A; this.B = B; this.k = k;
            Do();
        }

        public void Do()
        {
            points = new List<PointF>();
            for (int i = 0; i < k; i++)
            {
                float x = (k - i) * A.X + i * B.X;
                float y = (k - i) * A.Y + i * B.Y;
                points.Add(new PointF(x / k, y / k));
            }
        }

        public PointF GetPoint(int k) 
        {
            return points[k];
        }

        public void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Red, A.X - 5, A.Y - 5, 11, 11);
            handler.DrawEllipse(Pens.Red, B.X - 5, B.Y - 5, 11, 11);
            for (int i = 0; i < points.Count; i++)
            {
                if(i == 3)
                    handler.FillEllipse(Brushes.Blue, points[i].X - 2, points[i].Y - 2, 5, 5);
                handler.DrawEllipse(Pens.Black, points[i].X - 2, points[i].Y - 2, 5, 5);
            }

        }
    }
}
