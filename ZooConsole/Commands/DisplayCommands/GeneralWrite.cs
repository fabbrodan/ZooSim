using ConsoleSimulationEngine2000;
using System;
using System.Collections.Generic;
using System.Text;
using ZooConsole.Interfaces;

namespace ZooConsole.Commands
{
    class GeneralWrite : ICommand
    {
        private IDisplayWriter _writer;
        private string _message;


        public GeneralWrite(IDisplayWriter writer, string message)
        {
            _writer = writer;
            _message = message;
        }
        public void Execute()
        {
            _writer.Log(_message);
        }
    }
}
