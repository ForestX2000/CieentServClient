using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Client
{
    class MyTcpClient
    {
        static void Main(string[] args)
        {
            do
            {
                string message = Console.ReadLine();
                string request =
                SendRequestAndReceiveAnswer("localhost", 13000, message);
                //10.132.199.64
                Console.WriteLine("Ответ сервера: {0}", request);
            } while (true);
        }
        public static string SendRequestAndReceiveAnswer(string
        server, int port, string message)
        {
            TcpClient client = new TcpClient(server, port);
            Stream stream = client.GetStream();
            var bw = new BinaryWriter(stream);
            bw.Write(message);
            var br = new BinaryReader(stream);
            string request = br.ReadString();
            stream.Close();
            client.Close();
            br.Close();
            bw.Close();
            return request;
        }
    }
}