namespace GSC
{
    partial class NotifyBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyBox));
            this.TimerFlush = new System.Windows.Forms.Timer(this.components);
            this.Images = new System.Windows.Forms.ImageList(this.components);
            this.PicutreBoxMain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicutreBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerFlush
            // 
            this.TimerFlush.Enabled = true;
            this.TimerFlush.Interval = 500;
            this.TimerFlush.Tick += new System.EventHandler(this.TimerFlush_Tick);
            // 
            // Images
            // 
            this.Images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Images.ImageStream")));
            this.Images.TransparentColor = System.Drawing.Color.Transparent;
            this.Images.Images.SetKeyName(0, "Gasoline");
            this.Images.Images.SetKeyName(1, "Diesel");
            this.Images.Images.SetKeyName(2, "GasTip");
            // 
            // PicutreBoxMain
            // 
            this.PicutreBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicutreBoxMain.Location = new System.Drawing.Point(0, 0);
            this.PicutreBoxMain.Name = "PicutreBoxMain";
            this.PicutreBoxMain.Size = new System.Drawing.Size(200, 200);
            this.PicutreBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicutreBoxMain.TabIndex = 0;
            this.PicutreBoxMain.TabStop = false;
            // 
            // NotifyBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.Controls.Add(this.PicutreBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotifyBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NotifyBox";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.PictureNotifyBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicutreBoxMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerFlush;
        private System.Windows.Forms.PictureBox PicutreBoxMain;
        private System.Windows.Forms.ImageList Images;
    }
}