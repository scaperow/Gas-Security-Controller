using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Configuration;
using System.Media;
using System.IO;

namespace GSC
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    if (ConfigurationManager.AppSettings["Mode"] == "Debug")
                    {
                        Application.Run(new Test());
                    }
                    else
                    {
                        Application.Run(new UI());
                    }
                }
                else
                {
                    MessageBox.Show("应用程序已经在运行中。",
                        "GSC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
