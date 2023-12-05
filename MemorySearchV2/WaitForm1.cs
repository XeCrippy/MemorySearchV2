using DevExpress.XtraWaitForm;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MemorySearchV2
{
    public partial class WaitForm1 : WaitForm
    {
        Stopwatch stopwatch = new Stopwatch();

        public WaitForm1()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            int hours = (int)(elapsedMilliseconds / (1000 * 60 * 60));
            int minutes = (int)((elapsedMilliseconds % (1000 * 60 * 60)) / (1000 * 60));
            int seconds = (int)((elapsedMilliseconds % (1000 * 60)) / 1000);
            int milliseconds = (int)(elapsedMilliseconds % 1000);

            string elapsedTime = $"{hours:D2}:{minutes:D2}:{seconds:D2}:{milliseconds:D3}";
            progressPanel1.Description = elapsedTime ;
        }

        private void WaitForm1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            stopwatch.Start();
        }

        private void WaitForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            stopwatch.Stop();
        }
    }
}