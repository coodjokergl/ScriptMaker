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
    /// 鼠标节点
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// 特征码
        /// </summary>
        public static bool IsFeatureMode { get; set; }

        /// <summary>
        /// 屏幕索引
        /// </summary>
        public static int ScreenIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static List<Point> MousePoints { get; set; } = new List<Point>();

        /// <summary>
        /// 
        /// </summary>
        public static bool IsAddMouse { get;set; }


        public static List<ScriptItem> Scrips { get; set; }= new List<ScriptItem>();

        public enum MouseType
        {
            Click,

            DoubleClick,

            Move,

            Select
        }

        public class ScriptItem
        {
            public Point Pos { get; set; }

            public Rectangle Rect { get; set; }

            public MouseType Type { get; set; }

            public string Feature { get; set; }


            public void Do()
            {
                try
                {
                    switch (Type)
                    {
                        case MouseType.Click:
                            if(CurrentRunner == null || CurrentRunner!=null && !Match(CurrentRunner.Pos,Pos)) return;
                            Mouse.Click(Pos);
                            break;
                        case MouseType.DoubleClick:
                            if(CurrentRunner == null ||CurrentRunner!=null && !Match(CurrentRunner.Pos,Pos)) return;
                            Mouse.DoubleClick(Pos);
                            break;
                        case MouseType.Move:
                            if(CurrentRunner == null ||CurrentRunner!=null && !Match(CurrentRunner.Pos,Pos)) return;
                            Mouse.MoveTo(Pos);
                            break;
                        default:
                            return;
                    }

                }
                finally
                {
                    CurrentRunner = this;
                }
               
                Thread.Sleep(300);
            }

            private static ScriptItem CurrentRunner;

            private static bool Match(Point point1, Point pint2)
            {
                return Math.Abs(point1.X - pint2.X) > 10 || Math.Abs(point1.Y - pint2.Y) > 10;
            }


            /// <inheritdoc />
            public override string ToString()
            {
                try
                {
                    switch (Type)
                    {
                        case MouseType.Click:
                            if(CurrentRunner == null || CurrentRunner!=null && CurrentRunner.Type == Type && !Match(CurrentRunner.Pos,Pos)) return string.Empty;
                            return $@"代理.鼠标.单击({Pos.X},{Pos.Y});";
                        case MouseType.DoubleClick:
                            if(CurrentRunner == null || CurrentRunner!=null && CurrentRunner.Type == Type&& !Match(CurrentRunner.Pos,Pos)) return string.Empty;
                            return $@"代理.鼠标.双击({Pos.X},{Pos.Y});";
                        case MouseType.Move:
                            if(CurrentRunner == null || CurrentRunner!=null && !Match(CurrentRunner.Pos,Pos)) return string.Empty;
                            return $@"代理.鼠标.移动({Pos.X},{Pos.Y});";
                        case MouseType.Select:
                            return $@"function {FunctionName}(){{
return 代理.系统.图片特征('{Rect.X},{Rect.Y},{Rect.Width},{Rect.Height}') == '{Feature}';
}}";
                        default:
                            return string.Empty;
                    }
                }
                finally
                {
                    CurrentRunner = this;
                }
            }

            private string _functionName;
            public string FunctionName
            {
                get
                {
                    if (string.IsNullOrEmpty(_functionName))
                    {
                        _functionName = $@"区域特征{DateTime.Now.ToFileTime()}";
                    }

                    return _functionName;
                }
                set { _functionName = value; }
            }
        }
    }
}
