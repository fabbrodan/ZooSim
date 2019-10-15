using System;
using ZooSim;
using ConsoleSimulationEngine2000;
using System.Threading.Tasks;

namespace ZooConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var gui = new ConsoleGUI(35, 149)
            {
                TargetUpdateTime = 100
            };

            var sim = new MySimulation();
            await gui.Start(sim);
        }
    }
}
