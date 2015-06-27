using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EntityTextureCreator
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
                parent.new21File();
            }
            else if (rBut162.Checked)
            {
                parent.new22File();
            }
            else if (rBut32.Checked)
            {
                parent.new42File();
            }
            this.Close();
        }
    }
}
