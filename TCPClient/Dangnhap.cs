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
using System.Text;
namespace BTVN1_Nhom6_NT106.Q12
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
            string username = TB_Username.Text.Trim();
            string password = TB_MK.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Mật khẩu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = HashPassword(password);
            string connectionString = "Data Source=.;Initial Catalog=QL_TaiKhoan;Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM NguoiDung WHERE (Username = @Input OR Email=@Input) AND PasswordHash = @PasswordHash";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Input", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ThongTinNguoiDung home = new ThongTinNguoiDung(username);
                            home.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Sai username hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
