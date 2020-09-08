namespace Chapter1
{
    partial class translation
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
            this.start = new DevExpress.XtraEditors.SimpleButton();
            this.close = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yOffset = new System.Windows.Forms.TextBox();
            this.xOffset = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(123, 127);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 29);
            this.start.TabIndex = 0;
            this.start.Text = "确定";
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(11, 127);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 30);
            this.close.TabIndex = 0;
            this.close.Text = "退出";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "沿水平方向：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "沿垂直方向：";
            // 
            // yOffset
            // 
            this.yOffset.Location = new System.Drawing.Point(98, 82);
            this.yOffset.Name = "yOffset";
            this.yOffset.Size = new System.Drawing.Size(100, 25);
            this.yOffset.TabIndex = 2;
            this.yOffset.Text = "0";
            // 
            // xOffset
            // 
            this.xOffset.Location = new System.Drawing.Point(98, 34);
            this.xOffset.Name = "xOffset";
            this.xOffset.Size = new System.Drawing.Size(100, 25);
            this.xOffset.TabIndex = 2;
            this.xOffset.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xOffset);
            this.groupBox1.Controls.Add(this.start);
            this.groupBox1.Controls.Add(this.yOffset);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.close);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 175);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像平移量：";
            // 
            // translation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 203);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "translation";
            this.Text = "图像平移";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton start;
        private DevExpress.XtraEditors.SimpleButton close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox yOffset;
        private System.Windows.Forms.TextBox xOffset;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}