using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextureEditor
{
    public partial class Form2 : Form
    {
        Form1 parent;
        public Form2(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLS_Click(object sender, EventArgs e)
        {
                        for (int x = 0; x < parent.map.Width; x++)
                        {
                            for (int y = 0; y < parent.map.Height; y++)
                            {
                                parent.map.SetPixel(x, y, Color.FromArgb(parent.map.GetPixel(x, y).A, (parent.leftShift(parent.map.GetPixel(x, y).ToArgb() & 0xFFFFFF, (int)numericUpDown1.Value) >> 16) & 255, (parent.leftShift(parent.map.GetPixel(x, y).ToArgb() & 0xFFFFFF, (int)numericUpDown1.Value) >> 8) & 255, (parent.leftShift(parent.map.GetPixel(x, y).ToArgb() & 0xFFFFFF, (int)numericUpDown1.Value)) & 255));
                            }
                        }
                        parent.graphic = Graphics.FromImage(parent.map);
                        parent.previewBox.Image = parent.map;
//            parent.leftShiftAny((int)numericUpDown1.Value);
            Close();
        }

        private void buttonRS_Click(object sender, EventArgs e)
        {
                        for (int x = 0; x < parent.map.Width; x++)
                        {
                            for (int y = 0; y < parent.map.Height; y++)
                            {
                                parent.map.SetPixel(x, y, Color.FromArgb(parent.map.GetPixel(x, y).A, (parent.rightShift(parent.map.GetPixel(x, y).ToArgb() & 0xFFFFFF, (int)numericUpDown1.Value) >> 16) & 255, (parent.rightShift(parent.map.GetPixel(x, y).ToArgb() & 0xFFFFFF, (int)numericUpDown1.Value) >> 8) & 255, (parent.rightShift(parent.map.GetPixel(x, y).ToArgb() & 0xFFFFFF, (int)numericUpDown1.Value)) & 255));
                            }
                        }
                        parent.graphic = Graphics.FromImage(parent.map);
                        parent.previewBox.Image = parent.map;
//            parent.rightShiftAny((int)numericUpDown1.Value);
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
                        for (int x = 0; x < parent.map.Width; x++)
                        {
                            for (int y = 0; y < parent.map.Height; y++)
                            {
                                int temp = parent.groupColor(parent.averageColor(parent.map.GetPixel(x, y).R, parent.map.GetPixel(x, y).G, parent.map.GetPixel(x, y).B), trackBar1.Value);
                                parent.map.SetPixel(x, y, Color.FromArgb(parent.map.GetPixel(x, y).A, temp, temp, temp));
                            }
                        }
                        parent.graphic = Graphics.FromImage(parent.map);
                        parent.previewBox.Image = parent.map;
//            parent.BlackWhiteAny(trackBar1.Value);
            Close();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "Value: " + trackBar1.Value;
        }

        private void buttonOkRGB_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < parent.map.Width; x++)
            {
                for (int y = 0; y < parent.map.Height; y++)
                {
                    parent.map.SetPixel(x, y, Color.FromArgb(parent.map.GetPixel(x, y).A, parent.groupColor(parent.map.GetPixel(x, y).R), parent.groupColor(parent.map.GetPixel(x, y).G), parent.groupColor(parent.map.GetPixel(x, y).B)));
                }
            }
            parent.graphic = Graphics.FromImage(parent.map);
            parent.previewBox.Image = parent.map;
            //            parent.BlackWhiteAny(trackBar1.Value);
            Close();
        }
    }
}
