using System;
using System.Reflection;
using System.Diagnostics;
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
        // Display Components
        private BorderedDisplay _mainWindow = new BorderedDisplay(0, 0, Console.WindowWidth -80, 12);
        private BorderedDisplay _animalListDisplay = new BorderedDisplay(Console.WindowWidth - 80, 0, Console.WindowWidth - (Console.WindowWidth - 80), 12);
        private BorderedDisplay _clockDisplay = new BorderedDisplay(Console.WindowWidth - 80, 11, 30, 3);
        private BorderedDisplay _optionsDisplay = new BorderedDisplay(Console.WindowWidth - 25, 11, 25, 6);
        private BorderedDisplay _moneyDisplay = new BorderedDisplay(Console.WindowWidth - 50, 11, 25, 3);
        private BorderedDisplay _loanDisplay = new BorderedDisplay(Console.WindowWidth - 50, 14, 25, 3);
        private BorderedDisplay _commandDisplay = new BorderedDisplay(0, 11, Console.WindowWidth - 80, 12);
        private BorderedDisplay _versionDisplay = new BorderedDisplay(Console.WindowWidth - 30, Console.WindowHeight - 3, 30, 3);

        // Display Writers
        private BorderedDisplayWriter _clockWriter;
        private BorderedDisplayWriter _optionsWriter;
        private BorderedDisplayWriter _moneyWriter;
        private BorderedDisplayWriter _loanWriter;
        private BorderedDisplayWriter _listWriter;
        private BorderedDisplayWriter _mainWriter;
        private BorderedDisplayWriter _commandDisplayWriter;
        private BorderedDisplayWriter _versionWriter;

        // Input managers
        private TextInput _input;
        private InputParser _parser;

        private Invoker _commandInvoker = Invoker.GetInvoker();
        private DateTime _gameTime = DateTime.Now;
        
        // Main Simulation class
        public Zoo Zoo = new Zoo();

        private List<string> _commandList = new List<string>()
        {
            "Add Elephant",
            "Add Monkey",
            "Add Penguin",
            "Kill",
            "Feed",
            "Loan",
            "Pay Loan",
            "Sleep"
        };

        private List<string> _displayCommands = new List<string>()
        {
            "Add",
            "Kill",
            "Feed",
            "Sleep",
            "Loan",
            "Pay Loan"
        };

        public override List<BaseDisplay> Displays => new List<BaseDisplay>()
        {
            _mainWindow,
            _clockDisplay,
            _optionsDisplay,
            _moneyDisplay,
            _loanDisplay,
            _animalListDisplay,
            _commandDisplay,
            _versionDisplay,
            _input.CreateDisplay(0, -3, Console.WindowWidth - 30)
        };

        #region Constructor
        public MySimulation(IInput<string> input)
        {
            InitDisplayWriters();
            InitInput(input);
            InitParser();
            InitAnimalList();
            InitMoneyDisplay();
            InitLoanDisplay();
            InitCommandDisplay();
            InitVersionDisplay();
            InitMainDisplay();
        }
        #endregion

        #region Initializiers
        private void InitAnimalList()
        {
            List<IAnimal> _availableAnimals = new List<IAnimal>()
            {
                new Elephant("dummy", 0),
                new Monkey("dummy", 0),
                new Penguin("dummy", 0)
            };

            StringBuilder sb = new StringBuilder("Animals for Purchase:");
            sb.AppendLine();
            foreach (IAnimal animal in _availableAnimals)
            {
                sb.AppendLine(animal.GetType().Name + " " + animal.GetPrice() + "$");
            }
            _optionsWriter.Log(sb.ToString());
    }

        private void InitDisplayWriters()
        {
            _clockWriter = new BorderedDisplayWriter(_clockDisplay);
            _optionsWriter = new BorderedDisplayWriter(_optionsDisplay);
            _moneyWriter = new BorderedDisplayWriter(_moneyDisplay);
            _loanWriter = new BorderedDisplayWriter(_loanDisplay);
            _mainWriter = new BorderedDisplayWriter(_mainWindow);
            _listWriter = new BorderedDisplayWriter(_animalListDisplay);
            _commandDisplayWriter = new BorderedDisplayWriter(_commandDisplay);
            _versionWriter = new BorderedDisplayWriter(_versionDisplay);
        }

        private void InitInput(IInput<string> input)
        {
            
            _input = (TextInput)input;
            _input.SetAutoCompleteWordList(_commandList);
        }

        private void InitParser()
        {
            _parser = new InputParser(Zoo, _mainWriter);
        }

        private void InitMoneyDisplay()
        {
            _moneyWriter.Log("Balance: " + Zoo.Account.GetBalance() + "$")
;        }

        private void InitLoanDisplay()
        {
            _loanWriter.Log("Loan: " + Zoo.Account.GetLoan() + "$");
        }

        private void InitMainDisplay()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Welcome to the Zoo Simulation!");
            sb.AppendLine("You can purchase animals using your Balance.");
            sb.AppendLine("Each animal gets hungry/tired at different rates.");
            sb.AppendLine("If you run out of money, you can always loan more");
            sb.AppendLine("but there is an interest rate of 15% every five minutes.");
            sb.AppendLine();
            sb.AppendLine("To purchase an animal, use the following syntax:");
            sb.AppendLine("\"Add [Animal] [Name] [Age]\"");
            sb.AppendLine("E.g. Add Elephant Dumbo 3");
            sb.AppendLine("Note that names can only be one word in this version!");
            _mainWriter.Log(sb.ToString());
        }

        private void InitCommandDisplay()
        {
            StringBuilder sb = new StringBuilder("Commands:");
            sb.AppendLine();
            foreach (string s in _displayCommands)
            {
                sb.AppendLine(s);
            }

            _commandDisplayWriter.Log(sb.ToString());
        }

        private void InitVersionDisplay()
        {
            FileVersionInfo vInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            _versionWriter.Log("Version: Alpha " + vInfo.ProductVersion);
        }
        #endregion

        #region Game Loop
        public override void PassTime(int deltaTime)
        {
            StringBuilder sb = new StringBuilder();

            while (_input.HasInput)
            {
                string input = _input.Consume();
                ICommand command = _parser.ParseInputToCommand(input);
                _commandInvoker.SetCommand(command);
                _commandInvoker.Invoke();
            }
            foreach (IAnimal animal in Zoo.GetAnimals())
            {
                animal.Update(_gameTime);
                sb.AppendLine(animal.GetState());
                _listWriter.Log(sb.ToString());
            }
            Zoo.Account.WithdrawInterest(_gameTime);

            _gameTime = DateTime.Now;
            _clockWriter.Log(_gameTime.ToString("yyyy-MM-dd HH:mm:ss"));
            _moneyWriter.Log("Money: " + Zoo.Account.GetBalance() + "$");
            _loanWriter.Log("Loan: " + Zoo.Account.GetLoan() + "$");
        }
        #endregion
    }
}