using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenColorShot
{
    public static class Helper
    {
        public static System.Drawing.Rectangle GetRectangle(string ret)
        {
            if(string.IsNullOrEmpty(ret)) return System.Drawing.Rectangle.Empty;
            var pos = ret.Split(',').Select(q=>Convert.ToInt32(q)).ToList();
            return new System.Drawing.Rectangle(new System.Drawing.Point(pos[0],pos[1]),new System.Drawing.Size(pos[2],pos[3]));
        }

        public static System.Drawing.Point? GetPoint(string posVal)
        {
            if(string.IsNullOrEmpty(posVal)) return null;
            var pos = posVal.Split(',').Select(q=>Convert.ToInt32(q)).ToList();
            return new System.Drawing.Point(pos[0],pos[1]);
        }

        public static List<string> Values(string val)
        {
            if(string.IsNullOrEmpty(val)) return new List<string>();

            return val.Split(',').ToList();
        }

        public static string PictureUtf8Code(Bitmap img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms,System.Drawing.Imaging.ImageFormat.Bmp);
                var hashBytes = ms.GetBuffer();
                return Encoding.UTF8.GetString(hashBytes);
            }
        }

        /// <summary>
        /// C#截取屏幕并保存为图片
        /// </summary>
        public static Bitmap GetScreen(Screen screen)
        {
            Bitmap myImage = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);

            using (Graphics g = Graphics.FromImage(myImage))
            {
                g.CopyFromScreen(screen.Bounds.Location, new Point(0, 0),
                    new Size(screen.Bounds.Width, screen.Bounds.Height));
                IntPtr dc1 = g.GetHdc();
                g.ReleaseHdc(dc1);
            }

            return myImage;
        }
    }
}
