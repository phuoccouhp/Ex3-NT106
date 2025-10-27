using System;
using System.Windows.Forms;

namespace TCPServer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Chạy ServerForm thay vì code Console cũ
            Application.Run(new ServerForm());
        }
    }
}