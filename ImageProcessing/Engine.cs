using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ImageProcessing
{
    public static class Engine
    {
        public static double dcolorE(Color c)//euclidian
        {
            return Math.Sqrt(c.R * c.R + c.B * c.B + c.G * c.G);
        }

        public static double dcolorM(Color c) //manhattan
        {
            return c.R + c.B + c.G;
        }

        public static Color std(Color c, int k)
        { 
            int R = (c.R / k) * k;
            int B = (c.B / k) * k;
            int G = (c.G / k) * k;
            return Color.FromArgb(R,G,B);
        }
    }
}
