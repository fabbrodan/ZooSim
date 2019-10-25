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
        private readonly int _height;
        private readonly int _width;

        public BorderedDisplayWriter(BorderedDisplay display)
        {
            _display = display;
            _height = display.Height;
            _width = display.Width;
        }
        public void Log(string message)
        {
            _display.Value = message;
        }

        public int GetHeight()
        {
            return _height;
        }
        public int GetWidth()
        {
            return _width;
        }
    }
}
