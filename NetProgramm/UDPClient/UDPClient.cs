using NetProgramm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace UDPClient
{
    internal class UDPClient
    {
        public static void SendMessage(string from, string ip)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 45512);

            while (true)
            {
                string message;
                do
                {
                    
                    Console.WriteLine("Введите сообщение");
                    message = Console.ReadLine();
                    Console.Clear();
                } while (string.IsNullOrEmpty(message));

                Message msg = new Message() { Text = message, NickNameFrom = from, NickNameTo = "Server", DateTime = DateTime.Now };
                var JSONmsg = msg.SerialazeMessageToJSON();
                byte[] buffer = Encoding.UTF8.GetBytes(JSONmsg);
                udpClient.Send(buffer, buffer.Length, iPEndPoint);
            }
        }
    }
}
