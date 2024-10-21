using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Grafica_C2
{
    internal class MyPoint
    {
        public float X; 
        public float Y; 

        public MyPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Black, X - 3, Y - 3, 7, 7);
        }
    }

    internal class Polygon
    {
        /* TODO:
         * introducerea transformarilor R,T,S pe un MyPoint
         * si pe poligon, fie prin tranformarea fiecarei punct
         * sau prin matrici
         */
        MyPoint[] points;

        public Polygon(string fileName) 
        { 
            TextReader textReader = new StreamReader(fileName);
            string buffer;
            List<string> data = new List<string>();
            while((buffer = textReader.ReadLine())!= null)
            {
                data.Add(buffer);
            }

            textReader.Close();

            points = new MyPoint[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                float X = float.Parse(data[i].Split(' ')[0]);
                float Y = float.Parse(data[i].Split(' ')[1]);
                points[i] = new MyPoint(X,Y);
            }
        }

        public void Draw(Graphics handler)
        {
            for (int i = 0; i < points.Length; i++)
            {
                handler.DrawLine(Pens.Red, points[i].X, points[i].Y, points[(i + 1) % points.Length].X, points[(i + 1) % points.Length].Y);
            }

            foreach (MyPoint point in points)
            {
                point.Draw(handler);
            }
        }

        
    }
}
