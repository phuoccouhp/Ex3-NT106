using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BTVN1_Nhom6_NT106.Q12
{
    public partial class MatKhauMoi : Form
    {
        public MatKhauMoi()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("Resources/ba32008d4177b9868755336f5e4490f7.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.StartPosition = FormStartPosition.CenterScreen;
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                    c.BackColor = Color.Transparent;
            }

            TB_MKM.UseSystemPasswordChar = true;
            TB_MK.UseSystemPasswordChar = true;
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

        private void BT_Xacthuc_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = TB_User.Text.Trim();
            string newPassword = TB_MKM.Text;
            string confirmPassword = TB_MK.Text;
            if (string.IsNullOrWhiteSpace(usernameOrEmail) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPassword.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!newPassword.Any(char.IsUpper))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 1 chữ hoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!newPassword.Any(char.IsDigit))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 1 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!newPassword.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedNew = HashPassword(newPassword);
            string connectionString = "Data Source=.;Initial Catalog=QL_TaiKhoan;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string queryCheck = "SELECT PasswordHash FROM NguoiDung WHERE Username = @Input OR Email = @Input";
                using (SqlCommand cmd = new SqlCommand(queryCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@Input", usernameOrEmail);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy tài khoản này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string oldHash = result.ToString();
                    if (oldHash == hashedNew)
                    {
                        MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string queryUpdate = "UPDATE NguoiDung SET PasswordHash = @NewPass WHERE Username = @Input OR Email = @Input";
                    using (SqlCommand updateCmd = new SqlCommand(queryUpdate, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Input", usernameOrEmail);
                        updateCmd.Parameters.AddWithValue("@NewPass", hashedNew);

                        int rows = updateCmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            Dangnhap dangnhap = new Dangnhap();
                            dangnhap.Show();
                        }
                        else
                        {
                            MessageBox.Show("Không thể đổi mật khẩu. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
