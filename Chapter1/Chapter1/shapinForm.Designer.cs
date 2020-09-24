namespace Chapter1
{
    partial class shapinForm
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
            this.startShaping = new DevExpress.XtraEditors.SimpleButton();
            this.close = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(25, 323);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 33);
            this.open.TabIndex = 0;
            this.open.Text = "打开文件";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // startShaping
            // 
            this.startShaping.Location = new System.Drawing.Point(149, 323);
            this.startShaping.Name = "startShaping";
            this.startShaping.Size = new System.Drawing.Size(75, 33);
            this.startShaping.TabIndex = 0;
            this.startShaping.Text = "确定";
            this.startShaping.Click += new System.EventHandler(this.startShaping_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(265, 323);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 33);
            this.close.TabIndex = 0;
            this.close.Text = "退出";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // shapinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 368);
            this.ControlBox = false;
            this.Controls.Add(this.close);
            this.Controls.Add(this.startShaping);
            this.Controls.Add(this.open);
            this.Name = "shapinForm";
            this.Text = "直方图匹配";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.shapinForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton open;
        private DevExpress.XtraEditors.SimpleButton startShaping;
        private DevExpress.XtraEditors.SimpleButton close;
    }
}