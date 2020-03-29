using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ScreenColorShot
{
    public partial class BatchFeatureSetForm : Form
    {
        public BatchFeatureSetForm()
        {
            InitializeComponent();
        }

        private void BatchFeatureSetForm_Load(object sender, EventArgs e)
        {
            this.textBoxFile.Text = DefaultFile;
            this.textBoxTotalTimes.Text = $@"{1000 * 60}";

            this.textBoxPreTimes.Text = $@"{1000 / 10 }";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TimerFeatureCollector.IsRun) return;

            try
            {
                TimerFeatureCollector.Rect = Rects;
                var t = TotalTimes;
                var p = PreTimes;
                Task.Run(() => { TimerFeatureCollector.StartCollect(t, p); });
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public int TotalTimes
        {
            get
            {
                if (int.TryParse(this.textBoxTotalTimes.Text, out var time))
                {
                    return time;
                }

                throw new Exception("时间格式不对");
            }
        }

        public int PreTimes
        {
            get
            {
                if (int.TryParse(this.textBoxPreTimes.Text, out var time))
                {
                    return time;
                }

                throw new Exception("时间格式不对");
            }
        }

        public List<Rectangle> Rects
        {
            get
            {
                if (this.textBoxFile.Text ==DefaultFile && !File.Exists(DefaultFile))
                {
                    var rect = new List<Rectangle>()
                    {
                        new Rectangle(100,100,20,20),
                        new Rectangle(200,300,20,20)
                    };
                    File.WriteAllText(DefaultFile,JsonConvert.SerializeObject(rect));
                    return rect;
                }

                if (File.Exists(this.textBoxFile.Text))
                {
                    return JsonConvert.DeserializeObject<List<Rectangle>>(File.ReadAllText(this.textBoxFile.Text));
                }
                throw new Exception("特征区域文件不存在");
            }
        }

        public string DefaultFile = "rect.json";
    }
}
