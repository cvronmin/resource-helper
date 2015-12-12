using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorConvertor
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void butRGB_Click(object sender, EventArgs e)
        {
            int r = 0, g = 0, b = 0, rgb = 0;
            try
            {
                r = Int32.Parse(R.Text) & 255;
                g = Int32.Parse(G.Text) & 255;
                b = Int32.Parse(B.Text) & 255;
            }
            catch {
                MessageBox.Show("Cannot transfer!");
                R.Text = "";
                G.Text = "";
                B.Text = "";
            }
            int rc, gc, bc;
            rc = r << 16;
            gc = g << 8;
            bc = b;
            rgb = rc + gc + bc;
            RGB.Text = rgb.ToString();
        }

        private void butcolor3_Click(object sender, EventArgs e)
        {
            int rgb = 0;
            try
            {
                rgb = Int32.Parse(RGB.Text) & 16777215;
            }
            catch
            {
                MessageBox.Show("Cannot transfer!");
                RGB.Text = "";
            }
            int rc, gc, bc;
            rc = rgb >> 16 & 255;
            gc = rgb >> 8 & 255;
            bc = rgb & 255;
            R.Text = rc.ToString();
            G.Text = gc.ToString();
            B.Text = bc.ToString();
        }

        private void butARGB_Click(object sender, EventArgs e)
        {
            long a = 0, r = 0, g = 0, b = 0, argb = 0;
            try
            {
                a = Int64.Parse(A.Text) & 255;
                r = Int64.Parse(R.Text) & 255;
                g = Int64.Parse(G.Text) & 255;
                b = Int64.Parse(B.Text) & 255;
            }
            catch
            {
                MessageBox.Show("Cannot transfer!");
                A.Text = "";
                R.Text = "";
                G.Text = "";
                B.Text = "";
            }
            long ac, rc, gc, bc;
            ac = a << 24;
            rc = r << 16;
            gc = g << 8;
            bc = b;
            argb = ac + rc + gc + bc;
            ARGB.Text = argb.ToString();
        }

        private void butColor4_Click(object sender, EventArgs e)
        {
            long argb = 0;
            try
            {
                argb = Int64.Parse(ARGB.Text) & 4294967295;
            }
            catch
            {
                MessageBox.Show("Cannot transfer!");
                ARGB.Text = "";
            }
            long ac, rc, gc, bc;
            ac = argb >> 24 & 255;
            rc = argb >> 16 & 255;
            gc = argb >> 8 & 255;
            bc = argb & 255;
            A.Text = ac.ToString();
            R.Text = rc.ToString();
            G.Text = gc.ToString();
            B.Text = bc.ToString();
        }

        private void buttonLS_Click(object sender, EventArgs e)
        {
            int rgb = 0;
            try
            {
                rgb = Int32.Parse(RGB.Text);
            }
            catch
            {
                MessageBox.Show("Cannot shift!");
                RGB.Text = "";
            }
            RGB.Text = leftShift(rgb,4).ToString();
        }

        private void buttonRS_Click(object sender, EventArgs e)
        {
            int rgb = 0;
            try
            {
                rgb = Int32.Parse(RGB.Text);
            }
            catch
            {
                MessageBox.Show("Cannot shift!");
                RGB.Text = "";
            }
            RGB.Text = rightShift(rgb, 4).ToString();
        }
        private int leftShift(int par, int dight)
        {
            int temp = par << dight;
            temp = (temp | (par >> (Convert.ToString(0xFFFFFF, 2).Length - dight)));
            return temp & 0xFFFFFF;
        }
        private int rightShift(int par, int dight)
        {
            int temp = par >> dight;
            temp = (temp | ((par << Convert.ToString(0xFFFFFF, 2).Length - dight) & (twoDight(dight) << Convert.ToString(0xFFFFFF, 2).Length - dight)));
            return temp & 0xFFFFFF;
        }
        private int twoDight(int dight)
        {
            int temp = 0;
            for (int i = 0; i < dight; i++)
            {
                temp += (int)Math.Pow(2, i);
            }
            return temp;
        }
    }
}
