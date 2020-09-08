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
    public partial class cannoy : Form
    {
        public cannoy()
        {
            InitializeComponent();            
        }

        private void start_Click(object sender, EventArgs e)
        {            
            GetThresh[0] = Convert.ToByte(threshHigh.Text);
            GetThresh[1] = Convert.ToByte(threshLow.Text);
            DialogResult = DialogResult.OK;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        public double GetSigma
        {
            get
            {
                return Convert.ToDouble(sigma.Text);
            }
        }

        public byte[] GetThresh { get; } = new byte[2];

        public void gaussSmooth(double[] inputImage,out double[] outputImage,double sigma)
        {
            //方差
            double std2 = 2 * sigma * sigma;
            //半径=3
            int radius = Convert.ToInt16(Math.Ceiling(3*sigma));
            int filterWidth = 2 * radius + 1;
            double[] filter = new double[filterWidth];
            outputImage = new double[inputImage.Length];
            //限定输入的图像为方阵的情况下的到图像的宽度或高度
            int length = Convert.ToInt16(Math.Sqrt(inputImage.Length));
            double[] tempImage = new double[inputImage.Length];

            double sum = 0;
            //产生一维高斯函数
            for (int i = 0; i < filterWidth; i++)
            {
                int xx = (i - radius) * (i-radius);
                filter[i] = Math.Exp(-xx/std2);
                sum += filter[i];
            }
            //归一化
            for (int i = 0; i < filterWidth; i++)
            {
                filter[i] = filter[i] / sum;
            }

            //水平方向滤波
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    double temp = 0;
                    for (int k = -radius; k <= radius; k++)
                    {
                        //循环延拓
                        int rem = (Math.Abs(j + k)) % length;
                        //计算卷积和
                        temp += inputImage[i*length+rem]*filter[k+radius];
                    }
                    tempImage[i * length + j] = temp;
                }
            }

            //垂直方向滤波
            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i < length; i++)
                {
                    double temp = 0;
                    for (int k = -radius; k <= radius; k++)
                    {
                        //循环延拓
                        int rem = (Math.Abs(i + k)) % length;
                        //计算卷积和
                        temp += inputImage[i * length + rem] * filter[k + radius];
                    }
                    tempImage[i * length + i] = temp;
                }
            }
        }
        
    }
}
