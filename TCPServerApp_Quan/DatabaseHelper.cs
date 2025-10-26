using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;

namespace TcpServerApp
{
    public static class DatabaseHelper
    {
        // 🔹 Chuỗi kết nối SQL Server của bạn
        private static string connectionString =
            @"Data Source=DESKTOP-MENQFLI\MSSQLSERVER_1;Initial Catalog=MyDatabase;Integrated Security=True";

       
        public static void InitializeDatabase()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string createTableQuery = @"
                    IF OBJECT_ID('[User]', 'U') IS NULL
                    BEGIN
                        CREATE TABLE [User] (
                            UserId INT IDENTITY(1,1) PRIMARY KEY,
                            Username NVARCHAR(100) NOT NULL UNIQUE,
                            [Password] NVARCHAR(100) NOT NULL,
                            Email NVARCHAR(100)
                        );
                    END";

                    using (SqlCommand cmd = new SqlCommand(createTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("✅ Kiểm tra bảng [User] hoàn tất (tạo mới nếu chưa có).");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khi khởi tạo bảng [User]: " + ex.Message);
            }
        }

        // ===============================================
        // 🧍 2. ĐĂNG KÝ NGƯỜI DÙNG MỚI
        // ===============================================
        public static User? RegisterUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra trùng username trước
                    string checkQuery = "SELECT COUNT(*) FROM [User] WHERE Username = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", user.Username);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            Console.WriteLine("⚠️ Username đã tồn tại: " + user.Username);
                            return null;
                        }
                    }

                    // Mã hóa mật khẩu bằng SHA-256
                    string hashedPassword = ComputeSha256Hash(user.Password);

                    // Thêm người dùng mới
                    string insertQuery = @"
                        INSERT INTO [User] (Username, [Password], Email)
                        VALUES (@Username, @Password, @Email);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Email", user.Email ?? (object)DBNull.Value);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            user.UserId = Convert.ToInt32(result);
                            Console.WriteLine($"✅ Đăng ký thành công: {user.Username}");
                            return user;
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Lỗi không xác định khi đăng ký user.");
                            return null;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("❌ Lỗi SQL khi đăng ký: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khác khi đăng ký: " + ex.Message);
                return null;
            }
        }

        
        public static User? AuthenticateUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Mã hóa mật khẩu nhập vào
                    string hashedPassword = ComputeSha256Hash(password);

                    string query = @"
                        SELECT UserId, Username, Email
                        FROM [User]
                        WHERE Username = @Username AND [Password] = @Password;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User user = new User
                                {
                                    UserId = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Email = reader.IsDBNull(2) ? "" : reader.GetString(2)
                                };
                                Console.WriteLine($"✅ Đăng nhập thành công: {username}");
                                return user;
                            }
                            else
                            {
                                Console.WriteLine($"❌ Sai tài khoản hoặc mật khẩu: {username}");
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khi đăng nhập: " + ex.Message);
                return null;
            }
        }

      
        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}
