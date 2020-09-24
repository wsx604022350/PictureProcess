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
    public partial class shapinForm : Form
    {
        private string shapingFileName;
        private Bitmap shapingBitmap;
        private int[] shapingPixel;
        private double[] cumHist;
        private int shapingSize;
        private int maxPixel;

        public shapinForm()
        {
            InitializeComponent();
            shapingPixel = new int[256];
            cumHist = new double[256];
        }

        private void open_Click(object sender, EventArgs e)
        {
            //打开所要匹配的图像，得到其直方图
            //创建标准对话框，选择打开文件
            OpenFileDialog opnDlg = new OpenFileDialog();
            //为图像选择一个筛选器
            opnDlg.Filter = "所有文件(*.bmp;*.png;*.jpg;*.jif;*.gif)|*.bmp;*.png;*.jpg;*.jif;*.gif|" + "位图(*.bmp)|*.bmp";
            //设置对话框标题
            opnDlg.Title = "打开图像文件";
            //启用帮助按钮
            opnDlg.ShowHelp = true;

            //如果结果为“打开”，选定文件
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                //读取当前选中的文件名
                shapingFileName = opnDlg.FileName;
                //创建图像对象
                try
                {
                    shapingBitmap = (Bitmap)Image.FromFile(shapingFileName);
                }
                catch (Exception exp)
                {
                    //抛出异常
                    MessageBox.Show(exp.Message);
                }
            }

            //计算图像灰度等级像素个数
            byte temp;
            maxPixel = 0;
            Array.Clear(shapingPixel,0,256);
            for (int i = 0; i < shapingBitmap.Width; i++)
            {
                for (int j = 0; j < shapingBitmap.Height; j++)
                {
                    temp= shapingBitmap.GetPixel(i, j).R;
                    shapingPixel[temp]++;
                    if (shapingPixel[temp]>maxPixel)
                    {
                        maxPixel = shapingPixel[temp];
                    }
                }
            }

            Invalidate();
        }

        private void startShaping_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void shapinForm_Paint(object sender, PaintEventArgs e)
        {
            if (shapingFileName!=null)
            {
                //在窗体内绘制直方图
                Pen curPen = new Pen(Brushes.Black, 1);
                Graphics g = e.Graphics;

                g.DrawLine(curPen, 50, 240, 320, 240);
                g.DrawLine(curPen, 50, 240, 50, 30);

                g.DrawLine(curPen, 100, 240, 100, 242);
                g.DrawLine(curPen, 150, 240, 150, 242);
                g.DrawLine(curPen, 200, 240, 200, 242);
                g.DrawLine(curPen, 250, 240, 250, 242);
                g.DrawLine(curPen, 300, 240, 300, 242);
                g.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(46, 242));
                g.DrawString("50", new Font("New Timer", 8), Brushes.Black, new PointF(92, 242));
                g.DrawString("100", new Font("New Timer", 8), Brushes.Black, new PointF(139, 242));
                g.DrawString("150", new Font("New Timer", 8), Brushes.Black, new PointF(189, 242));
                g.DrawString("200", new Font("New Timer", 8), Brushes.Black, new PointF(239, 242));
                g.DrawString("250", new Font("New Timer", 8), Brushes.Black, new PointF(289, 242));
                g.DrawLine(curPen, 48, 40, 50, 40);
                g.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(34, 234));
                g.DrawString(maxPixel.ToString(), new Font("New Timer", 8), Brushes.Black, new PointF(18, 34));

                double temp = 0;
                int[] tempArray = new int[256];
                shapingSize = shapingBitmap.Width * shapingBitmap.Height;
                for (int i = 0; i < 256; i++)
                {
                    temp = 200 * (double)shapingPixel[i] / (double)maxPixel;
                    g.DrawLine(curPen,50+i,240,50+i,240-(int)temp);

                    //计算该直方图各灰度级的累积分布函数
                    if (i!=0)
                    {
                        tempArray[i] = tempArray[i - 1] + shapingPixel[i];
                    }
                    else
                    {
                        tempArray[i] = shapingPixel[i];
                    }
                    cumHist[i] = (double)tempArray[i] / (double)shapingSize;
                }
                curPen.Dispose();
            }           
        }

        public double[] ApplicationP
        {
            get
            {
                return cumHist;
            }
        }
    }
}
