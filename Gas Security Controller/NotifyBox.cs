using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GSC
{
    public partial class NotifyBox : Form
    {
        public NotifyBox()
        {
            this.InitializeComponent();
        }

        public PictureNotifyFlag NotifyMode = PictureNotifyFlag.Diesel;

        private bool Showed = false;

        public void FlowClose()
        {
            this.TimerFlush.Enabled = base.Visible = false;
            this.FlowStatue = FlowStatueFlag.Close;
        }

        public void FlowShow()
        {
            if (this.Showed)
            {
                base.Visible = this.TimerFlush.Enabled = true;
            }
            else
            {
                base.Show();
                this.TimerFlush.Enabled = true;
            }
            this.PicutreBoxMain.Image = this.Images.Images[this.NotifyMode.ToString()];
            this.FlowStatue = FlowStatueFlag.Show;
        }

        public void FlowShow(PictureNotifyFlag flag)
        {
            this.NotifyMode = flag;
            this.FlowShow();
        }

        public void MemoryStatueAndClose()
        {
            this.MemoryStatue = this.FlowStatue;
            this.FlowClose();
        }

        private void PictureNotifyBox_Load(object sender, EventArgs e)
        {
            this.Showed = true;
        }

        public void RestoreStatue()
        {
            if (this.MemoryStatue == FlowStatueFlag.Show)
            {
                this.FlowShow();
            }
            this.MemoryStatue = FlowStatueFlag.None;
        }

        private void TimerFlush_Tick(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }

        public FlowStatueFlag FlowStatue { get; private set; }

        public FlowStatueFlag MemoryStatue { get; private set; }
    }
}
