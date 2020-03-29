using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Timer = System.Threading.Timer;

namespace ScreenColorShot
{
    /// <summary>
    /// 基于时间线的特征扫描器
    /// </summary>
    [Serializable]
    public class TimerFeatureCollector
    {
        public static bool IsRun { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public static List<Rectangle> Rect { get; set; }

        public static List<FeatureResource> Feature;

        /// <summary>
        /// 开启搜集
        /// </summary>
        /// <param name="times">总时间</param>
        /// <param name="preTimes">间隔时间</param>
        public static void StartCollect(int times, int preTimes)
        {
            try
            {
                if (!Directory.Exists("截图"))
                {
                    Directory.CreateDirectory("截图");
                }

                IsRun = true;

                Feature = new List<FeatureResource>();
                var autoEvent = new AutoResetEvent(false);
                var timer = new Timer(Run, autoEvent, 500, preTimes);
                var span = 0;
                while (span < times)
                {
                    timer.Change(0, preTimes);
                    autoEvent.WaitOne();
                    span += preTimes;
                }

                timer.Dispose(autoEvent);

                File.WriteAllText($@"图片特征文件{DateTime.Now.ToFileTime()}.json", JsonConvert.SerializeObject(Feature));
                Feature = null;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            finally
            {
                IsRun = false;
            }

        }

        private static void Run(object state)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)state;

            try
            {
                //截图，打点
                //var screenImage = FlaUI.Core.Capturing.Capture.Screen();
                //var screenImage = Helper.GetScreen(Screen.PrimaryScreen);
                var screenImage = Helper.GetScreen(Screen.PrimaryScreen);

                var feat = new FeatureResource(screenImage);
                foreach (var rect in Rect)
                {
                    feat.AddFeature(screenImage, rect);
                }

                Feature.Add(feat);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                autoEvent.Set();
            }
        }
    }

    /// <summary>
    /// 特征数据源
    /// </summary>
    [Serializable]
    public class FeatureResource:IDisposable
    {
        public FeatureResource()
        {
            Features = new List<FeatureItem>();
        }

        public FeatureResource(Bitmap bmp)
        {
            Features = new List<FeatureItem>();
            ImageValue = $@"截图\{DateTime.Now.ToFileTime()}.png";
            _img = bmp;
            bmp.Save(ImageValue,ImageFormat.Png);
        }

        /// <summary>
        /// 图片 Base64编码的
        /// </summary>
        public string ImageValue { get; set; }

        private Bitmap _img;

        /// <summary>
        /// 图片
        /// </summary>
        [JsonIgnore]
        public Bitmap Image
        {
            get
            {
                if (_img != null) return _img;
                if (string.IsNullOrEmpty(ImageValue)) return null;
                _img = System.Drawing.Image.FromFile(ImageValue) as Bitmap;
                return _img;
            }
        }

        /// <summary>
        /// 特征
        /// </summary>
        public List<FeatureItem> Features { get; set; }

        /// <summary>
        /// 读取特征存储
        /// </summary>
        /// <param name="srcBmp"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public void AddFeature(Bitmap srcBmp, Rectangle rect)
        {
            using (System.Drawing.Bitmap bmp = srcBmp.Clone(rect, srcBmp.PixelFormat))
            {
                Features.Add(new FeatureItem()
                {
                    Name = $@"图片特征{DateTime.Now.ToFileTime()}",
                    Feature = HashNormalHelper.Hash(bmp),
                    Rect = rect
                });
            }
        }

        /// <summary>
        /// 特征值
        /// </summary>
        [Serializable]
        public class FeatureItem
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 矩形
            /// </summary>
            public Rectangle Rect { get; set; }

            /// <summary>
            /// 特征
            /// </summary>
            public string Feature { get; set; }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _img?.Dispose();
            Features = null;
        }
    }
}
