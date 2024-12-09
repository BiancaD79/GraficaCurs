using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonIntersectFill
{
    public class MyGraphics
    {
        public Graphics grp;
        PictureBox display;
        public Bitmap bmp;
        public Color backColor = Color.FromArgb(200,220,200);

        public int ResX { get { return display.Width; } }
        public int ResY { get { return display.Height; } }

        public MyGraphics(PictureBox pb)
        {
            this.display = pb;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            Clear();
            Refresh();
        }

        public void Clear()
        {
            grp.Clear(backColor);
        }

        public void Refresh()
        {
            display.Image = bmp;
        }
    }
}
