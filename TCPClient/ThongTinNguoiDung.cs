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
using System.Data.SqlClient;
using System.Data;

namespace BTVN1_Nhom6_NT106.Q12
{
    public partial class ThongTinNguoiDung : Form
    {
        private string connectionString =
            @"Data Source=.;Initial Catalog=QL_TaiKhoan;Integrated Security=True";

        private string currentUsername;

        public ThongTinNguoiDung(string usernameOrEmail)
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("Resources/ba32008d4177b9868755336f5e4490f7.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            LB_DC.BackColor = Color.Transparent;
            LB_Email.BackColor = Color.Transparent;
            LB_GT.BackColor = Color.Transparent;
            LB_MK.BackColor = Color.Transparent;
            LB_NS.BackColor = Color.Transparent;
            LB_SDT.BackColor = Color.Transparent;
            LB_Username.BackColor = Color.Transparent;
            lblXinChao.BackColor = Color.Transparent;

            currentUsername = usernameOrEmail;
        }

        private void ThongTinNguoiDung_Load(object sender, EventArgs e)
        {
            LoadUserInfo(currentUsername);
        }

        private void LoadUserInfo(string input)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NguoiDung WHERE Username = @Input OR Email = @Input";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Input", input);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblXinChao.Text = $"Xin chào, {reader["HoTen"]}!";
                    txtTenDangNhap.Text = reader["Username"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtMatKhau.Text = reader["PasswordHash"].ToString();
                    txtSDT.Text = reader["SoDienThoai"].ToString();
                    txtGioiTinh.Text = reader["GioiTinh"].ToString();
                    txtNgaySinh.Text = reader["NgaySinh"].ToString();
                    txtDiaChi.Text = reader["DiaChi"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin người dùng.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                reader.Close();
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
