using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ArnoldsCatMap
{
    internal class Arnold
    {
        public Bitmap source;
        Bitmap destination;
        public Arnold(string fileName)
        {
            this.source = new Bitmap(Image.FromFile(fileName));
        }
        public Arnold(Bitmap bmp)
        {
            this.source = bmp;
        }

        public void Iteratie()
        {
            destination = new Bitmap(source.Width, source.Height);

            int w = source.Width;
            int h = source.Height;

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    int x = (2 * i + j) % w;
                    int y = (i + j) % h;
                    destination.SetPixel(x,y,source.GetPixel(i,j));
                }
            }

            source = destination;
        }

    }
}
