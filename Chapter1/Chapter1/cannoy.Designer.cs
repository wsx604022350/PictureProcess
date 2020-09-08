namespace Chapter1
{
    partial class cannoy
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
            this.label3 = new System.Windows.Forms.Label();
            this.sigma = new System.Windows.Forms.TextBox();
            this.threshHigh = new System.Windows.Forms.TextBox();
            this.threshLow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(15, 165);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 33);
            this.start.TabIndex = 0;
            this.start.Text = "确定";
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(96, 165);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 33);
            this.close.TabIndex = 0;
            this.close.Text = "退出";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "均方差";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "高阙值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "低阙值";
            // 
            // sigma
            // 
            this.sigma.Location = new System.Drawing.Point(70, 29);
            this.sigma.Name = "sigma";
            this.sigma.Size = new System.Drawing.Size(100, 25);
            this.sigma.TabIndex = 3;
            this.sigma.Text = "2";
            // 
            // threshHigh
            // 
            this.threshHigh.Location = new System.Drawing.Point(70, 76);
            this.threshHigh.Name = "threshHigh";
            this.threshHigh.Size = new System.Drawing.Size(100, 25);
            this.threshHigh.TabIndex = 4;
            this.threshHigh.Text = "100";
            // 
            // threshLow
            // 
            this.threshLow.Location = new System.Drawing.Point(70, 117);
            this.threshLow.Name = "threshLow";
            this.threshLow.Size = new System.Drawing.Size(100, 25);
            this.threshLow.TabIndex = 5;
            this.threshLow.Text = "50";
            // 
            // cannoy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 228);
            this.ControlBox = false;
            this.Controls.Add(this.threshLow);
            this.Controls.Add(this.threshHigh);
            this.Controls.Add(this.sigma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.start);
            this.Name = "cannoy";
            this.Text = "cannoy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton start;
        private DevExpress.XtraEditors.SimpleButton close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sigma;
        private System.Windows.Forms.TextBox threshHigh;
        private System.Windows.Forms.TextBox threshLow;
    }
}