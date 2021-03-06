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
    public partial class DrawRectForm : UserControl, Geometry
    {
        Lite parent;
        public DrawRectForm(Lite parent)
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
            Pen pen = new Pen(Color.FromArgb(a, r, g, b), pixelsize);
            this.parent.gra.DrawRectangle(pen, sx, sy, ex - sx, ey - sy);
        }

    }
}
