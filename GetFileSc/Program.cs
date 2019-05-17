using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetFileSc.Forms;
using Microsoft.VisualStudio.SourceSafe.Interop;

namespace GetFileSc
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Properties.Settings.Default.ConfigName = "Config_" + Environment.UserDomainName + "_" + Environment.UserName + ".ini";
            Application.Run(new MainForm());
        }
    }
}
