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
            setEnableState();
        }
        private void setEnableState()
        {
            if(System.IO.File.Exists(Environment.CurrentDirectory + @"\ColorConvertor.dll")){
                button2.Enabled = true;
            }
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\TextureCreator.dll"))
            {
                button1.Enabled = true;
            }
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\EntityTextureCreator.dll"))
            {
                button3.Enabled = true;
            }
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\TextureEditor.dll"))
            {
                button6.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new TextureCreator.NewTC().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ColorConvertor.Main().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new EntityTextureCreator.NewTC().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new TextureComparer.Compare().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new TextureEditor.Form1().Show();
        }
    }
}
