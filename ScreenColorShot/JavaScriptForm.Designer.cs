namespace ScreenColorShot
{
    partial class JavaScriptForm
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
            if (disposing && (components != null))
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxJs = new System.Windows.Forms.TextBox();
            this.buttonrun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxJs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonrun);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 542;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBoxJs
            // 
            this.textBoxJs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxJs.Location = new System.Drawing.Point(0, 0);
            this.textBoxJs.Multiline = true;
            this.textBoxJs.Name = "textBoxJs";
            this.textBoxJs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxJs.Size = new System.Drawing.Size(542, 450);
            this.textBoxJs.TabIndex = 0;
            // 
            // buttonrun
            // 
            this.buttonrun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonrun.Location = new System.Drawing.Point(0, 428);
            this.buttonrun.Name = "buttonrun";
            this.buttonrun.Size = new System.Drawing.Size(254, 22);
            this.buttonrun.TabIndex = 0;
            this.buttonrun.Text = "执行";
            this.buttonrun.UseVisualStyleBackColor = true;
            this.buttonrun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // JavaScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "JavaScriptForm";
            this.Text = "JavaScriptForm";
            this.Load += new System.EventHandler(this.JavaScriptForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxJs;
        private System.Windows.Forms.Button buttonrun;
    }
}