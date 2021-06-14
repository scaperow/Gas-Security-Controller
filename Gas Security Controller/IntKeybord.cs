using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GSC
{
    public partial class IntKeybord : Form
    {
        public IntKeybord()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TextInput.Text)) { }
            else
            {
                this.TextInput.Text = this.TextInput.Text.Remove(this.TextInput.Text.Length - 1, 1);
            }
        }


        public string InputKeyword
        {
            private set;
            get;
        }


        private void TextInput_TextChanged(object sender, EventArgs e)
        {
            this.InputKeyword = this.TextInput.Text;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            this.TextInput.AppendText((sender as Button).Text);
        }
    }
}
