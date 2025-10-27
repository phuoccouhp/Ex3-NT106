using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic; 

namespace TCPServer
{
    public partial class ServerForm : Form
    {
        private TcpListener listener;
        private Thread listenerThread;
        private const int PORT = 9999;
        private const string connectionString = "Data Source=.;Initial Catalog=QL_TaiKhoan;User ID=appuser;Password=StrongPass@123;";

        public ServerForm()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            listenerThread = new Thread(new ThreadStart(StartListening));
            listenerThread.IsBackground = true;
            listenerThread.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = $"Status: Listening on port {PORT}...";
            Log("Server da khoi dong.");
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            try
            {
                listener?.Stop();
                if (listenerThread != null && listenerThread.IsAlive)
                {
                    listenerThread.Join(500);
                }
            }
            catch (Exception ex)
            {
                Log($"Loi khi dung server: {ex.Message}");
            }
            finally
            {
                listenerThread = null;
            }
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblStatus.Text = "Status: Offline";
            Log("Server da dung.");
        }

        private void StartListening()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), PORT); 
                listener.Start();
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Log($"[+] Client moi ket noi tu: {client.Client.RemoteEndPoint}");
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.Start(client);
                }
            }
            catch (SocketException ex)
            {
                Log($"Server da dung lang nghe: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log($"[LOI SERVER] {ex.Message}");
            }
        }

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

        private void Log(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(Log), new object[] { message });
            }
            else
            {
                txtLog.AppendText($"[{DateTime.Now.ToLongTimeString()}] {message}\n");
                txtLog.ScrollToCaret();
            }
        }

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
                    cmd.Parameters.AddWithValue("@Input", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var userData = new List<string>
                            {
                                "LOGIN_SUCCESS", 
                                reader["Username"]?.ToString() ?? "", 
                                reader["Email"]?.ToString() ?? "", 
                                reader["HoTen"]?.ToString() ?? "", 
                                reader["SoDienThoai"]?.ToString() ?? "", 
                                reader["NgaySinh"]?.ToString() ?? "",
                                reader["GioiTinh"]?.ToString() ?? "",
                                reader["DiaChi"]?.ToString() ?? "" 
                            };
                            string token = Guid.NewGuid().ToString();
                            userData.Add(token);
                            return string.Join("|", userData);
                        }
                        else
                        {
                            return "LOGIN_FAIL"; 
                        }
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

                        cmd.Parameters.AddWithValue("@NgaySinh", string.IsNullOrEmpty(ngaysinh) ? (object)DBNull.Value : ngaysinh);

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
    }
}
