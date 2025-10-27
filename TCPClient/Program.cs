namespace TCPClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            if (NetworkClient.ConnectToServer())
            {
                Application.Run(new Dangnhap());

                NetworkClient.Disconnect();
            }
        }
    }
}