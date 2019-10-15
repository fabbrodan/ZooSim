using System;
using System.Collections.Generic;
using ConsoleSimulationEngine2000;
using ZooSim.Interfaces;
using ZooSim.Animals;

namespace ZooSim
{
    public class MySimulation : Simulation
    {
        private RollingDisplay log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay clockDisplay = new BorderedDisplay(0, 11, 30, 3);
        private BorderedDisplay optionsDisplay = new BorderedDisplay(31, 11, 20, 3);
        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {log, clockDisplay, optionsDisplay, Input.CreateDisplay(0, -3, -1, 3)};

        private List<string> _commandList = new List<string>();

        private List<IAnimal> _animals = new List<IAnimal>();
        private DateTime gameTime = DateTime.Now;
        public MySimulation()
        {
            log.Log("Welcome to the Zoo Simulation!");
            log.Log("In game time is passed on one hour at every command you enter and real time otherwise.");
        }
        public override void PassTime(int deltaTime)
        {
            Input.SetAutoCompleteWordList(_commandList);
            gameTime = gameTime.AddMilliseconds(deltaTime);
            while (Input.HasInput)
            {
                string input = Input.Consume();
                if (input != "")
                {
                    if (input.StartsWith("Add"))
                    {
                        _animals.Add(InputParser.ParseActionInput(input));
                    }
                    gameTime = gameTime.AddHours(1);
                }
            }
            foreach (IAnimal animal in _animals)
            {
                string animalStatePriorToUpdate = animal.GetState();
                animal.Update(gameTime);
                string animalStateAfterUpdate = animal.GetState();

                if (animalStatePriorToUpdate != animalStateAfterUpdate)
                {
                    log.Log(animal.GetState());
                }
            }
            clockDisplay.Value = gameTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
