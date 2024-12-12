using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPalette
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MyGraphics graphics1;
        MyGraphics graphics2;
        Map test;
        private void Form1_Load(object sender, EventArgs e)
        {
            //voronoi :D
            graphics1 = new MyGraphics(pictureBox1);
            test = new Map(10,graphics1.ResX, graphics1.ResY);
            test.Draw(graphics1.grp);
            test.Fill(graphics1.bmp);

            graphics2 = new MyGraphics(pictureBox2);
            test = new Map(10, graphics2.ResX, graphics2.ResY);
            test.Draw(graphics2.grp);
            test.FillPonderat(graphics2.bmp);

            graphics1.Refresh();
            graphics2.Refresh();
        }
    }
}
