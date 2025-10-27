using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace TCPClient
{
    public static class NetworkClient
    {
        private static TcpClient client;
        private static NetworkStream stream;

        // Địa chỉ và cổng của TCPServer
        private const string serverIP = "127.0.0.1"; // IP của máy chủ (để localhost)
        private const int serverPort = 8080;       // Cổng mà server đang lắng nghe

        // Hàm này được gọi 1 LẦN DUY NHẤT khi ứng dụng khởi động
        public static bool ConnectToServer()
        {
            try
            {
                client = new TcpClient();
                client.Connect(serverIP, serverPort); // Thử kết nối
                stream = client.GetStream();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến server: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Hàm này dùng để gửi yêu cầu VÀ nhận phản hồi từ Server
        public static string SendRequest(string request)
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Mất kết nối với server.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ERROR_DISCONNECTED";
            }

            try
            {
                // 1. Gửi yêu cầu (string -> byte[])
                byte[] requestData = Encoding.UTF8.GetBytes(request);
                stream.Write(requestData, 0, requestData.Length);

                // 2. Chờ nhận phản hồi (byte[] -> string)
                byte[] buffer = new byte[4096]; // Bộ đệm 4KB
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi giao tiếp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ERROR_COMMUNICATION";
            }
        }

        // Đóng kết nối khi tắt ứng dụng
        public static void Disconnect()
        {
            stream?.Close();
            client?.Close();
        }
    }
}