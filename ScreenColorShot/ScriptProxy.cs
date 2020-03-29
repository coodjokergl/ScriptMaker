using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlaUI.Core.Input;

namespace ScreenColorShot
{
    /// <summary>
    /// 脚本代理
    /// </summary>
    public class ScriptProxy
    {
        public MouseProxy 鼠标 { get; } = new MouseProxy();
        public OsSystem 系统 { get; } = new OsSystem();
        public void 延迟(int delay)
        {
            Thread.Sleep(delay);
        }
    }

    public class MouseProxy
    {
        public void 移动(int x,int y)
        {
            Mouse.MoveTo(new Point(x,y));
        }

        public void 单击(int x,int y)
        {
            Mouse.Click(new Point(x,y));
        }

        public void 双击(int x,int y)
        {
            Mouse.DoubleClick(new Point(x,y));
        }

        public void 拖动(int x,int y,int x2,int y2)
        {
            Mouse.Drag(new Point(x,y),new Point(x2,y2));
        }

        public void 滚屏(int x,int y)
        {
            if (x > 0)
            {
                Mouse.HorizontalScroll(x);
            }
        }
    }

    public class 键盘
    {

    }

    public class OsSystem
    {
        /// <summary>
        /// 退出
        /// </summary>
        public void 退出()
        {
        }

        /// <summary>
        /// 图片特征
        /// </summary>
        /// <param name="rectVal"></param>
        /// <returns></returns>
        public string 图片特征(string rectVal)
        {
            var img = Img();
            var rect = Helper.GetRectangle(rectVal);
            using (var bmp = img.Clone(rect,img.PixelFormat))
            {
                return HashNormalHelper.Hash(bmp);
            }
        }

        internal Func<Bitmap> Img;
    }
}
