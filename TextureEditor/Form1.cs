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
    public partial class Form1 : Form
    {
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
            filename = openFileDialog1.FileName;
            this.Text = filename != null ? "Texture Creator - " + filename : "Texture Creator - Untitled";
            Image file = Image.FromFile(filename);
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
                        for (int x = 0; x < map.Width; x++)
                        {
                            for (int y = 0; y < map.Height; y++)
                            {
                                map.SetPixel(x,y,Color.FromArgb(map.GetPixel(x,y).A, averageColor(map.GetPixel(x, y).R, map.GetPixel(x, y).G, map.GetPixel(x, y).B), averageColor(map.GetPixel(x, y).R, map.GetPixel(x, y).G, map.GetPixel(x, y).B), averageColor(map.GetPixel(x, y).R, map.GetPixel(x, y).G, map.GetPixel(x, y).B)));
                            }
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
        public int averageColor(int R, int G, int B) {
            return (R + G + B) / 3;
        }
        public int groupColor(int average) {
            return average < 127 ? 0 : 255;
        }
        public int groupColor(int average, int split)
        {
            return average < split ? 0 : 255;
        }
        private void buttonBW_Click(object sender, EventArgs e)
        {
            buttonBW.Enabled = false;
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A, groupColor(averageColor(map.GetPixel(x, y).R, map.GetPixel(x, y).G, map.GetPixel(x, y).B)), groupColor(averageColor(map.GetPixel(x, y).R, map.GetPixel(x, y).G, map.GetPixel(x, y).B)), groupColor(averageColor(map.GetPixel(x, y).R, map.GetPixel(x, y).G, map.GetPixel(x, y).B))));
                }
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
                        for (int x = 0; x < map.Width; x++)
                        {
                            for (int y = 0; y < map.Height; y++)
                            {
                                map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A, (leftShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 1) >> 16) & 255, (leftShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 1) >> 8) & 255, (leftShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 1)) & 255));
                            }
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
        public int leftShift(int par, int dight) {
            int temp = par << dight;
            temp = (temp | (par >> (Convert.ToString(0xFFFFFF, 2).Length - dight)));
            return temp & 0xFFFFFF;
        }
        public int rightShift(int par, int dight)
        {
            int temp = par >> dight;
            temp = (temp | ((par << Convert.ToString(0xFFFFFF, 2).Length - dight) & (twoDight(dight) << Convert.ToString(0xFFFFFF, 2).Length - dight)));
            return temp & 0xFFFFFF;
        }
        [Obsolete]
        private int leftMove(int par) {
            return leftMove(par,1);
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
            return rightMove(par,1);
        }
        [Obsolete]
        private int rightMove(int par, int dight)
        {
            int temp = par >> dight;
            temp = (temp | ((par & temp) << Convert.ToString(par, 2).Length - dight));
            return temp & 0xFFFFFF;
        }
        private int twoDight(int dight) {
            int temp = 0;
            for (int i = 0; i < dight; i++)
            {
                temp += (int) Math.Pow(2,i);
            }
            return temp;
        }
        private void button2_Click(object sender, EventArgs e)
        {
                        button2.Enabled = false;
                        for (int x = 0; x < map.Width; x++)
                        {
                            for (int y = 0; y < map.Height; y++)
                            {
                                map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A, (rightShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 1) >> 16) & 255, (rightShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 1) >> 8) & 255, (rightShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 1)) & 255));
                            }
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
                        for (int x = 0; x < map.Width; x++)
                        {
                            for (int y = 0; y < map.Height; y++)
                            {
                                map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A, (leftShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 4) >> 16) & 255, (leftShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 4) >> 8) & 255, (leftShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 4)) & 255));
                            }
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
                        for (int x = 0; x < map.Width; x++)
                        {
                            for (int y = 0; y < map.Height; y++)
                            {
                                map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A, (rightShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 4) >> 16) & 255, (rightShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 4) >> 8) & 255, (rightShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 4)) & 255));
                            }
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
                        for (int x = 0; x < map.Width; x++)
                        {
                            for (int y = 0; y < map.Height; y++)
                            {
                                map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A, (leftShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 8) >> 16) & 255, (leftShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 8) >> 8) & 255, (leftShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 8)) & 255));
                            }
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
                        for (int x = 0; x < map.Width; x++)
                        {
                            for (int y = 0; y < map.Height; y++)
                            {
                                map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A, (rightShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 8) >> 16) & 255, (rightShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 8) >> 8) & 255, (rightShift(map.GetPixel(x, y).ToArgb() & 0xFFFFFF, 8)) & 255));
                            }
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
        private void OnModifyChange(int process, int max) {
            ProgressBarValueChange(process, max);
        }
        private void OnModifyFinish(Bitmap map) {
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = true;
        }
        public void ProgressBarValueChange(int process, int max) {
            progressBar.Maximum = max;
            progressBar.Value = process;
            label1.Text = "Process: " + process + "/" + max;
        }
        public void BlackWhiteAny(int seperater)
        {
            buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
            var thread = new PixelModifyThread(map, 2, seperater);
            thread.ModifyChangingEvent += OnModifyChange;
            thread.ModifyFinishEvent += OnModifyFinish;
            thread.Start();
        }
        public void leftShiftAny(int shift) {
            buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
            var thread = new PixelModifyThread(map, 3, shift);
            thread.ModifyChangingEvent += OnModifyChange;
            thread.ModifyFinishEvent += OnModifyFinish;
            thread.Start();
        }
        public void rightShiftAny(int shift)
        {
            buttonOther.Enabled = buttonLH.Enabled = buttonRH.Enabled = buttonLS2.Enabled = buttonRS2.Enabled = button1.Enabled = button2.Enabled = buttonBW.Enabled = buttonGray.Enabled = false;
            var thread = new PixelModifyThread(map, 4, shift);
            thread.ModifyChangingEvent += OnModifyChange;
            thread.ModifyFinishEvent += OnModifyFinish;
            thread.Start();
        }

        private void buttonInvert_Click(object sender, EventArgs e)
        {
            buttonInvert.Enabled = false;
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A, ~(map.GetPixel(x, y).R) & 255, ~(map.GetPixel(x, y).G) & 255, ~(map.GetPixel(x, y).B) & 255));
                }
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            buttonInvert.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A, groupColor(map.GetPixel(x, y).R), groupColor(map.GetPixel(x, y).G), groupColor(map.GetPixel(x, y).B)));
                }
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    map.SetPixel(x, y, Color.FromArgb(map.GetPixel(x, y).A, fourfive(map.GetPixel(x, y).R), fourfive(map.GetPixel(x, y).G), fourfive(map.GetPixel(x, y).B)));
                }
            }
            graphic = Graphics.FromImage(map);
            previewBox.Image = map;
            button4.Enabled = true;
        }
        public int fourfive(int target) {
            if (((target % 16) - 7) < 0)
            {
                target = (int)((float)target / 255 * 10f) * 16 - 1; 
            }
            else
            {
                target = (int)((float)target / 255 * 10f) * 16 - 1 + 16;
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
    }
}
