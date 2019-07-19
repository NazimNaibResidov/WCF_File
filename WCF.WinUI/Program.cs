using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF.Helpers;

namespace WCF.WinUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Tool.ClassCenerateDTO();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
