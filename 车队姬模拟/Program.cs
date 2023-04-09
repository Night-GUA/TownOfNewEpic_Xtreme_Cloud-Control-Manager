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
            Console.WriteLine("请选择语言/Please Choose your Language\n\nEnglish - Input “English”\n简体中文 - 请输入 “简体中文”");
            string language = Console.ReadLine();
            switch (language)
            {
                case "English":
                    Console.Write("Disclaimer: This program is for entertainment only. If banned by the program, I am not responsible. To accept this disclaimer, please enter 'I agree to this disclaimer'. Otherwise, please exit this program:\n");
                    string mianzetiaokuanEN = Console.ReadLine();
                    if (mianzetiaokuanEN == "I agree to this disclaimer")
                    {
                        Console.Write("Simulated room code：");
                        string a = Console.ReadLine();
                        Console.Write("Simulated mod version：");
                        string b = Console.ReadLine();
                        Console.Write("Number of simulated people：");
                        string c = Console.ReadLine();

                        string msg = a + "|" + b + "|" + c;
                        byte[] buffer = new byte[2048];
                        buffer = Encoding.Default.GetBytes(msg);

                        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        clientSocket.Connect(IP, PORT);
                        //clientSocket.BeginReceive(data, 0, data.Length, SocketFlags.None, CallBack, null);
                        clientSocket.Send(buffer);
                        clientSocket.Close();
                        Console.WriteLine("\nAfter execution, please press any key to exit");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("Input error, please press any key to exit");
                        Console.ReadKey();
                    }
                    break;
                case "简体中文":
                    Console.Write("免责声明：此程序仅供娱乐 如被车队姬封禁 本人概不负责 如接受此免责条款 请输入 “ 我同意本免责条款” 否则请退出此程序：\n");
                    string mianzetiaokuan = Console.ReadLine();
                    if (mianzetiaokuan == "我同意本免责条款")
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
                        Console.WriteLine("\n执行完毕 请按任意键退出");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("输入错误 请按任意键退出");
                        Console.ReadKey();
                    }
                    break;
                    default:
                    Console.Write("Input wrong Language Code, please press any key to exit / 输入了错误的语言代码 请按任意键退出");
                    Console.ReadKey();
                    break;
            }
            
            


        }
    }
}
