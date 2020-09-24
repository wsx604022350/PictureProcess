namespace Chapter1
{
    partial class Form1
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
            this.open = new DevExpress.XtraEditors.SimpleButton();
            this.save = new DevExpress.XtraEditors.SimpleButton();
            this.close = new DevExpress.XtraEditors.SimpleButton();
            this.displayImage = new System.Windows.Forms.PictureBox();
            this.pointer = new DevExpress.XtraEditors.SimpleButton();
            this.memory = new DevExpress.XtraEditors.SimpleButton();
            this.pixel = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.runingTime = new System.Windows.Forms.TextBox();
            this.histogram = new DevExpress.XtraEditors.SimpleButton();
            this.linearPO = new DevExpress.XtraEditors.SimpleButton();
            this.stretch = new DevExpress.XtraEditors.SimpleButton();
            this.equalization = new DevExpress.XtraEditors.SimpleButton();
            this.shaping = new DevExpress.XtraEditors.SimpleButton();
            this.translation = new DevExpress.XtraEditors.SimpleButton();
            this.mirror = new DevExpress.XtraEditors.SimpleButton();
            this.zoom = new DevExpress.XtraEditors.SimpleButton();
            this.rotation = new DevExpress.XtraEditors.SimpleButton();
            this.canny = new DevExpress.XtraEditors.SimpleButton();
            this.pixelMatrix = new DevExpress.XtraEditors.SimpleButton();
            this.edgeDetection = new DevExpress.XtraEditors.SimpleButton();
            this.binaryzation = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton8 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.displayImage)).BeginInit();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(12, 12);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 40);
            this.open.TabIndex = 1;
            this.open.Text = "打开图像";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(12, 58);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 40);
            this.save.TabIndex = 1;
            this.save.Text = "保存图像";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(12, 104);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 40);
            this.close.TabIndex = 1;
            this.close.Text = "关闭";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // displayImage
            // 
            this.displayImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayImage.Location = new System.Drawing.Point(281, 46);
            this.displayImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.displayImage.Name = "displayImage";
            this.displayImage.Size = new System.Drawing.Size(1061, 584);
            this.displayImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.displayImage.TabIndex = 2;
            this.displayImage.TabStop = false;
            // 
            // pointer
            // 
            this.pointer.Location = new System.Drawing.Point(12, 242);
            this.pointer.Name = "pointer";
            this.pointer.Size = new System.Drawing.Size(75, 40);
            this.pointer.TabIndex = 3;
            this.pointer.Text = "指针法";
            this.pointer.Click += new System.EventHandler(this.pointer_Click);
            // 
            // memory
            // 
            this.memory.Location = new System.Drawing.Point(12, 196);
            this.memory.Name = "memory";
            this.memory.Size = new System.Drawing.Size(75, 40);
            this.memory.TabIndex = 4;
            this.memory.Text = "内存法";
            this.memory.Click += new System.EventHandler(this.memory_Click);
            // 
            // pixel
            // 
            this.pixel.Location = new System.Drawing.Point(12, 150);
            this.pixel.Name = "pixel";
            this.pixel.Size = new System.Drawing.Size(75, 40);
            this.pixel.TabIndex = 5;
            this.pixel.Text = "提取像素法";
            this.pixel.Click += new System.EventHandler(this.pixel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1143, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "运行时间：";
            // 
            // runingTime
            // 
            this.runingTime.Location = new System.Drawing.Point(1232, 13);
            this.runingTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.runingTime.Name = "runingTime";
            this.runingTime.Size = new System.Drawing.Size(90, 26);
            this.runingTime.TabIndex = 8;
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point(12, 288);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(75, 33);
            this.histogram.TabIndex = 9;
            this.histogram.Text = "绘制直方图";
            this.histogram.Click += new System.EventHandler(this.histogram_Click);
            // 
            // linearPO
            // 
            this.linearPO.Location = new System.Drawing.Point(12, 327);
            this.linearPO.Name = "linearPO";
            this.linearPO.Size = new System.Drawing.Size(75, 32);
            this.linearPO.TabIndex = 10;
            this.linearPO.Text = "线性点运算";
            this.linearPO.Click += new System.EventHandler(this.linearPO_Click);
            // 
            // stretch
            // 
            this.stretch.Location = new System.Drawing.Point(12, 365);
            this.stretch.Name = "stretch";
            this.stretch.Size = new System.Drawing.Size(75, 37);
            this.stretch.TabIndex = 11;
            this.stretch.Text = "灰度拉伸";
            this.stretch.Click += new System.EventHandler(this.stretch_Click);
            // 
            // equalization
            // 
            this.equalization.Location = new System.Drawing.Point(12, 408);
            this.equalization.Name = "equalization";
            this.equalization.Size = new System.Drawing.Size(75, 31);
            this.equalization.TabIndex = 12;
            this.equalization.Text = "直方图均衡化";
            this.equalization.Click += new System.EventHandler(this.equalization_Click);
            // 
            // shaping
            // 
            this.shaping.Location = new System.Drawing.Point(12, 445);
            this.shaping.Name = "shaping";
            this.shaping.Size = new System.Drawing.Size(75, 31);
            this.shaping.TabIndex = 13;
            this.shaping.Text = "直方图匹配";
            this.shaping.Click += new System.EventHandler(this.shaping_Click);
            // 
            // translation
            // 
            this.translation.Location = new System.Drawing.Point(12, 482);
            this.translation.Name = "translation";
            this.translation.Size = new System.Drawing.Size(75, 30);
            this.translation.TabIndex = 14;
            this.translation.Text = "图像平移";
            this.translation.Click += new System.EventHandler(this.translation_Click);
            // 
            // mirror
            // 
            this.mirror.Location = new System.Drawing.Point(12, 518);
            this.mirror.Name = "mirror";
            this.mirror.Size = new System.Drawing.Size(75, 30);
            this.mirror.TabIndex = 15;
            this.mirror.Text = "图像镜像";
            this.mirror.Click += new System.EventHandler(this.mirror_Click);
            // 
            // zoom
            // 
            this.zoom.Location = new System.Drawing.Point(93, 12);
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(75, 40);
            this.zoom.TabIndex = 16;
            this.zoom.Text = "图像缩放";
            this.zoom.Click += new System.EventHandler(this.zoom_Click);
            // 
            // rotation
            // 
            this.rotation.Location = new System.Drawing.Point(93, 58);
            this.rotation.Name = "rotation";
            this.rotation.Size = new System.Drawing.Size(75, 40);
            this.rotation.TabIndex = 17;
            this.rotation.Text = "图像旋转";
            this.rotation.Click += new System.EventHandler(this.rotation_Click);
            // 
            // canny
            // 
            this.canny.Location = new System.Drawing.Point(93, 104);
            this.canny.Name = "canny";
            this.canny.Size = new System.Drawing.Size(75, 40);
            this.canny.TabIndex = 18;
            this.canny.Text = "Canny算子";
            this.canny.Click += new System.EventHandler(this.canny_Click);
            // 
            // pixelMatrix
            // 
            this.pixelMatrix.Location = new System.Drawing.Point(93, 150);
            this.pixelMatrix.Name = "pixelMatrix";
            this.pixelMatrix.Size = new System.Drawing.Size(75, 40);
            this.pixelMatrix.TabIndex = 19;
            this.pixelMatrix.Text = "像素矩阵";
            this.pixelMatrix.Click += new System.EventHandler(this.pixelMatrix_Click);
            // 
            // edgeDetection
            // 
            this.edgeDetection.Location = new System.Drawing.Point(93, 196);
            this.edgeDetection.Name = "edgeDetection";
            this.edgeDetection.Size = new System.Drawing.Size(75, 40);
            this.edgeDetection.TabIndex = 20;
            this.edgeDetection.Text = "边缘检测";
            this.edgeDetection.Click += new System.EventHandler(this.edgeDetection_Click);
            // 
            // binaryzation
            // 
            this.binaryzation.Location = new System.Drawing.Point(93, 242);
            this.binaryzation.Name = "binaryzation";
            this.binaryzation.Size = new System.Drawing.Size(75, 40);
            this.binaryzation.TabIndex = 21;
            this.binaryzation.Text = "二值化";
            this.binaryzation.Click += new System.EventHandler(this.binaryzation_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(93, 288);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 33);
            this.simpleButton1.TabIndex = 22;
            this.simpleButton1.Text = "24位转8位";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(93, 327);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 32);
            this.simpleButton2.TabIndex = 23;
            this.simpleButton2.Text = "腐蚀";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(93, 365);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 37);
            this.simpleButton3.TabIndex = 24;
            this.simpleButton3.Text = "去噪";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(93, 408);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(75, 31);
            this.simpleButton4.TabIndex = 25;
            this.simpleButton4.Text = "剔除杂点";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(93, 445);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(75, 31);
            this.simpleButton5.TabIndex = 26;
            this.simpleButton5.Text = "缺陷增强";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // simpleButton6
            // 
            this.simpleButton6.Location = new System.Drawing.Point(93, 482);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(75, 30);
            this.simpleButton6.TabIndex = 27;
            this.simpleButton6.Text = "抠图";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // simpleButton7
            // 
            this.simpleButton7.Location = new System.Drawing.Point(93, 518);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(75, 30);
            this.simpleButton7.TabIndex = 28;
            this.simpleButton7.Text = "划分圆环";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // simpleButton8
            // 
            this.simpleButton8.Location = new System.Drawing.Point(174, 13);
            this.simpleButton8.Name = "simpleButton8";
            this.simpleButton8.Size = new System.Drawing.Size(80, 39);
            this.simpleButton8.TabIndex = 29;
            this.simpleButton8.Text = "椭圆拟合";
            this.simpleButton8.Click += new System.EventHandler(this.simpleButton8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 643);
            this.Controls.Add(this.simpleButton8);
            this.Controls.Add(this.simpleButton7);
            this.Controls.Add(this.simpleButton6);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.binaryzation);
            this.Controls.Add(this.edgeDetection);
            this.Controls.Add(this.pixelMatrix);
            this.Controls.Add(this.canny);
            this.Controls.Add(this.rotation);
            this.Controls.Add(this.zoom);
            this.Controls.Add(this.mirror);
            this.Controls.Add(this.translation);
            this.Controls.Add(this.shaping);
            this.Controls.Add(this.equalization);
            this.Controls.Add(this.stretch);
            this.Controls.Add(this.linearPO);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.runingTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pointer);
            this.Controls.Add(this.memory);
            this.Controls.Add(this.pixel);
            this.Controls.Add(this.displayImage);
            this.Controls.Add(this.close);
            this.Controls.Add(this.save);
            this.Controls.Add(this.open);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.displayImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton open;
        private DevExpress.XtraEditors.SimpleButton save;
        private DevExpress.XtraEditors.SimpleButton close;
        private System.Windows.Forms.PictureBox displayImage;
        private DevExpress.XtraEditors.SimpleButton pointer;
        private DevExpress.XtraEditors.SimpleButton memory;
        private DevExpress.XtraEditors.SimpleButton pixel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox runingTime;
        private DevExpress.XtraEditors.SimpleButton histogram;
        private DevExpress.XtraEditors.SimpleButton linearPO;
        private DevExpress.XtraEditors.SimpleButton stretch;
        private DevExpress.XtraEditors.SimpleButton equalization;
        private DevExpress.XtraEditors.SimpleButton shaping;
        private DevExpress.XtraEditors.SimpleButton translation;
        private DevExpress.XtraEditors.SimpleButton mirror;
        private DevExpress.XtraEditors.SimpleButton zoom;
        private DevExpress.XtraEditors.SimpleButton rotation;
        private DevExpress.XtraEditors.SimpleButton canny;
        private DevExpress.XtraEditors.SimpleButton pixelMatrix;
        private DevExpress.XtraEditors.SimpleButton edgeDetection;
        private DevExpress.XtraEditors.SimpleButton binaryzation;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private DevExpress.XtraEditors.SimpleButton simpleButton8;
    }
}

