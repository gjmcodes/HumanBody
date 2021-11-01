using HumanBody.Brain.Interfaces;
using HumanBody.Brain.Signals;
using HumanBody.Core.CNS.Autonomous.Taste;
using HumanBody.Systems.Digestive.Mouth;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HumanBody.Inputs.Body
{
    class Program
    {
        static string[] options = new[]
        {
            "1"
        };

        static void Main(string[] args)
        {
            var signalDispatcherTask = Task.Run(() => SignalDispatcher());

            IBrainTasteSignal brainTasteSignal = new BrainTasteSignal();
            IIngestFood ingestFood = new IngestFood(brainTasteSignal);


            while (true)
            {
                Console.WriteLine("Press key for action:");
                Console.WriteLine("1 - Chew");
                var key = Console.ReadLine().Trim();
                if (!options.Contains(key))
                {
                    Console.WriteLine("Option not found. Press any key");
                    Console.ReadLine();
                    Console.Clear();

                    continue;
                }

                if (key == "1")
                {
                    ingestFood.ChewFood(ETasteType.TAKE_IN_SALTY, EFoodType.SOLID);
                }
                Console.WriteLine("Press any key");
            }
        }

        static async Task SignalDispatcher()
        {
            while (true)
            {
                if (SignalsQueue.Queue?.Count > 0)
                {
                    var signal = SignalsQueue.Queue.Dequeue();
                    Console.WriteLine($"Dequeing Signal: {signal.Message.MessageType}");
                }
            }
        }
    }
}
