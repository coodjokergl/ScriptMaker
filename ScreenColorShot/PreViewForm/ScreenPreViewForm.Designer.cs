namespace ScreenColorShot.PreViewForm
{
    partial class ScreenPreViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClose = new System.Windows.Forms.Button();
            this.pictureBoxCut = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCut)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(0, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "退出";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Visible = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // pictureBoxCut
            // 
            this.pictureBoxCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCut.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCut.Name = "pictureBoxCut";
            this.pictureBoxCut.Size = new System.Drawing.Size(514, 381);
            this.pictureBoxCut.TabIndex = 1;
            this.pictureBoxCut.TabStop = false;
            this.pictureBoxCut.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCut_Paint);
            this.pictureBoxCut.DoubleClick += new System.EventHandler(this.pictureBoxCut_DoubleClick);
            this.pictureBoxCut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCut_MouseDown);
            this.pictureBoxCut.MouseEnter += new System.EventHandler(this.pictureBoxCut_MouseEnter);
            this.pictureBoxCut.MouseLeave += new System.EventHandler(this.pictureBoxCut_MouseLeave);
            this.pictureBoxCut.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCut_MouseMove);
            this.pictureBoxCut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCut_MouseUp);
            // 
            // ScreenPreViewForm
            // 
            this.AccessibleDescription = "全屏截图预览";
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(514, 381);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxCut);
            this.Controls.Add(this.buttonClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenPreViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "截图预览";
            this.Load += new System.EventHandler(this.ScreenPreViewForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScreenPreViewForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBoxCut;
    }
}