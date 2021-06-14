namespace GSC
{
    partial class UI
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.NotifyMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuNotifyMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextMessage = new System.Windows.Forms.TextBox();
            this.StripMain = new System.Windows.Forms.StatusStrip();
            this.LabelStartTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeSelfCheck = new System.Windows.Forms.Timer(this.components);
            this.MenuNotifyMain.SuspendLayout();
            this.StripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyMain
            // 
            this.NotifyMain.BalloonTipTitle = "油站安防控制器";
            this.NotifyMain.ContextMenuStrip = this.MenuNotifyMain;
            this.NotifyMain.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyMain.Icon")));
            this.NotifyMain.Text = "油站安防控制器";
            this.NotifyMain.Visible = true;
            this.NotifyMain.DoubleClick += new System.EventHandler(this.NotifyMain_DoubleClick);
            // 
            // MenuNotifyMain
            // 
            this.MenuNotifyMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.MenuNotifyMain.Name = "MenuNotifyMain";
            this.MenuNotifyMain.Size = new System.Drawing.Size(95, 48);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.显示ToolStripMenuItem.Text = "打开";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // TextMessage
            // 
            this.TextMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextMessage.Enabled = false;
            this.TextMessage.Font = new System.Drawing.Font("宋体", 30F);
            this.TextMessage.Location = new System.Drawing.Point(0, 118);
            this.TextMessage.Name = "TextMessage";
            this.TextMessage.ReadOnly = true;
            this.TextMessage.Size = new System.Drawing.Size(366, 46);
            this.TextMessage.TabIndex = 1;
            this.TextMessage.Text = "请输入信息";
            this.TextMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StripMain
            // 
            this.StripMain.Location = new System.Drawing.Point(0, 304);
            this.StripMain.Name = "StripMain";
            this.StripMain.Size = new System.Drawing.Size(366, 22);
            this.StripMain.TabIndex = 2;
            this.StripMain.Text = "statusStrip1";
            // 
            // LabelStartTime
            // 
            this.LabelStartTime.Name = "LabelStartTime";
            this.LabelStartTime.Size = new System.Drawing.Size(56, 17);
            this.LabelStartTime.Text = "启动时间";
            // 
            // TimeSelfCheck
            // 
            this.TimeSelfCheck.Interval = 600000;
            this.TimeSelfCheck.Tick += new System.EventHandler(this.TimeSelfCheck_Tick);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 326);
            this.Controls.Add(this.StripMain);
            this.Controls.Add(this.TextMessage);
            this.KeyPreview = true;
            this.Name = "UI";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "油站安防控制器";
            this.Activated += new System.EventHandler(this.UI_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_FormClosing);
            this.Load += new System.EventHandler(this.UI_Load);
            this.Resize += new System.EventHandler(this.UI_Resize);
            this.MenuNotifyMain.ResumeLayout(false);
            this.StripMain.ResumeLayout(false);
            this.StripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyMain;
        private System.Windows.Forms.ContextMenuStrip MenuNotifyMain;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.TextBox TextMessage;
        private System.Windows.Forms.StatusStrip StripMain;
        private System.Windows.Forms.ToolStripStatusLabel LabelStartTime;
        private System.Windows.Forms.Timer TimeSelfCheck;
    }
}

