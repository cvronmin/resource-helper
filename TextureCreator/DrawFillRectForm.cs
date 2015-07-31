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
    public partial class DrawFillRectForm : UserControl, Geometry
    {
        Lite parent;
        public DrawFillRectForm(Lite parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        void Geometry.draw(int a, int r, int g, int b) {
            int sx, sy, ex, ey;
            try
            {
                sx = Int32.Parse(StartXPos.Text);
                sy = Int32.Parse(StartYPos.Text);
                ex = Int32.Parse(EndXPos.Text);
                ey = Int32.Parse(EndYPos.Text);
            }
            catch
            {
                sx = 0;
                sy = 0;
                ex = 0;
                ey = 0;
                return;
            }
            if(a == 0){
                for (int x = sx; x <= ex; x++) {
                    for (int y = sy; y < ey; y++)
                    {
                        this.parent.map.SetPixel(x, y, Color.Transparent);
                    }
                }
                return;
            }
            SolidBrush brush = new SolidBrush(Color.FromArgb(a, r, g, b));
            this.parent.gra.FillRectangle(brush, sx, sy, ex - sx + 1, ey - sy + 1);
        }
    }
}
