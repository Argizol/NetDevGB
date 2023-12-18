using UnitTests.Services;

namespace UnitTests
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
           // var client = new Client("Vasya", "172.0.0.1", 12345);
            var netmsgsorce = new UdpMessageSouce();
            var server = new Server(netmsgsorce);
            await server.Start();
            //await client.Start();

        }
    }
}