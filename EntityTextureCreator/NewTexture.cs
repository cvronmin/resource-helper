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
        private Former parent;
        public NewTexture(Former parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void butCreate_Click(object sender, EventArgs e)
        {
            if(rBut16.Checked){
                parent.new21file();
            }
            else if (rBut32.Checked)
            {
                parent.new42file();
            }
            else if (rBut64.Checked)
            {
                parent.new84file();
            }
            this.Close();
        }
    }
}
