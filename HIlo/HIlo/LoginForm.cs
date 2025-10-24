using System;
using System.Windows.Forms;

namespace UserManagementClient
{
    public class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnGotoRegister;

        public LoginForm()
        {
            // Cấu hình form
            this.Text = "Đăng nhập";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(320, 160);

            // Tạo control
            Label lblUser = new Label() { Text = "Username", Left = 20, Top = 25, AutoSize = true };
            Label lblPass = new Label() { Text = "Password", Left = 20, Top = 60, AutoSize = true };
            txtUsername = new TextBox() { Left = 110, Top = 22, Width = 180 };
            txtPassword = new TextBox() { Left = 110, Top = 57, Width = 180, UseSystemPasswordChar = true };

            btnLogin = new Button() { Text = "Đăng nhập", Left = 110, Top = 95, Width = 90 };
            btnGotoRegister = new Button() { Text = "Đăng ký", Left = 210, Top = 95, Width = 80 };

            // Gắn sự kiện
            btnLogin.Click += BtnLogin_Click;
            btnGotoRegister.Click += BtnGotoRegister_Click;

            // Thêm control vào form
            this.Controls.Add(lblUser);
            this.Controls.Add(lblPass);
            this.Controls.Add(txtUsername);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnGotoRegister);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng nhập thành công!");
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }

        private void BtnGotoRegister_Click(object sender, EventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            reg.Show();
            this.Hide();
        }
    }
}
