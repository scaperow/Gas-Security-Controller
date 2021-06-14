namespace GSC
{
    partial class Test
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
            this.TextMessage = new System.Windows.Forms.TextBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.TextSession = new System.Windows.Forms.TextBox();
            this.TextPort = new System.Windows.Forms.TextBox();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextMessage
            // 
            this.TextMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TextMessage.Location = new System.Drawing.Point(12, 12);
            this.TextMessage.Name = "TextMessage";
            this.TextMessage.Size = new System.Drawing.Size(268, 21);
            this.TextMessage.TabIndex = 0;
            this.TextMessage.Text = "Message";
            this.TextMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextMessage_KeyDown);
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(205, 39);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(75, 23);
            this.ButtonSend.TabIndex = 1;
            this.ButtonSend.Text = "Send";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // TextSession
            // 
            this.TextSession.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TextSession.Location = new System.Drawing.Point(12, 68);
            this.TextSession.Multiline = true;
            this.TextSession.Name = "TextSession";
            this.TextSession.Size = new System.Drawing.Size(268, 186);
            this.TextSession.TabIndex = 2;
            this.TextSession.Text = "Session";
            // 
            // TextPort
            // 
            this.TextPort.Location = new System.Drawing.Point(13, 39);
            this.TextPort.Name = "TextPort";
            this.TextPort.Size = new System.Drawing.Size(100, 21);
            this.TextPort.TabIndex = 3;
            this.TextPort.Text = "Port";
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(124, 39);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpen.TabIndex = 4;
            this.ButtonOpen.Text = "Open";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.TextPort);
            this.Controls.Add(this.TextSession);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.TextMessage);
            this.Name = "Test";
            this.Text = "测试";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextMessage;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.TextBox TextSession;
        private System.Windows.Forms.TextBox TextPort;
        private System.Windows.Forms.Button ButtonOpen;
    }
}