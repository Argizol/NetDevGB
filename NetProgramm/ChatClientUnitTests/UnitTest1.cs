using Lesson6.Services;
using Moq;
using UnitTests.Abstracts;
using UnitTests.Services;

namespace ChatClientUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestCreate()
        {
            var client = new Client("Vasya", "172.0.0.1", 12345);

            Assert.That(client, Is.EqualTo(new Client("Vasya", "172.0.0.1", 12345)));
        }

        [Test]
        public void TestListener()
        {
            var netmsgsorce = new UdpMessageSouce();
            var server = new Server(netmsgsorce);
            var client = new Client("Vasya", "172.0.0.1", 12345);
            server.Start();
            
        }
    }
}