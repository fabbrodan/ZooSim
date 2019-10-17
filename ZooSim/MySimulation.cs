using System;
using System.Collections.Generic;
using ConsoleSimulationEngine2000;
using ZooSim.Interfaces;
using ZooSim.Animals;
using ZooSim.Utils;
using System.Text;

namespace ZooSim
{
    public class MySimulation : Simulation
    {
        private RollingDisplay _log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay _clockDisplay = new BorderedDisplay(0, 11, 30, 3);
        private BorderedDisplay _statDisplay = new BorderedDisplay(0, 14, 30, 3);
        private BorderedDisplay _optionsDisplay = new BorderedDisplay(Console.WindowWidth - 25, 11, 25, _availableAnimals.Count + 3);
        private BorderedDisplay _moneyDisplay = new BorderedDisplay(Console.WindowWidth - 50, 11, 25, 3);
        private TextInput _input;
        private InputParser _parser;
        private decimal _money = 5000.00m;

        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {
            _log,
            _clockDisplay,
            _statDisplay,
            _optionsDisplay,
            _moneyDisplay,
            _input.CreateDisplay(0, -3, -1)
        };


        private List<string> _commandList = new List<string>()
        {
            "Add Elephant",
            "Add Monkey",
            "Kill",
            "Feed",
            "Status"
        };
        private static List<Animal> _availableAnimals = new List<Animal>()
        {
            new Elephant("dummy", 0),
            new Monkey("dummy", 0),
            new Penguin("dummy", 0)

        };
        
        private List<IAnimal> _animals = new List<IAnimal>();
        private DateTime _gameTime = DateTime.Now;

        public MySimulation(IInput<string> input)
        {
            StringBuilder sb = new StringBuilder("Animals for Purchase:");
            sb.AppendLine();
            foreach (Animal animal in _availableAnimals)
            {
                sb.AppendLine(animal.GetType().Name + " " + animal.Price + " $");
            }

            _input = (TextInput)input;
            _input.SetAutoCompleteWordList(_commandList);

            _parser = new InputParser(ref _animals, this);
            _optionsDisplay.Value = sb.ToString();
            _moneyDisplay.Value = "Money: " + _money + " $";
            _log.Log("Welcome to the Zoo Simulation!");
        }

        public override void PassTime(int deltaTime)
        {
            while (_input.HasInput)
            {
                string input = _input.Consume();
                _log.Log(input);
                if (input != "")
                {
                    _parser.ParseInput(input);
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
            _gameTime = DateTime.Now;
            _clockDisplay.Value = _gameTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
