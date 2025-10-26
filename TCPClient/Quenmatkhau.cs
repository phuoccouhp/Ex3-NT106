using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
namespace BTVN1_Nhom6_NT106.Q12
{
    public partial class Quenmatkhau : Form
    {
        int otp;
        public Quenmatkhau()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("Resources/ba32008d4177b9868755336f5e4490f7.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            LB_Username.BackColor = Color.Transparent;
            LB_OTP.BackColor = Color.Transparent;

        }
        bool IsValidGmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private void BT_Dangnhap_Click(object sender, EventArgs e)
        {
            if (otp == long.Parse(TB_OTP.Text))
            {
                MessageBox.Show("Xác thực OTP thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MatKhauMoi matKhauMoi = new MatKhauMoi();
                matKhauMoi.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("OTP nhập không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = TB_Username.Text.Trim();

            if (!IsValidGmail(email))
            {
                MessageBox.Show("Email phải hợp lệ và kết thúc bằng @gmail.com!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Random rand = new Random();
             otp = rand.Next(100000, 999999);
            
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("tengmailcuaban@gmail.com"); 
                mail.To.Add(TB_Username.Text);
                mail.Subject = "Mã OTP xác nhận của bạn";
                mail.Body = $"Mã OTP của bạn là: {otp}\nMã có hiệu lực trong 5 phút.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("taonekmay09112005@gmail.com", "npwl hkcy zshj knbx\r\n");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("Đã gửi OTP tới Gmail của bạn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Tag = otp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
