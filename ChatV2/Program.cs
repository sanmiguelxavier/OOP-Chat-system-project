using System;
using System.Windows.Forms;

namespace ChatV2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RegisterPage()); // Open RegisterPage first (with button to go to login)
        }
    }
}
