namespace TextureCreator
{
    partial class DrawLineForm
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawLineForm));
            this.Red = new System.Windows.Forms.Label();
            this.RedCount = new System.Windows.Forms.TextBox();
            this.GreenCount = new System.Windows.Forms.TextBox();
            this.Green = new System.Windows.Forms.Label();
            this.BlueCount = new System.Windows.Forms.TextBox();
            this.Blue = new System.Windows.Forms.Label();
            this.AlphaCount = new System.Windows.Forms.TextBox();
            this.Alpha = new System.Windows.Forms.Label();
            this.lblPixel = new System.Windows.Forms.Label();
            this.PixelCount = new System.Windows.Forms.TextBox();
            this.StartX = new System.Windows.Forms.Label();
            this.StartXPos = new System.Windows.Forms.TextBox();
            this.StartYPos = new System.Windows.Forms.TextBox();
            this.StartY = new System.Windows.Forms.Label();
            this.EndXPos = new System.Windows.Forms.TextBox();
            this.EndX = new System.Windows.Forms.Label();
            this.EndYPos = new System.Windows.Forms.TextBox();
            this.EndY = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Red
            // 
            resources.ApplyResources(this.Red, "Red");
            this.Red.Name = "Red";
            // 
            // RedCount
            // 
            resources.ApplyResources(this.RedCount, "RedCount");
            this.RedCount.Name = "RedCount";
            // 
            // GreenCount
            // 
            resources.ApplyResources(this.GreenCount, "GreenCount");
            this.GreenCount.Name = "GreenCount";
            // 
            // Green
            // 
            resources.ApplyResources(this.Green, "Green");
            this.Green.Name = "Green";
            // 
            // BlueCount
            // 
            resources.ApplyResources(this.BlueCount, "BlueCount");
            this.BlueCount.Name = "BlueCount";
            // 
            // Blue
            // 
            resources.ApplyResources(this.Blue, "Blue");
            this.Blue.Name = "Blue";
            // 
            // AlphaCount
            // 
            resources.ApplyResources(this.AlphaCount, "AlphaCount");
            this.AlphaCount.Name = "AlphaCount";
            // 
            // Alpha
            // 
            resources.ApplyResources(this.Alpha, "Alpha");
            this.Alpha.Name = "Alpha";
            // 
            // lblPixel
            // 
            resources.ApplyResources(this.lblPixel, "lblPixel");
            this.lblPixel.Name = "lblPixel";
            // 
            // PixelCount
            // 
            resources.ApplyResources(this.PixelCount, "PixelCount");
            this.PixelCount.Name = "PixelCount";
            // 
            // StartX
            // 
            resources.ApplyResources(this.StartX, "StartX");
            this.StartX.Name = "StartX";
            // 
            // StartXPos
            // 
            resources.ApplyResources(this.StartXPos, "StartXPos");
            this.StartXPos.Name = "StartXPos";
            // 
            // StartYPos
            // 
            resources.ApplyResources(this.StartYPos, "StartYPos");
            this.StartYPos.Name = "StartYPos";
            // 
            // StartY
            // 
            resources.ApplyResources(this.StartY, "StartY");
            this.StartY.Name = "StartY";
            // 
            // EndXPos
            // 
            resources.ApplyResources(this.EndXPos, "EndXPos");
            this.EndXPos.Name = "EndXPos";
            // 
            // EndX
            // 
            resources.ApplyResources(this.EndX, "EndX");
            this.EndX.Name = "EndX";
            // 
            // EndYPos
            // 
            resources.ApplyResources(this.EndYPos, "EndYPos");
            this.EndYPos.Name = "EndYPos";
            // 
            // EndY
            // 
            resources.ApplyResources(this.EndY, "EndY");
            this.EndY.Name = "EndY";
            // 
            // butCancel
            // 
            resources.ApplyResources(this.butCancel, "butCancel");
            this.butCancel.Name = "butCancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            resources.ApplyResources(this.butOK, "butOK");
            this.butOK.Name = "butOK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // DrawLineForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.EndYPos);
            this.Controls.Add(this.EndY);
            this.Controls.Add(this.EndXPos);
            this.Controls.Add(this.EndX);
            this.Controls.Add(this.StartYPos);
            this.Controls.Add(this.StartY);
            this.Controls.Add(this.StartXPos);
            this.Controls.Add(this.StartX);
            this.Controls.Add(this.PixelCount);
            this.Controls.Add(this.lblPixel);
            this.Controls.Add(this.AlphaCount);
            this.Controls.Add(this.Alpha);
            this.Controls.Add(this.BlueCount);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.GreenCount);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.RedCount);
            this.Controls.Add(this.Red);
            this.Name = "DrawLineForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Red;
        private System.Windows.Forms.TextBox RedCount;
        private System.Windows.Forms.TextBox GreenCount;
        private System.Windows.Forms.Label Green;
        private System.Windows.Forms.TextBox BlueCount;
        private System.Windows.Forms.Label Blue;
        private System.Windows.Forms.TextBox AlphaCount;
        private System.Windows.Forms.Label Alpha;
        private System.Windows.Forms.Label lblPixel;
        private System.Windows.Forms.TextBox PixelCount;
        private System.Windows.Forms.Label StartX;
        private System.Windows.Forms.TextBox StartXPos;
        private System.Windows.Forms.TextBox StartYPos;
        private System.Windows.Forms.Label StartY;
        private System.Windows.Forms.TextBox EndXPos;
        private System.Windows.Forms.Label EndX;
        private System.Windows.Forms.TextBox EndYPos;
        private System.Windows.Forms.Label EndY;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
    }
}
