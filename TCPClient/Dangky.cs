using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography;
using System.Text;
namespace TCPClient
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
       

        private void BT_Dangky_Click(object sender, EventArgs e)
        {
            // 1. Giữ nguyên toàn bộ code VALIDATION (kiểm tra trống, email, mật khẩu)
            string username = TB_Username.Text.Trim();
            string email = TB_Email.Text.Trim();
            string hoten = TB_Hoten.Text.Trim();
            string password = TB_Pass.Text;
            string repassword = TB_Repass.Text;

            if (string.IsNullOrWhiteSpace(username)) { /*... (giữ nguyên) ...*/ return; }
            if (string.IsNullOrWhiteSpace(email) || !email.EndsWith("@gmail.com")) { /*... (giữ nguyên) ...*/ return; }
            if (string.IsNullOrWhiteSpace(hoten)) { /*... (giữ nguyên) ...*/ return; }
            if (password.Length < 8) { /*... (giữ nguyên) ...*/ return; }
            // ... (giữ nguyên tất cả các 'if' kiểm tra mật khẩu) ...
            if (password != repassword) { /*... (giữ nguyên) ...*/ return; }

            string sdt = TB_SDT.Visible ? TB_SDT.Text.Trim() : "";
            string ngaysinh = TB_NS.Visible ? TB_NS.Text.Trim() : "";
            string gioitinh = TB_GT.Visible ? TB_GT.Text.Trim() : "";
            string diachi = TB_DC.Visible ? TB_DC.Text.Trim() : "";

            // 2. Hash mật khẩu (phần này bạn đã làm đúng)
            string hashedPassword = HashPassword(password); // Giữ nguyên hàm HashPassword

            // 3. THAY THẾ code SQL bằng code Socket
            try
            {
                // 3a. Tạo chuỗi yêu cầu (protocol)
                // Cú pháp: "COMMAND|param1|param2|param3..."
                string request = $"REGISTER|{username}|{email}|{hoten}|{hashedPassword}|{sdt}|{ngaysinh}|{gioitinh}|{diachi}";

                // 3b. Gửi yêu cầu và nhận phản hồi
                string response = NetworkClient.SendRequest(request);

                // 3c. Xử lý phản hồi
                if (response == "REGISTER_SUCCESS")
                {
                    MessageBox.Show("Đăng ký thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Có thể tự động đóng form này và mở form Đăng nhập
                    this.Close();
                    Dangnhap loginForm = new Dangnhap();
                    loginForm.Show();
                }
                else
                {
                    // Server sẽ trả về lý do lỗi, ví dụ: "REGISTER_FAIL|Username đã tồn tại"
                    // Ta chỉ cần hiển thị phần thông báo lỗi
                    string errorMessage = response.Split('|').Length > 1 ? response.Split('|')[1] : "Lỗi không xác định từ server";
                    MessageBox.Show(errorMessage, "Đăng ký thất bại",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi yêu cầu: " + ex.Message, "Lỗi Client",
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
