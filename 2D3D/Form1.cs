using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D3D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics grp;
        Bitmap bmp;
        public PointF RTS(PointF P, PointF M, float teta)
        {
            float X = (float)Math.Cos(teta) * (P.X - M.X) - 
                (float)Math.Sin(teta) * (P.Y - M.Y) + M.X;
            float Y = (float)Math.Sin(teta) * (P.X - M.X) +
                (float)Math.Cos(teta) * (P.Y - M.Y) + M.Y;

            return new PointF(X, Y);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            PointF t1 = new PointF(100, 100);
            PointF t2 = new PointF(200, 100);

            PointF tt1 = RTS(t1,new PointF(150,150),0.2f);
            PointF tt2 = RTS(t2,new PointF(150,150),0.2f);

            grp.DrawLine(Pens.Black,t1,t2);
            grp.DrawLine(Pens.Black,tt1,tt2);

            //listBox1.Items.Add();

            pictureBox1.Image = bmp;
        }
    }
}
