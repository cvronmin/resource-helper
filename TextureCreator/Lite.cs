using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextureCreator
{
    public partial class Lite : Form
    {
        private PixelButton[,] pixels = new PixelButton[16,16];
        private PixelButton selectpix;
        public static Bitmap map;
        public Graphics gra;
        public string filename;
        Recorder record = new Recorder();
        public Lite()
        {
            InitializeComponent();
            new16File();
            initCrossPixels();
        }
        public void new16File() {
            pixels = new PixelButton[16, 16];
            map = new Bitmap(16,16);
            gra = Graphics.FromImage(map);
            gra.Clear(Color.Transparent);
        }
        public void new32File() {
            pixels = new PixelButton[32, 32];
            map = new Bitmap(32, 32);
            gra = Graphics.FromImage(map);
            gra.Clear(Color.Transparent);
        }
        public void new64File()
        {
            pixels = new PixelButton[64, 64];
            map = new Bitmap(64, 64);
            gra = Graphics.FromImage(map);
            gra.Clear(Color.Transparent);
        }
/*        private void initPixels(){
            this.designPanel.Controls.Clear();
            for (int x = 0; x < pixels.GetLength(0);x++ )
            {
                for (int y = 0; y < pixels.GetLength(1); y++) {
                    pixels[x, y] = new PixelButton();
                    pixels[x, y].BackColor = System.Drawing.Color.Transparent;
                    pixels[x, y].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    pixels[x, y].FlatAppearance.BorderSize = 0;
                    pixels[x, y].Location = new System.Drawing.Point(0, 0);
                    pixels[x, y].Margin = new System.Windows.Forms.Padding(0);
                    pixels[x, y].Name = "pixel";
                    if (pixels.GetLength(0) == 32 && pixels.GetLength(1) == 32)
                    {
                        pixels[x, y].Size = new System.Drawing.Size(8, 8);
                    }
                    else
                    {
                        pixels[x, y].Size = new System.Drawing.Size(16, 16);
                    }
                    pixels[x, y].UseVisualStyleBackColor = false;
                    pixels[x, y].setXY(x, y);
                    pixels[x, y].Click += new System.EventHandler(this.pixels_Click);
                    pixels[x, y].BackColorChanged += new System.EventHandler(this.pixels_Changed);
                    this.designPanel.Controls.Add(pixels[x, y]);
                }
            }
            if (pixels.GetLength(0) == 32 && pixels.GetLength(1) == 32)
            {
                lblSizex.Text = "32x32";
            }
            else
            {
                lblSizex.Text = "16x16";
            }
            redrawPixels();
        }*/
        private void initCrossPixels()
        {
            this.designPanel.Controls.Clear();
            for (int x = 0; x < pixels.GetLength(0); x++)
            {
                for (int y = 0; y < pixels.GetLength(1); y++)
                {
                    pixels[y, x] = new PixelButton();
                    pixels[y, x].BackColor = System.Drawing.Color.Transparent;
                    pixels[y, x].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    pixels[y, x].FlatAppearance.BorderSize = 0;
                    pixels[y, x].Location = new System.Drawing.Point(0, 0);
                    pixels[y, x].Margin = new System.Windows.Forms.Padding(0);
                    pixels[y, x].Name = "pixel";
                    if (pixels.GetLength(0) == 64 && pixels.GetLength(1) == 64)
                    {
                        pixels[y, x].Size = new System.Drawing.Size(4, 4);
                    }
                    else if (pixels.GetLength(0) == 32 && pixels.GetLength(1) == 32)
                    {
                        pixels[y, x].Size = new System.Drawing.Size(8, 8);
                    }
                    else
                    {
                        pixels[y, x].Size = new System.Drawing.Size(16, 16);
                    }
                    pixels[y, x].UseVisualStyleBackColor = false;
                    pixels[y, x].setXY(y, x);
                    pixels[y, x].Click += new System.EventHandler(this.pixels_Click);
                    pixels[y, x].BackColorChanged += new System.EventHandler(this.pixels_Changed);
                    this.designPanel.Controls.Add(pixels[y, x]);
                }
            }
            if (pixels.GetLength(0) == 64 && pixels.GetLength(1) == 64)
            {
                lblSizex.Text = "64x64";
            }
            else if (pixels.GetLength(0) == 32 && pixels.GetLength(1) == 32)
            {
                lblSizex.Text = "32x32";
            }
            else
            {
                lblSizex.Text = "16x16";
            }
            redrawPixels();
        }
        private void redrawPixels() {
            for (int x = 0; x < pixels.GetLength(0); x++)
            {
                for (int y = 0; y < pixels.GetLength(1); y++)
                {
                    pixels[x,y].BackColor = map.GetPixel(pixels[x,y].getX(), pixels[x,y].getY());
                }
            }
        }
        private void pixels_Click(object sender, EventArgs e)
        {
            if((sender is PixelButton)){
            selectpix = (PixelButton)sender;
            RedCount.Text = (map.GetPixel(selectpix.getX(), selectpix.getY()).R).ToString();
            GreenCount.Text = (map.GetPixel(selectpix.getX(), selectpix.getY()).G).ToString();
            BlueCount.Text = (map.GetPixel(selectpix.getX(), selectpix.getY()).B).ToString();
            AlphaCount.Text = (map.GetPixel(selectpix.getX(), selectpix.getY()).A).ToString();
            pixelInfo.Text = "像素資訊" + selectpix.getX() + "," + selectpix.getY();
            }
        }
        private void pixels_Changed(object sender, EventArgs e) {
 /*           if(map != null){
            record.addRecord(map);
            record.saveHistory();
            undoItem.Enabled = (record.getRecordCount() != 0);
            }*/
        }

        private void AlphaCount_TextChanged(object sender, EventArgs e)
        {
            map.SetPixel(selectpix.getX(), selectpix.getY(), Color.FromArgb(
                    Int32.Parse(AlphaCount.Text) & 255,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).R,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).G,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).B));
            selectpix.BackColor = Color.FromArgb(
                    Int32.Parse(AlphaCount.Text) & 255,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).R,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).G,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).B);
        }

        private void RedCount_TextChanged(object sender, EventArgs e)
        {
            map.SetPixel(selectpix.getX(), selectpix.getY(), Color.FromArgb(
                    map.GetPixel(selectpix.getX(), selectpix.getY()).A,
                    Int32.Parse(RedCount.Text) & 255,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).G,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).B));
            selectpix.BackColor = Color.FromArgb(
                    map.GetPixel(selectpix.getX(), selectpix.getY()).A,
                    Int32.Parse(RedCount.Text) & 255,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).G,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).B);
        }

        private void GreenCount_TextChanged(object sender, EventArgs e)
        {
            map.SetPixel(selectpix.getX(), selectpix.getY(), Color.FromArgb(
                    map.GetPixel(selectpix.getX(), selectpix.getY()).A,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).R,
                    Int32.Parse(GreenCount.Text) & 255,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).B));
            selectpix.BackColor = Color.FromArgb(
                    map.GetPixel(selectpix.getX(), selectpix.getY()).A,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).R,
                    Int32.Parse(GreenCount.Text) & 255,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).B);
        }

        private void BlueCount_TextChanged(object sender, EventArgs e)
        {
            map.SetPixel(selectpix.getX(), selectpix.getY(), Color.FromArgb(
                    map.GetPixel(selectpix.getX(), selectpix.getY()).A,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).R,
                    map.GetPixel(selectpix.getX(), selectpix.getY()).G,
                    Int32.Parse(BlueCount.Text) & 255));
            selectpix.BackColor = Color.FromArgb(
                map.GetPixel(selectpix.getX(), selectpix.getY()).A,
                map.GetPixel(selectpix.getX(), selectpix.getY()).R,
                map.GetPixel(selectpix.getX(), selectpix.getY()).G,
                Int32.Parse(BlueCount.Text) & 255);
        }

        private void butColor_Click(object sender, EventArgs e)
        {
            if (AlphaCount.Text != null && RedCount.Text != null && GreenCount.Text != null && BlueCount.Text != null)
            {
                colorDialog1.Color = Color.FromArgb(Int32.Parse(AlphaCount.Text), Int32.Parse(RedCount.Text), Int32.Parse(GreenCount.Text), Int32.Parse(BlueCount.Text));
            }
            else
            {
                colorDialog1.Color = Color.Black;
            }
            colorDialog1.ShowDialog();
            RedCount.Text = colorDialog1.Color.R.ToString();
            GreenCount.Text = colorDialog1.Color.G.ToString();
            BlueCount.Text = colorDialog1.Color.B.ToString();
            AlphaCount.Text = colorDialog1.Color.A.ToString();
        }

        private void newFileMenu_Click(object sender, EventArgs e)
        {
            new NewTexture(this).ShowDialog();
            initCrossPixels();
        }

        private void saveFileMenu_Click(object sender, EventArgs e)
        {
            if (filename == null) {
                saveAsMenu_Click(sender, e);
            }
        }

        private void saveAsMenu_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.filename = saveFileDialog1.FileName;
            map.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void openFileMenu_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            filename = openFileDialog1.FileName;
            Image file = Image.FromFile(filename);
            if (file.Width >= 64 && file.Height >= 64)
            {
                pixels = new PixelButton[64, 64];
                map = new Bitmap(file, new Size(64, 64));
                initCrossPixels();
            }
            else if (file.Height >= 32 && file.Width >= 32 && file.Height < 64 && file.Width < 64)
            {
                pixels = new PixelButton[32, 32];
                map = new Bitmap(file, new Size(32, 32));
                initCrossPixels();
            }
            else
            {
                pixels = new PixelButton[16, 16];
                map = new Bitmap(file, new Size(16, 16));
                initCrossPixels();
            }
            gra = Graphics.FromImage(map);
            redrawPixels();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butDrawLine_Click(object sender, EventArgs e)
        {
            new DrawThings(this, 1).ShowDialog();
            redrawPixels();
        }

        private void butDrawOval_Click(object sender, EventArgs e)
        {
            new DrawThings(this, 2).ShowDialog();
            redrawPixels();
        }

        private void butDrawRect_Click(object sender, EventArgs e)
        {
            new DrawThings(this, 3).ShowDialog();
            redrawPixels();
        }

        private void butDrawFillRect_Click(object sender, EventArgs e)
        {
            new DrawThings(this, 4).ShowDialog();
            redrawPixels();
        }

        private void butFlipX_Click(object sender, EventArgs e)
        {
            map.RotateFlip(RotateFlipType.RotateNoneFlipX);
            redrawPixels();
        }

        private void butFilpY_Click(object sender, EventArgs e)
        {
            map.RotateFlip(RotateFlipType.RotateNoneFlipY);
            redrawPixels();
        }

        private void butRotate90_Click(object sender, EventArgs e)
        {
            map.RotateFlip(RotateFlipType.Rotate90FlipNone);
            redrawPixels();
        }

        private void butRotate180_Click(object sender, EventArgs e)
        {
            map.RotateFlip(RotateFlipType.Rotate180FlipNone);
            redrawPixels();
        }

        private void butRotate270_Click(object sender, EventArgs e)
        {
            map.RotateFlip(RotateFlipType.Rotate270FlipNone);
            redrawPixels();
        }
        private void butScale64_Click(object sender, EventArgs e)
        {
            Bitmap scalemap = new Bitmap(64, 64);
            if (map.Height == 16 && map.Width == 16)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        scalemap.SetPixel(x * 4    , y * 4    , map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 1, y * 4    , map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4    , y * 4 + 1, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 1, y * 4 + 1, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 2, y * 4    , map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4    , y * 4 + 2, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 3, y * 4    , map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4    , y * 4 + 3, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 1, y * 4 + 1, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 2, y * 4 + 1, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 3, y * 4 + 1, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 1, y * 4 + 2, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 1, y * 4 + 3, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 2, y * 4 + 2, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 2, y * 4 + 3, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 3, y * 4 + 2, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 4 + 3, y * 4 + 3, map.GetPixel(x, y));
                    }
                }
                map = scalemap;
            }
            if (map.Height == 32 && map.Width == 32)
            {
                for (int x = 0; x < 32; x++)
                {
                    for (int y = 0; y < 32; y++)
                    {
                        scalemap.SetPixel(x * 2    , y * 2    , map.GetPixel(x, y));
                        scalemap.SetPixel(x * 2 + 1, y * 2    , map.GetPixel(x, y));
                        scalemap.SetPixel(x * 2    , y * 2 + 1, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 2 + 1, y * 2 + 1, map.GetPixel(x, y));
                    }
                }
                map = scalemap;
            }
            pixels = new PixelButton[64, 64];
            initCrossPixels();
        }

        private void butScale32_Click(object sender, EventArgs e)
        {
            Bitmap scalemap = new Bitmap(32, 32);
            if (map.Height == 16 && map.Width == 16)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        scalemap.SetPixel(x * 2, y * 2, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 2 + 1, y * 2, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 2, y * 2 + 1, map.GetPixel(x, y));
                        scalemap.SetPixel(x * 2 + 1, y * 2 + 1, map.GetPixel(x, y));
                    }
                }
             map = scalemap;
            }
            if (map.Height == 64 && map.Width == 64)
            {
                for (int x = 0; x < 64; x++)
                {
                    for (int y = 0; y < 64; y++)
                    {
                        scalemap.SetPixel(x / 2, y / 2, map.GetPixel(x, y));
                    }
                }
                map = scalemap;
            }
            pixels = new PixelButton[32, 32];
            initCrossPixels();
        }

        private void butscale16_Click(object sender, EventArgs e)
        {
            Bitmap scalemap = new Bitmap(16, 16);
            if (map.Height == 64 && map.Width == 64)
            {
                for (int x = 0; x < 64; x++)
                {
                    for (int y = 0; y < 64; y++)
                    {
                        scalemap.SetPixel(x / 4, y / 4, map.GetPixel(x, y));
                    }
                }
                map = scalemap;
            }
            if(map.Height == 32 && map.Width == 32){
                for (int x = 0; x < 32; x++)
                {
                    for (int y = 0; y < 32; y++)
                    {
                        scalemap.SetPixel(x / 2, y / 2, map.GetPixel(x, y));
                    }
                }
            map = scalemap;
            }
            pixels = new PixelButton[16, 16];
            initCrossPixels();
        }

        private void undoItem_Click(object sender, EventArgs e)
        {
   /*         map = record.getRecord();
            redrawPixels();*/
        }

    }
}
