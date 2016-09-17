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
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, parent.map.Width, parent.map.Height);
                Bitmap _map = new Bitmap(parent.map.Width, parent.map.Height);
                System.Drawing.Imaging.BitmapData data = parent.map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, parent.map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, parent.map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * parent.map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (parent.map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < parent.map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < parent.map.Width; x++)
                    {
                        //create the shifted version
                        int shift = (oRow[x * sw + 2] << 16) + (oRow[x * sw + 1] << 8) + oRow[x * sw];
                        shift = parent.leftShift(shift, (int)numericUpDown1.Value);

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw + 2] = (byte)((shift >> 16) & 255); //B
                        nRow[x * sw + 1] = (byte)((shift >> 8) & 255); //G
                        nRow[x * sw] = (byte)(shift & 255); //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                parent.map.UnlockBits(data);
                _map.UnlockBits(_data);
                parent.map = _map;
            }
            parent.graphic = Graphics.FromImage(parent.map);
                        parent.previewBox.Image = parent.map;
//            parent.leftShiftAny((int)numericUpDown1.Value);
            Close();
        }

        private void buttonRS_Click(object sender, EventArgs e)
        {
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, parent.map.Width, parent.map.Height);
                Bitmap _map = new Bitmap(parent.map.Width, parent.map.Height);
                System.Drawing.Imaging.BitmapData data = parent.map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, parent.map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, parent.map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * parent.map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (parent.map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < parent.map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < parent.map.Width; x++)
                    {
                        //create the shifted version
                        int shift = (oRow[x * sw + 2] << 16) + (oRow[x * sw + 1] << 8) + oRow[x * sw];
                        shift = parent.rightShift(shift, (int)numericUpDown1.Value);

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw + 2] = (byte)((shift >> 16) & 255); //B
                        nRow[x * sw + 1] = (byte)((shift >> 8) & 255); //G
                        nRow[x * sw] = (byte)(shift & 255); //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                parent.map.UnlockBits(data);
                _map.UnlockBits(_data);
                parent.map = _map;
            }
            parent.graphic = Graphics.FromImage(parent.map);
                        parent.previewBox.Image = parent.map;
//            parent.rightShiftAny((int)numericUpDown1.Value);
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, parent.map.Width, parent.map.Height);
                Bitmap _map = new Bitmap(parent.map.Width, parent.map.Height);
                System.Drawing.Imaging.BitmapData data = parent.map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, parent.map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, parent.map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * parent.map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (parent.map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < parent.map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < parent.map.Width; x++)
                    {
                        //create the grayscale version
                        byte grayScale =
                           (byte)((oRow[x * sw] * .11) + //B
                           (oRow[x * sw + 1] * .59) +  //G
                           (oRow[x * sw + 2] * .3)); //R

                        int nThreshold = trackBar1.Value;
                        byte bw = (255 - grayScale < nThreshold) ? (byte)255 : (byte)0;

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw] = bw; //B
                        nRow[x * sw + 1] = bw; //G
                        nRow[x * sw + 2] = bw; //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                parent.map.UnlockBits(data);
                _map.UnlockBits(_data);
                parent.map = _map;
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
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, parent.map.Width, parent.map.Height);
                Bitmap _map = new Bitmap(parent.map.Width, parent.map.Height);
                System.Drawing.Imaging.BitmapData data = parent.map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, parent.map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, parent.map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * parent.map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (parent.map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < parent.map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < parent.map.Width; x++)
                    {
                        int nThreshold = trackBar1.Value;
                        //set the new image's pixel to the grayscale version
                        nRow[x * sw] = (255 - oRow[x * sw] < nThreshold) ? (byte)255 : (byte)0; //B
                        nRow[x * sw + 1] = (255 - oRow[x * sw + 1] < nThreshold) ? (byte)255 : (byte)0; //G
                        nRow[x * sw + 2] = (255 - oRow[x * sw + 2] < nThreshold) ? (byte)255 : (byte)0; //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                parent.map.UnlockBits(data);
                _map.UnlockBits(_data);
                parent.map = _map;
            }
            parent.graphic = Graphics.FromImage(parent.map);
            parent.previewBox.Image = parent.map;
            //            parent.BlackWhiteAny(trackBar1.Value);
            Close();
        }
    }
}
