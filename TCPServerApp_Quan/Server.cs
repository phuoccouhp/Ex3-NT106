using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace TcpServerApp
{
    public class Server
    {
        private TcpListener listener;
        private int port;
        private readonly Action<string> Log;  // delegate để ghi log ra form
        private bool isRunning = false;

        public Server(Action<string> logAction, int port = 8080)
        {
            this.Log = logAction;
            this.port = port;
        }

        // 🔹 Bắt đầu chạy server
        public void Start()
        {
            try
            {
                // Khởi tạo database (tạo bảng nếu chưa có)
                DatabaseHelper.InitializeDatabase();

                // Tạo TCP Listener lắng nghe trên tất cả IP
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                isRunning = true;

                Log($"✅ Server khởi động thành công trên cổng {port}.");
                Log("Đang chờ kết nối từ client...");

                // Tạo luồng riêng để chấp nhận nhiều kết nối client
                Thread acceptThread = new Thread(AcceptClients);
                acceptThread.IsBackground = true;
                acceptThread.Start();
            }
            catch (Exception ex)
            {
                Log("❌ Lỗi khi khởi động server: " + ex.Message);
            }
        }

        // 🔹 Vòng lặp chấp nhận client mới
        private void AcceptClients()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Log($"🟢 Client kết nối: {client.Client.RemoteEndPoint}");

                    // Xử lý mỗi client trong luồng riêng
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    Log("⚠️ Lỗi AcceptClients: " + ex.Message);
                }
            }
        }

        // 🔹 Xử lý dữ liệu từ từng client
        private void HandleClient(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                {
                    // Đọc dữ liệu từ client (mỗi request là 1 dòng JSON)
                    string request = reader.ReadLine();
                    if (string.IsNullOrEmpty(request)) return;

                    Log($"📩 Nhận từ client: {request}");

                    JObject json = JObject.Parse(request);
                    string type = (string)json["type"];

                    if (type == "register")
                    {
                        // Xử lý đăng ký
                        string username = (string)json["username"];
                        string password = (string)json["password"];
                        string email = (string)json["email"];

                        User newUser = new User(username, password, email);
                        User result = DatabaseHelper.RegisterUser(newUser);

                        JObject response = new JObject();

                        if (result != null)
                        {
                            response["status"] = "success";
                            response["UserId"] = result.UserId;
                            response["Username"] = result.Username;
                            response["Email"] = result.Email;
                            Log($"🟢 User '{username}' đăng ký thành công.");
                        }
                        else
                        {
                            response["status"] = "fail";
                            Log($"🔴 Đăng ký thất bại cho user '{username}'.");
                        }

                        writer.WriteLine(response.ToString());
                    }
                    else if (type == "login")
                    {
                        // Xử lý đăng nhập
                        string username = (string)json["username"];
                        string password = (string)json["password"];

                        User user = DatabaseHelper.AuthenticateUser(username, password);

                        JObject response = new JObject();

                        if (user != null)
                        {
                            response["status"] = "success";
                            response["UserId"] = user.UserId;
                            response["Username"] = user.Username;
                            response["Email"] = user.Email;
                            Log($"🟢 User '{username}' đăng nhập thành công.");
                        }
                        else
                        {
                            response["status"] = "fail";
                            Log($"🔴 Đăng nhập thất bại cho user '{username}'.");
                        }

                        writer.WriteLine(response.ToString());
                    }
                    else
                    {
                        Log("⚠️ Yêu cầu không hợp lệ: " + type);
                        JObject response = new JObject { ["status"] = "invalid" };
                        writer.WriteLine(response.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Log("❌ Lỗi xử lý client: " + ex.Message);
            }
            finally
            {
                client.Close();
                Log("🔻 Client ngắt kết nối.\n");
            }
        }
    }
}
