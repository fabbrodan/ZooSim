using System;
using System.Collections.Generic;
using System.Text;
using ZooConsole.Interfaces;
using ConsoleSimulationEngine2000;

namespace ZooConsole.Objects
{
    class RollingDisplayWriter : IDisplayWriter
    {
        private readonly RollingDisplay _display;
        private readonly int _height;
        private readonly int _width;
        public RollingDisplayWriter(RollingDisplay display)
        {
            _display = display;
            _height = display.Height;
            _width = display.Width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void Log(string message)
        {
            _display.Log(message);
        }
    }
}
