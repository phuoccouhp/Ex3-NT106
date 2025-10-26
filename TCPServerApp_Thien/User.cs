using System;

namespace TcpServerApp
{
    // 🔹 Lớp User ánh xạ trực tiếp với bảng [User] trong SQL Server
    public class User
    {
        // ID tự tăng (Primary Key)
        public int UserId { get; set; }

        // Tên đăng nhập
        public string Username { get; set; }

        // Mật khẩu (được mã hóa SHA-256 trước khi lưu)
        public string Password { get; set; }

        // Địa chỉ email
        public string Email { get; set; }

        // 🧱 Constructor mặc định
        public User() { }

        // 🧱 Constructor tiện lợi để khởi tạo nhanh
        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        // 🧩 Ghi đè ToString() – phục vụ debug/log
        public override string ToString()
        {
            return $"UserId: {UserId}, Username: {Username}, Email: {Email}";
        }
    }
}
