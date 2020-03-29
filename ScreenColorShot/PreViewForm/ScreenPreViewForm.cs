using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronOcr;

namespace ScreenColorShot.PreViewForm
{
    public partial class ScreenPreViewForm : Form
    {
        public ScreenPreViewForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭事件 按esc取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForms();
        }

        private void CloseForms()
        {
            try
            {
                foreach (var screenPreViewForm in otherScreenForms)
                {
                    screenPreViewForm.Close();
                }

                OnCloseFormEvent();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void ScreenPreViewForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CloseForms();
            }
        }

        /// <summary>
        /// 屏幕
        /// </summary>
        public Screen CurrentScreen { get; private set; }

        /// <summary>
        /// 截图
        /// </summary>
        public Bitmap Image { get; private set; }

        /// <summary>
        /// 所有界面
        /// </summary>
        private List<ScreenPreViewForm> otherScreenForms = new List<ScreenPreViewForm>();

        

        private void ScreenPreViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Screen.AllScreens.Any(_ => _.Equals(CurrentScreen)))
                {
                    //判断是否存在当前待显示的屏幕,存在则显示,否则不显示
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(CurrentScreen.Bounds.Left, CurrentScreen.Bounds.Top);
                    //this.WindowState = FormWindowState.Maximized;
                    this.Size = CurrentScreen.Bounds.Size;
                    this.TopMost = !Debugger.IsAttached;
                    this.pictureBoxCut.Image = Image;
                }
                else
                {
                    this.Visible = false;
                }
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception);
            }
        }

        private void pictureBoxCut_Paint(object sender, PaintEventArgs e)
        {
            if(!_beginColor && _mousPoint != Point.Empty) return;


            var color = this.Image.GetPixel(_mousPoint.X, _mousPoint.Y);

            var g = e.Graphics;

            //边框
            var borderBr = new SolidBrush(Color.Black);
            var borderPen = new Pen(borderBr, 2);
            var borderReadBr = new SolidBrush(Color.DarkRed);
            //背景色
            var backgroundBr = new SolidBrush(Color.White);

            try
            {
                var showInfoLoc = GetShowInfo(color, _mousPoint, g.ClipBounds);

                //绘制提示边框 及背景色
                g.DrawRectangle(borderPen, showInfoLoc.Location.InfoBorder);
                g.FillRectangle(backgroundBr, showInfoLoc.Location.InfoBorder);

                //绘制取色 色块
                var colorBr = new SolidBrush(color);

                g.DrawRectangle(borderPen, showInfoLoc.Location.InfoColor);

                if (StartPoint != Point.Empty)
                {
                    g.DrawRectangle(borderPen, CalcOcrRectangle());
                }


                if (OcrRectangle != null)
                {
                    var ocrRet = OcrRectangle.Value;
                    g.DrawRectangle(borderPen, ocrRet);

                    var ocrTipsRect = new RectangleF(new PointF(ocrRet.X + ocrRet.Width, ocrRet.Y), new SizeF(150, 24));
                    g.FillRectangle(backgroundBr, ocrTipsRect);
                    //绘制颜色信息
                    g.DrawString($@"ocr time span:{ocrStopwatch.Elapsed.TotalSeconds:###,##0.00}s {(IsOcrMaking ? "..." : "success")}", this.Font, borderReadBr,ocrTipsRect,StringFormat.GenericTypographic);
                }

                g.FillRectangle(colorBr, showInfoLoc.Location.InfoColor);

                //绘制颜色信息
                g.DrawString(showInfoLoc.InfoText, this.Font, borderBr, showInfoLoc.Location.InfoString);
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception);
            }
            finally
            {
                borderBr.Dispose();
                borderPen.Dispose();
                backgroundBr.Dispose();
            }
        }


        /// <summary>
        /// 获取显示信息
        /// </summary>
        /// <param name="color"></param>
        /// <param name="startPoint"></param>
        /// <param name="ret"></param>
        /// <returns></returns>
        private ShowInfo GetShowInfo(Color color, Point startPoint, RectangleF ret)
        {
            var showInfo = new ShowInfo();

            var startX = startPoint.X + 50;
            var startY = startPoint.Y;

            var haseOcrValue = !string.IsNullOrEmpty(OcrString) || IsOcrMaking;

            var width = haseOcrValue ? 260 : 130;
            var height = haseOcrValue ? 150 : 60;
            if (startX + width > ret.Width)
            {
                startX -= 190;
            }
            if (startY + height > ret.Bottom)
            {
                startY -= 80;
            }

            var loction = new ShowInfoLocation();
            loction.InfoColor = new Rectangle(new Point(startX + 10, startY + 10),new Size(10,10));
            loction.InfoString = new Rectangle(new Point(startX + 10, startY + 40),new Size(
                width-30,height-30));
            loction.InfoBorder = new Rectangle(new Point(startX, startY),new Size(width,height));

            showInfo.Location = loction;

            showInfo.InfoColor = color;
            var sb = new StringBuilder();
            sb.AppendLine(System.Drawing.ColorTranslator.ToHtml(color));
            

            if (haseOcrValue)
            {
                sb.AppendLine(OcrString);
            }

            showInfo.InfoText = sb.ToString();

            return showInfo;
        }

        #region 鼠标事件

        private bool _beginColor = false;


        private Point _mousPoint = Point.Empty;

        private void pictureBoxCut_MouseMove(object sender, MouseEventArgs e)
        {
            if (Common.IsAddMouse)
            {
                Common.MousePoints.Add(this.PointToClient(MousePosition));
            }

            if(!_beginColor)return;

            _mousPoint = e.Location;

            this.Invalidate(true);
        }

        private void pictureBoxCut_MouseLeave(object sender, EventArgs e)
        {
            _beginColor = false;

            this.Invalidate(true);

        }

        private void pictureBoxCut_MouseEnter(object sender, EventArgs e)
        {
            _beginColor = true;
        }

        #endregion

        #region 静态方法

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

        /// <summary>
        /// 显示屏幕
        /// </summary>
        public static void ShowScreen()
        {
            var forms = Screen.AllScreens.Select(_ => new ScreenPreViewForm()
            {
                CurrentScreen = _,
                Image = GetScreen(_)
            }).ToList();

            foreach (var preViewForm in forms)
            {
                preViewForm.otherScreenForms = forms;
            }

            foreach (var form in forms)
            {
                form.Show();
            }
        }



        #endregion

        /// <summary>
        /// 关闭事件
        /// </summary>
        public delegate void CloseFormHandler();

        /// <summary>
        /// 关闭事件
        /// </summary>

        public static event CloseFormHandler CloseFormEvent;

        /// <summary>
        /// 触发事件
        /// </summary>
        private static void OnCloseFormEvent()
        {
            CloseFormEvent?.Invoke();
        }

        /// <summary>
        /// 双击保留颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxCut_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Point formPoint = this.PointToClient(MousePosition);//鼠标相对于窗体左上角的坐标

                var color = this.Image.GetPixel(formPoint.X, formPoint.Y);

                var colorText = ColorTranslator.ToHtml(color);
                Clipboard.SetText(colorText);

                CloseForms();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void pictureBoxCut_MouseDown(object sender, MouseEventArgs e)
        {
            if(IsOcrMaking) return;
            StartPoint = MousePosition;
            OcrRectangle = null;
            OcrString = string.Empty;
        }

        /// <summary>
        /// 起始坐标
        /// </summary>
        public Point StartPoint { get; set; } = Point.Empty;
        
        public bool IsOcrMaking { get; set; } = false;

        public string OcrString { get; set; }

        readonly Stopwatch ocrStopwatch = new Stopwatch();
        private void pictureBoxCut_MouseUp(object sender, MouseEventArgs e)
        {
            if(IsOcrMaking) return;
            IsOcrMaking = true;

            OcrRectangle = CalcOcrRectangle();

            StartPoint = Point.Empty;
            Task.Run(() =>
            {
                var timer = new System.Threading.Timer(new TimerCallback((state =>
                {
                    this.BeginInvoke(new Action(()=>this.Refresh()));
                })),null,300,300);
                try
                {
                    IsOcrMaking = true;

                    if(OcrRectangle == null) return;

                    //鼠标相对于窗体左上角的坐标
                    ocrStopwatch.Restart();
                    using (var bitBmp = this.Image.Clone(OcrRectangle.Value,this.Image.PixelFormat))
                    {
                        var Result = Ocr.Read(bitBmp);
                    
                        ocrStopwatch.Stop();

                        this.BeginInvoke(new Action(()=>this.Refresh()));

                        OcrString = Result.Text;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
                finally
                {
                    timer.Dispose();
                    timer = null;
                    IsOcrMaking = false;
                }
               
            });
        }

        private AdvancedOcr Ocr = new AdvancedOcr()
        {
            Language = IronOcr.Languages.ChineseSimplified.OcrLanguagePack,
            CleanBackgroundNoise = false,
            DetectWhiteTextOnDarkBackgrounds = false,
            EnhanceContrast = false,
            RotateAndStraighten = false,
            Strategy = AdvancedOcr.OcrStrategy.Fast,
            ColorSpace = AdvancedOcr.OcrColorSpace.Color,
            AcceptedOcrCharacters = "",
            InputImageType = AdvancedOcr.InputTypes.Snippet,

        };
        private Rectangle? OcrRectangle;

        private Rectangle CalcOcrRectangle()
        {
            var s = this.PointToClient(StartPoint);
            var e = this.PointToClient(MousePosition);
            return new Rectangle(new Point(Math.Min(s.X,e.X),Math.Min(s.Y,e.Y)),new Size(Math.Abs(s.X -e.X),Math.Abs(s.Y -e.Y)) );
        }
    }
}


/// <summary>
/// 提示信息位置
/// </summary>
internal class ShowInfo
{
    public ShowInfoLocation Location { get; set; }

    /// <summary>
    /// 提示文本
    /// </summary>
    public string InfoText { get; set; }

    /// <summary>
    /// 颜色
    /// </summary>
    public Color InfoColor { get; set; }
}
/// <summary>
/// 提示信息位置
/// </summary>
internal class ShowInfoLocation
{
    /// <summary>
    /// 信息边框
    /// </summary>
    public Rectangle InfoBorder { get; set; }

    /// <summary>
    /// 信息颜色块
    /// </summary>
    public Rectangle InfoColor { get; set; }

    /// <summary>
    /// 信息字符串
    /// </summary>
    public Rectangle InfoString { get; set; }
}