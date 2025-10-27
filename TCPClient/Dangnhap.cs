using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace TCPClient
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
            try
            {
                this.BackgroundImage = Image.FromFile("Resources/ba32008d4177b9868755336f5e4490f7.jpg");
            }
            catch (Exception) { }
            this.BackgroundImageLayout = ImageLayout.Stretch;
            LB_Username.BackColor = Color.Transparent;
            LB_MK.BackColor = Color.Transparent;
            LB_LinkForget.BackColor = Color.Transparent;
            LB_Quen.BackColor = Color.Transparent;
            Link_DK.BackColor = Color.Transparent;
            TB_MK.UseSystemPasswordChar = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangky dangky = new Dangky();
            dangky.Show();
            this.Hide();
        }

        private void LB_LinkForget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Quenmatkhau quenmatkhau = new Quenmatkhau();
            quenmatkhau.Show();
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private void BT_Dangnhap_Click(object sender, EventArgs e)
        {
            string username = TB_Username.Text.Trim();
            string password = TB_MK.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Mật khẩu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string hashedPassword = HashPassword(password);
            try
            {
                string request = $"LOGIN|{username}|{hashedPassword}";
                string response = NetworkClient.SendRequest(request);

                if (response.StartsWith("LOGIN_SUCCESS|"))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string[] userData = response.Split('|');

                    // VV THÊM LOGIC LƯU TOKEN VV
                    // Server sẽ gửi: LOGIN_SUCCESS|data...|token
                    // userData[0] là "LOGIN_SUCCESS"
                    // userData[1-7] là dữ liệu user
                    // userData[8] (phần tử cuối) sẽ là token
                    if (userData.Length > 8)
                    {
                        NetworkClient.CurrentToken = userData[userData.Length - 1];
                        // Bạn có thể Ghi Log token ra đây để kiểm tra
                        // Console.WriteLine($"Token da luu: {NetworkClient.CurrentToken}");
                    }
                    // ^^ KẾT THÚC THÊM ^^

                    ThongTinNguoiDung home = new ThongTinNguoiDung(userData);
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai username hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
