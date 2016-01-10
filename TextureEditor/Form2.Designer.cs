namespace TextureEditor
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRS = new System.Windows.Forms.Button();
            this.buttonLS = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOkRGB = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRS);
            this.groupBox1.Controls.Add(this.buttonLS);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shift";
            // 
            // buttonRS
            // 
            this.buttonRS.Location = new System.Drawing.Point(215, 20);
            this.buttonRS.Name = "buttonRS";
            this.buttonRS.Size = new System.Drawing.Size(75, 23);
            this.buttonRS.TabIndex = 2;
            this.buttonRS.Text = "Right Shift";
            this.buttonRS.UseVisualStyleBackColor = true;
            this.buttonRS.Click += new System.EventHandler(this.buttonRS_Click);
            // 
            // buttonLS
            // 
            this.buttonLS.Location = new System.Drawing.Point(134, 21);
            this.buttonLS.Name = "buttonLS";
            this.buttonLS.Size = new System.Drawing.Size(75, 23);
            this.buttonLS.TabIndex = 1;
            this.buttonLS.Text = "Left Shift";
            this.buttonLS.UseVisualStyleBackColor = true;
            this.buttonLS.Click += new System.EventHandler(this.buttonLS_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(7, 21);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOkRGB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonOk);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Location = new System.Drawing.Point(13, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Threshold";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Value: 127";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(240, 94);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Grey";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.LargeChange = 16;
            this.trackBar1.Location = new System.Drawing.Point(6, 21);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(309, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 127;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(342, 170);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOkRGB
            // 
            this.buttonOkRGB.Location = new System.Drawing.Point(159, 94);
            this.buttonOkRGB.Name = "buttonOkRGB";
            this.buttonOkRGB.Size = new System.Drawing.Size(75, 23);
            this.buttonOkRGB.TabIndex = 3;
            this.buttonOkRGB.Text = "RGB";
            this.buttonOkRGB.UseVisualStyleBackColor = true;
            this.buttonOkRGB.Click += new System.EventHandler(this.buttonOkRGB_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 211);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRS;
        private System.Windows.Forms.Button buttonLS;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOkRGB;
    }
}