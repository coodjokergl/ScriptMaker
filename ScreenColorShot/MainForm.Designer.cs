namespace ScreenColorShot
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripColor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示主界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.截屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.鼠标移动测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录制特征ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量提取特征ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.回放鼠标脚本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.js脚本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量特征查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStripColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ScreenColorShot.Properties.Resources.fdj;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "查看颜色";
            this.notifyIcon1.BalloonTipTitle = "颜色查看器";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStripColor;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "颜色查看";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStripColor
            // 
            this.contextMenuStripColor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示主界面ToolStripMenuItem,
            this.截屏ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.ocrToolStripMenuItem,
            this.鼠标移动测试ToolStripMenuItem,
            this.录制特征ToolStripMenuItem,
            this.批量提取特征ToolStripMenuItem,
            this.批量特征查看ToolStripMenuItem,
            this.回放鼠标脚本ToolStripMenuItem,
            this.js脚本ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStripColor.Name = "contextMenuStripColor";
            this.contextMenuStripColor.Size = new System.Drawing.Size(181, 268);
            // 
            // 显示主界面ToolStripMenuItem
            // 
            this.显示主界面ToolStripMenuItem.Name = "显示主界面ToolStripMenuItem";
            this.显示主界面ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.显示主界面ToolStripMenuItem.Text = "显示主界面";
            this.显示主界面ToolStripMenuItem.Click += new System.EventHandler(this.显示主界面ToolStripMenuItem_Click);
            // 
            // 截屏ToolStripMenuItem
            // 
            this.截屏ToolStripMenuItem.Name = "截屏ToolStripMenuItem";
            this.截屏ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.截屏ToolStripMenuItem.Text = "截屏";
            this.截屏ToolStripMenuItem.Click += new System.EventHandler(this.截屏ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // ocrToolStripMenuItem
            // 
            this.ocrToolStripMenuItem.Name = "ocrToolStripMenuItem";
            this.ocrToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ocrToolStripMenuItem.Text = "Ocr";
            this.ocrToolStripMenuItem.Click += new System.EventHandler(this.ocrToolStripMenuItem_Click);
            // 
            // 鼠标移动测试ToolStripMenuItem
            // 
            this.鼠标移动测试ToolStripMenuItem.Name = "鼠标移动测试ToolStripMenuItem";
            this.鼠标移动测试ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.鼠标移动测试ToolStripMenuItem.Text = "录制鼠标";
            this.鼠标移动测试ToolStripMenuItem.Click += new System.EventHandler(this.录制脚本ToolStripMenuItem_Click);
            // 
            // 录制特征ToolStripMenuItem
            // 
            this.录制特征ToolStripMenuItem.Name = "录制特征ToolStripMenuItem";
            this.录制特征ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.录制特征ToolStripMenuItem.Text = "录制特征";
            this.录制特征ToolStripMenuItem.Click += new System.EventHandler(this.录制特征ToolStripMenuItem_Click);
            // 
            // 批量提取特征ToolStripMenuItem
            // 
            this.批量提取特征ToolStripMenuItem.Name = "批量提取特征ToolStripMenuItem";
            this.批量提取特征ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.批量提取特征ToolStripMenuItem.Text = "批量提取特征";
            this.批量提取特征ToolStripMenuItem.Click += new System.EventHandler(this.批量提取特征ToolStripMenuItem_Click);
            // 
            // 回放鼠标脚本ToolStripMenuItem
            // 
            this.回放鼠标脚本ToolStripMenuItem.Name = "回放鼠标脚本ToolStripMenuItem";
            this.回放鼠标脚本ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.回放鼠标脚本ToolStripMenuItem.Text = "回放鼠标脚本";
            this.回放鼠标脚本ToolStripMenuItem.Click += new System.EventHandler(this.回放鼠标脚本ToolStripMenuItem_Click);
            // 
            // js脚本ToolStripMenuItem
            // 
            this.js脚本ToolStripMenuItem.Name = "js脚本ToolStripMenuItem";
            this.js脚本ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.js脚本ToolStripMenuItem.Text = "Js脚本";
            this.js脚本ToolStripMenuItem.Click += new System.EventHandler(this.js脚本ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 批量特征查看ToolStripMenuItem
            // 
            this.批量特征查看ToolStripMenuItem.Name = "批量特征查看ToolStripMenuItem";
            this.批量特征查看ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.批量特征查看ToolStripMenuItem.Text = "批量特征查看";
            this.批量特征查看ToolStripMenuItem.Click += new System.EventHandler(this.批量特征查看ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(33, 30);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStripColor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripColor;
        private System.Windows.Forms.ToolStripMenuItem 显示主界面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 截屏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 鼠标移动测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 回放鼠标脚本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem js脚本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录制特征ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量提取特征ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量特征查看ToolStripMenuItem;
    }
}

