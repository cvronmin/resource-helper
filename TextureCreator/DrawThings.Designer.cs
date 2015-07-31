namespace TextureCreator
{
    partial class DrawThings
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
            this.lblA = new System.Windows.Forms.Label();
            this.txtbA = new System.Windows.Forms.TextBox();
            this.txtbR = new System.Windows.Forms.TextBox();
            this.lblR = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.txtbB = new System.Windows.Forms.TextBox();
            this.txtbG = new System.Windows.Forms.TextBox();
            this.lblG = new System.Windows.Forms.Label();
            this.butColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(200, 21);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(38, 15);
            this.lblA.TabIndex = 0;
            this.lblA.Text = "Alpha";
            // 
            // txtbA
            // 
            this.txtbA.Location = new System.Drawing.Point(203, 39);
            this.txtbA.MaxLength = 3;
            this.txtbA.Name = "txtbA";
            this.txtbA.Size = new System.Drawing.Size(75, 21);
            this.txtbA.TabIndex = 1;
            // 
            // txtbR
            // 
            this.txtbR.Location = new System.Drawing.Point(284, 39);
            this.txtbR.MaxLength = 3;
            this.txtbR.Name = "txtbR";
            this.txtbR.Size = new System.Drawing.Size(75, 21);
            this.txtbR.TabIndex = 2;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(281, 21);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(30, 15);
            this.lblR.TabIndex = 3;
            this.lblR.Text = "Red";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(281, 63);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(32, 15);
            this.lblB.TabIndex = 7;
            this.lblB.Text = "Blue";
            // 
            // txtbB
            // 
            this.txtbB.Location = new System.Drawing.Point(284, 81);
            this.txtbB.MaxLength = 3;
            this.txtbB.Name = "txtbB";
            this.txtbB.Size = new System.Drawing.Size(75, 21);
            this.txtbB.TabIndex = 6;
            // 
            // txtbG
            // 
            this.txtbG.Location = new System.Drawing.Point(203, 81);
            this.txtbG.MaxLength = 3;
            this.txtbG.Name = "txtbG";
            this.txtbG.Size = new System.Drawing.Size(75, 21);
            this.txtbG.TabIndex = 5;
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Location = new System.Drawing.Point(200, 63);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(41, 15);
            this.lblG.TabIndex = 4;
            this.lblG.Text = "Green";
            // 
            // butColor
            // 
            this.butColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butColor.Location = new System.Drawing.Point(203, 108);
            this.butColor.Name = "butColor";
            this.butColor.Size = new System.Drawing.Size(75, 75);
            this.butColor.TabIndex = 8;
            this.butColor.UseVisualStyleBackColor = true;
            this.butColor.Click += new System.EventHandler(this.butColor_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            this.colorDialog1.ShowHelp = true;
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(284, 108);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 9;
            this.butOk.Text = "Confirm";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(284, 160);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // DrawThings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 211);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.butColor);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtbB);
            this.Controls.Add(this.txtbG);
            this.Controls.Add(this.lblG);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.txtbR);
            this.Controls.Add(this.txtbA);
            this.Controls.Add(this.lblA);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DrawThings";
            this.Text = "DrawThings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox txtbA;
        private System.Windows.Forms.TextBox txtbR;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtbB;
        private System.Windows.Forms.TextBox txtbG;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Button butColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;

    }
}