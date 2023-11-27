using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetProgramm
{
    internal class UDPServer
    {
        public void Server()
        {
            UdpClient udpClient = new UdpClient(45512);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Сервер ждет сообщение от клиента");
            
            while (true)
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);

                var messageTxt = Encoding.UTF8.GetString(buffer);

                Message? message = Message.DeserializeMessgeFromJSON(messageTxt);                

            }
        }
    }
}
