using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    class drawLine
    {
        /// <summary>
        /// 在图片上画线
        /// </summary>
        /// <param name="bmp">原始图</param>
        /// <param name="p0">起始点</param>
        /// <param name="p1">终止点</param>
        /// <param name="RectColor">线的颜色</param>
        /// <param name="LineWidth">线宽</param>
        /// <param name="ds">线条样式</param>
        /// <returns>输出图</returns>
        public static Bitmap DrawLineInPicture(Bitmap bmp, Point p0, Point p1, Color LineColor, int LineWidth, DashStyle ds)
        {
            if (bmp == null) return null;

            if (p0.X == p1.X && p0.Y == p1.Y) return bmp;

            Graphics g = Graphics.FromImage(bmp);

            Brush brush = new SolidBrush(LineColor);

            Pen pen = new Pen(brush, LineWidth);
            //pen.Alignment = PenAlignment.Inset;

            pen.DashStyle = ds;

            g.DrawLine(pen, p0, p1);

            g.Dispose();

            return bmp;
        }
    }
}
