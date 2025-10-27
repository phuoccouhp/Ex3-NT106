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
        public ThongTinNguoiDung(string[] userData)
        {
            InitializeComponent();
          
            try
            {
                lblXinChao.Text = $"Xin chào, {userData[3]}!"; 
                txtTenDangNhap.Text = userData[1]; 
                txtEmail.Text = userData[2]; 
                txtMatKhau.Text = "**********"; 
                txtSDT.Text = userData[4]; 
                txtGioiTinh.Text = userData[6]; 
                txtNgaySinh.Text = userData[5]; 
                txtDiaChi.Text = userData[7]; 
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
