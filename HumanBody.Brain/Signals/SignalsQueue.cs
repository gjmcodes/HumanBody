using HumanBody.Core.CNS;
using System.Collections.Generic;

namespace HumanBody.Brain.Signals
{
    public class SignalsQueue
    {
        public static Queue<SignalsQueue> Queue = new Queue<SignalsQueue>();

        public SignalMessage Message { get; set; }

        public static void AddSignal(SignalsQueue queue)
        {
            SignalsQueue.Queue.Enqueue(queue);
        }
    }
}
