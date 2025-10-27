using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System;

namespace TCPClient
{
    public partial class ThongTinNguoiDung : Form
    {


        // Constructor cũ: public ThongTinNguoiDung(string usernameOrEmail)
        // Constructor MỚI:
        public ThongTinNguoiDung(string[] userData)
        {
            InitializeComponent();

            // Thiết lập giao diện (giữ nguyên)
            this.BackgroundImage = Image.FromFile("Resources/ba32008d4177b9868755336f5e4490f7.jpg");
            // ... (giữ nguyên code set màu trong suốt) ...

            // Load dữ liệu từ mảng userData (đã được server gửi về)
            // "LOGIN_SUCCESS|Username|Email|HoTen|SDT|NgaySinh|GioiTinh|DiaChi"
            //      userData[0] |  [1]   | [2] |  [3]  | [4] |   [5]    |   [6]  |  [7]
            try
            {
                lblXinChao.Text = $"Xin chào, {userData[3]}!"; // HoTen
                txtTenDangNhap.Text = userData[1]; // Username
                txtEmail.Text = userData[2]; // Email
                txtMatKhau.Text = "**********"; // KHÔNG hiển thị mật khẩu
                txtSDT.Text = userData[4]; // SDT
                txtGioiTinh.Text = userData[6]; // GioiTinh
                txtNgaySinh.Text = userData[5]; // NgaySinh
                txtDiaChi.Text = userData[7]; // DiaChi
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Dữ liệu nhận từ server không đầy đủ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void btnShowPass_Click_1(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !txtMatKhau.UseSystemPasswordChar;

        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Dangnhap dangnhap = new Dangnhap();
            dangnhap.Show();
        }
    }
}
