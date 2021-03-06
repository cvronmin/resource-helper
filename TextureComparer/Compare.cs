﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextureComparer
{
    public partial class Compare : Form
    {
        Bitmap map1, map2, map3, map4, zoomMap1, zoomMap2, zoomMap3, zoomMap4;
        public override bool AllowDrop { get { return true; } set {} }
        public Compare()
        {
            InitializeComponent();
            DragEnter += new DragEventHandler(this.Compare_DragEnter);
            DragDrop += new DragEventHandler(this.Compare_DragDrop);
        }

        private void butReset_Click(object sender, EventArgs e)
        {
            comp1.Image = null;
            comp2.Image = null;
            map1 = null; map2 = null; map3 = null; map4 = null;
            zoomMap1 = null; zoomMap2 = null; zoomMap3 = null; zoomMap4 = null;
            MessageBox.Show("d");
        }

        private void comp1_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show(e.Data.GetFormats().ToString());
        }

        private void comp1_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("comp1.dragEnter");
            object fileNameW = e.Data.GetData("FileNameW");
            if (fileNameW != null)
            {
                string[] fileNames = (string[])fileNameW;
                if (fileNames.Length == 1)
                {
                    string fileName = fileNames[0];

                    if (Path.GetExtension(fileName) == ".png")
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
        }

        private void Compare_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
/*            if (e.Data.GetDataPresent(DataFormats.Bitmap) ||
               e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }*/
        }
        private void Compare_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show(e.Data.GetFormats().ToString());
        }

        private void Compare_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            this.comp1.AllowDrop = true;
            this.comp2.AllowDrop = true;
            MessageBox.Show(this.AllowDrop.ToString());
        }

        private void butComp_Click(object sender, EventArgs e)
        {
            int count = 0;
            map3 = new Bitmap(map1.Size.Width, map1.Size.Height);
            map4 = new Bitmap(map2.Size.Width, map2.Size.Height);
            if (map1.Size != map2.Size) {
                MessageBox.Show("Cannot compare:different size");
                return;
            }
            for (int x = 0; x < map1.Size.Width; x++) {
                for (int y = 0; y < map1.Size.Height; y++) {
                    if (map1.GetPixel(x,y) != map2.GetPixel(x,y)) {
                        map3.SetPixel(x, y, map1.GetPixel(x, y));
                        map4.SetPixel(x, y, map2.GetPixel(x, y));
                        ++count;
                    }
                }
            }
            zoomMap3 = zoom(map3);
            zoomMap4 = zoom(map4);
            comp1.Image = zoomMap3;
            comp2.Image = zoomMap4;
            label1.Text = "There are " + (map1.Size.Width * map1.Size.Height - count)  + " same pixels and " + count + " different pixels";
        }

        private void butC1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            map1 = new Bitmap(Image.FromFile(openFileDialog1.FileName));
            zoomMap1 = zoom(map1);
            comp1.Image = zoomMap1;
        }

        private void butC2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            map2 = new Bitmap(Image.FromFile(openFileDialog2.FileName));
            zoomMap2 = zoom(map2);
            comp2.Image = zoomMap2;
        }

        private Bitmap zoom(Bitmap map) {
            Bitmap scalemap = new Bitmap(256, 256);
            int scaleX = 256 / map.Size.Width;
            int scaleY = 256 / map.Size.Height;
            for (int x = 0; x < map.Size.Width; x++)
            {
                for (int y = 0; y < map.Size.Height; y++)
                {
                    for (int u = 0;u < scaleX; u++) {
                        for (int v = 0; v < scaleY; v++) {
                            scalemap.SetPixel(x * scaleX + u, y * scaleY + v, map.GetPixel(x, y));
                        }
                    }
                }
            }
            return scalemap;
        }
    }
}
