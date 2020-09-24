using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter1
{
    public partial class zoomForm : Form
    {
        public zoomForm()
        {
            InitializeComponent();
        }

        private void startZoom_Click(object sender, EventArgs e)
        {
            if (xZoom.Text=="0"||yZoom.Text=="0")
            {
                MessageBox.Show("缩放量不能为0！\n请重新输入。");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void closeZoom_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool GetNearOrBil
        {
            get
            {
                return nearestNeigh.Checked;
            }
        }

        public string GetXZoom
        {
            get
            {
                return xZoom.Text;
            }
        }

        public string GetYZoom
        {
            get
            {
                return yZoom.Text;
            }
        }
    }
}
