using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace HIlo
{
    public class TCPClientHandler
    {
        private TcpClient client;
        private NetworkStream stream;

        public bool Connect(string ip, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ip, port);
                stream = client.GetStream();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Send(string message)
        {
            if (stream == null) return;
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
        public string Receive()
        {
            if (stream == null) return "";
            byte[] data = new byte[1024];
            int bytesRead = stream.Read(data, 0, data.Length);
            return Encoding.UTF8.GetString(data, 0, bytesRead);
        }

        public void Close()
        {
            stream?.Close();
            client?.Close();
        }
    }
}
