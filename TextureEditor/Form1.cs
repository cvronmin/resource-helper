using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextureEditor
{
    public partial class Form1 : Form
    {
        internal Image file;
        internal Bitmap map;
        internal Graphics graphic;
        string filename;
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileMenu_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (sender is FileDialog)
            {
                filename = openFileDialog1.FileName;
            }
            if (sender is string) filename = sender as string;
            this.Text = filename != null ? "Texture Creator - " + filename : "Texture Creator - Untitled";
            file = Image.FromFile(filename);
            map = new Bitmap(file);
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            buttonInvert.Enabled = buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = true;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.filename = saveFileDialog1.FileName;
            map.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            this.Text = filename != null ? "Texture Creator - " + filename : "Texture Creator - Untitled";
        }

        private void saveFileMenu_Click(object sender, EventArgs e)
        {
            if (filename == null)
            {
                saveAsMenu_Click(sender, e);
            }
            else
            {
                map.Save(filename);
            }
        }

        private void saveAsMenu_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void buttonGray_Click(object sender, EventArgs e)
        {
            buttonGray.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        //create the grayscale version
                        byte grayScale =
                           (byte)((oRow[x * sw] * .11) + //B
                           (oRow[x * sw + 1] * .59) +  //G
                           (oRow[x * sw + 2] * .3)); //R

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw] = grayScale; //B
                        nRow[x * sw + 1] = grayScale; //G
                        nRow[x * sw + 2] = grayScale; //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }

                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            buttonGray.Enabled = true;
            /*           buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
                       var thread = new PixelModifyThread(map, 1);
                       thread.ModifyChangingEvent += OnModifyChange;
                       thread.ModifyFinishEvent += OnModifyFinish;
                       thread.Start();*/
        }
        public int averageColor(int R, int G, int B)
        {
            return (R + G + B) / 3;
        }
        public int groupColor(int average)
        {
            return average < 127 ? 0 : 255;
        }
        public int groupColor(int average, int split)
        {
            return average < split ? 0 : 255;
        }
        private void buttonBW_Click(object sender, EventArgs e)
        {
            buttonBW.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        //create the grayscale version
                        byte grayScale =
                           (byte)((oRow[x * sw] * .11) + //B
                           (oRow[x * sw + 1] * .59) +  //G
                           (oRow[x * sw + 2] * .3)); //R

                        const int nThreshold = 105;
                        byte bw = (255 - grayScale < nThreshold) ? (byte)255 : (byte)0;

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw] = bw; //B
                        nRow[x * sw + 1] = bw; //G
                        nRow[x * sw + 2] = bw; //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }

                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            buttonBW.Enabled = true;
            /*            buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
                        var thread = new PixelModifyThread(map, 2);
                        thread.ModifyChangingEvent += OnModifyChange;
                        thread.ModifyFinishEvent += OnModifyFinish;
                        thread.Start();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        //create the shifted version
                        int shift = (oRow[x * sw + 2] << 16) + (oRow[x * sw + 1] << 8) + oRow[x * sw];
                        shift = leftShift(shift, 1);

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw + 2] = (byte)((shift >> 16) & 255); //B
                        nRow[x * sw + 1] = (byte)((shift >> 8) & 255); //G
                        nRow[x * sw] = (byte)(shift & 255); //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            button1.Enabled = true;
            /*           buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
                       var thread = new PixelModifyThread(map, 3, 1);
                       thread.ModifyChangingEvent += OnModifyChange;
                       thread.ModifyFinishEvent += OnModifyFinish;
                       thread.Start();*/
        }
        public int leftShift(int par, int dight)
        {
            int temp = par << dight;
            temp = (temp | (par >> (24 - dight)));
            return temp & 0xFFFFFF;
        }
        public int rightShift(int par, int dight)
        {
            int temp = par >> dight;
            temp = (temp | ((par << (24 - dight)) & 0xFFFFFF));
            return temp & 0xFFFFFF;
        }
        [Obsolete]
        private int leftMove(int par)
        {
            return leftMove(par, 1);
        }
        [Obsolete]
        private int leftMove(int par, int dight)
        {
            int temp = par << dight;
            temp = (temp | (par >> Convert.ToString(par, 2).Length - dight));
            return temp & 0xFFFFFF;
        }
        [Obsolete]
        private int rightMove(int par)
        {
            return rightMove(par, 1);
        }
        [Obsolete]
        private int rightMove(int par, int dight)
        {
            int temp = par >> dight;
            temp = (temp | ((par & temp) << Convert.ToString(par, 2).Length - dight));
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
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        //create the shifted version
                        int shift = (oRow[x * sw + 2] << 16) + (oRow[x * sw + 1] << 8) + oRow[x * sw];
                        shift = rightShift(shift, 1);

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw + 2] = (byte)((shift >> 16) & 255); //B
                        nRow[x * sw + 1] = (byte)((shift >> 8) & 255); //G
                        nRow[x * sw] = (byte)(shift & 255); //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            button2.Enabled = true;
            /*           buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
                       var thread = new PixelModifyThread(map, 4, 1);
                       thread.ModifyChangingEvent += OnModifyChange;
                       thread.ModifyFinishEvent += OnModifyFinish;
                       thread.Start();*/
        }

        private void buttonLH_Click(object sender, EventArgs e)
        {
            buttonLH.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        //create the shifted version
                        int shift = (oRow[x * sw + 2] << 16) + (oRow[x * sw + 1] << 8) + oRow[x * sw];
                        shift = leftShift(shift, 4);

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw + 2] = (byte)((shift >> 16) & 255); //B
                        nRow[x * sw + 1] = (byte)((shift >> 8) & 255); //G
                        nRow[x * sw] = (byte)(shift & 255); //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            buttonLH.Enabled = true;
            /*           buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
                       var thread = new PixelModifyThread(map, 3, 4);
                       thread.ModifyChangingEvent += OnModifyChange;
                       thread.ModifyFinishEvent += OnModifyFinish;
                       thread.Start();*/
        }

        private void buttonRH_Click(object sender, EventArgs e)
        {
            buttonRH.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        //create the shifted version
                        int shift = (oRow[x * sw + 2] << 16) + (oRow[x * sw + 1] << 8) + oRow[x * sw];
                        shift = rightShift(shift, 4);

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw + 2] = (byte)((shift >> 16) & 255); //B
                        nRow[x * sw + 1] = (byte)((shift >> 8) & 255); //G
                        nRow[x * sw] = (byte)(shift & 255); //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            buttonRH.Enabled = true;
            /*           buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
                       var thread = new PixelModifyThread(map, 4, 4);
                       thread.ModifyChangingEvent += OnModifyChange;
                       thread.ModifyFinishEvent += OnModifyFinish;
                       thread.Start();*/
        }

        private void buttonLS2_Click(object sender, EventArgs e)
        {
            buttonLS2.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        //create the shifted version
                        int shift = (oRow[x * sw + 2] << 16) + (oRow[x * sw + 1] << 8) + oRow[x * sw];
                        shift = leftShift(shift, 8);

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw + 2] = (byte)((shift >> 16) & 255); //B
                        nRow[x * sw + 1] = (byte)((shift >> 8) & 255); //G
                        nRow[x * sw] = (byte)(shift & 255); //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            buttonLS2.Enabled = true;
            /*            buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
                        var thread = new PixelModifyThread(map, 3, 8);
                        thread.ModifyChangingEvent += OnModifyChange;
                        thread.ModifyFinishEvent += OnModifyFinish;
                        thread.Start();*/
        }

        private void buttonRS2_Click(object sender, EventArgs e)
        {
            buttonRS2.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        //create the shifted version
                        int shift = (oRow[x * sw + 2] << 16) + (oRow[x * sw + 1] << 8) + oRow[x * sw];
                        shift = rightShift(shift, 8);

                        //set the new image's pixel to the grayscale version
                        nRow[x * sw + 2] = (byte)((shift >> 16) & 255); //B
                        nRow[x * sw + 1] = (byte)((shift >> 8) & 255); //G
                        nRow[x * sw] = (byte)(shift & 255); //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            buttonRS2.Enabled = true;
            /*            buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
                        var thread = new PixelModifyThread(map, 4, 8);
                        thread.ModifyChangingEvent += OnModifyChange;
                        thread.ModifyFinishEvent += OnModifyFinish;
                        thread.Start();*/
        }

        private void buttonOther_Click(object sender, EventArgs e)
        {
            new Form2(this).ShowDialog();
        }

        private void buttonInvert_Click(object sender, EventArgs e)
        {
            buttonInvert.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        nRow[x * sw + 2] = (byte)~oRow[x * sw + 2]; //B
                        nRow[x * sw + 1] = (byte)~oRow[x * sw + 1]; //G
                        nRow[x * sw] = (byte)~oRow[x * sw]; //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }
                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            buttonInvert.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        const int nThreshold = 105;
                        nRow[x * sw] = (255 - oRow[x * sw] < nThreshold) ? (byte)255 : (byte)0; //B
                        nRow[x * sw + 1] = (255 - oRow[x * sw + 1] < nThreshold) ? (byte)255 : (byte)0; //G
                        nRow[x * sw + 2] = (255 - oRow[x * sw + 2] < nThreshold) ? (byte)255 : (byte)0; //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }

                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, map.Width, map.Height);
                Bitmap _map = new Bitmap(map.Width, map.Height);
                System.Drawing.Imaging.BitmapData data = map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                System.Drawing.Imaging.BitmapData _data = _map.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, map.PixelFormat);
                IntPtr ptr = data.Scan0;
                IntPtr _ptr = _data.Scan0;
                int bytes = data.Stride * map.Height;
                byte[] bgr = new byte[bytes];
                byte[] _bgr = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bgr, 0, bytes);
                System.Runtime.InteropServices.Marshal.Copy(_ptr, _bgr, 0, bytes);
                int sw = 3;
                if (map.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    sw = 4;
                for (int y = 0; y < map.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)data.Scan0 + (y * data.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)_data.Scan0 + (y * _data.Stride);

                    for (int x = 0; x < map.Width; x++)
                    {
                        nRow[x * sw] = (byte)fourfive(oRow[x * sw]); //B
                        nRow[x * sw + 1] = (byte)fourfive(oRow[x * sw + 1]); //G
                        nRow[x * sw + 2] = (byte)fourfive(oRow[x * sw + 2]); //R
                        if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }
                }

                map.UnlockBits(data);
                _map.UnlockBits(_data);
                map = _map;
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            button4.Enabled = true;
        }
        public int fourfive(int target)
        {
            if ((target % 16) < 7)
            {
                target = (int)((float)target / 255 * 16f) * 16 - 1;
            }
            else
            {
                target = (int)((float)target / 255 * 16f) * 16 - 1 + 16;
            }
            if (target < 0)
            {
                target = 0;
            }
            if (target > 255)
            {
                target = 255;
            }
            return target;
        }

        private void button5_Click (object sender, EventArgs e)
        {
            string b = "";
            using (var f = System.IO.File.OpenRead(filename))
            {
                using (var a = new System.IO.StreamReader(f, Encoding.GetEncoding(1252)))
                {
                    b = a.ReadToEnd();
                    a.Close();
                }
                f.Close();
            }
            //Bitmap m = map.Clone(new Rectangle(0, 0, map.Width, map.Height), map.PixelFormat);
            file.Dispose();
            map.Dispose();
            graphic.Dispose();
            b = CRMKJK.CRMKJK.EncodeEasy(b, Encoding.UTF8, CRMKJK.CRMKJKState.EncodeTextB64Encode);
            using (var f= System.IO.File.OpenWrite(filename))
            {
                using (var a = new System.IO.StreamWriter(f,Encoding.UTF8))
                {
                    a.Write(b);
                }

            }
            //map = m.Clone(new Rectangle(0, 0, m.Width, m.Height), m.PixelFormat);
            //m.Dispose();
        }

        private void button6_Click (object sender, EventArgs e)
        {
            var o = new OpenFileDialog() { SupportMultiDottedExtensions = true};
            o.FileOk += (arg, arg1)=>{
                var aa = "";
                using (var f = System.IO.File.OpenRead(o.FileName))
                {
                    using (var f1 = new System.IO.StreamReader(f,Encoding.UTF8))
                    {
                        var a = f1.ReadToEnd();
                        try
                        {
                            aa = CRMKJK.CRMKJK.Decode(a, Encoding.UTF8);
                        }
                        catch (CRMKJK.UnexpectedCRMKJKEncodeException)
                        {
                            openFileDialog1_FileOk(arg, arg1);
                            return;
                        }
                        catch (FormatException ex) {
                            throw ex;
                        }
                    }
                }
                using (var f1 = new System.IO.StreamWriter(o.FileName, false, Encoding.GetEncoding(1252)))
                {
                    f1.Write(aa);
                }
                GC.Collect();
            };
            o.ShowDialog();

        }

        private void button7_Click (object sender, EventArgs e)
        {
            var o = new OpenFileDialog() { SupportMultiDottedExtensions = true };
            o.FileOk += (arg, arg1) => {
                var b = "";
                using (var f = System.IO.File.OpenRead(o.FileName))
                {
                    using (var a = new System.IO.StreamReader(f, Encoding.GetEncoding(1252)))
                    {
                        b = a.ReadToEnd();
                        a.Close();
                    }
                    f.Close();
                }
                b = CRMKJK.CRMKJK.EncodeEasy(b, Encoding.UTF8, CRMKJK.CRMKJKState.EncodeTextB64Encode);
                using (var f = System.IO.File.OpenWrite(o.FileName))
                {
                    using (var a = new System.IO.StreamWriter(f, Encoding.UTF8))
                    {
                        a.Write(b);
                    }

                }
                GC.Collect();
            };
            o.ShowDialog();
        }

        private void button8_Click (object sender, EventArgs e)
        {
            var o = new FolderBrowserDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {

                    var dir = new DirectoryInfo(o.SelectedPath);
                    var files = from f in dir.EnumerateFiles() where isFileImage(f) select f;
                    var i = 0;
                    foreach (var file in files)
                    {
                        i++;
                        lblEncryptProgress.Text = "Encrypting... (" + i + "/" + files.Count() + ")";
                        //var t = new System.Threading.Thread(() => {
                            var b = "";
                            using (var f = File.OpenRead(file.FullName))
                            {
                                using (var a = new StreamReader(f, Encoding.GetEncoding(1252)))
                                {
                                    b = a.ReadToEnd();
                                    a.Close();
                                }
                                f.Close();
                            }
                            b = CRMKJK.CRMKJK.EncodeEasy(b, Encoding.UTF8, CRMKJK.CRMKJKState.EncodeTextB64Encode);
                            using (var f = File.OpenWrite(file.FullName))
                            {
                                using (var a = new StreamWriter(f, Encoding.UTF8))
                                {
                                    a.Write(b);
                                }

                            }
                            GC.Collect();
                        //});

                    //t.SetApartmentState(System.Threading.ApartmentState.STA);
                    //t.Start();
                    }
                    MessageBox.Show("Done!");
            }
        }

        private void button9_Click (object sender, EventArgs e)
        {
            var o = new FolderBrowserDialog();
            if (o.ShowDialog() == DialogResult.OK) {
                    var dir = new System.IO.DirectoryInfo(o.SelectedPath);
                    var files = from f in dir.EnumerateFiles() where isFileImage(f) select f;
                    var i = 0;
                    foreach (var file in files)
                    {
                        i++;
                        lblEncryptProgress.Text = "Decrypting... (" + i + "/" + files.Count() + ")";
                        var aa = "";
                        //var t = new System.Threading.Thread(() => {
                            using (var f = System.IO.File.OpenRead(file.FullName))
                            {
                                using (var f1 = new System.IO.StreamReader(f, Encoding.UTF8))
                                {
                                    var a = f1.ReadToEnd();
                                    try
                                    {
                                        aa = CRMKJK.CRMKJK.Decode(a, Encoding.UTF8);
                                    }
                                    catch (CRMKJK.UnexpectedCRMKJKEncodeException)
                                    {
                                        return;
                                    }
                                    catch (FormatException ex)
                                    {
                                        throw ex;
                                    }
                                }
                            }
                            using (var f1 = new System.IO.StreamWriter(file.FullName, false, Encoding.GetEncoding(1252)))
                            {
                                f1.Write(aa);
                            }
                            GC.Collect();
                        //});

                    //t.SetApartmentState(System.Threading.ApartmentState.STA);
                    //t.Start();
                }
                    MessageBox.Show("Done!");
                
            }
        }

        private bool isFileImage (FileInfo f) {
            return f.Extension.Equals(".png", StringComparison.InvariantCultureIgnoreCase) |
                f.Extension.Equals(".jpg", StringComparison.InvariantCultureIgnoreCase) |
                f.Extension.Equals(".jpeg", StringComparison.InvariantCultureIgnoreCase) |
                f.Extension.Equals(".jpe", StringComparison.InvariantCultureIgnoreCase) |
                f.Extension.Equals(".jfif", StringComparison.InvariantCultureIgnoreCase) |
                f.Extension.Equals(".tif", StringComparison.InvariantCultureIgnoreCase) |
                f.Extension.Equals(".tiff", StringComparison.InvariantCultureIgnoreCase) |
                f.Extension.Equals(".bmp", StringComparison.InvariantCultureIgnoreCase) |
                f.Extension.Equals(".dib", StringComparison.InvariantCultureIgnoreCase) |
                f.Extension.Equals(".gif", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
