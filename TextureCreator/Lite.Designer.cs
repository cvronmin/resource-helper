namespace TextureCreator
{
    partial class Lite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lite));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBox = new System.Windows.Forms.GroupBox();
            this.butscale16 = new System.Windows.Forms.Button();
            this.butScale32 = new System.Windows.Forms.Button();
            this.butRotate270 = new System.Windows.Forms.Button();
            this.butRotate180 = new System.Windows.Forms.Button();
            this.butRotate90 = new System.Windows.Forms.Button();
            this.butFilpY = new System.Windows.Forms.Button();
            this.butFlipX = new System.Windows.Forms.Button();
            this.butDrawFillRect = new System.Windows.Forms.Button();
            this.butDrawRect = new System.Windows.Forms.Button();
            this.butDrawOval = new System.Windows.Forms.Button();
            this.butDrawLine = new System.Windows.Forms.Button();
            this.designBox = new System.Windows.Forms.GroupBox();
            this.lblSizex = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pixelInfo = new System.Windows.Forms.GroupBox();
            this.butColor = new System.Windows.Forms.Button();
            this.AlphaCount = new System.Windows.Forms.TextBox();
            this.Alpha = new System.Windows.Forms.Label();
            this.BlueCount = new System.Windows.Forms.TextBox();
            this.Blue = new System.Windows.Forms.Label();
            this.GreenCount = new System.Windows.Forms.TextBox();
            this.Green = new System.Windows.Forms.Label();
            this.RedCount = new System.Windows.Forms.TextBox();
            this.Red = new System.Windows.Forms.Label();
            this.designPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.butScale64 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolBox.SuspendLayout();
            this.designBox.SuspendLayout();
            this.pixelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
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
            resources.ApplyResources(this.fileMenu, "fileMenu");
            // 
            // newFileMenu
            // 
            this.newFileMenu.Image = global::TextureCreator.Properties.Resources.newFileMenu;
            this.newFileMenu.Name = "newFileMenu";
            resources.ApplyResources(this.newFileMenu, "newFileMenu");
            this.newFileMenu.Click += new System.EventHandler(this.newFileMenu_Click);
            // 
            // openFileMenu
            // 
            this.openFileMenu.Image = global::TextureCreator.Properties.Resources.openFileMenu;
            this.openFileMenu.Name = "openFileMenu";
            resources.ApplyResources(this.openFileMenu, "openFileMenu");
            this.openFileMenu.Click += new System.EventHandler(this.openFileMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // saveFileMenu
            // 
            this.saveFileMenu.Image = global::TextureCreator.Properties.Resources.saveFileMenu;
            this.saveFileMenu.Name = "saveFileMenu";
            resources.ApplyResources(this.saveFileMenu, "saveFileMenu");
            this.saveFileMenu.Click += new System.EventHandler(this.saveFileMenu_Click);
            // 
            // saveAsMenu
            // 
            this.saveAsMenu.Name = "saveAsMenu";
            resources.ApplyResources(this.saveAsMenu, "saveAsMenu");
            this.saveAsMenu.Click += new System.EventHandler(this.saveAsMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            resources.ApplyResources(this.exitMenu, "exitMenu");
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // toolBox
            // 
            this.toolBox.Controls.Add(this.butScale64);
            this.toolBox.Controls.Add(this.butscale16);
            this.toolBox.Controls.Add(this.butScale32);
            this.toolBox.Controls.Add(this.butRotate270);
            this.toolBox.Controls.Add(this.butRotate180);
            this.toolBox.Controls.Add(this.butRotate90);
            this.toolBox.Controls.Add(this.butFilpY);
            this.toolBox.Controls.Add(this.butFlipX);
            this.toolBox.Controls.Add(this.butDrawFillRect);
            this.toolBox.Controls.Add(this.butDrawRect);
            this.toolBox.Controls.Add(this.butDrawOval);
            this.toolBox.Controls.Add(this.butDrawLine);
            resources.ApplyResources(this.toolBox, "toolBox");
            this.toolBox.Name = "toolBox";
            this.toolBox.TabStop = false;
            // 
            // butscale16
            // 
            resources.ApplyResources(this.butscale16, "butscale16");
            this.butscale16.Name = "butscale16";
            this.butscale16.UseVisualStyleBackColor = true;
            this.butscale16.Click += new System.EventHandler(this.butscale16_Click);
            // 
            // butScale32
            // 
            resources.ApplyResources(this.butScale32, "butScale32");
            this.butScale32.Name = "butScale32";
            this.butScale32.UseVisualStyleBackColor = true;
            this.butScale32.Click += new System.EventHandler(this.butScale32_Click);
            // 
            // butRotate270
            // 
            resources.ApplyResources(this.butRotate270, "butRotate270");
            this.butRotate270.Name = "butRotate270";
            this.butRotate270.UseVisualStyleBackColor = true;
            this.butRotate270.Click += new System.EventHandler(this.butRotate270_Click);
            // 
            // butRotate180
            // 
            resources.ApplyResources(this.butRotate180, "butRotate180");
            this.butRotate180.Name = "butRotate180";
            this.butRotate180.UseVisualStyleBackColor = true;
            this.butRotate180.Click += new System.EventHandler(this.butRotate180_Click);
            // 
            // butRotate90
            // 
            resources.ApplyResources(this.butRotate90, "butRotate90");
            this.butRotate90.Name = "butRotate90";
            this.butRotate90.UseVisualStyleBackColor = true;
            this.butRotate90.Click += new System.EventHandler(this.butRotate90_Click);
            // 
            // butFilpY
            // 
            resources.ApplyResources(this.butFilpY, "butFilpY");
            this.butFilpY.Name = "butFilpY";
            this.butFilpY.UseVisualStyleBackColor = true;
            this.butFilpY.Click += new System.EventHandler(this.butFilpY_Click);
            // 
            // butFlipX
            // 
            resources.ApplyResources(this.butFlipX, "butFlipX");
            this.butFlipX.Name = "butFlipX";
            this.butFlipX.UseVisualStyleBackColor = true;
            this.butFlipX.Click += new System.EventHandler(this.butFlipX_Click);
            // 
            // butDrawFillRect
            // 
            resources.ApplyResources(this.butDrawFillRect, "butDrawFillRect");
            this.butDrawFillRect.Name = "butDrawFillRect";
            this.butDrawFillRect.UseVisualStyleBackColor = true;
            this.butDrawFillRect.Click += new System.EventHandler(this.butDrawFillRect_Click);
            // 
            // butDrawRect
            // 
            resources.ApplyResources(this.butDrawRect, "butDrawRect");
            this.butDrawRect.Name = "butDrawRect";
            this.butDrawRect.UseVisualStyleBackColor = true;
            this.butDrawRect.Click += new System.EventHandler(this.butDrawRect_Click);
            // 
            // butDrawOval
            // 
            resources.ApplyResources(this.butDrawOval, "butDrawOval");
            this.butDrawOval.Name = "butDrawOval";
            this.butDrawOval.UseVisualStyleBackColor = true;
            this.butDrawOval.Click += new System.EventHandler(this.butDrawOval_Click);
            // 
            // butDrawLine
            // 
            resources.ApplyResources(this.butDrawLine, "butDrawLine");
            this.butDrawLine.Name = "butDrawLine";
            this.butDrawLine.UseVisualStyleBackColor = true;
            this.butDrawLine.Click += new System.EventHandler(this.butDrawLine_Click);
            // 
            // designBox
            // 
            this.designBox.Controls.Add(this.lblSizex);
            this.designBox.Controls.Add(this.label1);
            this.designBox.Controls.Add(this.pixelInfo);
            this.designBox.Controls.Add(this.designPanel);
            resources.ApplyResources(this.designBox, "designBox");
            this.designBox.Name = "designBox";
            this.designBox.TabStop = false;
            // 
            // lblSizex
            // 
            resources.ApplyResources(this.lblSizex, "lblSizex");
            this.lblSizex.Name = "lblSizex";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pixelInfo
            // 
            this.pixelInfo.Controls.Add(this.butColor);
            this.pixelInfo.Controls.Add(this.AlphaCount);
            this.pixelInfo.Controls.Add(this.Alpha);
            this.pixelInfo.Controls.Add(this.BlueCount);
            this.pixelInfo.Controls.Add(this.Blue);
            this.pixelInfo.Controls.Add(this.GreenCount);
            this.pixelInfo.Controls.Add(this.Green);
            this.pixelInfo.Controls.Add(this.RedCount);
            this.pixelInfo.Controls.Add(this.Red);
            resources.ApplyResources(this.pixelInfo, "pixelInfo");
            this.pixelInfo.Name = "pixelInfo";
            this.pixelInfo.TabStop = false;
            // 
            // butColor
            // 
            this.butColor.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.butColor, "butColor");
            this.butColor.Name = "butColor";
            this.butColor.UseVisualStyleBackColor = false;
            this.butColor.Click += new System.EventHandler(this.butColor_Click);
            // 
            // AlphaCount
            // 
            resources.ApplyResources(this.AlphaCount, "AlphaCount");
            this.AlphaCount.Name = "AlphaCount";
            this.AlphaCount.TextChanged += new System.EventHandler(this.AlphaCount_TextChanged);
            // 
            // Alpha
            // 
            resources.ApplyResources(this.Alpha, "Alpha");
            this.Alpha.Name = "Alpha";
            // 
            // BlueCount
            // 
            resources.ApplyResources(this.BlueCount, "BlueCount");
            this.BlueCount.Name = "BlueCount";
            this.BlueCount.TextChanged += new System.EventHandler(this.BlueCount_TextChanged);
            // 
            // Blue
            // 
            resources.ApplyResources(this.Blue, "Blue");
            this.Blue.Name = "Blue";
            // 
            // GreenCount
            // 
            resources.ApplyResources(this.GreenCount, "GreenCount");
            this.GreenCount.Name = "GreenCount";
            this.GreenCount.TextChanged += new System.EventHandler(this.GreenCount_TextChanged);
            // 
            // Green
            // 
            resources.ApplyResources(this.Green, "Green");
            this.Green.Name = "Green";
            // 
            // RedCount
            // 
            resources.ApplyResources(this.RedCount, "RedCount");
            this.RedCount.Name = "RedCount";
            this.RedCount.TextChanged += new System.EventHandler(this.RedCount_TextChanged);
            // 
            // Red
            // 
            resources.ApplyResources(this.Red, "Red");
            this.Red.Name = "Red";
            // 
            // designPanel
            // 
            this.designPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.designPanel, "designPanel");
            this.designPanel.Name = "designPanel";
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoItem,
            this.redoItem});
            this.editMenu.Name = "editMenu";
            resources.ApplyResources(this.editMenu, "editMenu");
            // 
            // undoItem
            // 
            resources.ApplyResources(this.undoItem, "undoItem");
            this.undoItem.Name = "undoItem";
            this.undoItem.Click += new System.EventHandler(this.undoItem_Click);
            // 
            // redoItem
            // 
            this.redoItem.Name = "redoItem";
            resources.ApplyResources(this.redoItem, "redoItem");
            // 
            // butScale64
            // 
            resources.ApplyResources(this.butScale64, "butScale64");
            this.butScale64.Name = "butScale64";
            this.butScale64.UseVisualStyleBackColor = true;
            this.butScale64.Click += new System.EventHandler(this.butScale64_Click);
            // 
            // Lite
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.designBox);
            this.Controls.Add(this.toolBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Lite";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolBox.ResumeLayout(false);
            this.designBox.ResumeLayout(false);
            this.designBox.PerformLayout();
            this.pixelInfo.ResumeLayout(false);
            this.pixelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newFileMenu;
        private System.Windows.Forms.ToolStripMenuItem openFileMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveFileMenu;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.GroupBox toolBox;
        private System.Windows.Forms.GroupBox designBox;
        private System.Windows.Forms.FlowLayoutPanel designPanel;
        private System.Windows.Forms.GroupBox pixelInfo;
        private System.Windows.Forms.TextBox AlphaCount;
        private System.Windows.Forms.Label Alpha;
        private System.Windows.Forms.TextBox BlueCount;
        private System.Windows.Forms.Label Blue;
        private System.Windows.Forms.TextBox GreenCount;
        private System.Windows.Forms.Label Green;
        private System.Windows.Forms.TextBox RedCount;
        private System.Windows.Forms.Label Red;
        private System.Windows.Forms.Button butColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button butDrawLine;
        private System.Windows.Forms.Button butDrawOval;
        private System.Windows.Forms.Button butDrawRect;
        private System.Windows.Forms.Label lblSizex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butDrawFillRect;
        private System.Windows.Forms.Button butFlipX;
        private System.Windows.Forms.Button butFilpY;
        private System.Windows.Forms.Button butRotate270;
        private System.Windows.Forms.Button butRotate180;
        private System.Windows.Forms.Button butRotate90;
        private System.Windows.Forms.Button butScale32;
        private System.Windows.Forms.Button butscale16;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem undoItem;
        private System.Windows.Forms.ToolStripMenuItem redoItem;
        private System.Windows.Forms.Button butScale64;
    }
}

