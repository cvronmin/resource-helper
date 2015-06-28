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
    public partial class NewTexture : Form
    {
        private Lite parent;
        public NewTexture(Lite parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void butCreate_Click(object sender, EventArgs e)
        {
            if(rBut16.Checked){
                parent.new16File();
            }
            else if (rBut32.Checked)
            {
                parent.new32File();
            }
            else if (rBut64.Checked)
            {
                parent.new64File();
            }
            this.Close();
        }
    }
}
