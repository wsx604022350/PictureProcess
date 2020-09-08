using System;
using System.Runtime;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;
using VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using System.Drawing.Drawing2D;

namespace Chapter1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private string curFileName;//文件名
        private Bitmap curBitmap;//图像对象        

        private HiPerfTimer myTimer = new HiPerfTimer();//计时

        public Form1()
        {
            InitializeComponent();
        }

        //打开图像文件
        private void open_Click(object sender, EventArgs e)
        {
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
                curFileName = opnDlg.FileName;
                //创建图像对象
                try
                {
                    curBitmap = (Bitmap)Image.FromFile(curFileName);
                    //displayImage.Load(curFileName);
                    displayImage.Image = curBitmap;
                }
                catch (Exception exp)
                {
                    //抛出异常
                    MessageBox.Show(exp.Message);
                }
            }
            //对窗体进行重新绘制，这将强制执行paint事件处理程序
            //Invalidate();
        }

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    //获取要绘制的对象
        //    Graphics g = e.Graphics;

        //    if (curBitmap != null)
        //    {
        //        //绘制图像
        //        //160,20:显示在主窗体内，图像左上角的坐标
        //        //图像的宽度和高度
        //        g.DrawImage(curBitmap,160, 20, curBitmap.Width, curBitmap.Height);
        //    }
        //}

        //保存图像
        private void save_Click(object sender, EventArgs e)
        {
            //如果没有创建图像，则退出
            if (curBitmap == null)
            {
                return;
            }
            //创建标准对话框，选择保存文件
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "保存为";
            //改写已存在文件时提醒用户
            //saveDlg.OverwritePrompt = false;
            saveDlg.Filter = "JPEG文件(*.jpg)|*.jpg|" + "BMP文件(*.bmp)|*.bmp|" + "Gif文件(*.gif)|*.gif|" +
                "PNG文件(*.png)|*.png";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择的文件名
                string fileName = saveDlg.FileName;
                //保存文件
                curBitmap.Save(fileName);
                //获取用户选择文件的扩展名
                //string strFilExtn = fileName.Remove(0,fileName.Length-3);

                ////保存文件
                //switch (strFilExtn)
                //{
                //    case "bmp":
                //        curBitmap.Save(fileName,ImageFormat.Bmp);
                //        break;
                //    case "jpg":
                //        curBitmap.Save(fileName, ImageFormat.Jpeg);
                //        break;
                //    case "png":
                //        curBitmap.Save(fileName, ImageFormat.Png);
                //        break;
                //    case "gif":
                //        curBitmap.Save(fileName, ImageFormat.Gif);
                //        break;
                //    default:
                //        break;
            }
        }


        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pixel_Click(object sender, EventArgs e)
        {
            //启动计时器
            myTimer.Start();

            if (curBitmap != null)
            {
                Color curColor;
                int ret;

                //遍历图像二维像素
                for (int i = 0; i < curBitmap.Width; i++)
                {
                    for (int j = 0; j < curBitmap.Height; j++)
                    {
                        //获取该像素点的RGB颜色值
                        curColor = curBitmap.GetPixel(i, j);
                        //计算灰度值
                        ret = (int)(curColor.R * 0.299 + curColor.G * 0.587 + curColor.B * 0.114);
                        //ret = (int)(curColor.R+ curColor.G+ curColor.B)/3;
                        //ret=(int)curColor.G;
                        curBitmap.SetPixel(i, j, Color.FromArgb(ret, ret, ret));
                    }
                }
            }
            //关闭计时器
            myTimer.Stop();
            //显示计数时间
            runingTime.Text = myTimer.Duration().ToString("####.##") + "毫秒";

            displayImage.Image = curBitmap;
            //Invalidate();
        }

        private void memory_Click(object sender, EventArgs e)
        {
            //启动计时器
            myTimer.Start();

            if (curBitmap != null)
            {
                //位图矩阵
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                //以可读写的方式锁定全部位图数据
                BitmapData bmpData = curBitmap.LockBits(rect, ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                //得到首地址
                IntPtr ptr = bmpData.Scan0;

                //24位bmp位图字节数
                int bytes;
                if (curBitmap.Width % 4 == 0)//没有扩展字节，被锁定的数组就是全部的图像数据
                {
                    bytes = curBitmap.Width * curBitmap.Height * 3;
                }
                else
                {
                    bytes = bmpData.Stride * curBitmap.Height;
                }
                //定义位图数组
                byte[] rgbValues = new byte[bytes];
                //复制被锁定的位图像素值到该数组内
                Marshal.Copy(ptr, rgbValues, 0, bytes);

                //灰度化
                double colorTemp = 0;
                if (curBitmap.Width % 4 == 0)
                {
                    for (int i = 0; i < rgbValues.Length; i += 3)
                    {
                        colorTemp = rgbValues[i + 2] * 0.299 + rgbValues[i + 1] * 0.587 + rgbValues[i] * 0.114;
                        rgbValues[i + 2] = rgbValues[i + 1] = rgbValues[i] = (byte)colorTemp;
                    }
                }
                else
                {
                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        //只处理每行中是图像像素的数据，舍弃未用空间
                        for (int j = 0; j < curBitmap.Width * 3; j += 3)
                        {
                            colorTemp = rgbValues[i * bmpData.Stride + j + 2] * 0.299 + rgbValues[i * bmpData.Stride + j + 1] * 0.587 + rgbValues[i * bmpData.Stride + j] * 0.114;
                            rgbValues[i * bmpData.Stride + j + 2] = rgbValues[i * bmpData.Stride + j + 1] = rgbValues[i * bmpData.Stride + j] = (byte)colorTemp;
                        }

                    }
                }

                //数组复制回位图
                Marshal.Copy(rgbValues, 0, ptr, bytes);
                //解锁位图像素
                curBitmap.UnlockBits(bmpData);

                //关闭计时器
                myTimer.Stop();
                //显示计数时间
                runingTime.Text = myTimer.Duration().ToString("####.##") + "毫秒";

                //显示图像
                displayImage.Image = curBitmap;
                //Invalidate();
            }
        }

        private void pointer_Click(object sender, EventArgs e)
        {
            //启动计时器
            myTimer.Start();

            if (curBitmap != null)
            {
                //位图矩阵
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                //以可读写的方式锁定全部位图数据
                BitmapData bmpData = curBitmap.LockBits(rect, ImageLockMode.ReadWrite, curBitmap.PixelFormat);

                byte temp = 0;
                //启用不安全代码
                unsafe
                {
                    //得到首地址
                    byte* ptr = (byte*)bmpData.Scan0;
                    //遍历图像像素点
                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        for (int j = 0; j < curBitmap.Width; j++)
                        {
                            temp = (byte)(ptr[2] * 0.299 + ptr[1] * 0.587 + ptr[0] * 0.114);
                            ptr[2] = ptr[1] = ptr[0] = temp;
                            //指向下一个像素
                            ptr += 3;
                        }
                        //指向下一行数组的首地址
                        ptr += bmpData.Stride - curBitmap.Width * 3;
                    }
                }

                //解锁位图像素
                curBitmap.UnlockBits(bmpData);

                //关闭计时器
                myTimer.Stop();
                //显示计数时间
                runingTime.Text = myTimer.Duration().ToString(".##") + "毫秒";

                //显示图像
                displayImage.Image = curBitmap;
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //获取要绘制的对象
            Graphics g = e.Graphics;

            if (curBitmap != null)
            {
                //绘制图像
                //160,20:显示在主窗体内，图像左上角的坐标
                //图像的宽度和高度
                g.DrawImage(curBitmap, 160, 20, curBitmap.Width, curBitmap.Height);
            }
        }

        private void histogram_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                //定义并实例化新窗体，并把图像数据传递给它
                histForm histGram = new histForm(curBitmap);
                //打开窗体
                histGram.ShowDialog();
            }
            MessageBox.Show("完成！");
        }

        private void linearPO_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                linearPOForm linearPOForm = new linearPOForm();

                int temp = 0;


                if (linearPOForm.ShowDialog() == DialogResult.OK)
                {
                    //得到斜率
                    double a = Convert.ToDouble(linearPOForm.GetScaling);
                    //得到偏移量
                    double b = Convert.ToDouble(linearPOForm.GetOffset);

                    for (int i = 0; i < curBitmap.Width; i++)
                    {
                        for (int j = 0; j < curBitmap.Height; j++)
                        {
                            temp = (int)(a * curBitmap.GetPixel(i, j).R + b + 0.5);
                            if (temp > 255)
                            {
                                curBitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                            }
                            else if (temp < 0)
                            {
                                curBitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                            }
                            else
                            {
                                curBitmap.SetPixel(i, j, Color.FromArgb(temp, temp, temp));
                            }
                        }
                    }
                }
            }
            displayImage.Image = curBitmap;
        }

        private void stretch_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                byte a = 255, b = 0, temp;
                double p;
                for (int i = 0; i < curBitmap.Width; i++)
                {
                    for (int j = 0; j < curBitmap.Height; j++)
                    {
                        //得到最小灰度级
                        if (a > curBitmap.GetPixel(i, j).R)
                        {
                            a = curBitmap.GetPixel(i, j).R;
                        }
                        //得到最大灰度级
                        if (b < curBitmap.GetPixel(i, j).R)
                        {
                            b = curBitmap.GetPixel(i, j).R;
                        }
                    }
                }
                //得到斜率
                p = 255.0 / (b - a);
                //灰度拉伸
                for (int i = 0; i < curBitmap.Width; i++)
                {
                    for (int j = 0; j < curBitmap.Height; j++)
                    {
                        temp = (byte)(p * (curBitmap.GetPixel(i, j).R - a) + 0.5);
                        curBitmap.SetPixel(i, j, Color.FromArgb(temp, temp, temp));
                    }
                }
            }
            displayImage.Image = curBitmap;
            MessageBox.Show("完成");
        }

        private void equalization_Click(object sender, EventArgs e)
        {
            byte temp = 0;
            int[] tempArray = new int[256];
            int[] countPixel = new int[256];
            byte[] pixelMap = new byte[256];
            //计算各灰度级的像素个数
            for (int i = 0; i < curBitmap.Width; i++)
            {
                for (int j = 0; j < curBitmap.Height; j++)
                {
                    //灰度级
                    temp = curBitmap.GetPixel(i, j).R;
                    countPixel[temp]++;
                }
            }
            //计算各灰度级的累计分布函数
            for (int i = 0; i < 256; i++)
            {
                if (i != 0)
                {
                    tempArray[i] = tempArray[i - 1] + countPixel[i];
                }
                else
                {
                    tempArray[i] = countPixel[i];
                }
                //计算累计概率函数，并把值扩展为0-255范围内
                pixelMap[i] = (byte)(255.0 * tempArray[i] / (curBitmap.Width * curBitmap.Height));
            }

            //灰度等级映射转换处理
            for (int i = 0; i < curBitmap.Width; i++)
            {
                for (int j = 0; j < curBitmap.Height; j++)
                {
                    temp = curBitmap.GetPixel(i, j).R;
                    curBitmap.SetPixel(i, j, Color.FromArgb(pixelMap[temp], pixelMap[temp], pixelMap[temp]));
                }
            }
            displayImage.Image = curBitmap;
            MessageBox.Show("完成");
        }

        private void shaping_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                shapinForm sForm = new shapinForm();
                if (sForm.ShowDialog() == DialogResult.OK)
                {
                    byte temp = 0;
                    double[] PPixel = new double[256];
                    double[] QPixel = new double[256];
                    int[] qPixel = new int[256];
                    int[] tempArray = new int[256];

                    for (int i = 0; i < curBitmap.Width; i++)
                    {
                        for (int j = 0; j < curBitmap.Height; j++)
                        {
                            temp = curBitmap.GetPixel(i, j).R;
                            qPixel[temp]++;
                        }
                    }

                    for (int i = 0; i < 256; i++)
                    {
                        if (i != 0)
                        {
                            tempArray[i] = tempArray[i - 1] + qPixel[i];
                        }
                        else
                        {
                            tempArray[i] = qPixel[i];
                        }
                        QPixel[i] = (double)tempArray[i] / (double)(curBitmap.Width * curBitmap.Height);
                    }
                    //得到被匹配的直方图的累积分布函数
                    PPixel = sForm.ApplicationP;

                    double diffA, diffB;
                    byte k = 0;
                    byte[] mapPixel = new byte[256];

                    //直方图匹配
                    for (int i = 0; i < 256; i++)
                    {
                        diffB = 1;
                        for (int j = k; j < 256; j++)
                        {
                            //找到两个累积分布函数中最相似的位置
                            diffA = Math.Abs(QPixel[i] - PPixel[j]);
                            if (diffA - diffB < 1.0E-08)
                            {
                                //记录下差值
                                diffB = diffA;
                                k = (byte)j;
                            }
                            else
                            {
                                //找到了，记录下位置，并退出内层循环
                                k = (byte)(j - 1);
                                break;
                            }
                        }

                        //达到最大灰度级，标识未处理灰度级，并退出外层循环
                        if (k == 255)
                        {
                            for (int l = i; l < 256; l++)
                            {
                                mapPixel[l] = k;
                            }
                            break;
                        }
                        //得到映射关系
                        mapPixel[i] = k;
                    }

                    //灰度级映射处理
                    for (int i = 0; i < curBitmap.Width; i++)
                    {
                        for (int j = 0; j < curBitmap.Height; j++)
                        {
                            temp = curBitmap.GetPixel(i, j).R;
                            curBitmap.SetPixel(i, j, Color.FromArgb(mapPixel[temp], mapPixel[temp], mapPixel[temp]));
                        }
                    }
                }
                displayImage.Image = curBitmap;
            }
        }

        private void translation_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                translation traForm = new translation();
                if (traForm.ShowDialog() == DialogResult.OK)
                {
                    int x = Convert.ToInt32(traForm.GetXOffset);
                    int y = Convert.ToInt32(traForm.GetYOffset);
                    int bytes = curBitmap.Width * curBitmap.Height;

                    byte[] tempArray = new byte[bytes];
                    for (int i = 0; i < bytes; i++)
                    {
                        tempArray[i] = 255;
                    }
                    int temp = 0;

                    //平移运算
                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        //保证纵向平移不出界
                        if ((i + y) < curBitmap.Height && (i + y) > 0)
                        {
                            for (int j = 0; j < curBitmap.Width; j++)
                            {
                                //保证横向不出界
                                if ((j + x) < curBitmap.Width && (j + x) > 0)
                                {
                                    tempArray[(i + y) * curBitmap.Width + (j + x)] = curBitmap.GetPixel(j, i).R;

                                }
                            }
                        }

                    }
                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        for (int j = 0; j < curBitmap.Width; j++)
                        {
                            curBitmap.SetPixel(j, i, Color.FromArgb(tempArray[temp], tempArray[temp], tempArray[temp]));
                            temp++;
                        }
                    }
                    displayImage.Image = curBitmap;
                }
            }
        }

        private void mirror_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                mirForm mirForm = new mirForm();
                if (mirForm.ShowDialog() == DialogResult.OK)
                {
                    byte tempX, tempY;
                    if (mirForm.GetMirror)
                    {
                        //水平镜像
                        for (int i = 0; i < curBitmap.Height; i++)
                        {
                            for (int j = 0; j < curBitmap.Width / 2; j++)
                            {
                                //以水平中轴线为对称轴，两边像素值互换
                                tempX = curBitmap.GetPixel(curBitmap.Width - j - 1, i).R;
                                tempY = curBitmap.GetPixel(j, i).R;
                                curBitmap.SetPixel(j, i, Color.FromArgb(tempX, tempX, tempX));
                                curBitmap.SetPixel(curBitmap.Width - j - 1, i, Color.FromArgb(tempY, tempY, tempY));
                            }
                        }
                    }
                    else
                    {
                        //垂直镜像
                        for (int i = 0; i < curBitmap.Height / 2; i++)
                        {
                            for (int j = 0; j < curBitmap.Width; j++)
                            {
                                //以水平中轴线为对称轴，两边像素值互换
                                tempX = curBitmap.GetPixel(j, curBitmap.Height - i - 1).R;
                                tempY = curBitmap.GetPixel(j, i).R;
                                curBitmap.SetPixel(j, i, Color.FromArgb(tempX, tempX, tempX));
                                curBitmap.SetPixel(j, curBitmap.Height - i - 1, Color.FromArgb(tempY, tempY, tempY));
                            }
                        }
                    }
                    displayImage.Image = curBitmap;
                }
            }
        }

        private void zoom_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                zoomForm zoomForm = new zoomForm();
                if (zoomForm.ShowDialog() == DialogResult.OK)
                {
                    double x = Convert.ToDouble(zoomForm.GetXZoom);
                    double y = Convert.ToDouble(zoomForm.GetYZoom);

                    int halfWidth = curBitmap.Width / 2;
                    int halfHeight = curBitmap.Height / 2;

                    int bytes = curBitmap.Width * curBitmap.Height;
                    int xz = 0;
                    int yz = 0;
                    int tempWidth = 0;
                    int tempHeight = 0;
                    int temp = 0;
                    byte[] arrayTemp = new byte[bytes];

                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        for (int j = 0; j < curBitmap.Width; j++)
                        {
                            arrayTemp[temp++] = curBitmap.GetPixel(j, i).R;
                        }
                    }

                    if (zoomForm.GetNearOrBil)
                    {
                        //最近邻插值法
                        for (int i = 0; i < curBitmap.Height; i++)
                        {
                            for (int j = 0; j < curBitmap.Width; j++)
                            {
                                //以图像的几何中心为坐标原点进行坐标变换
                                //按逆向映射法得到输入图像的坐标
                                tempHeight = i - halfHeight;
                                tempWidth = j - halfWidth;

                                //在不同象限进行四舍五入处理
                                if (tempHeight > 0)
                                {
                                    yz = (int)(tempHeight / y + 0.5);
                                }
                                else
                                {
                                    yz = (int)(tempHeight / y - 0.5);
                                }

                                if (tempWidth > 0)
                                {
                                    xz = (int)(tempWidth / x + 0.5);
                                }
                                else
                                {
                                    xz = (int)(tempWidth / x - 0.5);
                                }

                                //坐标逆变换
                                tempHeight = yz + halfHeight;
                                tempWidth = xz + halfWidth;

                                //得到输出图像像素值
                                if (tempWidth < 0 || tempWidth >= curBitmap.Width || tempHeight < 0 || tempHeight >= curBitmap.Height)
                                {
                                    curBitmap.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                                }
                                else
                                {
                                    temp = (int)arrayTemp[tempHeight * curBitmap.Width + tempWidth];
                                    curBitmap.SetPixel(j, i, Color.FromArgb(temp, temp, temp));
                                }
                            }
                        }
                    }
                    else
                    {
                        //双线性插值法
                        double tempX, tempY, p, q;
                        for (int i = 0; i < curBitmap.Height; i++)
                        {
                            for (int j = 0; j < curBitmap.Width; j++)
                            {
                                tempHeight = i - halfHeight;
                                tempWidth = j - halfWidth;
                                tempY = tempHeight / y;
                                tempX = tempWidth / x;

                                if (tempY > 0)
                                {
                                    yz = (int)tempY;
                                }
                                else
                                {
                                    yz = (int)(tempY - 1);
                                }

                                if (tempX > 0)
                                {
                                    xz = (int)(tempX);
                                }
                                else
                                {
                                    xz = (int)(tempX - 1);
                                }

                                p = tempX - xz;
                                q = tempY - yz;

                                tempHeight = yz + halfHeight;
                                tempWidth = xz + halfWidth;

                                if (tempWidth < 0 || (tempWidth + 1) >= curBitmap.Width || tempHeight < 0 || (tempHeight + 1) >= curBitmap.Height)
                                {
                                    curBitmap.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                                }
                                else
                                {
                                    temp = (int)((1 - p) * (1 - q) * arrayTemp[tempHeight * curBitmap.Width + tempWidth]) +
                                        (int)((1 - p) * q * arrayTemp[(tempHeight + 1) * curBitmap.Width + tempWidth]) +
                                        (int)(p * (1 - q) * arrayTemp[tempHeight * curBitmap.Width + tempWidth + 1]) +
                                        (int)(p * q * arrayTemp[(tempHeight + 1) * curBitmap.Width + tempWidth + 1]);
                                    curBitmap.SetPixel(j, i, Color.FromArgb(temp, temp, temp));
                                }
                            }
                        }

                    }
                    displayImage.Image = curBitmap;
                }
            }
        }

        private void rotation_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                rotForm rotForm = new rotForm();
                if (rotForm.ShowDialog() == DialogResult.OK)
                {
                    int degree = Convert.ToInt32(rotForm.GetDegree);
                    //转换为弧度
                    double radian = degree * Math.PI / 180.0;
                    double mySin = Math.Sin(radian);
                    double myCos = Math.Cos(radian);

                    int halfWidth = curBitmap.Width / 2;
                    int halfHeight = curBitmap.Height / 2;

                    int bytes = curBitmap.Width * curBitmap.Height;
                    int xz = 0;
                    int yz = 0;
                    int tempWidth = 0;
                    int tempHeight = 0;
                    int temp = 0;
                    double tempX, tempY, p, q;
                    byte[] arrayTemp = new byte[bytes];

                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        for (int j = 0; j < curBitmap.Width; j++)
                        {
                            arrayTemp[temp++] = curBitmap.GetPixel(j, i).R;
                        }
                    }

                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        for (int j = 0; j < curBitmap.Width; j++)
                        {
                            tempHeight = i - halfHeight;
                            tempWidth = j - halfWidth;

                            tempY = tempHeight * myCos + tempWidth * mySin;
                            tempX = tempWidth * myCos - tempHeight * mySin;

                            //对不同象限进行取整处理
                            if (tempY > 0)
                            {
                                yz = (int)tempY;
                            }
                            else
                            {
                                yz = (int)(tempY - 1);
                            }

                            if (tempX > 0)
                            {
                                xz = (int)(tempX);
                            }
                            else
                            {
                                xz = (int)(tempX - 1);
                            }

                            p = tempX - xz;
                            q = tempY - yz;

                            tempHeight = yz + halfHeight;
                            tempWidth = xz + halfWidth;

                            if (tempWidth < 0 || (tempWidth + 1) >= curBitmap.Width || tempHeight < 0 || (tempHeight + 1) >= curBitmap.Height)
                            {
                                curBitmap.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                            }
                            else
                            {
                                temp = (int)((1 - p) * (1 - q) * arrayTemp[tempHeight * curBitmap.Width + tempWidth]) +
                                        (int)(p * (1 - q) * arrayTemp[tempHeight * curBitmap.Width + tempWidth + 1]) +
                                        (int)(q * (1 - p) * arrayTemp[(tempHeight + 1) * curBitmap.Width + tempWidth]) +
                                        (int)(p * q * arrayTemp[(tempHeight + 1) * curBitmap.Width + tempWidth + 1]);

                                curBitmap.SetPixel(j, i, Color.FromArgb(temp, temp, temp));
                            }
                        }
                    }
                    displayImage.Image = curBitmap;
                }
            }
        }

        private void canny_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                cannoy cannyOp = new cannoy();
                if (cannyOp.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    BitmapData bmpData = curBitmap.LockBits(rect, ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = curBitmap.Width * curBitmap.Height;
                    byte[] grayValues = new byte[bytes];
                    Marshal.Copy(ptr, grayValues, 0, bytes);

                    byte[] thresholding = new byte[2];
                    //得到阙值
                    thresholding = cannyOp.GetThresh;
                    //得到均方差
                    double sigma = cannyOp.GetSigma;

                    double[] tempArray;
                    double[] tempImage = new double[bytes];
                    double[] grad = new double[bytes];
                    double[] aLabel = new double[bytes];
                    double[] edgeMap = new double[bytes];
                    double gradX, gradY, angle;

                    //高斯模板半径=3
                    int rad = Convert.ToInt16(Math.Ceiling(3 * sigma));

                    for (int i = 0; i < bytes; i++)
                    {
                        tempImage[i] = Convert.ToDouble(grayValues[i]);
                    }

                    //调用高斯平滑处理方法
                    cannyOp.gaussSmooth(tempImage, out tempArray, sigma);

                    //Sobel一阶偏导求梯度幅值和方向
                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        for (int j = 0; j < curBitmap.Width; j++)
                        {
                            //水平方向梯度
                            gradX = tempArray[((Math.Abs(i - 1)) % curBitmap.Height) * curBitmap.Width + ((j + 1) % curBitmap.Width)] +
                                2 * tempArray[i * curBitmap.Width + ((j + 1) % curBitmap.Width)] +
                                tempArray[((i + 1) % curBitmap.Height) * curBitmap.Width + ((j + 1) % curBitmap.Width)] -
                                tempArray[((Math.Abs(i - 1)) % curBitmap.Height) * curBitmap.Width + ((Math.Abs(j - 1)) % curBitmap.Width)] -
                                2 * tempArray[i * curBitmap.Width + ((Math.Abs(j - 1)) % curBitmap.Width)] -
                                tempArray[((i + 1) % curBitmap.Height) * curBitmap.Width + ((Math.Abs(j - 1)) % curBitmap.Width)];
                            //垂直方向梯度
                            gradY = tempArray[((Math.Abs(i - 1)) % curBitmap.Height) * curBitmap.Width + ((Math.Abs(j - 1)) % curBitmap.Width)] +
                                2 * tempArray[((Math.Abs(i - 1)) % curBitmap.Height) * curBitmap.Width + j] +
                                tempArray[((Math.Abs(i - 1)) % curBitmap.Height) * curBitmap.Width + ((j + 1) % curBitmap.Width)] -
                                tempArray[((i + 1) % curBitmap.Height) * curBitmap.Width + ((Math.Abs(j - 1)) % curBitmap.Width)] -
                                2 * tempArray[((i + 1) % curBitmap.Height) * curBitmap.Width + j] -
                                tempArray[((i + 1) % curBitmap.Height) * curBitmap.Width + ((j + 1) % curBitmap.Width)];
                            //梯度和
                            grad[i * curBitmap.Width + j] = Math.Sqrt(gradX * gradX + gradY * gradY);
                            //梯度方向（弧度）
                            angle = Math.Atan2(gradY, gradX);
                            //四个方向量化
                            if (angle >= -1.178097 && angle < 1.178097 || angle >= 2.748894 || angle < -2.748894)
                            {
                                aLabel[i * curBitmap.Width + j] = 0;
                            }
                            else if (angle >= 0.392699 && angle < 1.178097 || angle >= -2.748894 || angle < -1.963495)
                            {
                                aLabel[i * curBitmap.Width + j] = 1;
                            }
                            else if (angle >= -1.178097 && angle < -0.392699 || angle >= 1.963495 || angle < 2.748894)
                            {
                                aLabel[i * curBitmap.Width + j] = 2;
                            }
                            else
                            {
                                aLabel[i * curBitmap.Width + j] = 3;
                            }
                        }
                    }
                    //非最大抑制
                    //数组清零
                    Array.Clear(edgeMap, 0, bytes);
                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        for (int j = 0; j < curBitmap.Width; j++)
                        {
                            switch (aLabel[i * curBitmap.Width + j])
                            {
                                case 3://水平方向
                                    if (grad[i * curBitmap.Width + j] > grad[((Math.Abs(i - 1)) % curBitmap.Height) * curBitmap.Width + j]
                                        && grad[i * curBitmap.Width + j] > grad[((i + 1) % curBitmap.Height) * curBitmap.Width + j])
                                    {
                                        edgeMap[i * curBitmap.Width + j] = grad[i * curBitmap.Width + j];
                                    }
                                    break;
                                case 2://+45度方向
                                    if (grad[i * curBitmap.Width + j] > grad[((Math.Abs(i - 1)) % curBitmap.Height) * curBitmap.Width + (Math.Abs(j - 1) % curBitmap.Width)]
                                        && grad[i * curBitmap.Width + j] > grad[((i + 1) % curBitmap.Height) * curBitmap.Width + ((j + 1) % curBitmap.Width)])
                                    {
                                        edgeMap[i * curBitmap.Width + j] = grad[i * curBitmap.Width + j];
                                    }
                                    break;
                                case 1://-45度方向
                                    if (grad[i * curBitmap.Width + j] > grad[((Math.Abs(i - 1)) % curBitmap.Height) * curBitmap.Width + ((j + 1) % curBitmap.Width)]
                                        && grad[i * curBitmap.Width + j] > grad[((i + 1) % curBitmap.Height) * curBitmap.Width + j])
                                    {
                                        edgeMap[i * curBitmap.Width + j] = grad[i * curBitmap.Width + j];
                                    }
                                    break;
                                case 0://垂直方向
                                    if (grad[i * curBitmap.Width + j] > grad[i * curBitmap.Width + (Math.Abs(j - 1) % curBitmap.Width)]
                                        && grad[i * curBitmap.Width + j] > grad[i * curBitmap.Width + ((j + 1) % curBitmap.Width)])
                                    {
                                        edgeMap[i * curBitmap.Width + j] = grad[i * curBitmap.Width + j];
                                    }
                                    break;
                                default:
                                    break;

                            }
                        }
                    }

                    //双阙值算法
                    Array.Clear(grayValues, 0, bytes);
                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        for (int j = 0; j < curBitmap.Width; j++)
                        {
                            if (edgeMap[i * curBitmap.Width + j] > thresholding[0])
                            {
                                grayValues[i * curBitmap.Width + j] = 255;
                                //调用边缘点跟踪方法
                                traceEdge(i, j, edgeMap, ref grayValues, thresholding[1]);
                            }
                        }
                    }
                    Marshal.Copy(grayValues, 0, ptr, bytes);
                    curBitmap.UnlockBits(bmpData);
                    int temp = 0;
                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        for (int j = 0; j < curBitmap.Width; j++)
                        {
                            curBitmap.SetPixel(j, i, Color.FromArgb(grayValues[temp], grayValues[temp], grayValues[temp]));
                            temp++;
                        }
                    }
                }

                displayImage.Image = curBitmap;
            }
        }
        /*************************************
         边缘跟踪，递归算法
         k:图像纵坐标
         l:图像横坐标
         inputImage:梯度图像
         outputImage:输出边缘图像
         thrLow:低阙值
         * *********************************/
        public void traceEdge(int k, int l, double[] inputImage, ref byte[] outputImage, byte thrLow)
        {
            //8领域
            int[] kOffset = new int[] { 1, 1, 0, -1, -1, -1, 0, 1 };
            int[] lOffset = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };

            int kk, ll;
            for (int p = 0; p < 8; p++)
            {
                kk = k + kOffset[p];
                //循环延拓
                kk = Math.Abs(kk) % curBitmap.Height;
                ll = l + lOffset[p];
                //循环延拓
                ll = Math.Abs(ll) % curBitmap.Width;
                if (outputImage[ll * curBitmap.Width + kk] != 255)
                {
                    if (inputImage[ll * curBitmap.Width + kk] > thrLow)
                    {
                        outputImage[ll * curBitmap.Width + kk] = 255;
                        //递归调用
                        traceEdge(ll, kk, inputImage, ref outputImage, thrLow);
                    }
                }
            }
        }

        private void pixelMatrix_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                XSSFWorkbook workbook = new XSSFWorkbook();

                //创建工作表
                var sheet = workbook.CreateSheet("像素矩阵");

                //设置格式
                //ICellStyle style1 = workbook.CreateCellStyle();//声明style1对象，设置Excel表格的样式
                //ICellStyle style2 = workbook.CreateCellStyle();
                //ICellStyle style3 = workbook.CreateCellStyle();
                //IFont font = workbook.CreateFont();
                //font.Color = IndexedColors.Red.Index;
                //style3.SetFont(font);
                //style1.Alignment = HorizontalAlignment.Justify;//两端自动对齐（自动换行）
                //style1.VerticalAlignment = VerticalAlignment.Center;
                //style2.Alignment = HorizontalAlignment.Center;
                //style2.VerticalAlignment = VerticalAlignment.Center;
                //style3.Alignment = HorizontalAlignment.Center;
                //style3.VerticalAlignment = VerticalAlignment.Center;

                byte temp;
                for (int i = 0; i < curBitmap.Height; i++)
                {
                    var row = sheet.CreateRow(i);
                    for (int j = 0; j < curBitmap.Width; j++)
                    {
                        var pixel = row.CreateCell(j);
                        temp = curBitmap.GetPixel(j, i).R;
                        pixel.SetCellValue(temp.ToString());
                    }
                }
                FileStream file = null;
                String path = "C:\\Users\\QianChangDe\\Desktop";
                file = new FileStream(path + "\\像素矩阵1.xlsx", FileMode.CreateNew, FileAccess.Write);
                workbook.Write(file);
                file.Dispose();
                MessageBox.Show("输出成功！");
            }
        }

        private void edgeDetection_Click(object sender, EventArgs e)
        {
            int l = curBitmap.Height / 2 - 5;
            int k = curBitmap.Width / 2 - 10;

            if (curBitmap != null)
            {
                for (int i = 0; i < curBitmap.Height - 4;)
                {
                    for (int j = 0; j < curBitmap.Width - 4;)
                    {
                        int distance = (int)Math.Sqrt(Math.Pow(l - i, 2) + Math.Pow(k - j, 2));
                        int pixel = (curBitmap.GetPixel(j, i).R + curBitmap.GetPixel(j + 1, i).R + curBitmap.GetPixel(j + 2, i).R + curBitmap.GetPixel(j + 3, i).R + curBitmap.GetPixel(j + 4, i).R +
                            curBitmap.GetPixel(j, i + 1).R + curBitmap.GetPixel(j + 1, i + 1).R + curBitmap.GetPixel(j + 2, i + 1).R + curBitmap.GetPixel(j + 3, i + 1).R + curBitmap.GetPixel(j + 4, i + 1).R +
                            curBitmap.GetPixel(j, i + 2).R + curBitmap.GetPixel(j + 1, i + 2).R + curBitmap.GetPixel(j + 2, i + 2).R + curBitmap.GetPixel(j + 3, i + 2).R + curBitmap.GetPixel(j + 4, i + 2).R +
                            curBitmap.GetPixel(j, i + 3).R + curBitmap.GetPixel(j + 1, i + 3).R + curBitmap.GetPixel(j + 2, i + 3).R + curBitmap.GetPixel(j + 3, i + 3).R + curBitmap.GetPixel(j + 4, i + 3).R +
                            curBitmap.GetPixel(j, i + 4).R + curBitmap.GetPixel(j + 1, i + 4).R + curBitmap.GetPixel(j + 2, i + 4).R + curBitmap.GetPixel(j + 3, i + 4).R + curBitmap.GetPixel(j + 4, i + 4).R) / 16;
                        if (pixel == 0 && distance > 806)
                        {
                            curBitmap.SetPixel(j, i, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 1, i, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 2, i, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 3, i, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 4, i, Color.FromArgb(0, 250, 0));

                            curBitmap.SetPixel(j, i + 1, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 1, i + 1, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 2, i + 1, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 3, i + 1, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 4, i + 1, Color.FromArgb(0, 250, 0));

                            curBitmap.SetPixel(j, i + 2, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 1, i + 2, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 2, i + 2, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 3, i + 2, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 4, i + 2, Color.FromArgb(0, 250, 0));

                            curBitmap.SetPixel(j, i + 3, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 1, i + 3, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 2, i + 3, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 3, i + 3, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 4, i + 3, Color.FromArgb(0, 250, 0));

                            curBitmap.SetPixel(j, i + 4, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 1, i + 4, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 2, i + 4, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 3, i + 4, Color.FromArgb(0, 250, 0));
                            curBitmap.SetPixel(j + 4, i + 4, Color.FromArgb(0, 250, 0));
                        }
                        //else
                        //{
                        //    curBitmap.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 1, i, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 2, i, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 3, i, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j, i + 1, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 1, i + 1, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 2, i + 1, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 3, i + 1, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j, i + 2, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 1, i + 2, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 2, i + 2, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 3, i + 2, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j, i + 3, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 1, i + 3, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 2, i + 3, Color.FromArgb(0, 0, 0));
                        //    curBitmap.SetPixel(j + 3, i + 3, Color.FromArgb(0, 0, 0));
                        //}
                        j = j + 4;
                    }
                    i = i + 4;
                }

                displayImage.Image = curBitmap;
                MessageBox.Show("完成！");
                //displayImage.Image = curBitmap1;
            }
        }
        private string readTargetpath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择在图片数据所在文件夹";
            DialogResult result = dialog.ShowDialog();
            string targetPath = dialog.SelectedPath;

            // 判断给定的目录是否存在                
            if (!string.IsNullOrEmpty(targetPath))
            {
                MessageBox.Show("浏览成功！");
            }
            else
            {
                MessageBox.Show("浏览失败！");
            }
            Text = targetPath;
            return targetPath;
        }

        private void binaryzation_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                //for (int i = 0; i < curBitmap.Height; i++)
                //{
                //    for (int j = 0; j < curBitmap.Width; j++)
                //    {                        
                //        if (curBitmap.GetPixel(j, i).R==0)
                //        {
                //            curBitmap.SetPixel(j, i, Color.FromArgb(255,255,255));
                //        }
                //        //else
                //        //{
                //        //    curBitmap.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                //        //}
                //    }
                //}
                //displayImage.Image = curBitmap;

                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = curBitmap.Width * curBitmap.Height;
                byte[] rgbValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                //double colorTemp = 0;
                for (int i = 0; i < rgbValues.Length; i++)
                {
                    if (rgbValues[i] == 0)
                    {
                        rgbValues[i] = 1;
                    }
                }
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
                curBitmap.UnlockBits(bmpData);
                displayImage.Image = curBitmap;
                MessageBox.Show("结束");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                curBitmap = transForm24to8(curBitmap);
                displayImage.Image = curBitmap;
                MessageBox.Show("转换完成！");
            }
        }

        public static Bitmap transForm24to8(Bitmap bmp)
        {

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bmpData.Stride * bmpData.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            Rectangle rect2 = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Bitmap bit = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format8bppIndexed);
            System.Drawing.Imaging.BitmapData bmpData2 = bit.LockBits(rect2, System.Drawing.Imaging.ImageLockMode.ReadWrite, bit.PixelFormat);
            IntPtr ptr2 = bmpData2.Scan0;
            int bytes2 = bmpData2.Stride * bmpData2.Height;
            byte[] rgbValues2 = new byte[bytes2];
            System.Runtime.InteropServices.Marshal.Copy(ptr2, rgbValues2, 0, bytes2);
            double colorTemp = 0;
            for (int i = 0; i < bmpData.Height; i++)
            {
                for (int j = 0; j < bmpData.Width * 3; j += 3)
                {
                    colorTemp = rgbValues[i * bmpData.Stride + j + 2] * 0.299 + rgbValues[i * bmpData.Stride + j + 1] * 0.578 + rgbValues[i * bmpData.Stride + j] * 0.114;
                    rgbValues2[i * bmpData2.Stride + j / 3] = (byte)colorTemp;
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(rgbValues2, 0, ptr2, bytes2);
            bmp.UnlockBits(bmpData);
            ColorPalette tempPalette;
            {
                using (Bitmap tempBmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
                {
                    tempPalette = tempBmp.Palette;
                }
                for (int i = 0; i < 256; i++)
                {
                    tempPalette.Entries[i] = Color.FromArgb(i, i, i);
                }
                bit.Palette = tempPalette;
            }
            bit.UnlockBits(bmpData2);
            //string path = ((g++).ToString()) + "_8bit" + ".bmp";
            //bit.Save("C:\\Users\\QianChangDe\\Desktop\\8位图.jpg");
            return bit;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                for (int i = 0; i < curBitmap.Height; i++)
                {
                    for (int j = 1; j < curBitmap.Width - 1; j++)
                    {
                        if (curBitmap.GetPixel(j, i).R == 0 &&
                            curBitmap.GetPixel(j + 1, i).R == 0 &&
                            curBitmap.GetPixel(j - 1, i).R == 0)
                        {
                            curBitmap.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
                displayImage.Image = curBitmap;
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                for (int i = 0; i < curBitmap.Height - 1; i++)
                {
                    for (int j = 0; j < curBitmap.Width - 1; j++)
                    {
                        int k = (int)Math.Sqrt(Math.Pow(Math.Abs(j - curBitmap.Width / 2), 2) + Math.Pow(Math.Abs(i - curBitmap.Height / 2), 2));
                        int l = (int)Math.Sqrt(Math.Pow(Math.Abs(j - curBitmap.Width / 2 + 40), 2) + Math.Pow(Math.Abs(i - curBitmap.Height / 2 + 20), 2));
                        if (curBitmap.GetPixel(j, i).R > 150)
                        {
                            int[] pixel = { curBitmap.GetPixel(j, i).R, curBitmap.GetPixel(j+1, i).R, curBitmap.GetPixel(j-1, i).R, curBitmap.GetPixel(j, i-1).R, curBitmap.GetPixel(j, i+1).R,
                            curBitmap.GetPixel(j+2, i).R, curBitmap.GetPixel(j-2, i).R, curBitmap.GetPixel(j, i-2).R, curBitmap.GetPixel(j, i+2).R,
                            curBitmap.GetPixel(j+3, i).R, curBitmap.GetPixel(j-3, i).R, curBitmap.GetPixel(j, i-3).R, curBitmap.GetPixel(j, i+3).R,
                            curBitmap.GetPixel(j+4, i).R, curBitmap.GetPixel(j-4, i).R, curBitmap.GetPixel(j, i-4).R, curBitmap.GetPixel(j, i+4).R,
                            curBitmap.GetPixel(j+5, i).R, curBitmap.GetPixel(j-5, i).R, curBitmap.GetPixel(j, i-5).R, curBitmap.GetPixel(j, i+5).R
                            };
                            //curBitmap.SetPixel(j, i, Color.FromArgb(0, 0, 255));
                            //int pixel = curBitmap.GetPixel(j, i).R;
                            //curBitmap.SetPixel(j, i, Color.FromArgb(pixel-50, pixel - 50, pixel - 50));
                            if (pixel.Min() > 120)
                            {
                                curBitmap.SetPixel(j, i, Color.FromArgb(pixel.Min(), pixel.Min(), pixel.Min()));
                            }

                        }

                    }
                }
                displayImage.Image = curBitmap;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            int l = curBitmap.Height / 2 - 8;
            int k = curBitmap.Width / 2 - 8;
            for (int i = 0; i < curBitmap.Height; i++)
            {
                for (int j = 0; j < curBitmap.Width; j++)
                {
                    int distance = (int)Math.Sqrt(Math.Pow(l - i, 2) + Math.Pow(k - j, 2));
                    int pixel = curBitmap.GetPixel(j, i).R;

                    if ((distance > 845 || distance < 840) && pixel > 200)
                    {
                        curBitmap.SetPixel(j, i, Color.FromArgb(pixel - 50, pixel - 50, pixel - 50));
                    }

                    if (distance < 845 && distance > 840 && pixel > 100 && pixel < 200)
                    {
                        curBitmap.SetPixel(j, i, Color.FromArgb(pixel + 50, pixel + 50, pixel + 50));
                    }

                    if (distance < 818 && distance > 813)
                    {
                        curBitmap.SetPixel(j, i, Color.FromArgb(10, 10, 10));
                    }
                    if (distance < 845 && distance > 840 && curBitmap.GetPixel(j, i).R > 120)
                    {
                        curBitmap.SetPixel(j, i, Color.FromArgb(250, 250, 250));
                    }
                }
            }
            displayImage.Image = curBitmap;
            MessageBox.Show("完成！");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            int l = curBitmap.Height / 2 - 8;
            int k = curBitmap.Width / 2 - 8;
            Bitmap curBitmap1 = (Bitmap)Image.FromFile("C:\\Users\\QianChangDe\\Desktop\\清晰图像.jpg");
            if (curBitmap != null)
            {
                for (int i = 0; i < curBitmap.Height; i++)
                {
                    for (int j = 0; j < curBitmap.Width; j++)
                    {
                        int distance = (int)Math.Sqrt(Math.Pow(l - i, 2) + Math.Pow(k - j, 2));
                        int pixel = curBitmap.GetPixel(j, i).R;
                        if (distance < 818 && distance > 813)
                        {
                            curBitmap.SetPixel(j, i, Color.FromArgb(0, 255, 0));
                            curBitmap1.SetPixel(j - 30, i - 15, Color.FromArgb(0, 255, 0));
                        }
                        if (distance < 844 && distance > 841 && pixel > 180)
                        {
                            curBitmap.SetPixel(j, i, Color.FromArgb(255, 0, 0));
                            curBitmap1.SetPixel(j - 30, i - 15, Color.FromArgb(255, 0, 0));
                        }

                        //else if (curBitmap.GetPixel(j, i).R == 0)
                        //{
                        //    curBitmap.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                        //}
                    }
                }
                //curBitmap1.Save("C:\\Users\\QianChangDe\\Desktop\\01\\02.jpg");
                displayImage.Image = curBitmap1;
                curBitmap1.Save("C:\\Users\\QianChangDe\\Desktop\\直接抠图.jpg");
                MessageBox.Show("完成！");
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Bitmap curBitmap1 = (Bitmap)Image.FromFile(curFileName);
            Bitmap curBitmap2 = (Bitmap)Image.FromFile(curFileName);
            Bitmap curBitmap3 = (Bitmap)Image.FromFile(curFileName);
            List<Point> inRing = new List<Point>();
            List<Point> outRing = new List<Point>();

            //圆心坐标
            //int l = curBitmap.Height / 2 - 23;//原图
            //int k = curBitmap.Width / 2 - 38;

            int l = curBitmap.Height / 2 - 8;//复原图
            int k = curBitmap.Width / 2 - 8;

            //垂直方向直线
            Point p0 = new Point();
            Point p1 = new Point();
            p0.X = k;
            p0.Y = l - 860;
            p1.X = k;
            p1.Y = l + 860;

            //外圈标定点
            Point p2 = new Point();
            Point p3 = new Point();
            p2.X = k;
            p2.Y = l - 842;
            p3.X = k;
            p3.Y = l + 842;

            //内圈标定点
            Point p4 = new Point();
            Point p5 = new Point();
            p4.X = k;
            p4.Y = l - 820;
            p5.X = k;
            p5.Y = l + 820;

            //将圆环36等分            
            List<Point> inRingTarget = new List<Point>();            
            List<Point> outRingTarget = new List<Point>();            

            for (double i = 0; i < Math.PI-0.001;)
            {
                p0.X = k +Convert.ToInt32(860 * Math.Sin(i));
                p0.Y = l- Convert.ToInt32(860 * Math.Cos(i));
                p1.X = k - Convert.ToInt32(860 * Math.Sin(i));
                p1.Y = l + Convert.ToInt32(860 * Math.Cos(i));
                curBitmap = drawLine.DrawLineInPicture(curBitmap, p0, p1, Color.FromArgb(255,0,0), 2, DashStyle.Solid);

                p4.X = k + Convert.ToInt32(842 * Math.Sin(i));
                p4.Y = l - Convert.ToInt32(842 * Math.Cos(i));
                p5.X = k - Convert.ToInt32(842 * Math.Sin(i));
                p5.Y = l + Convert.ToInt32(842 * Math.Cos(i));
                outRingTarget.Add(p4);
                outRingTarget.Add(p5);

                p2.X = k + Convert.ToInt32(820 * Math.Sin(i));
                p2.Y = l - Convert.ToInt32(820 * Math.Cos(i));
                p3.X = k - Convert.ToInt32(820 * Math.Sin(i));
                p3.Y = l + Convert.ToInt32(820 * Math.Cos(i));
                inRingTarget.Add(p2);
                inRingTarget.Add(p3);
                
                i = i +  Math.PI / 18;                
            }

            List<List<Point>> inRingSave = new List<List<Point>>();
            List<List<Point>> outRingSave = new List<List<Point>>();
            for (int i = 0; i < 36; i++)
            {
                inRingSave.Add(new List<Point>());
                outRingSave.Add(new List<Point>());
            }

            //检测圆环区域
            if (curBitmap != null)
            {
                for (int i = 0; i < curBitmap.Height; i++)
                {
                    for (int j = 0; j < curBitmap.Width; j++)
                    {
                        int distance = (int)Math.Sqrt(Math.Pow(l - i, 2) + Math.Pow(k - j, 2));
                        int pixel = curBitmap.GetPixel(j, i).R;
                        int pixel1 = curBitmap1.GetPixel(j, i).R;
                        
                        //内环
                        if (distance < 820 && distance > 810 && pixel == 255 && pixel1 < 105)
                        {
                            curBitmap2.SetPixel(j, i, Color.FromArgb(0,255,0));
                            Point point = new Point(j, i);
                            inRing.Add(point);
                        }

                        //外环
                        if (distance < 845 && distance > 830 && pixel == 255 && pixel1 > 150)
                        {
                            curBitmap2.SetPixel(j, i, Color.FromArgb(0, 0, 255));
                            Point point = new Point(j, i);
                            outRing.Add(point);
                        }
                    }
                }
            }

            //点分类
            for (int i = 0; i < inRing.Count; i++)
            {
                for (int j = 0; j < inRingTarget.Count; j++)
                {
                    if (Math.Abs(inRing[i].X - inRingTarget[j].X) < 10 && Math.Abs(inRing[i].Y - inRingTarget[j].Y) < 10)
                    {
                        inRingSave[j].Add(inRing[i]);
                    }
                    continue;
                }
            }

            for (int i = 0; i < outRing.Count; i++)
            {
                for (int j = 0; j < outRingTarget.Count; j++)
                {
                    if (Math.Abs(outRing[i].X - outRingTarget[j].X) < 10 && Math.Abs(outRing[i].Y - outRingTarget[j].Y) < 10)
                    {
                        outRingSave[j].Add(outRing[i]);
                    }
                }
            }

            //计算到中心点的平均距离        
            int aveDistance = 0;
            List<int> outDistance = new List<int>();
            for (int i = 0; i < outRingSave.Count; i++)
            {
                if (outRingSave[i].Count != 0)
                {
                    int sum = 0;
                    for (int j = 0; j < outRingSave[i].Count; j++)
                    {
                        int distance = (int)Math.Sqrt(Math.Pow(l - outRingSave[i][j].Y, 2) + Math.Pow(k - outRingSave[i][j].X, 2));
                        sum = sum + distance;
                    }
                    aveDistance = sum / outRingSave[i].Count;
                    outDistance.Add(aveDistance);
                }
                else
                {
                    outDistance.Add(0);
                }
            }

            List<int> inDistance = new List<int>();
            for (int i = 0; i < inRingSave.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < inRingSave[i].Count; j++)
                {
                    int distance = (int)Math.Sqrt(Math.Pow(l - inRingSave[i][j].Y, 2) + Math.Pow(k - inRingSave[i][j].X, 2));
                    sum = sum + distance;
                }
                aveDistance = sum / inRingSave[i].Count;
                inDistance.Add(aveDistance);
            }

            //displayImage.Image = curBitmap;
            displayImage.Image = curBitmap;
            //curBitmap2.Save("C:\\Users\\QianChangDe\\Desktop\\标定点2.jpg");

            ////记录数据
            //XSSFWorkbook workbook = new XSSFWorkbook();
            ////创建工作表
            //var sheet = workbook.CreateSheet("像素矩阵");

            //int temp;

            //for (int i = 0; i < outDistance.Count; i++)
            //{
            //    var row = sheet.CreateRow(i);
            //    var pixel = row.CreateCell(1);
            //    temp = outDistance[i];
            //    pixel.SetCellValue(temp.ToString());

            //}

            //FileStream file = null;
            //String path = "C:\\Users\\QianChangDe\\Desktop";
            //file = new FileStream(path + "\\像素矩阵2.xlsx", FileMode.CreateNew, FileAccess.Write);
            //workbook.Write(file);
            //file.Dispose();

            //MessageBox.Show("完成！");
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            //二值化图
            Bitmap curBitmap1 = (Bitmap)Image.FromFile("C:\\Users\\QianChangDe\\Desktop\\椭圆拟合\\二值化\\1.jpg");
            if (curBitmap != null)
            {
                for (int i = 0; i < curBitmap.Height - 1; i++)
                {
                    for (int j = 0; j < curBitmap.Width - 1; j++)
                    {
                        int pixel= curBitmap.GetPixel(j, i).R;
                        //去除外环
                        if (pixel>50)
                        {                            
                          curBitmap.SetPixel(j, i, Color.FromArgb(0, 255, 0));                            
                        }
                        
                        

                    }
                }
                displayImage.Image = curBitmap;
                MessageBox.Show("完成！");
            }
        }
    }
}
