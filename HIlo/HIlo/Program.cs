using System;
using System.Windows.Forms;

namespace UserManagementClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); // chạy từ form đăng nhập
        }
    }
}
