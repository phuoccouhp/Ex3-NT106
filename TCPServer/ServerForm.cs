using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms; // Thêm thư viện này

namespace TCPServer
{
    // Đổi tên class từ "Form1" thành "ServerForm"
    public partial class ServerForm : Form
    {
        private TcpListener listener;
        private Thread listenerThread;
        private const int PORT = 8080;
        private const string connectionString = "Data Source=.;Initial Catalog=QL_TaiKhoan;User ID=appuser;Password=StrongPass@123;";
        public ServerForm()
        {
            InitializeComponent();
            btnStop.Enabled = false; // Ban đầu không thể Stop
        }



        

        /// <summary>
        /// Hàm này chạy trên một luồng riêng để lắng nghe kết nối.
        /// </summary>
        private void StartListening()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, PORT);
                listener.Start();

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Log($"[+] Client moi ket noi tu: {client.Client.RemoteEndPoint}");

                    // Tạo một luồng riêng cho mỗi client
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.Start(client);
                }
            }
            catch (SocketException ex)
            {
                // Lỗi này xảy ra khi ta gọi listener.Stop() (ở btnStop_Click)
                Log($"Server da dung lang nghe: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log($"[LOI SERVER] {ex.Message}");
            }
        }

        /// <summary>
        /// Hàm này xử lý cho MỘT client (chạy trên luồng của client đó)
        /// </summary>
        private void HandleClient(object obj)
        {
            TcpClient tcpClient = (TcpClient)obj;
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[4096];
            int bytesRead;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Log($"[NHAN] {request}");

                    string response = ProcessRequest(request);

                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);
                    Log($"[GUI] {response}");
                }
            }
            catch (Exception ex)
            {
                Log($"[LOI CLIENT] {ex.Message}");
            }
            finally
            {
                stream.Close();
                tcpClient.Close();
                Log("[-] Client da ngat ket noi.");
            }
        }

        /// <summary>
        /// Hàm này giúp cập nhật RichTextBox (txtLog) một cách an toàn
        /// từ bất kỳ luồng nào (UI thread, Listener thread, Client thread).
        /// </summary>
        private void Log(string message)
        {
            if (txtLog.InvokeRequired)
            {
                // Nếu đang ở luồng khác (không phải UI),
                // thì "gửi" message này về cho luồng UI tự xử lý
                txtLog.Invoke(new Action<string>(Log), new object[] { message });
            }
            else
            {
                // Nếu đang ở luồng UI, thì cập nhật trực tiếp
                txtLog.AppendText($"[{DateTime.Now.ToLongTimeString()}] {message}\n");
                txtLog.ScrollToCaret(); // Tự cuộn xuống
            }
        }

        // --- CÁC HÀM XỬ LÝ CSDL VÀ LOGIC (Giữ nguyên) ---

        private string ProcessRequest(string request)
        {
            string[] parts = request.Split('|');
            string command = parts[0];

            try
            {
                switch (command)
                {
                    case "REGISTER":
                        return LuuNguoiDungVaoSQL(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8]);
                    case "LOGIN":
                        return KiemTraDangNhap(parts[1], parts[2]);
                    default:
                        return "ERROR|Lenh khong xac dinh";
                }
            }
            catch (Exception ex)
            {
                return $"ERROR|Loi xu ly server: {ex.Message}";
            }
        }

        private string KiemTraDangNhap(string usernameOrEmail, string hashedPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NguoiDung WHERE (Username = @Input OR Email=@Input) AND PasswordHash = @PasswordHash";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // ... (Code CSDL giữ nguyên y hệt) ...
                    cmd.Parameters.AddWithValue("@Input", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string response = string.Join("|", "LOGIN_SUCCESS",
                                reader["Username"]?.ToString() ?? "", reader["Email"]?.ToString() ?? "",
                                reader["HoTen"]?.ToString() ?? "", reader["SoDienThoai"]?.ToString() ?? "",
                                reader["NgaySinh"]?.ToString() ?? "", reader["GioiTinh"]?.ToString() ?? "",
                                reader["DiaChi"]?.ToString() ?? "");
                            return response;
                        }
                        else { return "LOGIN_FAIL"; }
                    }
                }
            }
        }

        private string LuuNguoiDungVaoSQL(string username, string email, string hoten, string hashedPassword,
                                          string sdt, string ngaysinh, string gioitinh, string diachi)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // ... (Code CSDL giữ nguyên y hệt) ...
                    string query = @"INSERT INTO NguoiDung ... VALUES ...";
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
                return "REGISTER_SUCCESS";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    return "REGISTER_FAIL|Username hoặc Email đã tồn tại.";
                return $"REGISTER_FAIL|Loi SQL: {ex.Message}";
            }
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            // Bắt đầu lắng nghe trên một luồng MỚI
            listenerThread = new Thread(new ThreadStart(StartListening));
            listenerThread.IsBackground = true; // Đảm bảo luồng tự tắt khi đóng Form
            listenerThread.Start();

            // Cập nhật giao diện
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = "Status: Listening on port 8080...";
            Log("Server da khoi dong.");
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            try
            {
                listener.Stop();
                listenerThread.Abort(); // Dừng luồng lắng nghe
            }
            catch (Exception ex)
            {
                Log($"Loi khi dung server: {ex.Message}");
            }

            // Cập nhật giao diện
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblStatus.Text = "Status: Offline";
            Log("Server da dung.");
        }
    }
}