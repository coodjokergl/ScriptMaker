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
    public partial class FeatureViewForm : Form
    {

        public FeatureViewForm()
        {
            InitializeComponent();
        }


        private void ScreenPreViewForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Up)
            {
                if (Features.FirstOrDefault() == _currentFeatureResource)
                {
                    MessageBox.Show(@"已经是第一个了");
                    return;
                }

                CurrentFeatureResource = Features[Features.IndexOf(_currentFeatureResource) - 1];
            }

            if (e.KeyCode == Keys.Down)
            {
                if (Features.LastOrDefault() == _currentFeatureResource)
                {
                    MessageBox.Show(@"已经是最后一个了");
                    return;
                }

                CurrentFeatureResource = Features[Features.IndexOf(_currentFeatureResource) + 1];
            }
        }


        public List<FeatureResource> Features { get; set; }

        private void ScreenPreViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                //判断是否存在当前待显示的屏幕,存在则显示,否则不显示
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(0, 0);
               
                this.TopMost = !Debugger.IsAttached;

                CurrentFeatureResource = Features?.FirstOrDefault();
                this.Invalidate();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private FeatureResource _currentFeatureResource;
        public FeatureResource CurrentFeatureResource
        {
            get { return _currentFeatureResource; }
            set
            {
                _currentFeatureResource = value;
                if (_currentFeatureResource != null)
                {
                    var img = _currentFeatureResource.Image;
                    this.Size = img.Size;
                    this.pictureBoxCut.Image = img;

                    this.Invalidate(true);
                }
            }
        }

        private void pictureBoxCut_Paint(object sender, PaintEventArgs e)
        {
            //边框
            var borderBr = new SolidBrush(Color.DarkRed);
            var borderPen = new Pen(borderBr, 2);
            //背景色
            var backgroundBr = new SolidBrush(Color.White);
            var g = e.Graphics;
            try
            {
                if (_currentFeatureResource != null && _currentFeatureResource.Features != null)
                {
                    foreach (var feature in _currentFeatureResource.Features)
                    {
                        g.DrawRectangle(borderPen, feature.Rect);
                    }
                }
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

        private void pictureBoxCut_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void pictureBoxCut_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_currentFeatureResource != null && _currentFeatureResource.Features != null)
                {
                    var pos = this.PointToClient(CurPos);
                    foreach (var feature in _currentFeatureResource.Features)
                    {
                        var scriptItem = new Common.ScriptItem()
                        {
                            Pos = pos,
                            Rect = feature.Rect,
                            Feature = feature.Feature,
                            Type = Common.MouseType.Select,
                            FunctionName = feature.Name
                        };
                        if (feature.Rect.Contains(pos))
                        {
                            Clipboard.SetText(scriptItem.ToString());
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void pictureBoxCut_MouseMove(object sender, MouseEventArgs e)
        {
            CurPos = e.Location;
        }

        public Point CurPos { get; set; }
    }
}