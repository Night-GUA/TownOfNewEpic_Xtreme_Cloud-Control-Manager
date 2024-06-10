using System;
using System.Net.Sockets;
using System.Text;

namespace 车队姬模拟
{
    internal class Program
    {
        private const string IP = "154.21.201.164";
        private const int PORT = 25455;
        private static Socket ClientSocket;
        static void Main()
        {
            Console.Write("模拟的房间代码：");
            string a = Console.ReadLine();
            Console.Write("模拟的模组版本：");
            string b = Console.ReadLine();
            Console.Write("模拟的人数：");
            string c = Console.ReadLine();
            Console.Write("模拟的语言id：");
            string d = Console.ReadLine();
            Console.Write("模拟的服务器名字：");
            string e = Console.ReadLine();
            Console.Write("模拟的房主名字：");
            string f = Console.ReadLine();

            string msg = a + "|" + b + "|" + c + "|" + d + "|" + e + "|" + f;
            byte[] buffer = Encoding.Default.GetBytes(msg);

            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ClientSocket.Connect(IP, PORT);
            ClientSocket.Send(buffer);
            ClientSocket.Close();
            Console.Write("\n执行完毕 请按任意键退出");
            string sf = Console.ReadLine();
            if (sf == "1") Main();
            else Console.ReadKey();
            }
        }
}
