using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class HiPerfTimer
    {
        //查询任意时刻高精度计数器的实际值
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCounter);

        //返回高精度计数器每秒的计数值
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpPerformanceCounter);

        private long startTime, stopTime;
        private long frey;

        //构造函数
        public HiPerfTimer()
        {
            startTime = 0;
            stopTime = 0;

            if (QueryPerformanceFrequency(out frey) == false)
            {
                //不支持高性能计时器
                throw new Win32Exception();
            }
        }

        //开始计时
        public void Start()
        {
            //让等待线程工作
            Thread.Sleep(0);

            QueryPerformanceCounter(out startTime);
        }

        //结束计时
        public void Stop()
        {
            QueryPerformanceCounter(out stopTime);
        }

        //返回计时结果（ms）
        public double Duration()
        {
            return (double)(stopTime - startTime) * 1000 / (double)frey;
        }
    }
}
