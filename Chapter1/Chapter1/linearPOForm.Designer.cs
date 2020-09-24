namespace Chapter1
{
    partial class linearPOForm
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
            this.startLinear = new DevExpress.XtraEditors.SimpleButton();
            this.close = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scaling = new System.Windows.Forms.TextBox();
            this.offset = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startLinear
            // 
            this.startLinear.Location = new System.Drawing.Point(12, 12);
            this.startLinear.Name = "startLinear";
            this.startLinear.Size = new System.Drawing.Size(72, 33);
            this.startLinear.TabIndex = 0;
            this.startLinear.Text = "确定";
            this.startLinear.Click += new System.EventHandler(this.startLinear_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(256, 12);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(72, 32);
            this.close.TabIndex = 0;
            this.close.Text = "退出";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "线性点运算：g(x,y)=Pf(x,y)+L";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "斜率（P）：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "偏移量（L）:";
            // 
            // scaling
            // 
            this.scaling.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scaling.Location = new System.Drawing.Point(137, 95);
            this.scaling.Name = "scaling";
            this.scaling.Size = new System.Drawing.Size(100, 30);
            this.scaling.TabIndex = 2;
            this.scaling.Text = "1";
            // 
            // offset
            // 
            this.offset.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.offset.Location = new System.Drawing.Point(137, 137);
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(100, 30);
            this.offset.TabIndex = 2;
            this.offset.Text = "0";
            // 
            // linearPOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 239);
            this.ControlBox = false;
            this.Controls.Add(this.offset);
            this.Controls.Add(this.scaling);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.startLinear);
            this.Name = "linearPOForm";
            this.Text = "线性点运算";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton startLinear;
        private DevExpress.XtraEditors.SimpleButton close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scaling;
        private System.Windows.Forms.TextBox offset;
    }
}