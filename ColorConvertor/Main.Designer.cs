namespace ColorConvertor
{
    partial class Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Red = new System.Windows.Forms.Label();
            this.Green = new System.Windows.Forms.Label();
            this.Blue = new System.Windows.Forms.Label();
            this.Alpha = new System.Windows.Forms.Label();
            this.A = new System.Windows.Forms.TextBox();
            this.R = new System.Windows.Forms.TextBox();
            this.G = new System.Windows.Forms.TextBox();
            this.B = new System.Windows.Forms.TextBox();
            this.color4 = new System.Windows.Forms.Label();
            this.color3 = new System.Windows.Forms.Label();
            this.RGB = new System.Windows.Forms.TextBox();
            this.ARGB = new System.Windows.Forms.TextBox();
            this.butARGB = new System.Windows.Forms.Button();
            this.butColor4 = new System.Windows.Forms.Button();
            this.butcolor3 = new System.Windows.Forms.Button();
            this.butRGB = new System.Windows.Forms.Button();
            this.buttonLS = new System.Windows.Forms.Button();
            this.buttonRS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Red
            // 
            this.Red.AutoSize = true;
            this.Red.Location = new System.Drawing.Point(37, 123);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(30, 15);
            this.Red.TabIndex = 0;
            this.Red.Text = "Red";
            // 
            // Green
            // 
            this.Green.AutoSize = true;
            this.Green.Location = new System.Drawing.Point(37, 195);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(41, 15);
            this.Green.TabIndex = 1;
            this.Green.Text = "Green";
            // 
            // Blue
            // 
            this.Blue.AutoSize = true;
            this.Blue.Location = new System.Drawing.Point(37, 281);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(31, 15);
            this.Blue.TabIndex = 2;
            this.Blue.Text = "Blue";
            // 
            // Alpha
            // 
            this.Alpha.AutoSize = true;
            this.Alpha.Location = new System.Drawing.Point(37, 50);
            this.Alpha.Name = "Alpha";
            this.Alpha.Size = new System.Drawing.Size(40, 15);
            this.Alpha.TabIndex = 3;
            this.Alpha.Text = "Alpha";
            // 
            // A
            // 
            this.A.Location = new System.Drawing.Point(83, 50);
            this.A.MaxLength = 3;
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(100, 23);
            this.A.TabIndex = 4;
            // 
            // R
            // 
            this.R.Location = new System.Drawing.Point(83, 123);
            this.R.MaxLength = 3;
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(100, 23);
            this.R.TabIndex = 5;
            // 
            // G
            // 
            this.G.Location = new System.Drawing.Point(84, 195);
            this.G.MaxLength = 3;
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(100, 23);
            this.G.TabIndex = 6;
            // 
            // B
            // 
            this.B.Location = new System.Drawing.Point(84, 278);
            this.B.MaxLength = 3;
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(100, 23);
            this.B.TabIndex = 7;
            // 
            // color4
            // 
            this.color4.AutoSize = true;
            this.color4.Location = new System.Drawing.Point(384, 123);
            this.color4.Name = "color4";
            this.color4.Size = new System.Drawing.Size(39, 15);
            this.color4.TabIndex = 8;
            this.color4.Text = "ARGB";
            // 
            // color3
            // 
            this.color3.AutoSize = true;
            this.color3.Location = new System.Drawing.Point(384, 174);
            this.color3.Name = "color3";
            this.color3.Size = new System.Drawing.Size(31, 15);
            this.color3.TabIndex = 9;
            this.color3.Text = "RGB";
            // 
            // RGB
            // 
            this.RGB.Location = new System.Drawing.Point(351, 192);
            this.RGB.MaxLength = 8;
            this.RGB.Name = "RGB";
            this.RGB.Size = new System.Drawing.Size(100, 23);
            this.RGB.TabIndex = 10;
            // 
            // ARGB
            // 
            this.ARGB.Location = new System.Drawing.Point(351, 97);
            this.ARGB.MaxLength = 10;
            this.ARGB.Name = "ARGB";
            this.ARGB.Size = new System.Drawing.Size(100, 23);
            this.ARGB.TabIndex = 11;
            // 
            // butARGB
            // 
            this.butARGB.Location = new System.Drawing.Point(233, 77);
            this.butARGB.Name = "butARGB";
            this.butARGB.Size = new System.Drawing.Size(75, 23);
            this.butARGB.TabIndex = 12;
            this.butARGB.Text = "to ARGB";
            this.butARGB.UseVisualStyleBackColor = true;
            this.butARGB.Click += new System.EventHandler(this.butARGB_Click);
            // 
            // butColor4
            // 
            this.butColor4.Location = new System.Drawing.Point(233, 106);
            this.butColor4.Name = "butColor4";
            this.butColor4.Size = new System.Drawing.Size(75, 23);
            this.butColor4.TabIndex = 13;
            this.butColor4.Text = "to Colours";
            this.butColor4.UseVisualStyleBackColor = true;
            this.butColor4.Click += new System.EventHandler(this.butColor4_Click);
            // 
            // butcolor3
            // 
            this.butcolor3.Location = new System.Drawing.Point(233, 203);
            this.butcolor3.Name = "butcolor3";
            this.butcolor3.Size = new System.Drawing.Size(75, 23);
            this.butcolor3.TabIndex = 15;
            this.butcolor3.Text = "to Colours";
            this.butcolor3.UseVisualStyleBackColor = true;
            this.butcolor3.Click += new System.EventHandler(this.butcolor3_Click);
            // 
            // butRGB
            // 
            this.butRGB.Location = new System.Drawing.Point(233, 174);
            this.butRGB.Name = "butRGB";
            this.butRGB.Size = new System.Drawing.Size(75, 23);
            this.butRGB.TabIndex = 14;
            this.butRGB.Text = "to RGB";
            this.butRGB.UseVisualStyleBackColor = true;
            this.butRGB.Click += new System.EventHandler(this.butRGB_Click);
            // 
            // buttonLS
            // 
            this.buttonLS.Location = new System.Drawing.Point(351, 221);
            this.buttonLS.Name = "buttonLS";
            this.buttonLS.Size = new System.Drawing.Size(50, 23);
            this.buttonLS.TabIndex = 16;
            this.buttonLS.Text = "<<";
            this.buttonLS.UseVisualStyleBackColor = true;
            this.buttonLS.Click += new System.EventHandler(this.buttonLS_Click);
            // 
            // buttonRS
            // 
            this.buttonRS.Location = new System.Drawing.Point(401, 221);
            this.buttonRS.Name = "buttonRS";
            this.buttonRS.Size = new System.Drawing.Size(50, 23);
            this.buttonRS.TabIndex = 17;
            this.buttonRS.Text = ">>";
            this.buttonRS.UseVisualStyleBackColor = true;
            this.buttonRS.Click += new System.EventHandler(this.buttonRS_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 326);
            this.Controls.Add(this.buttonRS);
            this.Controls.Add(this.buttonLS);
            this.Controls.Add(this.butcolor3);
            this.Controls.Add(this.butRGB);
            this.Controls.Add(this.butColor4);
            this.Controls.Add(this.butARGB);
            this.Controls.Add(this.ARGB);
            this.Controls.Add(this.RGB);
            this.Controls.Add(this.color3);
            this.Controls.Add(this.color4);
            this.Controls.Add(this.B);
            this.Controls.Add(this.G);
            this.Controls.Add(this.R);
            this.Controls.Add(this.A);
            this.Controls.Add(this.Alpha);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.Red);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.Text = "Colour Convertor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Red;
        private System.Windows.Forms.Label Green;
        private System.Windows.Forms.Label Blue;
        private System.Windows.Forms.Label Alpha;
        private System.Windows.Forms.TextBox A;
        private System.Windows.Forms.TextBox R;
        private System.Windows.Forms.TextBox G;
        private System.Windows.Forms.TextBox B;
        private System.Windows.Forms.Label color4;
        private System.Windows.Forms.Label color3;
        private System.Windows.Forms.TextBox RGB;
        private System.Windows.Forms.TextBox ARGB;
        private System.Windows.Forms.Button butARGB;
        private System.Windows.Forms.Button butColor4;
        private System.Windows.Forms.Button butcolor3;
        private System.Windows.Forms.Button butRGB;
        private System.Windows.Forms.Button buttonLS;
        private System.Windows.Forms.Button buttonRS;
    }
}

