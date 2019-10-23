using System;
using System.Collections.Generic;
using System.Text;
using ZooConsole.Interfaces;

namespace ZooConsole.Utils
{
    public sealed class Invoker
    {
        public readonly List<ICommand> _commands;
        private ICommand _command;
        private static Invoker _instance = null;

        public static Invoker GetInvoker()
        {
            if (_instance == null)
            {
                return new Invoker();
            }
            else
            {
                return _instance;
            }
        }
        private Invoker()
        {
            _commands = new List<ICommand>();
        }
        public void SetCommand(ICommand command) => _command = command;

        public void Invoke()
        {
            _commands.Add(_command);
            _command.Execute();
        }
    }
}
