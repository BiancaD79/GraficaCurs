﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafica_C2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MyGraphics graphics;

        //Un punct (x,y) il mutam in (x',y') - translatie
        //Transformare fata de un pivot (x'',y'')
        //Transformare fata de (0,0)
        //
        // Clasa Punct, Matrice(inmultire)

        //Daca am P un punct de coordonate Px,Py
        //Avem matricea T (1 0 x) coordonatele P' = P * T
        //                (0 1 y)
        //                (0 0 1)
        //reprezinta coordonatele punctului translatat cu x,y

        //Avem matricea R (cos(T) -sin(T) 0) reprezinta coord P' = P * R
        //                (sin(T) cos(T)  0)
        //                (0        0     1)
        //reprezinta coordonatele rotit fata de origine. 

        //Avem matricea S (x 0 0) , P' = P * S 
        //                (0 y 0)
        //                (0 0 1)
        //reprezinta coordonatele punctului scalat


        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = new MyGraphics(pictureBox1);
            Matrix T = new Matrix(@"../../input.txt");
            Matrix A = new Matrix(@"../../input2.txt");
            foreach (string s in (T*A).View()) 
            {
                listBox1.Items.Add(s);
            }

            Polygon polygon = new Polygon(@"../../polygon.txt");
            polygon.Draw(graphics.grp);
            graphics.Refresh();
        }

        
    }
}