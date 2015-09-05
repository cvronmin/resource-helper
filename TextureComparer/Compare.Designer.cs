namespace TextureComparer
{
    partial class Compare
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comp1 = new System.Windows.Forms.PictureBox();
            this.comp2 = new System.Windows.Forms.PictureBox();
            this.butC1 = new System.Windows.Forms.Button();
            this.butC2 = new System.Windows.Forms.Button();
            this.butComp = new System.Windows.Forms.Button();
            this.butReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.comp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comp2)).BeginInit();
            this.SuspendLayout();
            // 
            // comp1
            // 
            this.comp1.AllowDrop = true;
            this.comp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.comp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comp1.Location = new System.Drawing.Point(12, 12);
            this.comp1.Name = "comp1";
            this.comp1.Size = new System.Drawing.Size(258, 258);
            this.comp1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.comp1.TabIndex = 0;
            this.comp1.TabStop = false;
            this.comp1.DragDrop += new System.Windows.Forms.DragEventHandler(this.comp1_DragDrop);
            this.comp1.DragEnter += new System.Windows.Forms.DragEventHandler(this.comp1_DragEnter);
            // 
            // comp2
            // 
            this.comp2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.comp2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comp2.Location = new System.Drawing.Point(353, 12);
            this.comp2.Name = "comp2";
            this.comp2.Size = new System.Drawing.Size(258, 258);
            this.comp2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.comp2.TabIndex = 1;
            this.comp2.TabStop = false;
            // 
            // butC1
            // 
            this.butC1.Location = new System.Drawing.Point(276, 12);
            this.butC1.Name = "butC1";
            this.butC1.Size = new System.Drawing.Size(75, 23);
            this.butC1.TabIndex = 2;
            this.butC1.Text = "<-Browse";
            this.butC1.UseVisualStyleBackColor = true;
            this.butC1.Click += new System.EventHandler(this.butC1_Click);
            // 
            // butC2
            // 
            this.butC2.Location = new System.Drawing.Point(272, 247);
            this.butC2.Name = "butC2";
            this.butC2.Size = new System.Drawing.Size(75, 23);
            this.butC2.TabIndex = 3;
            this.butC2.Text = "Browse->";
            this.butC2.UseVisualStyleBackColor = true;
            this.butC2.Click += new System.EventHandler(this.butC2_Click);
            // 
            // butComp
            // 
            this.butComp.Location = new System.Drawing.Point(195, 378);
            this.butComp.Name = "butComp";
            this.butComp.Size = new System.Drawing.Size(75, 23);
            this.butComp.TabIndex = 4;
            this.butComp.Text = "Compare";
            this.butComp.UseVisualStyleBackColor = true;
            this.butComp.Click += new System.EventHandler(this.butComp_Click);
            // 
            // butReset
            // 
            this.butReset.Location = new System.Drawing.Point(353, 378);
            this.butReset.Name = "butReset";
            this.butReset.Size = new System.Drawing.Size(75, 23);
            this.butReset.TabIndex = 5;
            this.butReset.Text = "Reset";
            this.butReset.UseVisualStyleBackColor = true;
            this.butReset.Click += new System.EventHandler(this.butReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "There are %s same pixels and %s different pixels";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // Compare
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butReset);
            this.Controls.Add(this.butComp);
            this.Controls.Add(this.butC2);
            this.Controls.Add(this.butC1);
            this.Controls.Add(this.comp2);
            this.Controls.Add(this.comp1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Compare";
            this.Text = "Comparer";
            this.Load += new System.EventHandler(this.Compare_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Compare_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.comp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comp2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox comp1;
        private System.Windows.Forms.PictureBox comp2;
        private System.Windows.Forms.Button butC1;
        private System.Windows.Forms.Button butC2;
        private System.Windows.Forms.Button butComp;
        private System.Windows.Forms.Button butReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

