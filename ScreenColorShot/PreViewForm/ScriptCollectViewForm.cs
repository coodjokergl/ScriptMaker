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
    public partial class ScriptCollectViewForm : Form
    {
        public int Index { get; set; }

        public ScriptCollectViewForm()
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
        private List<ScriptCollectViewForm> otherScreenForms = new List<ScriptCollectViewForm>();

        

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
            if(StartPoint == Point.Empty) return;
            var selectRect = CalcSelectRectangle();
             //边框
            var borderBr = new SolidBrush(Color.DarkRed);
            var borderPen = new Pen(borderBr, 2);
            //背景色
            var backgroundBr = new SolidBrush(Color.White);
            var g = e.Graphics;
            try
            {
                g.DrawRectangle(borderPen, selectRect);
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


        #region 鼠标事件

        private void pictureBoxCut_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Common.IsFeatureMode)
            {
                Common.Scrips.Add(new Common.ScriptItem()
                {
                    Pos = this.PointToClient(MousePosition),
                    Type = Common.MouseType.Move
                });
            }


            this.Invalidate(true);
        }

        private void pictureBoxCut_MouseLeave(object sender, EventArgs e)
        {

            this.Invalidate(true);

        }

        private void pictureBoxCut_MouseEnter(object sender, EventArgs e)
        {
            Common.ScreenIndex = Index;
            this.Invalidate(true);

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
            var index = 0;
            var forms = Screen.AllScreens.Select(_ => new ScriptCollectViewForm()
            {
                Index = index ++,
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
                Clipboard.SetText(FeatureValue);

                Common.Scrips.Add(new Common.ScriptItem()
                {
                    Feature = FeatureValue,
                    Pos = this.PointToClient(MousePosition),
                    Type = Common.MouseType.DoubleClick
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void pictureBoxCut_MouseDown(object sender, MouseEventArgs e)
        {
            if(IsSelectRect) return;
            StartPoint = MousePosition;
            SelectRectangle = null;
            FeatureValue = string.Empty;
        }

        /// <summary>
        /// 起始坐标
        /// </summary>
        public Point StartPoint { get; set; } = Point.Empty;
        
        public bool IsSelectRect { get; set; } = false;

        public string FeatureValue { get; set; }

        private void pictureBoxCut_MouseUp(object sender, MouseEventArgs e)
        {
            if(IsSelectRect) return;
            IsSelectRect = true;
            try
            {
                SelectRectangle = CalcSelectRectangle();

                StartPoint = Point.Empty;
                if(SelectRectangle == null || SelectRectangle.Value.Height <= 0 || SelectRectangle.Value.Width <= 0) return;
                using (var bmp = this.Image.Clone(SelectRectangle.Value,this.Image.PixelFormat))
                {
                    FeatureValue = HashNormalHelper.Hash(bmp);
                    Common.Scrips.Add(new Common.ScriptItem()
                    {
                        Feature = FeatureValue,
                        Rect = SelectRectangle.Value,
                        Type = Common.MouseType.Select,
                        Pos = this.PointToClient(MousePosition),
                    });
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                IsSelectRect = false;
            }
           
        }

        private Rectangle? SelectRectangle;

        private Rectangle CalcSelectRectangle()
        {
            var s = this.PointToClient(StartPoint);
            var e = this.PointToClient(MousePosition);
            return new Rectangle(new Point(Math.Min(s.X,e.X),Math.Min(s.Y,e.Y)),new Size(Math.Abs(s.X -e.X),Math.Abs(s.Y -e.Y)) );
        }

        private void pictureBoxCut_Click(object sender, EventArgs e)
        {
            if(Common.IsFeatureMode) return;

            try
            {
                Common.Scrips.Add(new Common.ScriptItem()
                {
                    Feature = FeatureValue,
                    Pos = this.PointToClient(MousePosition),
                    Type = Common.MouseType.Click
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}