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
    public partial class DrawThings : Form
    {
        private DrawLineForm drawLineForm1;
        private DrawOvalForm drawOvalForm1;
        private DrawRectForm drawRectForm1;
        private DrawFillRectForm drawFillRectForm1;
        private Geometry drawer;
        Lite parent;
        int id;
        public DrawThings(Lite parent, int id)
        {
            InitializeComponent();
            this.parent = parent;
            this.id = id;
            showDraw(id);
        }
        private void showDraw(int id) {
            switch (id)
            {
                case 1:
                    this.drawLineForm1 = new TextureCreator.DrawLineForm(parent);
                    this.drawLineForm1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    this.drawLineForm1.Location = new System.Drawing.Point(0, 0);
                    this.drawLineForm1.Margin = new System.Windows.Forms.Padding(0);
                    this.drawLineForm1.Name = "drawLineForm1";
                    this.drawLineForm1.Size = new System.Drawing.Size(185, 200);
                    this.drawLineForm1.TabIndex = 0;
                    this.Controls.Add(this.drawLineForm1);
                    this.drawer = this.drawLineForm1;
                    break;
                case 2:
                    this.drawOvalForm1 = new TextureCreator.DrawOvalForm(parent);
                    this.drawOvalForm1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    this.drawOvalForm1.Location = new System.Drawing.Point(0, 0);
                    this.drawOvalForm1.Margin = new System.Windows.Forms.Padding(0);
                    this.drawOvalForm1.Name = "drawOvalForm1";
                    this.drawOvalForm1.Size = new System.Drawing.Size(185, 200);
                    this.drawOvalForm1.TabIndex = 0;
                    this.Controls.Add(this.drawOvalForm1);
                    this.drawer = this.drawOvalForm1;
                    break;
                case 3:
                    this.drawRectForm1 = new TextureCreator.DrawRectForm(parent);
                    this.drawRectForm1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    this.drawRectForm1.Location = new System.Drawing.Point(0, 0);
                    this.drawRectForm1.Margin = new System.Windows.Forms.Padding(0);
                    this.drawRectForm1.Name = "drawRectForm1";
                    this.drawRectForm1.Size = new System.Drawing.Size(185, 200);
                    this.drawRectForm1.TabIndex = 0;
                    this.Controls.Add(this.drawRectForm1);
                    this.drawer = this.drawRectForm1;
                    break;
                case 4:
                    this.drawFillRectForm1 = new TextureCreator.DrawFillRectForm(parent);
                    this.drawFillRectForm1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    this.drawFillRectForm1.Location = new System.Drawing.Point(0, 0);
                    this.drawFillRectForm1.Margin = new System.Windows.Forms.Padding(0);
                    this.drawFillRectForm1.Name = "drawFillRectForm1";
                    this.drawFillRectForm1.Size = new System.Drawing.Size(400, 200);
                    this.drawFillRectForm1.TabIndex = 0;
                    this.Controls.Add(this.drawFillRectForm1);
                    this.drawer = this.drawFillRectForm1;
                    break;
            }
        }

        private void butColor_Click(object sender, EventArgs e)
        {
            int a, r, g, b;
            try
            {
                a = Int32.Parse(txtbA.Text); r = Int32.Parse(txtbR.Text); g = Int32.Parse(txtbG.Text); b = Int32.Parse(txtbB.Text);
            }
            catch (Exception)
            {
                a = 0; r = 0; g = 0; b = 0;
            }
            this.colorDialog1.Color = Color.FromArgb(a,r,g,b);
            this.colorDialog1.ShowDialog();
            txtbA.Text = this.colorDialog1.Color.A.ToString();
            txtbR.Text = this.colorDialog1.Color.R.ToString();
            txtbG.Text = this.colorDialog1.Color.G.ToString();
            txtbB.Text = this.colorDialog1.Color.B.ToString();
            this.butColor.BackColor = this.colorDialog1.Color;
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            int a, r, g, b;
            try
            {
                a = Int32.Parse(txtbA.Text); r = Int32.Parse(txtbR.Text); g = Int32.Parse(txtbG.Text); b = Int32.Parse(txtbB.Text);
            }
            catch (Exception)
            {
                a = 0; r = 0; g = 0; b = 0;
                return;
            }
            this.drawer.draw(a, r, g, b);
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
