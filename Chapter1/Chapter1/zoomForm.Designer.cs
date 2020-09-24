namespace Chapter1
{
    partial class zoomForm
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
            this.yZoom = new System.Windows.Forms.TextBox();
            this.xZoom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startZoom = new DevExpress.XtraEditors.SimpleButton();
            this.closeZoom = new DevExpress.XtraEditors.SimpleButton();
            this.bilinear = new System.Windows.Forms.RadioButton();
            this.nearestNeigh = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yZoom);
            this.groupBox1.Controls.Add(this.xZoom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.startZoom);
            this.groupBox1.Controls.Add(this.closeZoom);
            this.groupBox1.Controls.Add(this.bilinear);
            this.groupBox1.Controls.Add(this.nearestNeigh);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "灰度插值";
            // 
            // yZoom
            // 
            this.yZoom.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yZoom.Location = new System.Drawing.Point(165, 126);
            this.yZoom.Name = "yZoom";
            this.yZoom.Size = new System.Drawing.Size(100, 30);
            this.yZoom.TabIndex = 5;
            this.yZoom.Text = "1";
            // 
            // xZoom
            // 
            this.xZoom.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xZoom.Location = new System.Drawing.Point(165, 84);
            this.xZoom.Name = "xZoom";
            this.xZoom.Size = new System.Drawing.Size(100, 30);
            this.xZoom.TabIndex = 6;
            this.xZoom.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(40, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "纵向缩放量:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "横向缩放量：";
            // 
            // startZoom
            // 
            this.startZoom.Location = new System.Drawing.Point(34, 180);
            this.startZoom.Name = "startZoom";
            this.startZoom.Size = new System.Drawing.Size(75, 29);
            this.startZoom.TabIndex = 1;
            this.startZoom.Text = "确定";
            this.startZoom.Click += new System.EventHandler(this.startZoom_Click);
            // 
            // closeZoom
            // 
            this.closeZoom.Location = new System.Drawing.Point(182, 180);
            this.closeZoom.Name = "closeZoom";
            this.closeZoom.Size = new System.Drawing.Size(75, 30);
            this.closeZoom.TabIndex = 2;
            this.closeZoom.Text = "退出";
            this.closeZoom.Click += new System.EventHandler(this.closeZoom_Click);
            // 
            // bilinear
            // 
            this.bilinear.AutoSize = true;
            this.bilinear.Location = new System.Drawing.Point(182, 43);
            this.bilinear.Name = "bilinear";
            this.bilinear.Size = new System.Drawing.Size(103, 19);
            this.bilinear.TabIndex = 0;
            this.bilinear.Text = "双线性插值";
            this.bilinear.UseVisualStyleBackColor = true;
            // 
            // nearestNeigh
            // 
            this.nearestNeigh.AutoSize = true;
            this.nearestNeigh.Location = new System.Drawing.Point(34, 43);
            this.nearestNeigh.Name = "nearestNeigh";
            this.nearestNeigh.Size = new System.Drawing.Size(103, 19);
            this.nearestNeigh.TabIndex = 0;
            this.nearestNeigh.Text = "最近邻插值";
            this.nearestNeigh.UseVisualStyleBackColor = true;
            // 
            // zoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 251);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "zoomForm";
            this.Text = "图像缩放";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton bilinear;
        private System.Windows.Forms.RadioButton nearestNeigh;
        private DevExpress.XtraEditors.SimpleButton startZoom;
        private DevExpress.XtraEditors.SimpleButton closeZoom;
        private System.Windows.Forms.TextBox yZoom;
        private System.Windows.Forms.TextBox xZoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}