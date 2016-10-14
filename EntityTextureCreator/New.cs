using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EntityTextureCreator
{
    public partial class NewTC : Form, Former
    {
        public static Bitmap map, zoommap;
        public Graphics graphic;
        public string filename;
        public int state;
        private bool isLockLoc = false;
        private int locX, locY;
        public NewTC()
        {
            InitializeComponent();
            ((Former)this).new21file();
            zoommap = zoom(map);
            designBox.Image = zoommap;
//            designBox.Scale(new SizeF(2, 2));
        }
        private Bitmap zoom(Bitmap map)
        {
            Bitmap scalemap = new Bitmap(512, 256);
            int scaleX = 512 / map.Size.Width;
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
        void Former.new21file(){
            map = new Bitmap(64, 32);
            graphic = Graphics.FromImage(map);
            graphic.Clear(Color.Transparent);
            zoommap = zoom(map);
            redraw();
        }
        void Former.new42file()
        {
            map = new Bitmap(128, 64);
            graphic = Graphics.FromImage(map);
            graphic.Clear(Color.Transparent);
            zoommap = zoom(map);
            redraw();
        }
        void Former.new84file()
        {
            map = new Bitmap(256, 128);
            graphic = Graphics.FromImage(map);
            graphic.Clear(Color.Transparent);
            zoommap = zoom(map);
            redraw();
        }
        public void new168file()
        {
            map = new Bitmap(512, 256);
            graphic = Graphics.FromImage(map);
            graphic.Clear(Color.Transparent);
            zoommap = zoom(map);
            redraw();
        }
        private void redraw() {
            graphic = Graphics.FromImage(map);
            designBox.Image = zoommap;
        }
        private void redraw(Bitmap map)
        {
            designBox.Image = map;
        }
        private void cursorItem_Click(object sender, EventArgs e)
        {
            state = -1;
            cursorItem.CheckState = CheckState.Checked;
            pencilItem.CheckState = CheckState.Unchecked;
            ereasorItem.CheckState = CheckState.Unchecked;
            dRectItem.CheckState = CheckState.Unchecked;
            dOvalItem.CheckState = CheckState.Unchecked;
            fRectItem.CheckState = CheckState.Unchecked;
            fOvalItem.CheckState = CheckState.Unchecked;
        }

        private void pencilItem_Click(object sender, EventArgs e)
        {
            state = 1;
            cursorItem.CheckState = CheckState.Unchecked;
            pencilItem.CheckState = CheckState.Checked;
            ereasorItem.CheckState = CheckState.Unchecked;
            dRectItem.CheckState = CheckState.Unchecked;
            dOvalItem.CheckState = CheckState.Unchecked;
            fRectItem.CheckState = CheckState.Unchecked;
            fOvalItem.CheckState = CheckState.Unchecked;
        }
        private void ereasorItem_Click(object sender, EventArgs e)
        {
            state = 2;
            cursorItem.CheckState = CheckState.Unchecked;
            pencilItem.CheckState = CheckState.Unchecked;
            ereasorItem.CheckState = CheckState.Checked;
            dRectItem.CheckState = CheckState.Unchecked;
            dOvalItem.CheckState = CheckState.Unchecked;
            fRectItem.CheckState = CheckState.Unchecked;
            fOvalItem.CheckState = CheckState.Unchecked;
        }
        private void dRectItem_Click(object sender, EventArgs e)
        {
            state = 3;
            cursorItem.CheckState = CheckState.Unchecked;
            pencilItem.CheckState = CheckState.Unchecked;
            ereasorItem.CheckState = CheckState.Unchecked;
            dRectItem.CheckState = CheckState.Checked;
            dOvalItem.CheckState = CheckState.Unchecked;
            fRectItem.CheckState = CheckState.Unchecked;
            fOvalItem.CheckState = CheckState.Unchecked;
        }
        private void dOvalItem_Click(object sender, EventArgs e)
        {
            state = 4;
            cursorItem.CheckState = CheckState.Unchecked;
            pencilItem.CheckState = CheckState.Unchecked;
            ereasorItem.CheckState = CheckState.Unchecked;
            dRectItem.CheckState = CheckState.Unchecked;
            dOvalItem.CheckState = CheckState.Checked;
            fRectItem.CheckState = CheckState.Unchecked;
            fOvalItem.CheckState = CheckState.Unchecked;
        }
        private void fRectItem_Click(object sender, EventArgs e)
        {
            state = 5;
            cursorItem.CheckState = CheckState.Unchecked;
            pencilItem.CheckState = CheckState.Unchecked;
            ereasorItem.CheckState = CheckState.Unchecked;
            dRectItem.CheckState = CheckState.Unchecked;
            dOvalItem.CheckState = CheckState.Unchecked;
            fRectItem.CheckState = CheckState.Checked;
            fOvalItem.CheckState = CheckState.Unchecked;
        }

        private void fOvalItem_Click(object sender, EventArgs e)
        {
            state = 6;
            cursorItem.CheckState = CheckState.Unchecked;
            pencilItem.CheckState = CheckState.Unchecked;
            ereasorItem.CheckState = CheckState.Unchecked;
            dRectItem.CheckState = CheckState.Unchecked;
            dOvalItem.CheckState = CheckState.Unchecked;
            fRectItem.CheckState = CheckState.Unchecked;
            fOvalItem.CheckState = CheckState.Checked;
        }
        private void designBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > 511 || e.Y < 0 || e.Y > 255) { return; }
            if (e.Button == MouseButtons.Left)
            {
                switch (state)
                {
                    case 1:
                        drawPixel(e.X, e.Y, foreColorItem.BackColor);
                        break;
                    case 2:
                        ereasePixel(e.X, e.Y);
                        break;
                    case 3:
                        drawRect(e.X, e.Y, false);
                        break;
                    case 4:
                        drawOval(e.X, e.Y, false);
                        break;
                    case 5:
                        fillRect(e.X, e.Y, false);
                        break;
                    case 6:
                        fillOval(e.X, e.Y, false);
                        break;
                    default:
                        break;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                switch (state)
                {
                    case 1:
                        drawPixel(e.X, e.Y, backColorItem.BackColor);
                        break;
                    case 2:
                        ereasePixel(e.X, e.Y);
                        break;
                    case 3:
                        drawRect(e.X, e.Y, true);
                        break;
                    case 4:
                        drawOval(e.X, e.Y, true);
                        break;
                    case 5:
                        fillRect(e.X, e.Y, true);
                        break;
                    case 6:
                        fillOval(e.X, e.Y, true);
                        break;
                    default:
                        break;
                }
            }
        }
        private void designBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X > 511 || e.Y < 0 || e.Y > 255) { return; }
            if(e.Button == MouseButtons.Left){
                switch (state)
                {
                    case 1:
                        drawPixel(e.X, e.Y, foreColorItem.BackColor);
                        break;
                    case 2:
                        ereasePixel(e.X, e.Y);
                        break;
                    default:
                        break;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                switch (state)
                {
                    case 1:
                        drawPixel(e.X, e.Y, backColorItem.BackColor);
                        break;
                    case 2:
                        ereasePixel(e.X, e.Y);
                        break;
                    default:
                        break;
                }
            }
            switch (state)
            {
                case 3:
                    previewRect(e.X, e.Y);
                    break;
                case 4:
                    previewOval(e.X, e.Y);
                    break;
                case 5:
                    previewFillRect(e.X, e.Y);
                    break;
                case 6:
                    previewFillOval(e.X, e.Y);
                    break;
                default:
                    break;
            }
        }

        private void drawPixel(int x, int y, Color color) {
            map.SetPixel(x / (512 / map.Width), y / (256 / map.Height), color);
            for (int u = 0; u < (512 / map.Width); u++) {
                for (int v = 0; v < (256 / map.Height); v++) {
                    zoommap.SetPixel(x / (512 / map.Width) * (512 / map.Width) + u, y / (256 / map.Height) * (256 / map.Height) + v, color);
                }
            }
            redraw();
        }

        private void ereasePixel(int x, int y){
            map.SetPixel(x / (512 / map.Width), y / (256 / map.Height), Color.Transparent);
            for (int u = 0; u < (512 / map.Width); u++)
            {
                for (int v = 0; v < (256 / map.Height); v++)
                {
                    zoommap.SetPixel(x / (512 / map.Width) * (512 / map.Width) + u, y / (256 / map.Height) * (256 / map.Height) + v, Color.Transparent);
                }
            }
            redraw();
        }

        private void drawRect(int x, int y, bool isRightClick) {
            if (!isLockLoc && !isRightClick)
            {
                locX = x;locY = y;
                isLockLoc = true;
                return;
            }
            if (isLockLoc)
            {
                if (isRightClick)
                {
                    locX = 0; locY = 0;
                    isLockLoc = false;
                }
                else
                {
                    graphic.DrawRectangle(new Pen(foreColorItem.BackColor,1), Math.Min(locX,x) / (512 / map.Width), Math.Min(locY,y) / (256 / map.Height), Math.Abs(locX - x) / (512 / map.Width), Math.Abs(locY - y) / (256 / map.Height) );
                    zoommap = zoom(map);
                    isLockLoc = false;
                }
            }
            redraw();
        }
        private void previewRect(int x, int y) {
            if (isLockLoc)
            {
                Bitmap preMap = new Bitmap(map);
                Graphics preGraphic = Graphics.FromImage(preMap);
                preGraphic.DrawRectangle(new Pen(foreColorItem.BackColor,1), Math.Min(locX, x) / (512 / map.Width), Math.Min(locY, y) / (256 / map.Height), Math.Abs(locX - x) / (512 / map.Width), Math.Abs(locY - y) / (256 / map.Height));
                redraw(preMap);
            }
        }
        private void drawOval(int x, int y, bool isRightClick)
        {
            if (!isLockLoc && !isRightClick)
            {
                locX = x; locY = y;
                isLockLoc = true;
                return;
            }
            if (isLockLoc)
            {
                if (isRightClick)
                {
                    locX = 0; locY = 0;
                    isLockLoc = false;
                }
                else
                {
                    graphic.DrawEllipse(new Pen(foreColorItem.BackColor, 1), Math.Min(locX, x) / (512 / map.Width), Math.Min(locY, y) / (256 / map.Height), Math.Abs(locX - x) / (512 / map.Width), Math.Abs(locY - y) / (256 / map.Height));
                    zoommap = zoom(map);
                    isLockLoc = false;
                }
            }
            redraw();
        }
        private void previewOval(int x, int y)
        {
            if (isLockLoc)
            {
                Bitmap preMap = new Bitmap(map);
                Graphics preGraphic = Graphics.FromImage(preMap);
                preGraphic.DrawEllipse(new Pen(foreColorItem.BackColor, 1), Math.Min(locX, x) / (512 / map.Width), Math.Min(locY, y) / (256 / map.Height), Math.Abs(locX - x) / (512 / map.Width), Math.Abs(locY - y) / (256 / map.Height));
                redraw(preMap);
            }
        }
        private void fillRect(int x, int y, bool isRightClick)
        {
            if (!isLockLoc && !isRightClick)
            {
                locX = x; locY = y;
                isLockLoc = true;
                return;
            }
            if (isLockLoc)
            {
                if (isRightClick)
                {
                    locX = 0; locY = 0;
                    isLockLoc = false;
                }
                else
                {
                    graphic.FillRectangle(new SolidBrush(foreColorItem.BackColor), Math.Min(locX, x) / (512 / map.Width), Math.Min(locY, y) / (256 / map.Height), Math.Abs(locX - x) / (512 / map.Width) + 1, Math.Abs(locY - y) / (256 / map.Height) + 1);
                    graphic.FillRectangle(new SolidBrush(backColorItem.BackColor), Math.Min(locX, x) / (512 / map.Width) + (locX > x ? -1 : 1), Math.Min(locY, y) / (256 / map.Height) + (locY > y ? -1 : 1), (Math.Abs(locX - x) / (512 / map.Width)) + 1 - 2, (Math.Abs(locY - y) / (256 / map.Height)) + 1 - 2);
                    zoommap = zoom(map);
                    isLockLoc = false;
                }
            }
            redraw();
        }
        private void previewFillRect(int x, int y)
        {
            if (isLockLoc)
            {
                Bitmap preMap = new Bitmap(map);
                Graphics preGraphic = Graphics.FromImage(preMap);
                preGraphic.FillRectangle(new SolidBrush(foreColorItem.BackColor), Math.Min(locX, x) / (512 / map.Width), Math.Min(locY, y) / (256 / map.Height), Math.Abs(locX - x) / (512 / map.Width) + 1, Math.Abs(locY - y) / (256 / map.Height) + 1);
                preGraphic.FillRectangle(new SolidBrush(backColorItem.BackColor), Math.Min(locX, x) / (512 / map.Width) + (locX > x ? -1 : 1), Math.Min(locY, y) / (256 / map.Height) + (locY > y ? -1 : 1), (Math.Abs(locX - x) / (512 / map.Width)) + 1 - 2, (Math.Abs(locY - y) / (256 / map.Height)) + 1 - 2);
                redraw(preMap);
            }
        }
        private void fillOval(int x, int y, bool isRightClick)
        {
            if (!isLockLoc && !isRightClick)
            {
                locX = x; locY = y;
                isLockLoc = true;
                return;
            }
            if (isLockLoc)
            {
                if (isRightClick)
                {
                    locX = 0; locY = 0;
                    isLockLoc = false;
                }
                else
                {
                    graphic.FillEllipse(new SolidBrush(backColorItem.BackColor), Math.Min(locX, x) / (512 / map.Width), Math.Min(locY, y) / (256 / map.Height), Math.Abs(locX - x) / (512 / map.Width), Math.Abs(locY - y) / (256 / map.Height));
                    graphic.DrawEllipse(new Pen(foreColorItem.BackColor,1), Math.Min(locX, x) / (512 / map.Width), Math.Min(locY, y) / (256 / map.Height), Math.Abs(locX - x) / (512 / map.Width), Math.Abs(locY - y) / (256 / map.Height));
                    zoommap = zoom(map);
                    isLockLoc = false;
                }
            }
            redraw();
        }
        private void previewFillOval(int x, int y)
        {
            if (isLockLoc)
            {
                Bitmap preMap = new Bitmap(map);
                Graphics preGraphic = Graphics.FromImage(preMap);
                preGraphic.FillEllipse(new SolidBrush(backColorItem.BackColor), Math.Min(locX, x) / (512 / map.Width), Math.Min(locY, y) / (256 / map.Height), Math.Abs(locX - x) / (512 / map.Width), Math.Abs(locY - y) / (256 / map.Height));
                preGraphic.DrawEllipse(new Pen(foreColorItem.BackColor, 1), Math.Min(locX, x) / (512 / map.Width), Math.Min(locY, y) / (256 / map.Height), Math.Abs(locX - x) / (512 / map.Width), Math.Abs(locY - y) / (256 / map.Height));
                redraw(preMap);
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

        private void newFileItem_Click(object sender, EventArgs e)
        {
            new NewTexture(this).ShowDialog();
            redraw();
        }

        private void x64Item_Click(object sender, EventArgs e)
        {
            scaleBitmap(256,128);
        }

        private void x32Item_Click(object sender, EventArgs e)
        {
            scaleBitmap(128,64);
        }
        private void scaleBitmap(int width,int height) {
            Bitmap scalemap = new Bitmap(width, height);
            if (map.Height < height && map.Width < width)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    for (int y = 0; y < map.Height; y++)
                    {
                        for (int i = 0; i < (width / map.Width); i++)
                        {
                            for (int j = 0; j < (height / map.Height); j++)
                            {
                                scalemap.SetPixel(x * (width / map.Width) + i, y * (height / map.Height) + j, map.GetPixel(x, y));
                            }
                        }
                    }
                }
                map = scalemap;
            }
            else if (map.Height > height && map.Width > width)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    for (int y = 0; y < map.Height; y++)
                    {
                        scalemap.SetPixel(x / (map.Width / width), y / (map.Height / height), map.GetPixel(x, y));
                    }
                }
                map = scalemap;
            }
            zoommap = zoom(map);
            redraw();
        }

        private void x16Item_Click(object sender, EventArgs e)
        {
            scaleBitmap(64,32);
        }

        private void x128Item_Click(object sender, EventArgs e)
        {
            scaleBitmap(512,256);
        }

        private void C90Item_Click(object sender, EventArgs e)
        {
            map.RotateFlip(RotateFlipType.Rotate90FlipNone);
            zoommap = zoom(map);
            redraw();
        }

        private void AC90Item_Click(object sender, EventArgs e)
        {
            map.RotateFlip(RotateFlipType.Rotate270FlipNone);
            zoommap = zoom(map);
            redraw();
        }

        private void R180Item_Click(object sender, EventArgs e)
        {
            map.RotateFlip(RotateFlipType.Rotate180FlipNone);
            zoommap = zoom(map);
            redraw();
        }

        private void HMItem_Click(object sender, EventArgs e)
        {
            map.RotateFlip(RotateFlipType.RotateNoneFlipX);
            zoommap = zoom(map);
            redraw();
        }

        private void VMItem_Click(object sender, EventArgs e)
        {
            map.RotateFlip(RotateFlipType.RotateNoneFlipY);
            zoommap = zoom(map);
            redraw();
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
            if (file.Width >= 512 && file.Height >= 256)
            {
                map = new Bitmap(file, new Size(512, 256));
            }
            else if (file.Width >= 256 && file.Height >= 128 && file.Width < 512 && file.Height < 256)
            {
                map = new Bitmap(file, new Size(256, 128));
            }
            else if (file.Width >= 128 && file.Height >= 64 && file.Width < 256 && file.Height < 128)
            {
                map = new Bitmap(file, new Size(128, 64));
            }
            else
            {
                map = new Bitmap(file, new Size(64, 32));
            }
            graphic = Graphics.FromImage(map);
            zoommap = zoom(map);
            redraw();
        }

    }
}
