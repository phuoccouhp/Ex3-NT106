using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Net; // Để sử dụng IPAddress
using System.Net.Sockets; // <--- THÊM DÒNG NÀY (cho AddressFamily)

namespace TCPClient
{
    public static class NetworkClient
    {
        private static TcpClient client;
        private static NetworkStream stream;

        private const string serverIP = "127.0.0.1";
        private const int serverPort = 9999;

        // VV THÊM DÒNG NÀY ĐỂ LƯU TOKEN VV
        public static string CurrentToken { get; set; } // Bỏ chữ "private" đi        // ^^ KẾT THÚC THÊM ^^

        public static bool ConnectToServer()
        {
            try
            {
                // Sửa lỗi IPv4/IPv6 triệt để
                client = new TcpClient(AddressFamily.InterNetwork);

                IPAddress ipAddress = IPAddress.Parse(serverIP);
                client.Connect(ipAddress, serverPort);

                stream = client.GetStream();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến server: {ex.Message}, bạn hãy thử bật server và lắng nghe để bật TCPClient", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string SendRequest(string request)
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Mất kết nối với server.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ERROR_DISCONNECTED";
            }

            try
            {
                byte[] requestData = Encoding.UTF8.GetBytes(request);
                stream.Write(requestData, 0, requestData.Length);

                byte[] buffer = new byte[4096];
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

        public static void Disconnect()
        {
            stream?.Close();
            client?.Close();
        }
    }
}

