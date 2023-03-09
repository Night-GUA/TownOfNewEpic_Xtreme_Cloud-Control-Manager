using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;

namespace 车队姬模拟
{
    internal class Program
    {
        private const string IP = "150.158.149.217";
        private const int PORT = 52000;
        private static Socket clientSocket;
        private static byte[] data = new byte[1024];
        static void Main(string[] args)
        {
            Console.Write("免责声明：此程序仅供娱乐 如被车队姬封禁 本人概不负责 如接受此免责条款 请输入1 否则请退出此程序：\n");
            int mianzetiaokuan = Convert.ToInt32(Console.ReadLine());
            if (mianzetiaokuan == 1)
            {
                Console.Write("模拟的房间代码：");
                string a = Console.ReadLine();
                Console.Write("模拟的模组版本：");
                string b = Console.ReadLine();
                Console.Write("模拟的人数：");
                string c = Console.ReadLine();

                string msg = a + "|" + b + "|" + c;
                byte[] buffer = new byte[2048];
                buffer = Encoding.Default.GetBytes(msg);

                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(IP, PORT);
                //clientSocket.BeginReceive(data, 0, data.Length, SocketFlags.None, CallBack, null);
                clientSocket.Send(buffer);
                clientSocket.Close();
                Console.WriteLine("\n执行完毕 请按Enter键退出");
                Console.ReadLine();
            }
            else
            {
                Console.Write("输入错误 请按Enter键退出");
                Console.ReadLine();
            }
            


        }
    }
}
