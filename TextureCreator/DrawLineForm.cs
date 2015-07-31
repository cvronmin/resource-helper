﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextureCreator
{
    public partial class DrawLineForm : UserControl , Geometry
    {
        Lite parent;
        public DrawLineForm(Lite parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        void Geometry.draw(int a, int r, int g, int b) {
            int pixelsize;
            int sx, sy, ex, ey;
            try
            {
                pixelsize = Int32.Parse(PixelCount.Text);
                sx = Int32.Parse(StartXPos.Text);
                sy = Int32.Parse(StartYPos.Text);
                ex = Int32.Parse(EndXPos.Text);
                ey = Int32.Parse(EndYPos.Text);
            }
            catch
            {
                pixelsize = 1;
                sx = 0;
                sy = 0;
                ex = 0;
                ey = 0;
                return;
            }
            if(a == 0 && (sx == ex || sy == ey)){
                if (sx == ex) {
                    for (int y = sy; y <= ey; y++) {
                        this.parent.map.SetPixel(sx, y, Color.Transparent);
                    }
                    return;
                }
                if (sy == ey) {
                    for (int x = sx; x <= ex; x++)
                    {
                        this.parent.map.SetPixel(x, sy, Color.Transparent);
                    }
                    return;
                }
            }
            Pen pen = new Pen(Color.FromArgb(a, r, g, b), pixelsize);
            this.parent.gra.DrawLine(pen, new Point(sx, sy), new Point(ex, ey));
        }
    }
}
