namespace Chapter1
{
    partial class mirForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.start = new DevExpress.XtraEditors.SimpleButton();
            this.close = new DevExpress.XtraEditors.SimpleButton();
            this.horMirror = new System.Windows.Forms.RadioButton();
            this.verMirror = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.verMirror);
            this.groupBox1.Controls.Add(this.horMirror);
            this.groupBox1.Controls.Add(this.start);
            this.groupBox1.Controls.Add(this.close);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 175);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像镜像：";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(30, 126);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 29);
            this.start.TabIndex = 0;
            this.start.Text = "确定";
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(136, 125);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 30);
            this.close.TabIndex = 0;
            this.close.Text = "退出";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // horMirror
            // 
            this.horMirror.AutoSize = true;
            this.horMirror.Location = new System.Drawing.Point(30, 45);
            this.horMirror.Name = "horMirror";
            this.horMirror.Size = new System.Drawing.Size(88, 19);
            this.horMirror.TabIndex = 5;
            this.horMirror.TabStop = true;
            this.horMirror.Text = "水平镜像";
            this.horMirror.UseVisualStyleBackColor = true;
            // 
            // verMirror
            // 
            this.verMirror.AutoSize = true;
            this.verMirror.Location = new System.Drawing.Point(30, 84);
            this.verMirror.Name = "verMirror";
            this.verMirror.Size = new System.Drawing.Size(88, 19);
            this.verMirror.TabIndex = 6;
            this.verMirror.TabStop = true;
            this.verMirror.Text = "垂直镜像";
            this.verMirror.UseVisualStyleBackColor = true;
            // 
            // mirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 195);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "mirForm";
            this.Text = "图像镜像";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton verMirror;
        private System.Windows.Forms.RadioButton horMirror;
        private DevExpress.XtraEditors.SimpleButton start;
        private DevExpress.XtraEditors.SimpleButton close;
    }
}