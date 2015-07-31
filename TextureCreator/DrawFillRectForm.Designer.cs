namespace TextureCreator
{
    partial class DrawFillRectForm
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
            this.StartX = new System.Windows.Forms.Label();
            this.StartXPos = new System.Windows.Forms.TextBox();
            this.StartYPos = new System.Windows.Forms.TextBox();
            this.StartY = new System.Windows.Forms.Label();
            this.EndXPos = new System.Windows.Forms.TextBox();
            this.EndX = new System.Windows.Forms.Label();
            this.EndYPos = new System.Windows.Forms.TextBox();
            this.EndY = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartX
            // 
            this.StartX.AutoSize = true;
            this.StartX.Location = new System.Drawing.Point(17, 24);
            this.StartX.Name = "StartX";
            this.StartX.Size = new System.Drawing.Size(43, 15);
            this.StartX.TabIndex = 10;
            this.StartX.Text = "Start X";
            // 
            // StartXPos
            // 
            this.StartXPos.Location = new System.Drawing.Point(65, 21);
            this.StartXPos.Name = "StartXPos";
            this.StartXPos.Size = new System.Drawing.Size(100, 21);
            this.StartXPos.TabIndex = 11;
            // 
            // StartYPos
            // 
            this.StartYPos.Location = new System.Drawing.Point(65, 50);
            this.StartYPos.Name = "StartYPos";
            this.StartYPos.Size = new System.Drawing.Size(100, 21);
            this.StartYPos.TabIndex = 13;
            // 
            // StartY
            // 
            this.StartY.AutoSize = true;
            this.StartY.Location = new System.Drawing.Point(17, 53);
            this.StartY.Name = "StartY";
            this.StartY.Size = new System.Drawing.Size(42, 15);
            this.StartY.TabIndex = 12;
            this.StartY.Text = "Start Y";
            // 
            // EndXPos
            // 
            this.EndXPos.Location = new System.Drawing.Point(65, 79);
            this.EndXPos.Name = "EndXPos";
            this.EndXPos.Size = new System.Drawing.Size(100, 21);
            this.EndXPos.TabIndex = 15;
            // 
            // EndX
            // 
            this.EndX.AutoSize = true;
            this.EndX.Location = new System.Drawing.Point(17, 82);
            this.EndX.Name = "EndX";
            this.EndX.Size = new System.Drawing.Size(40, 15);
            this.EndX.TabIndex = 14;
            this.EndX.Text = "End X";
            // 
            // EndYPos
            // 
            this.EndYPos.Location = new System.Drawing.Point(65, 108);
            this.EndYPos.Name = "EndYPos";
            this.EndYPos.Size = new System.Drawing.Size(100, 21);
            this.EndYPos.TabIndex = 17;
            // 
            // EndY
            // 
            this.EndY.AutoSize = true;
            this.EndY.Location = new System.Drawing.Point(17, 111);
            this.EndY.Name = "EndY";
            this.EndY.Size = new System.Drawing.Size(39, 15);
            this.EndY.TabIndex = 16;
            this.EndY.Text = "End Y";
            // 
            // DrawFillRectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EndYPos);
            this.Controls.Add(this.EndY);
            this.Controls.Add(this.EndXPos);
            this.Controls.Add(this.EndX);
            this.Controls.Add(this.StartYPos);
            this.Controls.Add(this.StartY);
            this.Controls.Add(this.StartXPos);
            this.Controls.Add(this.StartX);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DrawFillRectForm";
            this.Size = new System.Drawing.Size(185, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StartX;
        private System.Windows.Forms.TextBox StartXPos;
        private System.Windows.Forms.TextBox StartYPos;
        private System.Windows.Forms.Label StartY;
        private System.Windows.Forms.TextBox EndXPos;
        private System.Windows.Forms.Label EndX;
        private System.Windows.Forms.TextBox EndYPos;
        private System.Windows.Forms.Label EndY;
    }
}
