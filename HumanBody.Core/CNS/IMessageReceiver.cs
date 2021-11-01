using System.Threading.Tasks;

namespace HumanBody.Core.CNS
{
    public interface IMessageReceiver
    {
        Task ReceiveMessageAsync(SignalMessage message);
    }
}
