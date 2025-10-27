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
using System.Text;
namespace TCPClient
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
         InitializeComponent();
            this.BackgroundImage = Image.FromFile("Resources/ba32008d4177b9868755336f5e4490f7.jpg");
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
            string username = TB_Username.Text.Trim(); // Dùng username hoặc email
            string password = TB_MK.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Mật khẩu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash mật khẩu (bạn đã làm đúng)
            string hashedPassword = HashPassword(password); // Giữ nguyên hàm HashPassword

            // THAY THẾ code SQL bằng code Socket
            try
            {
                // 1. Tạo chuỗi yêu cầu
                string request = $"LOGIN|{username}|{hashedPassword}";

                // 2. Gửi yêu cầu và nhận phản hồi
                string response = NetworkClient.SendRequest(request);

                // 3. Xử lý phản hồi
                if (response.StartsWith("LOGIN_SUCCESS|"))
                {
                    // Nếu thành công, server sẽ trả về:
                    // "LOGIN_SUCCESS|Username|Email|HoTen|SDT|NgaySinh|GioiTinh|DiaChi"
                    MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tách dữ liệu server trả về
                    string[] userData = response.Split('|');

                    // Mở form thông tin và truyền dữ liệu qua
                    // (Chúng ta sẽ sửa hàm khởi tạo của ThongTinNguoiDung ở bước 5)
                    ThongTinNguoiDung home = new ThongTinNguoiDung(userData);
                    home.Show();
                    this.Hide();
                }
                else // (response == "LOGIN_FAIL" hoặc lỗi khác)
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
