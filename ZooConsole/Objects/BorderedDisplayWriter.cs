using System;
using System.Collections.Generic;
using System.Text;
using ZooConsole.Interfaces;
using ConsoleSimulationEngine2000;

namespace ZooConsole.Objects
{
    class BorderedDisplayWriter : IDisplayWriter
    {
        private readonly BorderedDisplay _display;

        public BorderedDisplayWriter(BorderedDisplay display)
        {
            _display = display;
        }
        public void Log(string message)
        {
            _display.Value = message;
        }
    }
}
