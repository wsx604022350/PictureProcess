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
    public partial class rotForm : Form
    {
        public rotForm()
        {
            InitializeComponent();
        }

        private void startRot_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
        public string GetDegree
        {
            get
            {
                return degree.Text;
            }
        }
    }
}
