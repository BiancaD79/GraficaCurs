using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multigraf
{
    internal class Bezier
    {
        //Traseaza o linie de la A -> B
        //cu punct intermediar C
        PointF A, B, C;
        int k;
        Segment test1, test2;
        List<PointF> points; 
        public Bezier(PointF A, PointF B, PointF C, int k) 
        {
            this.A = A; this.B = B; this.C = C; this.k = k;

            test1 = new Segment(A, C, k);
            test2 = new Segment(C, B, k);

            Do();
        }

        public void Do()
        {
            points = new List<PointF>();

            for (int i = 0; i < k; i++)
            {
                PointF X = test1.GetPoint(i);
                PointF Y = test2.GetPoint(i);

                Segment temp = new Segment(X, Y, k);
                PointF t = temp.GetPoint(i);
                points.Add(t);
            }
        }

        public void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Red, A.X - 4,
                A.Y - 4, 9, 9);
            handler.DrawEllipse(Pens.Red, B.X - 4,
                B.Y - 4, 9, 9);
            handler.DrawEllipse(Pens.Green, C.X - 4,
                C.Y - 4, 9, 9);

            for (int i = 1; i <  k; i++)
            {
                handler.DrawLine(Pens.Black, points[i - 1],
                    points[i]);
            }

            handler.DrawLine(Pens.Black, points[k - 1],
                    B);

        }
    }
}
