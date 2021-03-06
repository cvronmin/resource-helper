﻿namespace TextureEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonInvert = new System.Windows.Forms.Button();
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
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.lblEncryptProgress = new System.Windows.Forms.Label();
            this.previewGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewGroup
            // 
            resources.ApplyResources(this.previewGroup, "previewGroup");
            this.previewGroup.Controls.Add(this.lblEncryptProgress);
            this.previewGroup.Controls.Add(this.previewBox);
            this.previewGroup.Name = "previewGroup";
            this.previewGroup.TabStop = false;
            // 
            // previewBox
            // 
            resources.ApplyResources(this.previewBox, "previewBox");
            this.previewBox.Name = "previewBox";
            this.previewBox.TabStop = false;
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
            resources.ApplyResources(this.newFileMenu, "newFileMenu");
            this.newFileMenu.Name = "newFileMenu";
            // 
            // openFileMenu
            // 
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
            // 
            // redoItem
            // 
            this.redoItem.Name = "redoItem";
            resources.ApplyResources(this.redoItem, "redoItem");
            // 
            // toolGroup
            // 
            resources.ApplyResources(this.toolGroup, "toolGroup");
            this.toolGroup.Controls.Add(this.button9);
            this.toolGroup.Controls.Add(this.button8);
            this.toolGroup.Controls.Add(this.button7);
            this.toolGroup.Controls.Add(this.button6);
            this.toolGroup.Controls.Add(this.button5);
            this.toolGroup.Controls.Add(this.button4);
            this.toolGroup.Controls.Add(this.button3);
            this.toolGroup.Controls.Add(this.buttonInvert);
            this.toolGroup.Controls.Add(this.buttonOther);
            this.toolGroup.Controls.Add(this.buttonRS2);
            this.toolGroup.Controls.Add(this.buttonLS2);
            this.toolGroup.Controls.Add(this.buttonRH);
            this.toolGroup.Controls.Add(this.buttonLH);
            this.toolGroup.Controls.Add(this.button2);
            this.toolGroup.Controls.Add(this.button1);
            this.toolGroup.Controls.Add(this.buttonBW);
            this.toolGroup.Controls.Add(this.buttonGray);
            this.toolGroup.Name = "toolGroup";
            this.toolGroup.TabStop = false;
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonInvert
            // 
            resources.ApplyResources(this.buttonInvert, "buttonInvert");
            this.buttonInvert.Name = "buttonInvert";
            this.buttonInvert.UseVisualStyleBackColor = true;
            this.buttonInvert.Click += new System.EventHandler(this.buttonInvert_Click);
            // 
            // buttonOther
            // 
            resources.ApplyResources(this.buttonOther, "buttonOther");
            this.buttonOther.Name = "buttonOther";
            this.buttonOther.UseVisualStyleBackColor = true;
            this.buttonOther.Click += new System.EventHandler(this.buttonOther_Click);
            // 
            // buttonRS2
            // 
            resources.ApplyResources(this.buttonRS2, "buttonRS2");
            this.buttonRS2.Name = "buttonRS2";
            this.buttonRS2.UseVisualStyleBackColor = true;
            this.buttonRS2.Click += new System.EventHandler(this.buttonRS2_Click);
            // 
            // buttonLS2
            // 
            resources.ApplyResources(this.buttonLS2, "buttonLS2");
            this.buttonLS2.Name = "buttonLS2";
            this.buttonLS2.UseVisualStyleBackColor = true;
            this.buttonLS2.Click += new System.EventHandler(this.buttonLS2_Click);
            // 
            // buttonRH
            // 
            resources.ApplyResources(this.buttonRH, "buttonRH");
            this.buttonRH.Name = "buttonRH";
            this.buttonRH.UseVisualStyleBackColor = true;
            this.buttonRH.Click += new System.EventHandler(this.buttonRH_Click);
            // 
            // buttonLH
            // 
            resources.ApplyResources(this.buttonLH, "buttonLH");
            this.buttonLH.Name = "buttonLH";
            this.buttonLH.UseVisualStyleBackColor = true;
            this.buttonLH.Click += new System.EventHandler(this.buttonLH_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBW
            // 
            resources.ApplyResources(this.buttonBW, "buttonBW");
            this.buttonBW.Name = "buttonBW";
            this.buttonBW.UseVisualStyleBackColor = true;
            this.buttonBW.Click += new System.EventHandler(this.buttonBW_Click);
            // 
            // buttonGray
            // 
            resources.ApplyResources(this.buttonGray, "buttonGray");
            this.buttonGray.Name = "buttonGray";
            this.buttonGray.UseVisualStyleBackColor = true;
            this.buttonGray.Click += new System.EventHandler(this.buttonGray_Click);
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
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button8
            // 
            resources.ApplyResources(this.button8, "button8");
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            resources.ApplyResources(this.button9, "button9");
            this.button9.Name = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // lblEncryptProgress
            // 
            resources.ApplyResources(this.lblEncryptProgress, "lblEncryptProgress");
            this.lblEncryptProgress.Name = "lblEncryptProgress";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolGroup);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.previewGroup);
            this.Name = "Form1";
            this.previewGroup.ResumeLayout(false);
            this.previewGroup.PerformLayout();
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
        private System.Windows.Forms.Button buttonInvert;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label lblEncryptProgress;
    }
}

