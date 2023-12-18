using Moq;
using System.Net;
using System.Net.Sockets;
using UnitTests.Abstracts;
using UnitTests.Models;
using UnitTests.Services;

namespace ChatClientUnitTests
{
    public class Tests
    {
        [Test]
        public async Task ClientListener_ReceivesMessage_CallsConfirm()
        {
            // Arrange
            var name = "TestClient";
            var address = "127.0.0.1";
            var port = 1234;

            var messageSourceMock = new Mock<IMessageSource>();
            var udpClientMock = new Mock<UdpClient>();

            var client = new Client(name, address, port)
            {
                _messageSouce = messageSourceMock.Object,
                udpClientClient = udpClientMock.Object
            };

            var remoteEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.1"), 5678);
            var netMessage = new NetMessage { NickNameFrom = "Sender", Text = "Hello", Command = Command.Message };

            messageSourceMock.Setup(m => m.Receive(ref remoteEndPoint)).Returns(netMessage);
            messageSourceMock.Setup(m => m.SendAsync(It.IsAny<NetMessage>(), It.IsAny<IPEndPoint>())).Returns(Task.CompletedTask);

            // Act
            await client.ClientListener();

            // Assert
            messageSourceMock.Verify(m => m.Receive(ref remoteEndPoint), Times.Once);
            messageSourceMock.Verify(m => m.SendAsync(It.IsAny<NetMessage>(), remoteEndPoint), Times.Once);
        }

        [Test]
        public void Register_CallsMessageSourceSendAsync()
        {
            // Arrange
            var name = "TestClient";
            var address = "127.0.0.1";
            var port = 1234;

            var messageSourceMock = new Mock<IMessageSource>();
            var udpClientMock = new Mock<UdpClient>();

            var client = new Client(name, address, port)
            {
                _messageSouce = messageSourceMock.Object,
                udpClientClient = udpClientMock.Object
            };

            var remoteEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.1"), 5678);

            // Act
            client.Register(remoteEndPoint);

            // Assert
            messageSourceMock.Verify(m => m.SendAsync(It.IsAny<NetMessage>(), remoteEndPoint), Times.Once);
        }

    }
}