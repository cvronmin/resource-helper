namespace TextureCreator
{
    partial class NewTC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTC));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.foreColorItem = new System.Windows.Forms.ToolStripButton();
            this.backColorItem = new System.Windows.Forms.ToolStripButton();
            this.designBox = new System.Windows.Forms.PictureBox();
            this.cursorItem = new System.Windows.Forms.ToolStripButton();
            this.pencilItem = new System.Windows.Forms.ToolStripButton();
            this.ereasorItem = new System.Windows.Forms.ToolStripButton();
            this.dRectItem = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案FToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(579, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案FToolStripMenuItem
            // 
            this.檔案FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileItem,
            this.openItem,
            this.toolStripSeparator1,
            this.saveItem,
            this.saveAsItem});
            this.檔案FToolStripMenuItem.Name = "檔案FToolStripMenuItem";
            this.檔案FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.檔案FToolStripMenuItem.Text = "檔案(&F)";
            // 
            // newFileItem
            // 
            this.newFileItem.Name = "newFileItem";
            this.newFileItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileItem.Size = new System.Drawing.Size(167, 22);
            this.newFileItem.Text = "開新檔案";
            // 
            // openItem
            // 
            this.openItem.Name = "openItem";
            this.openItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openItem.Size = new System.Drawing.Size(167, 22);
            this.openItem.Text = "開啟舊檔";
            this.openItem.Click += new System.EventHandler(this.openItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // saveItem
            // 
            this.saveItem.Name = "saveItem";
            this.saveItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveItem.Size = new System.Drawing.Size(167, 22);
            this.saveItem.Text = "儲存檔案";
            this.saveItem.Click += new System.EventHandler(this.saveItem_Click);
            // 
            // saveAsItem
            // 
            this.saveAsItem.Name = "saveAsItem";
            this.saveAsItem.Size = new System.Drawing.Size(167, 22);
            this.saveAsItem.Text = "另存新檔";
            this.saveAsItem.Click += new System.EventHandler(this.saveAsItem_Click);
            // 
            // toolBar
            // 
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cursorItem,
            this.pencilItem,
            this.ereasorItem,
            this.toolStripSeparator2,
            this.dRectItem});
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(32, 356);
            this.toolBar.TabIndex = 1;
            this.toolBar.Text = "工具";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.foreColorItem,
            this.backColorItem});
            this.toolStrip1.Location = new System.Drawing.Point(32, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(547, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel1.Text = "Color";
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "PNG (*.png)|*.png|所有檔案 (*.*)|*.*";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.Filter = "PNG (*.png)|*.png|所有檔案 (*.*)|*.*";
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(29, 6);
            // 
            // foreColorItem
            // 
            this.foreColorItem.BackColor = System.Drawing.Color.Black;
            this.foreColorItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.foreColorItem.Image = ((System.Drawing.Image)(resources.GetObject("foreColorItem.Image")));
            this.foreColorItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.foreColorItem.Name = "foreColorItem";
            this.foreColorItem.Size = new System.Drawing.Size(23, 22);
            this.foreColorItem.Text = "ForeColor";
            this.foreColorItem.Click += new System.EventHandler(this.foreColorItem_Click);
            // 
            // backColorItem
            // 
            this.backColorItem.BackColor = System.Drawing.Color.White;
            this.backColorItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.backColorItem.Image = ((System.Drawing.Image)(resources.GetObject("backColorItem.Image")));
            this.backColorItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backColorItem.Name = "backColorItem";
            this.backColorItem.Size = new System.Drawing.Size(23, 22);
            this.backColorItem.Text = "Back Color";
            this.backColorItem.Click += new System.EventHandler(this.backColorItem_Click);
            // 
            // designBox
            // 
            this.designBox.BackColor = System.Drawing.Color.White;
            this.designBox.BackgroundImage = global::TextureCreator.Properties.Resources.TranBack;
            this.designBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.designBox.Location = new System.Drawing.Point(178, 78);
            this.designBox.Name = "designBox";
            this.designBox.Size = new System.Drawing.Size(256, 256);
            this.designBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.designBox.TabIndex = 2;
            this.designBox.TabStop = false;
            this.designBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.designBox_MouseDown);
            this.designBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.designBox_MouseMove);
            // 
            // cursorItem
            // 
            this.cursorItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cursorItem.Image = global::TextureCreator.Properties.Resources.Cursor;
            this.cursorItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cursorItem.Name = "cursorItem";
            this.cursorItem.Size = new System.Drawing.Size(29, 20);
            this.cursorItem.Text = "Cursor";
            this.cursorItem.Click += new System.EventHandler(this.cursorItem_Click);
            // 
            // pencilItem
            // 
            this.pencilItem.BackColor = System.Drawing.SystemColors.Control;
            this.pencilItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pencilItem.Image = global::TextureCreator.Properties.Resources.Pencil;
            this.pencilItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pencilItem.Name = "pencilItem";
            this.pencilItem.Size = new System.Drawing.Size(29, 20);
            this.pencilItem.Text = "Pencil";
            this.pencilItem.Click += new System.EventHandler(this.pencilItem_Click);
            // 
            // ereasorItem
            // 
            this.ereasorItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ereasorItem.Image = global::TextureCreator.Properties.Resources.Ereasor;
            this.ereasorItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ereasorItem.Name = "ereasorItem";
            this.ereasorItem.Size = new System.Drawing.Size(29, 20);
            this.ereasorItem.Text = "Ereasor";
            this.ereasorItem.Click += new System.EventHandler(this.ereasorItem_Click);
            // 
            // dRectItem
            // 
            this.dRectItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dRectItem.Image = global::TextureCreator.Properties.Resources.dRect;
            this.dRectItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dRectItem.Name = "dRectItem";
            this.dRectItem.Size = new System.Drawing.Size(29, 20);
            this.dRectItem.Text = "draw Rectangle";
            // 
            // NewTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 380);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.designBox);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NewTC";
            this.Text = "Texture Creator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileItem;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsItem;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton cursorItem;
        private System.Windows.Forms.PictureBox designBox;
        private System.Windows.Forms.ToolStripButton pencilItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton foreColorItem;
        private System.Windows.Forms.ToolStripButton backColorItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton ereasorItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton dRectItem;
    }
}