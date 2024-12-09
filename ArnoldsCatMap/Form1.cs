using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArnoldsCatMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Arnold test;
        private void Form1_Load(object sender, EventArgs e)
        {
            test = new Arnold(@"C:\Users\bianc\Documents\Projects\Year 3\Laslo\Grafica\Curs\ArnoldsCatMap\cat.jpg");
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test.Iteratie();
            pictureBox1.Image = test.source;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
