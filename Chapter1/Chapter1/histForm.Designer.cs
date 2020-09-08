namespace Chapter1
{
    partial class histForm
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
            this.colse = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_maxPixel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // colse
            // 
            this.colse.Location = new System.Drawing.Point(395, 12);
            this.colse.Name = "colse";
            this.colse.Size = new System.Drawing.Size(75, 28);
            this.colse.TabIndex = 0;
            this.colse.Text = "关闭";
            this.colse.Click += new System.EventHandler(this.colse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "最大相同像素值数：";
            // 
            // txt_maxPixel
            // 
            this.txt_maxPixel.Location = new System.Drawing.Point(146, 426);
            this.txt_maxPixel.Name = "txt_maxPixel";
            this.txt_maxPixel.Size = new System.Drawing.Size(100, 25);
            this.txt_maxPixel.TabIndex = 2;
            // 
            // histForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 453);
            this.ControlBox = false;
            this.Controls.Add(this.txt_maxPixel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colse);
            this.Name = "histForm";
            this.Text = "直方图";
            this.Load += new System.EventHandler(this.histForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.histForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton colse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_maxPixel;
    }
}