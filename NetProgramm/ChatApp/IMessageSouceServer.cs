using ChatCommon.Models;

namespace ChatApp
{
    public interface IMessageSourceServer<T>
    {
        Task SendAsync(NetMessage message , T ep);

        NetMessage Receive(ref T ep);

        T CreateEndpoint();

        T CopyEndpoint(T ep);
    }
}
