namespace TextureEditor
{
    partial class Form1
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
            this.previewGroup = new System.Windows.Forms.GroupBox();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolGroup = new System.Windows.Forms.GroupBox();
            this.buttonOther = new System.Windows.Forms.Button();
            this.buttonRS2 = new System.Windows.Forms.Button();
            this.buttonLS2 = new System.Windows.Forms.Button();
            this.buttonRH = new System.Windows.Forms.Button();
            this.buttonLH = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonBW = new System.Windows.Forms.Button();
            this.buttonGray = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.previewGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewGroup
            // 
            this.previewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewGroup.Controls.Add(this.previewBox);
            this.previewGroup.Location = new System.Drawing.Point(215, 27);
            this.previewGroup.Name = "previewGroup";
            this.previewGroup.Size = new System.Drawing.Size(333, 351);
            this.previewGroup.TabIndex = 0;
            this.previewGroup.TabStop = false;
            this.previewGroup.Text = "Preview";
            // 
            // previewBox
            // 
            this.previewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewBox.Location = new System.Drawing.Point(6, 21);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(321, 324);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(560, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileMenu,
            this.openFileMenu,
            this.toolStripSeparator1,
            this.saveFileMenu,
            this.saveAsMenu,
            this.toolStripSeparator2,
            this.exitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(57, 20);
            this.fileMenu.Text = "檔案(&F)";
            // 
            // newFileMenu
            // 
            this.newFileMenu.Enabled = false;
            this.newFileMenu.Name = "newFileMenu";
            this.newFileMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileMenu.Size = new System.Drawing.Size(185, 22);
            this.newFileMenu.Text = "開新檔案(&N)";
            // 
            // openFileMenu
            // 
            this.openFileMenu.Name = "openFileMenu";
            this.openFileMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileMenu.Size = new System.Drawing.Size(185, 22);
            this.openFileMenu.Text = "開啟舊檔(&O)";
            this.openFileMenu.Click += new System.EventHandler(this.openFileMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // saveFileMenu
            // 
            this.saveFileMenu.Name = "saveFileMenu";
            this.saveFileMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileMenu.Size = new System.Drawing.Size(185, 22);
            this.saveFileMenu.Text = "儲存檔案(&S)";
            this.saveFileMenu.Click += new System.EventHandler(this.saveFileMenu_Click);
            // 
            // saveAsMenu
            // 
            this.saveAsMenu.Name = "saveAsMenu";
            this.saveAsMenu.Size = new System.Drawing.Size(185, 22);
            this.saveAsMenu.Text = "另存新檔(&A)";
            this.saveAsMenu.Click += new System.EventHandler(this.saveAsMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(185, 22);
            this.exitMenu.Text = "結束(&X)";
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoItem,
            this.redoItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(58, 20);
            this.editMenu.Text = "編輯(&E)";
            // 
            // undoItem
            // 
            this.undoItem.Enabled = false;
            this.undoItem.Name = "undoItem";
            this.undoItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoItem.Size = new System.Drawing.Size(157, 22);
            this.undoItem.Text = "復原(&U)";
            // 
            // redoItem
            // 
            this.redoItem.Name = "redoItem";
            this.redoItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoItem.Size = new System.Drawing.Size(157, 22);
            this.redoItem.Text = "重做(&R)";
            // 
            // toolGroup
            // 
            this.toolGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.toolGroup.Controls.Add(this.buttonOther);
            this.toolGroup.Controls.Add(this.buttonRS2);
            this.toolGroup.Controls.Add(this.buttonLS2);
            this.toolGroup.Controls.Add(this.buttonRH);
            this.toolGroup.Controls.Add(this.buttonLH);
            this.toolGroup.Controls.Add(this.button2);
            this.toolGroup.Controls.Add(this.button1);
            this.toolGroup.Controls.Add(this.buttonBW);
            this.toolGroup.Controls.Add(this.buttonGray);
            this.toolGroup.Location = new System.Drawing.Point(0, 27);
            this.toolGroup.Name = "toolGroup";
            this.toolGroup.Size = new System.Drawing.Size(215, 351);
            this.toolGroup.TabIndex = 2;
            this.toolGroup.TabStop = false;
            this.toolGroup.Text = "ToolBox";
            // 
            // buttonOther
            // 
            this.buttonOther.Enabled = false;
            this.buttonOther.Location = new System.Drawing.Point(7, 140);
            this.buttonOther.Name = "buttonOther";
            this.buttonOther.Size = new System.Drawing.Size(156, 23);
            this.buttonOther.TabIndex = 8;
            this.buttonOther.Text = "Other...";
            this.buttonOther.UseVisualStyleBackColor = true;
            this.buttonOther.Click += new System.EventHandler(this.buttonOther_Click);
            // 
            // buttonRS2
            // 
            this.buttonRS2.Enabled = false;
            this.buttonRS2.Location = new System.Drawing.Point(88, 110);
            this.buttonRS2.Name = "buttonRS2";
            this.buttonRS2.Size = new System.Drawing.Size(75, 23);
            this.buttonRS2.TabIndex = 7;
            this.buttonRS2.Text = "Right 2 hex";
            this.buttonRS2.UseVisualStyleBackColor = true;
            this.buttonRS2.Click += new System.EventHandler(this.buttonRS2_Click);
            // 
            // buttonLS2
            // 
            this.buttonLS2.Enabled = false;
            this.buttonLS2.Location = new System.Drawing.Point(7, 110);
            this.buttonLS2.Name = "buttonLS2";
            this.buttonLS2.Size = new System.Drawing.Size(75, 23);
            this.buttonLS2.TabIndex = 6;
            this.buttonLS2.Text = "Left 2 hex";
            this.buttonLS2.UseVisualStyleBackColor = true;
            this.buttonLS2.Click += new System.EventHandler(this.buttonLS2_Click);
            // 
            // buttonRH
            // 
            this.buttonRH.Enabled = false;
            this.buttonRH.Location = new System.Drawing.Point(89, 81);
            this.buttonRH.Name = "buttonRH";
            this.buttonRH.Size = new System.Drawing.Size(75, 23);
            this.buttonRH.TabIndex = 5;
            this.buttonRH.Text = "Right 1 hex";
            this.buttonRH.UseVisualStyleBackColor = true;
            this.buttonRH.Click += new System.EventHandler(this.buttonRH_Click);
            // 
            // buttonLH
            // 
            this.buttonLH.Enabled = false;
            this.buttonLH.Location = new System.Drawing.Point(7, 81);
            this.buttonLH.Name = "buttonLH";
            this.buttonLH.Size = new System.Drawing.Size(75, 23);
            this.buttonLH.TabIndex = 4;
            this.buttonLH.Text = "Left 1 hex";
            this.buttonLH.UseVisualStyleBackColor = true;
            this.buttonLH.Click += new System.EventHandler(this.buttonLH_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(89, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Right 1 bin";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(7, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Left 1 bin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBW
            // 
            this.buttonBW.Enabled = false;
            this.buttonBW.Location = new System.Drawing.Point(89, 21);
            this.buttonBW.Name = "buttonBW";
            this.buttonBW.Size = new System.Drawing.Size(75, 23);
            this.buttonBW.TabIndex = 1;
            this.buttonBW.Text = "Black White";
            this.buttonBW.UseVisualStyleBackColor = true;
            this.buttonBW.Click += new System.EventHandler(this.buttonBW_Click);
            // 
            // buttonGray
            // 
            this.buttonGray.Enabled = false;
            this.buttonGray.Location = new System.Drawing.Point(7, 21);
            this.buttonGray.Name = "buttonGray";
            this.buttonGray.Size = new System.Drawing.Size(75, 23);
            this.buttonGray.TabIndex = 0;
            this.buttonGray.Text = "Gray";
            this.buttonGray.UseVisualStyleBackColor = true;
            this.buttonGray.Click += new System.EventHandler(this.buttonGray_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.Filter = "PNG (*.png)|*.png|所有檔案 (*.*)|*.*";
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "PNG (*.png)|*.png|所有檔案 (*.*)|*.*";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 390);
            this.Controls.Add(this.toolGroup);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.previewGroup);
            this.Name = "Form1";
            this.Text = "Form1";
            this.previewGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox previewGroup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newFileMenu;
        private System.Windows.Forms.ToolStripMenuItem openFileMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveFileMenu;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem undoItem;
        private System.Windows.Forms.ToolStripMenuItem redoItem;
        private System.Windows.Forms.GroupBox toolGroup;
        private System.Windows.Forms.Button buttonBW;
        private System.Windows.Forms.Button buttonGray;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonRH;
        private System.Windows.Forms.Button buttonLH;
        private System.Windows.Forms.Button buttonRS2;
        private System.Windows.Forms.Button buttonLS2;
        private System.Windows.Forms.Button buttonOther;
        internal System.Windows.Forms.PictureBox previewBox;
    }
}

