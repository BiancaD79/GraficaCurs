using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multigraf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MyGraphics graphics;
        PointF A, B, C;
        List<PointF> points = new List<PointF>();
        List<PointF> inter = new List<PointF>();

        Bezier test;
        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = new MyGraphics(pictureBox1);
            //A = new PointF(70,35);
            //B = new PointF(200, 300);
            //C = new PointF(550, 40);

            //test = new Bezier(A, B, C, 10);
            //test.Draw(graphics.grp);

            TextReader rd = new StreamReader("../../input.txt");
            int n = int.Parse(rd.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = rd.ReadLine().Split();
                float X = float.Parse(line[0]);
                float Y = float.Parse(line[1]);
                points.Add(new PointF(X,Y));
            }
            for (int i = 0; i < n - 1; i++)
            {
                string[] line = rd.ReadLine().Split();
                float X = float.Parse(line[0]);
                float Y = float.Parse(line[1]);
                inter.Add(new PointF(X, Y));
            }
            rd.Close();

            for (int i = 0; i < n - 1; i++)
            {
                Bezier b = new Bezier(points[i]
                    , points[i+1], inter[i], 20);
                b.Draw(graphics.grp);
            }

            //graphics.grp.DrawBezier(Pens.Red, points[0], inter[0], inter[1], points[1]);
            
            graphics.Refresh();
        }
    }
}
