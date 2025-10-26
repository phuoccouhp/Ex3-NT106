using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
namespace BTVN1_Nhom6_NT106.Q12
{


    public partial class Dangky : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
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
        public Dangky()
        {

            InitializeComponent();
            this.BackgroundImage = Image.FromFile("Resources/ba32008d4177b9868755336f5e4490f7.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            LB_Username.BackColor = Color.Transparent;
            LB_CoTK.BackColor = Color.Transparent;
            LB_DC.BackColor = Color.Transparent;
            LB_Email.BackColor = Color.Transparent;
            LB_GT.BackColor = Color.Transparent;
            LB_Hoten.BackColor = Color.Transparent;
            LB_Link.BackColor = Color.Transparent;
            LB_NS.BackColor = Color.Transparent;
            LB_Pass.BackColor = Color.Transparent;
            LB_Repass.BackColor = Color.Transparent;
            LB_SDT.BackColor = Color.Transparent;
           
            this.BT_Dangky.CausesValidation = false;
            SetCueBanner(TB_Email, "abc@gmail.com");
            TB_SDT.Visible = false;
            TB_NS.Visible = false;
            TB_GT.Visible = false;
            TB_DC.Visible = false;
            LB_SDT.Visible = false;
            LB_NS.Visible = false;
            LB_GT.Visible = false;
            LB_DC.Visible = false;
            TB_Pass.UseSystemPasswordChar = true;
            TB_Repass.UseSystemPasswordChar = true;

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            bool isVisible = TB_SDT.Visible;

            TB_SDT.Visible = !isVisible;
            TB_NS.Visible = !isVisible;
            TB_GT.Visible = !isVisible;
            TB_DC.Visible = !isVisible;

            LB_SDT.Visible = !isVisible;
            LB_NS.Visible = !isVisible;
            LB_GT.Visible = !isVisible;
            LB_DC.Visible = !isVisible;
        }
        private void LuuNguoiDungVaoSQL(string username, string email, string hoten, string password,
                                          string sdt, string ngaysinh, string gioitinh, string diachi)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_TaiKhoan;Integrated Security=True;";
            string hashedPassword = HashPassword(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO NguoiDung 
                                (Username, Email, HoTen, PasswordHash, SoDienThoai, NgaySinh, GioiTinh, DiaChi)
                                 VALUES 
                                (@Username, @Email, @HoTen, @PasswordHash, @SoDienThoai, @NgaySinh, @GioiTinh, @DiaChi)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@HoTen", string.IsNullOrEmpty(hoten) ? (object)DBNull.Value : hoten);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrEmpty(sdt) ? (object)DBNull.Value : sdt);
                    if (DateTime.TryParse(ngaysinh, out DateTime parsedDate))
                        cmd.Parameters.AddWithValue("@NgaySinh", parsedDate);
                    else
                        cmd.Parameters.AddWithValue("@NgaySinh", DBNull.Value);

                    cmd.Parameters.AddWithValue("@GioiTinh", string.IsNullOrEmpty(gioitinh) ? (object)DBNull.Value : gioitinh);
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(diachi) ? (object)DBNull.Value : diachi);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void BT_Dangky_Click(object sender, EventArgs e)
        {
            string username = TB_Username.Text.Trim();
            string email = TB_Email.Text.Trim();
            string hoten = TB_Hoten.Text.Trim();
            string password = TB_Pass.Text;
            string repassword = TB_Repass.Text;
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Không được để username trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(email) || !email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Email phải kết thúc bằng @gmail.com!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(hoten))
            {
                MessageBox.Show("Không được để họ tên trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!password.Any(char.IsUpper))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 1 chữ hoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!password.Any(char.IsDigit))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 1 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != repassword)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sdt = TB_SDT.Visible ? TB_SDT.Text.Trim() : "";
            string ngaysinh = TB_NS.Visible ? TB_NS.Text.Trim() : "";
            string gioitinh = TB_GT.Visible ? TB_GT.Text.Trim() : "";
            string diachi = TB_DC.Visible ? TB_DC.Text.Trim() : "";
            try
            {
                LuuNguoiDungVaoSQL(username, email, hoten, password, sdt, ngaysinh, gioitinh, diachi);
                MessageBox.Show("Đăng ký thành công và đã lưu vào cơ sở dữ liệu!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: "+ ex.Message, "Lỗi SQL",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetCueBanner(TextBox box, string cue)
        {
            SendMessage(box.Handle, EM_SETCUEBANNER, (IntPtr)0, cue);
        }

       
        public bool checkmk(string mk)
        {
            if (mk == null) return false;


            return true;
        }
       

        private void LB_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangnhap dangnhap= new Dangnhap();
            dangnhap.Show();
            this.Close();
        }
    }
}
