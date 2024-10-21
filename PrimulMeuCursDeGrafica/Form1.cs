using System.Text;

namespace PrimulMeuCursDeGrafica
{
    public partial class Form1 : Form
    {
        MyGraphics myGraphics;
        static Random rnd = new Random();
        float a = 0, b = 0;

        public Form1()
        {
            InitializeComponent();
            myGraphics = new MyGraphics(pictureBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            DrawPolygon(myGraphics.grp, RegularPolygon(4, new PointF(250, 250), 150, 0));
            
            for (float a=0; a<=(float)(Math.PI * 2); a += 0.01f)
            {
                DrawPolygon(myGraphics.grp, RegularPolygon(4, new PointF(250, 250), 150, a));
            }

            float b = 0;
            for (float a = 0; a <= 200; a += 10, b += 0.1f)
            {
                DrawPoints(myGraphics.grp, RegularPolygon(6, new PointF(250, 250), a, b));

            }
            */
            button1.Text = "Start";

            //DrawPolygon(myGraphics.grp, IrregularPolygon(20, new PointF(250, 250), 100, 200, 0));

            //IrregularRec(myGraphics.grp, 5, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), 150, 200, 0);

            //RegularRec(myGraphics.grp, 20, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), 200, 0);

            float R = 200;
            //indicator de interzis vehicule
            /*
            FillPolygon(myGraphics.grp, RegularPolygon(360, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R, 0), Color.Red);
            FillPolygon(myGraphics.grp, RegularPolygon(360, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.8f, 0), Color.White);
            */

            //Indicator Drum cu prioritate
            /* 
            FillPolygon(myGraphics.grp, RegularPolygon(4, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R, 0), Color.Black);
            FillPolygon(myGraphics.grp, RegularPolygon(4, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.98f, 0), Color.White);
            FillPolygon(myGraphics.grp, RegularPolygon(4, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.6f, 0), Color.Yellow);
            */

            //Indicator Cedeaza
            /*
            FillPolygon(myGraphics.grp, RegularPolygon(3, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R, (float)Math.PI / 6 + (float)Math.PI), Color.Red);
            FillPolygon(myGraphics.grp, RegularPolygon(3, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.98f, (float)Math.PI / 6 + (float)Math.PI), Color.White);
            FillPolygon(myGraphics.grp, RegularPolygon(3, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.9f, (float)Math.PI / 6 + (float)Math.PI), Color.Red);
            FillPolygon(myGraphics.grp, RegularPolygon(3, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.3f, (float)Math.PI / 6 + (float)Math.PI), Color.White);
            */

            DrawSierpinski(myGraphics.grp, new PointF(130, 30), new PointF(20, 500), new PointF(750, 110));


            myGraphics.Refresh();
        }

        private static List<PointF> RegularPolygon(int n, PointF C, float R, float fi)
        {
            List<PointF> toReturn = new List<PointF>();

            float alpha = (float)(2 * Math.PI) / n;

            for (int i = 0; i < n; i++)
            {
                float x = C.X + R * (float)Math.Cos(i * alpha + fi);
                float y = C.Y + R * (float)Math.Sin(i * alpha + fi);
                toReturn.Add(new PointF(x, y));
            }
            return toReturn;
        }

        private List<PointF> IrregularPolygon(int n, PointF C, float minR, float maxR, float fi)
        {
            List<PointF> toReturn = new List<PointF>();

            float[] alpha = new float[n];
            float[] dist = new float[n];

            for (int i = 0; i < n; i++)
            {
                alpha[i] = (float)(rnd.NextDouble() * (float)(2 * Math.PI));
                dist[i] = (float)rnd.NextDouble() * (maxR - minR) + minR;
            }

            Array.Sort(alpha);

            for (int i = 0; i < n; i++)
            {
                float x = C.X + dist[i] * (float)Math.Cos(alpha[i] + fi);
                float y = C.Y + dist[i] * (float)Math.Sin(alpha[i] + fi);
                toReturn.Add(new PointF(x, y));
                myGraphics.grp.DrawLine(Pens.Red, x, y, C.X, C.Y);
            }
            return toReturn;
        }

        void IrregularRec(Graphics grp, int n, PointF C, float minR, float maxR, float fi)
        {
            List<PointF> t = IrregularPolygon(n, C, minR, maxR, fi);
            if (AriaPolygon(C, t) > 10)
            {

                DrawPolygon(grp, t);

                foreach (PointF p in t)
                {
                    IrregularRec(grp, n, p, minR / 2, maxR / 2, fi);
                }
            }
        }

        void RegularRec(Graphics grp, int n, PointF C, float R, float fi)
        {
            List<PointF> t = RegularPolygon(n, C, R, fi);
            if (AriaPolygon(C, t) > 100)
            {

                DrawPolygon(grp, t);

                foreach (PointF p in t)
                {
                    if (rnd.Next(2) == 0)
                        RegularRec(grp, n, p, R / 2, fi + 0.2f);
                }
            }
        }

        public float Determinant(PointF A, PointF B, PointF C)
        {
            return A.X * B.Y + B.X * C.Y + A.Y * C.X - C.X * B.Y - A.Y * B.X - C.Y * A.X;
        }

        public float Aria(PointF A, PointF B, PointF C)
        {
            return 0.5f * (float)Math.Abs(Determinant(A, B, C));
        }

        public float AriaPolygon(PointF C, List<PointF> points)
        {
            float sum = 0;
            for (int i = 0; i < points.Count; i++)
            {
                sum += Aria(C, points[i], points[(i + 1) % points.Count]);
            }

            return sum;
        }

        public void DrawPolygon(Graphics grp, List<PointF> points)
        {
            grp.DrawPolygon(new Pen(Color.Black), points.ToArray());
        }

        public void FillPolygon(Graphics grp, List<PointF> points, Color fillColor)
        {
            grp.FillPolygon(new SolidBrush(fillColor), points.ToArray());
            grp.DrawPolygon(new Pen(Color.Black), points.ToArray());
        }

        public void DrawTriangle(Graphics grp, PointF A, PointF B, PointF C)
        {
            grp.DrawLine(Pens.Black, A, B);
            grp.DrawLine(Pens.Black, B, C);
            grp.DrawLine(Pens.Black, C, A);
        }

        public void DrawSierpinski(Graphics grp, PointF A, PointF B, PointF C)
        {
            if (PointDistance(A, B) > 1 && PointDistance(B, C) > 1 && PointDistance(A, C) > 1)
            {
                float k1 = 1;
                float k2 = 3;

                DrawTriangle(grp, A, B, C);
                PointF M = new PointF((A.X * k1 + B.X * k2) / (k1 + k2), (A.Y * k1 + B.Y * k2) / (k1 + k2));
                PointF N = new PointF((A.X * k1 + C.X * k2) / (k1 + k2), (A.Y * k1 + C.Y * k2) / (k1 + k2));
                PointF P = new PointF((C.X * k1 + B.X * k2) / (k1 + k2), (C.Y * k1 + B.Y * k2) / (k1 + k2));

                DrawSierpinski(grp, A, M, N);
                DrawSierpinski(grp, M, B, P);
                DrawSierpinski(grp, N, P, C);
            }
        }

        public float PointDistance(PointF A, PointF B)
        {
            return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }

        public void DrawPoints(Graphics grp, List<PointF> points)
        {
            foreach (var point in points)
            {
                grp.DrawEllipse(new Pen(Color.Black), point.X - 1, point.Y - 1, 3, 3);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a += 10;
            b += 0.1f;

            if (a >= 200)
                a = 10;

            myGraphics.Clear();
            DrawPoints(myGraphics.grp, RegularPolygon(6, new PointF(250, 250), a, b));
            myGraphics.Refresh();
        }

    }
}