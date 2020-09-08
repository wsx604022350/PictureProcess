namespace Chapter1
{
    partial class rotForm
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
            this.startRot = new DevExpress.XtraEditors.SimpleButton();
            this.close = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.degree = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startRot
            // 
            this.startRot.Location = new System.Drawing.Point(12, 62);
            this.startRot.Name = "startRot";
            this.startRot.Size = new System.Drawing.Size(75, 35);
            this.startRot.TabIndex = 0;
            this.startRot.Text = "确定";
            this.startRot.Click += new System.EventHandler(this.startRot_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(138, 62);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 35);
            this.close.TabIndex = 1;
            this.close.Text = "关闭";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "旋转角度(°)";
            // 
            // degree
            // 
            this.degree.Location = new System.Drawing.Point(113, 12);
            this.degree.Name = "degree";
            this.degree.Size = new System.Drawing.Size(100, 25);
            this.degree.TabIndex = 3;
            this.degree.Text = "0";
            // 
            // rotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 130);
            this.ControlBox = false;
            this.Controls.Add(this.degree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.startRot);
            this.Name = "rotForm";
            this.Text = "图像旋转";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton startRot;
        private DevExpress.XtraEditors.SimpleButton close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox degree;
    }
}