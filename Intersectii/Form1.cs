using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intersectii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PointF Intersect(PointF A, PointF B, PointF C, PointF D)
        {
            float ds = (A.Y - B.Y) * (D.X - C.X) 
                - (B.X - A.X) * (C.Y - D.Y);

            if (ds == 0) return PointF.Empty;

            float dx = (A.Y * B.X - A.X * B.Y) * (D.X - C.X)
                - (B.X - A.X) * (C.Y * D.X - C.X * D.Y);

            float dy = (A.Y - B.Y) * (C.Y * D.X - C.X * D.Y)
                - (A.Y * B.X - A.X * B.Y ) * (C.Y - D.Y);

            float x = dx / ds;
            float y = dy / ds;
            
            if(((x >= A.X && x <= B.X) || (x >= B.X && x <= A.X))
                && ((x >= C.X && x <= D.X) || (x>=D.X && x<=C.X)))
                    return new PointF(x,y);
            else
                return PointF.Empty;
        }
        Graphics graphics;
        Bitmap bmp;
        public static Random rnd = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bmp);
            for (int i = 0; i < 20; i++)
            {
                PointF A = new PointF(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height));
                PointF B = new PointF(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height));
                PointF C = new PointF(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height));
                PointF D = new PointF(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height));
                PointF M;
                Color t = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                graphics.DrawLine(new Pen(t), A, B);
                graphics.DrawLine(new Pen(t), C, D);
                if ((M = Intersect(A, B, C, D)) != PointF.Empty)
                    graphics.DrawEllipse(Pens.Red, M.X - 5, M.Y - 5, 11, 11);
            }

            pictureBox1.Image = bmp;
        }


    }
}
