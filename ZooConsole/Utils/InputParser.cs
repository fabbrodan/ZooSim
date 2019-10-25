using ZooConsole.Interfaces;
using System.Collections.Generic;
using ZooSim.Animals;
using ZooConsole.Commands;
using System.Text.RegularExpressions;
using ZooSim;

namespace ZooConsole.Utils
{
    public class InputParser
    {
        private IDisplayWriter _logDisplayWriter;
        private Zoo _zoo;
        public InputParser(Zoo zoo, IDisplayWriter writer)
        {
            _logDisplayWriter = writer;
            _zoo = zoo;
        }

        public ICommand ParseInputToCommand(string input)
        {
            Dictionary<string, ICommand> _commandDict;
            input.Trim();
            string[] _inputAsArray = input.Split(" ");
            string[] paramArr = new string[2];
            if (_inputAsArray.Length < 1)
            {
                return new GeneralWrite(_logDisplayWriter, "\"" + input + "\"" + " is not a recognized command");
            }
            else  if (_inputAsArray.Length == 3)
            {
                paramArr[1] = _inputAsArray[2];
            }
            else if (_inputAsArray.Length == 4)
            {
                paramArr[0] = _inputAsArray[2];
                paramArr[1] = _inputAsArray[3];
            }
            else 
            {
                paramArr = _inputAsArray;
            }
            _commandDict = new Dictionary<string, ICommand>()
            {
                { "Add Elephant", new Add<Elephant>(_zoo, paramArr) },
                { "Add Monkey", new Add<Monkey>(_zoo, paramArr) },
                { "Add Penguin", new Add<Penguin>(_zoo, paramArr) },
                { "Feed", new Feed(_zoo, paramArr) },
                { "Kill", new Kill(_zoo, paramArr) },
                { "Status", new WriteStatus(_zoo, _logDisplayWriter, paramArr) },
                { "Loan", new Loan(_zoo, paramArr) },
                { "Pay Loan", new PayLoan(_zoo, paramArr) },
                { "Sleep", new Sleep(_zoo, paramArr) }
            };

            foreach (KeyValuePair<string, ICommand> kvp in _commandDict)
            {
                if (Regex.IsMatch(input, @"^" + kvp.Key))
                {
                    return kvp.Value;
                }
            }
            return new GeneralWrite(_logDisplayWriter, "\"" + input + "\"" + " is not a recognized command");
        }
    }
}
