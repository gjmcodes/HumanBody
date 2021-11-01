using HumanBody.Brain.Signals;
using HumanBody.Core.CNS.Autonomous.Taste;
using System;
using System.Threading.Tasks;

namespace HumanBody.Brain.Interfaces
{
    public interface IBrainTasteSignal : IDisposable
    {
        Task ReceiveFoodSignalAsync(ETasteType tasteType, EFoodType foodType);
    }

    public sealed class BrainTasteSignal : IBrainTasteSignal
    {
        

        public async Task ReceiveFoodSignalAsync(ETasteType tasteType, EFoodType foodType)
        {
            Console.WriteLine("-- BRAIN SIGNAL --");
            Console.WriteLine($"Receiving food signal: {foodType.ToString()} that tastes {tasteType.ToString()}");
            SignalsQueue.AddSignal(new SignalsQueue()
            {
                Message = new Core.CNS.SignalMessage()
                {
                    MessageType = "FOOD_INTAKE"
                }
            });
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
