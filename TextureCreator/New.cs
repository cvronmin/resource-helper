using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextureCreator
{
    public partial class NewTC : Form
    {
        public static Bitmap map, zoommap;
        public Graphics graphic;
        public string filename;
        public int state;
        public NewTC()
        {
            InitializeComponent();
            new16file();
            zoommap = zoom(map);
            designBox.Image = zoommap;
//            designBox.Scale(new SizeF(2, 2));
        }
        private Bitmap zoom(Bitmap map)
        {
            Bitmap scalemap = new Bitmap(256, 256);
            int scaleX = 256 / map.Size.Width;
            int scaleY = 256 / map.Size.Height;
            for (int x = 0; x < map.Size.Width; x++)
            {
                for (int y = 0; y < map.Size.Height; y++)
                {
                    for (int u = 0; u < scaleX; u++)
                    {
                        for (int v = 0; v < scaleY; v++)
                        {
                            scalemap.SetPixel(x * scaleX + u, y * scaleY + v, map.GetPixel(x, y));
                        }
                    }
                }
            }
            return scalemap;
        }
        public void new16file(){
            map = new Bitmap(16, 16);
            graphic = Graphics.FromImage(map);
            graphic.Clear(Color.Transparent);
        }
        public void new32file()
        {
            map = new Bitmap(32, 32);
            graphic = Graphics.FromImage(map);
            graphic.Clear(Color.Transparent);
        }
        public void new64file()
        {
            map = new Bitmap(64, 64);
            graphic = Graphics.FromImage(map);
            graphic.Clear(Color.Transparent);
        }
        public void new256file()
        {
            map = new Bitmap(256, 256);
            graphic = Graphics.FromImage(map);
            graphic.Clear(Color.Transparent);
        }
        private void redraw() {
            graphic = Graphics.FromImage(map);
            designBox.Image = zoommap;
        }
        private void cursorItem_Click(object sender, EventArgs e)
        {
            state = -1;
            cursorItem.CheckState = CheckState.Checked;
            pencilItem.CheckState = CheckState.Unchecked;
            ereasorItem.CheckState = CheckState.Unchecked;
        }

        private void pencilItem_Click(object sender, EventArgs e)
        {
            state = 1;
            cursorItem.CheckState = CheckState.Unchecked;
            pencilItem.CheckState = CheckState.Checked;
            ereasorItem.CheckState = CheckState.Unchecked;
        }
        private void ereasorItem_Click(object sender, EventArgs e)
        {
            state = 2;
            cursorItem.CheckState = CheckState.Unchecked;
            pencilItem.CheckState = CheckState.Unchecked;
            ereasorItem.CheckState = CheckState.Checked;
        }
        private void designBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > 255 || e.Y < 0 || e.Y > 255) { return; }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (state == 1)
                {
                    drawPixel(e.X, e.Y, foreColorItem.BackColor);
                }
                if (state == 2)
                {
                    ereasePixel(e.X, e.Y);
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (state == 1)
                {
                    drawPixel(e.X, e.Y, backColorItem.BackColor);
                }
                if (state == 2)
                {
                    ereasePixel(e.X, e.Y);
                }
            }
            redraw();
        }
        private void designBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > 255 || e.Y < 0 || e.Y > 255) { return; }
            if(e.Button == System.Windows.Forms.MouseButtons.Left){
                if(state == 1){
                    drawPixel(e.X, e.Y, foreColorItem.BackColor);
                }
                if (state == 2)
                {
                    ereasePixel(e.X, e.Y);
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (state == 1)
                {
                    drawPixel(e.X, e.Y, backColorItem.BackColor);
                }
                if (state == 2)
                {
                    ereasePixel(e.X, e.Y);
                }
            }
            redraw();
        }

        private void drawPixel(int x, int y, Color color) {
            map.SetPixel(x / (256 / map.Width), y / (256 / map.Height), color);
            for (int u = 0; u < (256 / map.Width); u++) {
                for (int v = 0; v < (256 / map.Height); v++) {
                    zoommap.SetPixel(x / (256 / map.Width) * (256 / map.Width) + u, y / (256 / map.Height) * (256 / map.Height) + v, color);
                }
            }
        }

        private void ereasePixel(int x, int y){
            map.SetPixel(x / (256 / map.Width), y / (256 / map.Height), Color.Transparent);
            for (int u = 0; u < (256 / map.Width); u++)
            {
                for (int v = 0; v < (256 / map.Height); v++)
                {
                    zoommap.SetPixel(x / (256 / map.Width) * (256 / map.Width) + u, y / (256 / map.Height) * (256 / map.Height) + v, Color.Transparent);
                }
            }
        }

        private void foreColorItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = foreColorItem.BackColor;
            colorDialog1.ShowDialog();
            foreColorItem.BackColor = colorDialog1.Color;
        }

        private void backColorItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = backColorItem.BackColor;
            colorDialog1.ShowDialog();
            backColorItem.BackColor = colorDialog1.Color;
        }

        private void saveItem_Click(object sender, EventArgs e)
        {
            if (filename == null)
            {
                saveAsItem_Click(sender, e);
            }
            else
            {
                map.Save(filename);
            }
        }

        private void saveAsItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.filename = saveFileDialog1.FileName;
            map.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            this.Text = filename != null ? "Texture Creator - " + filename : "Texture Creator - Untitled";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            filename = openFileDialog1.FileName;
            this.Text = filename != null ? "Texture Creator - " + filename : "Texture Creator - Untitled";
            Image file = Image.FromFile(filename);
            if (file.Width >= 256 && file.Height >= 256)
            {
                map = new Bitmap(file, new Size(256, 256));
            }
            else if (file.Width >= 64 && file.Height >= 64 && file.Height < 256 && file.Width < 256)
            {
                map = new Bitmap(file, new Size(64, 64));
            }
            else if (file.Height >= 32 && file.Width >= 32 && file.Height < 64 && file.Width < 64)
            {
                map = new Bitmap(file, new Size(32, 32));
            }
            else
            {
                map = new Bitmap(file, new Size(16, 16));
            }
            graphic = Graphics.FromImage(map);
            redraw();
        }

    }
}
