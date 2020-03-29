using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlaUI.Core.Input;
using IronOcr;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using ScreenColorShot.PreViewForm;

namespace ScreenColorShot
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ScreenPreViewForm.CloseFormEvent += ScreenPreViewFormOnCloseFormEvent;
        }

        private void ScreenPreViewFormOnCloseFormEvent()
        {
            try
            {
                this.BringToFront();
                this.TopMost = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        /// <summary>
        /// 点击查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.SendToBack();

                ScreenPreViewForm.ShowScreen();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var screen = Screen.FromControl(this);

                var point = new Point(screen.Bounds.Right - 100,screen.Bounds.Top + 100);
                this.Location = point;
                this.Size = new Size(33,30);
                this.TopMost = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

        }

        private void 显示主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 截屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ScreenPreViewForm.ShowScreen();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"屏幕取色工具.龚磊制作.");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Visible = false;
            }
        }

        private void ocrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CommonOpenFileDialog cofd = new CommonOpenFileDialog();
                cofd.IsFolderPicker = false;
                cofd.AllowNonFileSystemItems = true;
                cofd.Multiselect = false;
                if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    var Ocr = new AdvancedOcr()
                    {
                        Language = IronOcr.Languages.ChineseSimplified.OcrLanguagePack,
                    };
                    Ocr.CleanBackgroundNoise = false;
                    Ocr.DetectWhiteTextOnDarkBackgrounds = false;
                    Ocr.EnhanceContrast = false;
                    Ocr.RotateAndStraighten = false;
                    Ocr.Strategy = AdvancedOcr.OcrStrategy.Fast;
                    var Result = Ocr.Read(cofd.FileName);
                    MessageBox.Show(Result.Text);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 录制脚本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Scrips = new List<Common.ScriptItem>();
            Common.IsFeatureMode = false;
            try
            {
                ScriptCollectViewForm.ShowScreen();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void 回放鼠标脚本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(Common.Scrips == null) return;
                foreach (var script in Common.Scrips)
                {
                    script.Do();
                }

                Common.IsAddMouse = false;
               
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void js脚本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new JavaScriptForm();
                dlg.ShowDialog();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 录制特征ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Scrips = new List<Common.ScriptItem>();
            Common.IsFeatureMode = true;
            try
            {
                ScriptCollectViewForm.ShowScreen();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 批量提取特征ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new BatchFeatureSetForm();
                dlg.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 批量特征查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CommonOpenFileDialog cofd = new CommonOpenFileDialog();
                cofd.IsFolderPicker = false;
                cofd.AllowNonFileSystemItems = true;
                cofd.Multiselect = false;
                if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    var dlg = new FeatureViewForm();
                    dlg.Features = JsonConvert.DeserializeObject<List<FeatureResource>>(File.ReadAllText(cofd.FileName));
                    dlg.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
