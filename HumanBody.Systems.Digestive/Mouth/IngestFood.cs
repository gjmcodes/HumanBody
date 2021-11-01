using HumanBody.Brain.Interfaces;
using HumanBody.Brain.Responses;
using HumanBody.Core.CNS.Autonomous.Taste;
using System;
using System.Threading.Tasks;

namespace HumanBody.Systems.Digestive.Mouth
{
    public interface IIngestFood : IDisposable
    {
        Task<StimulusResponse> OpenFoodIntakeStream(string stimulusType);
        bool ChewFood(ETasteType tasteType, EFoodType foodType);
        Task<StimulusResponse> CloseFoodIntakeStream(string stimulusType);
    }

    public sealed class IngestFood : IIngestFood
    {
        private readonly IBrainTasteSignal brainTasteSignal;

        public IngestFood(IBrainTasteSignal brainTasteSignal)
        {
            this.brainTasteSignal = brainTasteSignal;
        }

        public bool ChewFood(ETasteType tasteType, EFoodType foodType)
        {
            Console.WriteLine("-- DIGESTIVE SYSTEM --");
            Console.WriteLine($"Chewing: {foodType.ToString()} that tastes {tasteType.ToString()}");
            brainTasteSignal.ReceiveFoodSignalAsync(tasteType, foodType);

            return true;
        }

        public Task<StimulusResponse> CloseFoodIntakeStream(string stimulusType)
        {
            throw new NotImplementedException();
        }

      

        public Task<StimulusResponse> OpenFoodIntakeStream(string stimulusType)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
