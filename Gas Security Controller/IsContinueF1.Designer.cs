namespace GSC
{
    partial class IsContinueF1
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
            this.LabelMessage = new System.Windows.Forms.Label();
            this.ButtoOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelMessage
            // 
            this.LabelMessage.AutoSize = true;
            this.LabelMessage.Font = new System.Drawing.Font("宋体", 20F);
            this.LabelMessage.Location = new System.Drawing.Point(12, 18);
            this.LabelMessage.Name = "LabelMessage";
            this.LabelMessage.Size = new System.Drawing.Size(472, 27);
            this.LabelMessage.TabIndex = 0;
            this.LabelMessage.Text = "当前操作会导致断电、断油,是否继续?";
            // 
            // ButtoOK
            // 
            this.ButtoOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtoOK.Font = new System.Drawing.Font("宋体", 20F);
            this.ButtoOK.Location = new System.Drawing.Point(17, 83);
            this.ButtoOK.Name = "ButtoOK";
            this.ButtoOK.Size = new System.Drawing.Size(371, 79);
            this.ButtoOK.TabIndex = 1;
            this.ButtoOK.Text = "继续关闭";
            this.ButtoOK.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Font = new System.Drawing.Font("宋体", 20F);
            this.ButtonCancel.Location = new System.Drawing.Point(409, 83);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 79);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // IsContinueF1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 188);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtoOK);
            this.Controls.Add(this.LabelMessage);
            this.Name = "IsContinueF1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "警告";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelMessage;
        private System.Windows.Forms.Button ButtoOK;
        private System.Windows.Forms.Button ButtonCancel;
    }
}