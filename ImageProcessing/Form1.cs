using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Bitmap source;
        Bitmap dest;

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(@"..\..\..\Resurse");
            
            foreach (string file in files) 
            { 
                comboBox1.Items.Add(file);
            }

            comboBox1.SelectedIndex = 0;
            source = new Bitmap(comboBox1.SelectedItem.ToString());
            pictureBox1.Image = source;
            dest = new Bitmap(source.Width, source.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 4;
            for (int i = k; i < source.Width - k; i++)
            {
                for (int j = k; j < source.Height - k; j++)
                {
                    List<Color> colors = new List<Color>();
                    for (int l = -k; l <= k; l++)
                    {
                        for (int c = -k; c <= k; c++)
                        {
                            colors.Add(source.GetPixel(i + l,j + c));
                        }
                    }
                    colors.Sort(delegate(Color A, Color B) { return Engine.dcolorE(A).CompareTo(Engine.dcolorE(B)); });
                    dest.SetPixel(i, j, colors[colors.Count / 2]);
                }
            }
            pictureBox2.Image = dest;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            source = new Bitmap(comboBox1.SelectedItem.ToString());
            pictureBox1.Image = source;
            dest = new Bitmap(source.Width, source.Height);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = Engine.std(source.GetPixel(i,j), 32);
                    dest.SetPixel(i, j, color);
                }
            }
            pictureBox2.Image= dest;
        }
        // next: algoritm de contur, fill
        private void button4_Click(object sender, EventArgs e)
        {
            button3_Click(sender ,e);
            float eps = 45;

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    source.SetPixel(i, j, dest.GetPixel(i, j));
                }
            }

            for (int i = 1; i < source.Width - 1; i++)
            {
                for (int j = 1; j < source.Height - 1; j++)
                {
                    bool contur = false;
                    Color c1 = source.GetPixel(i,j);
                    
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int c = -1; c <= 1 ; c++)
                        {
                            Color c2 = source.GetPixel(i + k, j + c);
                            if (Math.Abs(Engine.dcolorE(c1) - Engine.dcolorE(c2)) > eps)
                            { contur = true; }
                        }
                    }
                    if (contur)
                        dest.SetPixel(i, j, Color.Black);
                    else
                        dest.SetPixel(i, j,Color.White);
                }
            }
            pictureBox2.Image = dest;
        }
    }
}
