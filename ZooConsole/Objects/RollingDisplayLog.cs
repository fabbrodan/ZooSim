using System;
using System.Collections.Generic;
using System.Text;
using ZooConsole.Interfaces;
using ConsoleSimulationEngine2000;

namespace ZooConsole.Objects
{
    class RollingDisplayLog : IDisplayWriter
    {
        private readonly RollingDisplay _display;
        public RollingDisplayLog(RollingDisplay display)
        {
            _display = display;
        }

        public void Log(string message)
        {
            _display.Log(message);
        }
    }
}
