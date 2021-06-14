using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace GSC
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        SerialPort Port;

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void Send()
        {

            Byte[] buffer = HexCode.HexStringToByteArray(this.TextMessage.Text);

            Port.Write(buffer, 0, buffer.Length);



        }

        void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.TextSession.AppendText(Environment.NewLine + this.TextMessage.Text + Port.ReadExisting());
                }));
            }
            catch
            {
            }

        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void TextMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send();
            }
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Port = new SerialPort(this.TextPort.Text, 9600, Parity.None, 8, StopBits.One);

                Port.Open();

                this.ButtonOpen.Enabled = false;

                Port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
