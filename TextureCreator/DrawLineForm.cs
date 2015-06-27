using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextureCreator
{
    public partial class DrawLineForm : UserControl
    {
        Lite parent;
        public DrawLineForm(Lite parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            int alpha;
            int red;
            int green;
            int blue;
            int pixelsize;
            int sx, sy, ex, ey;
            try
            {
                alpha = Int32.Parse(AlphaCount.Text) & 255;
                red = Int32.Parse(RedCount.Text) & 255;
                green = Int32.Parse(GreenCount.Text) & 255;
                blue = Int32.Parse(BlueCount.Text) & 255;
                pixelsize = Int32.Parse(PixelCount.Text);
                sx = Int32.Parse(StartXPos.Text);
                sy = Int32.Parse(StartYPos.Text);
                ex = Int32.Parse(EndXPos.Text);
                ey = Int32.Parse(EndYPos.Text);
            }
            catch
            {
                alpha = 0;
                red = 0;
                green = 0;
                blue = 0;
                pixelsize = 1;
                sx = 0;
                sy = 0;
                ex = 0;
                ey = 0;
            }
            Pen pen = new Pen(Color.FromArgb(alpha, red, green, blue), pixelsize);
            this.parent.gra.DrawLine(pen, new Point(sx, sy), new Point(ex, ey));
            this.FindForm().Close();
        }
    }
}
