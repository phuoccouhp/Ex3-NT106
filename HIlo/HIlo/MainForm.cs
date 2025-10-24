using System;
using System.Windows.Forms;

namespace UserManagementClient
{
    public class MainForm : Form
    {
        private Button btnLogout;

        public MainForm()
        {
            this.Text = "Thông tin người dùng";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(300, 150);

            btnLogout = new Button()
            {
                Text = "Đăng xuất",
                Left = 90,
                Top = 40,
                Width = 120
            };

            btnLogout.Click += BtnLogout_Click;
            Controls.Add(btnLogout);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã đăng xuất.");
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}
