using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Ports;
using System.Diagnostics;
using System.Configuration;
using System.Media;
using System.IO;

namespace GSC
{
    public partial class UI : Form
    {
        private SerialPort Port;
        private string Password = "123456";
        private string PortName = ConfigurationManager.AppSettings["PortName"];
        private Keys LastPress;
        private bool IsNoResponse;
        private NotifyBox PictureNotify = new NotifyBox();
        private bool IsKeyDown = false;
        private const int WM_HOTKEY = 0x0312;//如果m.Msg的值为0x0312那么表示用户按下了热键
        private bool FirstShowed;
        private ManualResetEvent SelftCheck1 = new ManualResetEvent(false);
        private ManualResetEvent SelftCheck2 = new ManualResetEvent(false);
        private ManualResetEvent SelftCheck3 = new ManualResetEvent(false);
        private ManualResetEvent SelftCheck4 = new ManualResetEvent(false);
        public UI()
        {
            InitializeComponent();
        }

        private void OnPressF1()
        {
            this.PictureNotify.MemoryStatueAndClose();

            try
            {
                IsContinueF1 confirm = new IsContinueF1();

                if (confirm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (SendCommand(Command.F1))
                    {
                        LastPress = Keys.F1;

                        MessageBox.Show("加油机、油阀已全部关闭。", "油站安防控制器", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        EventLog.WriteEntry("GSC", "加油机、油阀已全部关闭。");

                        this.PictureNotify.FlowClose();
                    }
                    else
                    {
                        this.PictureNotify.RestoreStatue();
                    }
                }
                else { this.PictureNotify.RestoreStatue(); }
            }
            catch { this.PictureNotify.RestoreStatue(); }
        }

        private void OnPressF2()
        {
            if (LastPress == Keys.F1)
            {
                if (ValidateAccount())
                {
                    OpenF2();
                }
                else { }
            }
            else
            {
                if (SendCommand(Command.F2))
                {
                    OpenF2();
                }
            }
        }

        private void OpenF2()
        {
            if (SendCommand(Command.F2))
            {
                LastPress = Keys.F2;

                MessageBox.Show("加油机正常供电, 汽、柴油油阀都已全部关闭。", "油站安防控制器", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.PictureNotify.FlowClose();
                try
                {
                    EventLog.WriteEntry("GSC", "汽、柴油油阀都已全部关闭。");
                }
                catch { }

            }
            else { }
        }

        private void OnPressF3()
        {
            if (ValidateAccount())
            {
                if (SendCommand(Command.F3))
                {

                    LastPress = Keys.F3;

                    MessageBox.Show("汽油阀已打开。", "油站安防控制器", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.PictureNotify.FlowShow(PictureNotifyFlag.Gasoline);
                    try
                    {
                        EventLog.WriteEntry("GSC", "汽油阀已打开。");
                    }
                    catch { }
                }
                else { }
            }
            else { }
        }

        private void OnPressF4()
        {
            if (ValidateAccount())
            {
                if (SendCommand(Command.F4))
                {
                    LastPress = Keys.F4;

                    MessageBox.Show("柴油阀已打开。", "油站安防控制器", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.PictureNotify.FlowShow(PictureNotifyFlag.Diesel);
                    try
                    {
                        EventLog.WriteEntry("GSC", "柴油阀已打开。");
                    }
                    catch { }
                }
                else { }
            }
            else { }
        }

        private bool SendCommand(string command)
        {
            lock (this)
            {
                int counter = 0;

                bool result = false;

                if (Port.IsOpen || TryOpen())
                {
                    byte[] buffer = HexCode.HexStringToByteArray(command);

                    IsNoResponse = true;

                    do
                    {
                        Port.Write(buffer, 0, buffer.Length);

                        Thread.Sleep(100);

                        if (++counter == 5)
                        {
                            MessageBox.Show("硬件设备出现异常,命令不能发送,请您检查。", "GSC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else { }


                    } while (IsNoResponse);

                    result = true;
                }
                else
                {
                    MessageBox.Show("抱歉,不能发送命令,程序可能出现错误,请重新运行。");
                }

                return result;
            }
        }

        private void InstancePort()
        {
            try
            {
                Port = new SerialPort(PortName, 9600, Parity.None, 8, StopBits.One);

                Port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                Port.ErrorReceived += new SerialErrorReceivedEventHandler(Port_ErrorReceived);
            }
            catch (Exception e)
            {
                try
                {
                    EventLog.WriteEntry("GSC", string.Format("在实例化{0}口时出现异常。{1}", PortName, e.Message));
                }
                catch { }

                throw e;
            }
        }

        void Port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

        }

        void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string code = Port.ReadExisting();

            string s = HexCode.ByteToHexString(code);
            string d = HexCode.ByteToHexString(code);

            switch (code)
            {
                case Command.F_1:
                case Command.S_1:
                case Command.Q_1:
                    if (SendCommand(Command.F1))
                    {
                        LastPress = Keys.F1;

                        PictureNotify.FlowShow(PictureNotifyFlag.Gas1);

                        EventLog.WriteEntry("GSC", "加油机、油阀已全部关闭。");
                    }
                    else { }
                    break;
                case Command.F_2:
                case Command.S_2:
                case Command.Q_2:
                    if (SendCommand(Command.F1))
                    {
                        LastPress = Keys.F1;

                        PictureNotify.FlowShow(PictureNotifyFlag.Gas2);

                        EventLog.WriteEntry("GSC", "加油机、油阀已全部关闭。");
                    }
                    else { }
                    break;
                case Command.F_3:
                case Command.S_3:
                case Command.Q_3:
                    if (SendCommand(Command.F1))
                    {
                        LastPress = Keys.F1;

                        PictureNotify.FlowShow(PictureNotifyFlag.Gas3);

                        EventLog.WriteEntry("GSC", "加油机、油阀已全部关闭。");
                    }
                    else { }
                    break;
                case Command.F_4:
                case Command.S_4:
                case Command.Q_4:
                    if (SendCommand(Command.F1))
                    {
                        LastPress = Keys.F1;

                        PictureNotify.FlowShow(PictureNotifyFlag.Gas4);

                        EventLog.WriteEntry("GSC", "加油机、油阀已全部关闭。");
                    }
                    else { }
                    break;

                case Command.Check1Response:
                    SelftCheck1.Set();
                    break;
                case Command.Check2Response:
                    SelftCheck2.Set();
                    break;
                case Command.Check3Response:
                    SelftCheck3.Set();
                    break;
                case Command.Check4Response:
                    SelftCheck4.Set();
                    break;
                default:
                    this.IsNoResponse = false;
                    return;
            }

            string media = "";

            switch (code)
            {
                case Command.S_1:
                    media = "1-1";
                    break;
                case Command.F_1:
                    media = "1-2";
                    break;
                case Command.Q_1:
                    media = "1-3";
                    break;
                case Command.S_2:
                    media = "2-1";
                    break;
                case Command.F_2:
                    media = "2-2";
                    break;
                case Command.Q_2:
                    media = "2-3";
                    break;
                case Command.S_3:
                    media = "3-1";
                    break;
                case Command.F_3:
                    media = "3-2";
                    break;
                case Command.Q_3:
                    media = "3-3";
                    break;
                case Command.S_4:
                    media = "4-1";
                    break;
                case Command.F_4:
                    media = "4-2";
                    break;
                case Command.Q_4:
                    media = "4-3";
                    break;

                default:
                    break;
            }

            if (string.IsNullOrEmpty(media)) { }
            else
            {
                Winmm.Play(string.Format("{0}{1}{2}{3}{4}", Application.StartupPath, Path.DirectorySeparatorChar, "Media", Path.DirectorySeparatorChar, media));
            }
        }

        private void TryClose()
        {
            int counter = 0;

            while (++counter < 5)
            {
                try
                {
                    Port.Close();

                    break;
                }
                catch (Exception e)
                {
                    try
                    {
                        EventLog.WriteEntry("GSC", string.Format("在关闭{0}口时出现异常。{1}", "COM4", e.Message));
                    }
                    catch { }

                    Thread.Sleep(1000);
                }
            }
        }

        private bool TryOpen()
        {
            bool result = false;
            int counter = 0;

            if (Port == null)
            {
                MessageBox.Show("系统发生致命错误,请尝试重新运行。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Exit();
            }
            else
            {
                while (++counter < 5)
                {
                    try
                    {
                        Port.Open();

                        result = true;

                        break;
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            EventLog.WriteEntry("GSC", string.Format("在打开{0}口时出现异常。{1}", PortName, e.Message));
                        }
                        catch { }

                        Thread.Sleep(1000);
                    }
                }
            }

            return result;
        }

        private void Exit()
        {
            this.NotifyMain.Visible = false;

            TryClose();

            Environment.Exit(0);
        }

        private void UI_Load(object sender, EventArgs e)
        {
            try
            {
                this.TextMessage.Text = "系统正在初始化";

                if (string.IsNullOrEmpty(PortName))
                {
                    MessageBox.Show("当前没有设置串口号,或者配置不正确,请在配置文件当中检查设置后再运行。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Application.Exit();
                }
                else
                {
                    //TryClose(); 
                }

                InstancePort();

                if (TryOpen()) { }
                else
                {
                    MessageBox.Show("不能打开串口,请尝试重新运行程序。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Exit();
                }

                this.LabelStartTime.Text = string.Format("启动时间 {0}", DateTime.Now.ToString());

                if (InstallHotKey()) { }
                else
                {
                    MessageBox.Show("不能正确注册系统热键,程序无法正常运行。");
                    Exit();
                }

                this.TextMessage.Text = "系统正在运行";
            }
            catch
            {
                MessageBox.Show("抱歉,系统不能初始化,请您重新运行再试。");
            }
        }

        private bool ValidateAccount()
        {
            this.PictureNotify.MemoryStatueAndClose();

            IntKeybord form = new IntKeybord();

            bool result = false;

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (form.InputKeyword == Password)
                {
                    result = true;
                }
                else
                {
                    MessageBox.Show("密码不正确,不能执行操作。");
                }
            }

            this.PictureNotify.RestoreStatue();

            return result;
        }

        private void UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();

            UnstallHotKey();
        }

        private void NotifyMain_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;

        }

        private void UI_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
            else { }
        }

        private void UI_KeyPress(Message m)
        {
            IntPtr id = m.WParam;

            string sid = id.ToString();

            switch (sid)
            {
                case "100":
                    OnPressF1();
                    break;
                case "200":
                    OnPressF2();
                    break;
                case "300":
                    OnPressF3();
                    break;
                case "400":
                    OnPressF4();
                    break;
                default:
                    LastPress = Keys.None;
                    break;
            }
        }

        //重写WndProc()方法，通过监视系统消息，来调用过程
        protected override void WndProc(ref Message m)//监视Windows消息
        {
            if (IsKeyDown) { }
            else
            {
                IsKeyDown = true;

                switch (m.Msg)
                {
                    case WM_HOTKEY:
                        UI_KeyPress(m);//按下热键时调用ProcessHotkey()函数
                        break;
                }

                IsKeyDown = false;
            }

            base.WndProc(ref m); //将系统消息传递自父类的WndProc
        }

        private bool InstallHotKey()
        {
            bool result = true;

            try
            {
                result = result && Win32.RegisterHotKey(Handle, 100, 0, Keys.F1);
                result = result && Win32.RegisterHotKey(Handle, 200, 0, Keys.F2);
                result = result && Win32.RegisterHotKey(Handle, 300, 0, Keys.F3);
                result = result && Win32.RegisterHotKey(Handle, 400, 0, Keys.F4);
            }
            catch (Exception e)
            {
                try
                {
                    EventLog.WriteEntry("GSC", string.Format("在注册系统热键时发生错误。{0}", e.Message));

                    result = false;
                }
                catch { }
            }

            return result;
        }

        private bool UnstallHotKey()
        {
            bool result = false;

            try
            {
                Win32.UnregisterHotKey(Handle, 100);
                Win32.UnregisterHotKey(Handle, 200);
                Win32.UnregisterHotKey(Handle, 300);
                Win32.UnregisterHotKey(Handle, 400);

                result = true;
            }
            catch { }

            return result;
        }

        private void UI_Activated(object sender, EventArgs e)
        {
            if (FirstShowed) { }
            else
            {
                this.WindowState = FormWindowState.Minimized;

                FirstShowed = true;
            }
        }

        private void TimeSelfCheck_Tick(object sender, EventArgs e)
        {
            SendCommand(Command.Check1);
            SelftCheck1.Reset();
            if (SelftCheck1.WaitOne(5000))
            {
            }
            else { MessageBox.Show("1号传感器自检失败,请检查。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            SendCommand(Command.Check2);
            SelftCheck1.Reset();
            if (SelftCheck2.WaitOne(5000))
            {
            }
            else { MessageBox.Show("2号传感器自检失败,请检查。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            SendCommand(Command.Check3);
            SelftCheck1.Reset();
            if (SelftCheck3.WaitOne(5000))
            {
            }
            else { MessageBox.Show("3号传感器自检失败,请检查。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            SendCommand(Command.Check4);
            SelftCheck1.Reset();
            if (SelftCheck4.WaitOne(5000))
            {
            }
            else { MessageBox.Show("4号传感器自检失败,请检查。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
