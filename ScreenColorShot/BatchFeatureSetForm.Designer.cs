namespace ScreenColorShot
{
    partial class BatchFeatureSetForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTotalTimes = new System.Windows.Forms.TextBox();
            this.textBoxPreTimes = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "采集总时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "采集频率(ms)";
            // 
            // textBoxTotalTimes
            // 
            this.textBoxTotalTimes.Location = new System.Drawing.Point(107, 25);
            this.textBoxTotalTimes.Name = "textBoxTotalTimes";
            this.textBoxTotalTimes.Size = new System.Drawing.Size(205, 21);
            this.textBoxTotalTimes.TabIndex = 2;
            // 
            // textBoxPreTimes
            // 
            this.textBoxPreTimes.Location = new System.Drawing.Point(109, 82);
            this.textBoxPreTimes.Name = "textBoxPreTimes";
            this.textBoxPreTimes.Size = new System.Drawing.Size(202, 21);
            this.textBoxPreTimes.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "启动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "待采集特征区域坐标";
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(171, 130);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(233, 21);
            this.textBoxFile.TabIndex = 6;
            // 
            // BatchFeatureSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 228);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPreTimes);
            this.Controls.Add(this.textBoxTotalTimes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BatchFeatureSetForm";
            this.Text = "BatchFeatureSetForm";
            this.Load += new System.EventHandler(this.BatchFeatureSetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTotalTimes;
        private System.Windows.Forms.TextBox textBoxPreTimes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFile;
    }
}