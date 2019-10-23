using System;
using System.Collections.Generic;
using ConsoleSimulationEngine2000;
using ZooSim;
using ZooSim.Interfaces;
using ZooSim.Animals;
using ZooConsole.Utils;
using ZooConsole.Interfaces;
using ZooConsole.Objects;
using System.Text;

namespace ZooConsole
{
    public class MySimulation : Simulation
    {
        #region Initialization
        private RollingDisplay _log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay _clockDisplay = new BorderedDisplay(0, 11, 30, 3);
        private BorderedDisplay _optionsDisplay = new BorderedDisplay(Console.WindowWidth - 25, 11, 25, _availableAnimals.Count + 3);
        private BorderedDisplay _moneyDisplay = new BorderedDisplay(Console.WindowWidth - 50, 11, 25, 3);
        private BorderedDisplay _loanDisplay = new BorderedDisplay(Console.WindowWidth - 50, 14, 25, 3);
        private TextInput _input;
        private InputParser _parser;
        private Invoker _commandInvoker = Invoker.GetInvoker();
        private DateTime _gameTime = DateTime.Now;
        public Zoo Zoo = new Zoo();
        private BorderedDisplayWriter _clockWriter;
        private BorderedDisplayWriter _optionsWriter;
        private BorderedDisplayWriter _moneyWriter;
        private BorderedDisplayWriter _loanWriter;
        private RollingDisplayLog _logWriter;

        public override List<BaseDisplay> Displays => new List<BaseDisplay>()
        {
            _log,
            _clockDisplay,
            _optionsDisplay,
            _moneyDisplay,
            _loanDisplay,
            _input.CreateDisplay(0, -3, -1)
        };

        public List<IDisplayWriter> Writers { get; }

        private List<string> _commandList = new List<string>()
        {
            "Add Elephant",
            "Add Monkey",
            "Add Penguin",
            "Kill",
            "Feed",
            "Status"
        };
        private static List<IAnimal> _availableAnimals = new List<IAnimal>()
        {
            new Elephant("dummy", 0),
            new Monkey("dummy", 0),
            new Penguin("dummy", 0)

        };


        #region Constructor
        public MySimulation(IInput<string> input)
        {
            _input = (TextInput)input;
            _input.SetAutoCompleteWordList(_commandList);

            _clockWriter = new BorderedDisplayWriter(_clockDisplay);
            _optionsWriter = new BorderedDisplayWriter(_optionsDisplay);
            _moneyWriter = new BorderedDisplayWriter(_moneyDisplay);
            _loanWriter = new BorderedDisplayWriter(_loanDisplay);
            _logWriter = new RollingDisplayLog(_log);

            Writers = new List<IDisplayWriter>()
            {
                _clockWriter,
                _optionsWriter,
                _moneyWriter,
                _logWriter,
                _loanWriter
            };

            _parser = new InputParser(Zoo, _logWriter);

            StringBuilder sb = new StringBuilder("Animals for Purchase:");
            sb.AppendLine();
            foreach (Animal animal in _availableAnimals)
            {
                sb.AppendLine(animal.GetType().Name + " " + animal.Price + "$");
            }

            _optionsWriter.Log(sb.ToString());
            _moneyWriter.Log("Balance: " + Zoo.Account.GetBalance() + "$");
            _loanWriter.Log("Loan: " + Zoo.Account.GetLoan() + "$");
            _logWriter.Log("Welcome to the Zoo Simulation!");
        }
        #endregion
        #endregion

        #region Game Loop
        public override void PassTime(int deltaTime)
        {
            while (_input.HasInput)
            {
                string input = _input.Consume();
                _logWriter.Log(input);
                ICommand command = _parser.ParseInputToCommand(input);
                _commandInvoker.SetCommand(command);
                _commandInvoker.Invoke();
            }
            foreach (IAnimal animal in Zoo.GetAnimals())
            {
                string animalStatePriorToUpdate = animal.GetState();
                animal.Update(_gameTime);
                string animalStateAfterUpdate = animal.GetState();

                if (animalStatePriorToUpdate != animalStateAfterUpdate)
                {
                    _logWriter.Log(animal.GetState());
                }
            }
            _gameTime = DateTime.Now;
            _clockWriter.Log(_gameTime.ToString("yyyy-MM-dd HH:mm:ss"));
            _moneyWriter.Log("Money: " + Zoo.Account.GetBalance() + "$");
            _loanWriter.Log("Loan: " + Zoo.Account.GetLoan() + "$");
        }
        #endregion
    }
}