﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Main
{
    public partial class ResourceHelper : Form
    {
        public ResourceHelper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new TextureCreator.Lite().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ColorConvertor.Main().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new EntityTextureCreator.Lite().ShowDialog();
        }
    }
}