using System;
using System.Collections.Generic;
using ConsoleSimulationEngine2000;
using ZooSim.Interfaces;
using ZooSim.Animals;

namespace ZooSim
{
    public class MySimulation : Simulation
    {
        private RollingDisplay _log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay _clockDisplay = new BorderedDisplay(0, 11, 30, 3);
        private BorderedDisplay _optionsDisplay = new BorderedDisplay(Console.WindowWidth - 20, 11, 20, 5);
        private TextInput _input;
        private InputParser _parser;
        public override List<BaseDisplay> Displays => new List<BaseDisplay>() { _log, _clockDisplay, _optionsDisplay, _input.CreateDisplay(0, -3, -1) };

        private List<string> _commandList = new List<string>()
        {
            "Add Elephant",
            "Add Monkey",
            "AdvanceTime",
            "Kill",
            "Feed",
            "Status"
        };

        private List<IAnimal> _animals = new List<IAnimal>();
        private DateTime _gameTime = DateTime.Now;

        public MySimulation(IInput<string> input)
        {
            _input = (TextInput)input;
            _input.SetAutoCompleteWordList(_commandList);
            _parser = new InputParser(ref _animals, this);
            _optionsDisplay.Value = "Elephant" + Environment.NewLine +  "Monkey" + Environment.NewLine + "Penguin";
            _log.Log("Welcome to the Zoo Simulation!");
        }

        public override void PassTime(int deltaTime)
        {
            _gameTime = _gameTime.AddMilliseconds(deltaTime);
            while (_input.HasInput)
            {
                string input = _input.Consume();
                _log.Log(input);
                if (input != "")
                {
                    if (input == "AdvanceTime")
                    {
                        _gameTime = _gameTime.AddHours(1);
                    }
                    else
                    {
                        _parser.ParseInput(input);
                    }
                }
                else
                {
                    _log.Log("Not a valid input");
                }

            }
            foreach (IAnimal animal in _animals)
            {
                string animalStatePriorToUpdate = animal.GetState();
                animal.Update(_gameTime);
                string animalStateAfterUpdate = animal.GetState();

                if (animalStatePriorToUpdate != animalStateAfterUpdate)
                {
                    _log.Log(animal.GetState());
                }
            }
            _clockDisplay.Value = _gameTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
