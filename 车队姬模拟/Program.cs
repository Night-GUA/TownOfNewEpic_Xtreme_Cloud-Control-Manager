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
        private static string a = "",b = "",c = "",d = "",e = "",f = "",msg = "";
        static void Main()
        {
            Console.Write("模拟的房间代码：");
            a = Console.ReadLine();
            Console.Write("模拟的模组版本：");
            b = Console.ReadLine();
            Console.Write("模拟的人数：");
            c = Console.ReadLine();
            Console.Write("模拟的语言id：");
            d = Console.ReadLine();
            Console.Write("模拟的服务器名字：");
            e = Console.ReadLine();
            Console.Write("模拟的房主名字：");
            f = Console.ReadLine();

#if RELEASE
            b += " ByYuCDJ";
#endif

            msg = a + "|" + b + "|" + c + "|" + d + "|" + e + "|" + f;
            SentMessage();
            //Console.Write(msg);
        }
        static void SentMessage()
        {
            byte[] buffer = Encoding.Default.GetBytes(msg);

            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ClientSocket.Connect(IP, PORT);
            ClientSocket.Send(buffer);
            ClientSocket.Close();
            Console.Write("\n执行完毕 按ENTER退出 输入JX继续发送本消息 输入CX发送新消息");
            string sf = Console.ReadLine();
            if (sf == "CX") Main();
            else if (sf == "JX") SentMessage();
            else Console.ReadKey();
        }
    }
}
