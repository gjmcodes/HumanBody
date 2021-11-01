using HumanBody.Brain.Interfaces;
using HumanBody.Core.CNS.Autonomous.Taste;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanBody.Taste.Signals
{
    public interface ITasteFoodSignal : IDisposable
    {
        Task SendFoodSignalAsync(ETasteType tasteType, EFoodType foodType);

    }
    public sealed class TasteFoodSignal : ITasteFoodSignal
    {

        private readonly IBrainTasteSignal brainTasteSignal;

        public TasteFoodSignal(IBrainTasteSignal brainTasteSignal)
        {
            this.brainTasteSignal = brainTasteSignal;
        }

        public async Task SendFoodSignalAsync(ETasteType tasteType, EFoodType foodType)
        {
            await brainTasteSignal.ReceiveFoodSignalAsync(tasteType, foodType);
        }

        public void Dispose()
        {
            brainTasteSignal.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
