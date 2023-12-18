using ChatCommon.Models;

namespace ChatApp
{
    internal interface ImessageSourceClient<T>
    {
        Task SendAsync(NetMessage message, T ep);

        NetMessage Receive(ref T ep);

        T CreateEndpoint();

        T GetServer();
    }
}
