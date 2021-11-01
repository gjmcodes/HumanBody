using System;
using System.Threading.Tasks;

namespace HumanBody.Core.CNS
{
    public interface IMessageSender : IDisposable
    {
        Task SendMessageasync(SignalMessage message);
    }
}
