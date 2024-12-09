using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoligonIntersectFill
{
    public class Map
    {
        List<Polygon> polygons;
        PointF point;
        Color fill;

        public Map(string fileName) 
        { 
            TextReader reader = new StreamReader(fileName);
            List<string> data = new List<string>();
            string buffer;

            while ((buffer = reader.ReadLine()) != null)
                data.Add(buffer);

            reader.Close();

            polygons = new List<Polygon>();

            for (int i = 0; i < data.Count - 1; i++)
            {
                polygons.Add(new Polygon(data[i]));
            }

            string[] line = data[data.Count - 1].Split(' ');
            point = new PointF(float.Parse(line[0]),
                float.Parse(line[1]));
            fill = Color.FromArgb(int.Parse(line[2]),
                int.Parse(line[3]), int.Parse(line[4]));

            for (int i = 0; i < 3; i++)
            {
                polygons.Add(new Polygon());
            }
        }

        public void Fill(MyGraphics handler)
        {
            Queue<PointF> q = new Queue<PointF>();
            q.Enqueue(point);
            handler.bmp.SetPixel((int)point.X, (int)point.Y, fill);
            do
            {
                PointF t = q.Dequeue();

                if(t.X - 1 >= 0)
                {
                    Color a = handler.bmp.GetPixel((int)(t.X - 1)
                        , (int)t.Y);
                    if(a == handler.backColor)
                    {
                        handler.bmp.SetPixel((int)(t.X - 1)
                        , (int)t.Y, fill);
                        q.Enqueue(new PointF(t.X -1, t.Y));
                    }
                }

                if(t.Y - 1 >= 0)
                {
                    Color a = handler.bmp.GetPixel((int)(t.X)
                        , (int)t.Y - 1);
                    if(a == handler.backColor)
                    {
                        handler.bmp.SetPixel((int)t.X
                        , (int)t.Y - 1, fill);
                        q.Enqueue(new PointF(t.X, t.Y - 1));
                    }
                }

                if (t.Y + 1 < handler.ResY)
                {
                    Color a = handler.bmp.GetPixel((int)t.X
                        , (int)t.Y + 1);
                    if (a == handler.backColor)
                    {
                        handler.bmp.SetPixel((int)t.X
                        , (int)t.Y + 1, fill);
                        q.Enqueue(new PointF(t.X, t.Y + 1));
                    }
                }

                if (t.X + 1 < handler.ResX)
                {
                    Color a = handler.bmp.GetPixel((int)t.X + 1
                        , (int)t.Y);
                    if (a == handler.backColor)
                    {
                        handler.bmp.SetPixel((int)t.X + 1
                        , (int)t.Y, fill);
                        q.Enqueue(new PointF(t.X + 1, t.Y));
                    }
                }
            } while (q.Count > 0);
        }

        public void Draw(Graphics handler)
        {
            foreach (Polygon p in polygons)
            {
                p.Draw(handler);
            }

        }
    }
}
