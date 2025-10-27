namespace TCPClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Thử kết nối đến server TRƯỚC KHI chạy
            if (NetworkClient.ConnectToServer())
            {
                // Nếu kết nối thành công, chạy Form Đăng nhập
                Application.Run(new Dangnhap());

                // Đảm bảo đóng kết nối khi ứng dụng tắt
                NetworkClient.Disconnect();
            }
            // Nếu kết nối thất bại, ứng dụng sẽ tự tắt sau thông báo lỗi
        }
    }
}