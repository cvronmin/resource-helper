using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextureCreator
{
    class PixelButton : Button
    {
        private int X, Y;
        public PixelButton() { 
        }
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }
        public void setX(int x)
        {
            this.X = x;
        }
        public void setY(int y)
        {
            this.Y = y;
        }
        public void setXY(int x, int y)
        {
            this.setX(x);
            this.setY(y);
        }
    }
}
