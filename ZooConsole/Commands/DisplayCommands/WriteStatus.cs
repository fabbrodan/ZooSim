using System.Collections.Generic;
using ZooConsole.Interfaces;
using ConsoleSimulationEngine2000;
using ZooSim.Interfaces;
using System.Text;
using System.Linq;

namespace ZooConsole.Commands
{
    class WriteStatus : ICommand
    {
        private IDisplayWriter _writer;
        private string _message;
        private IZooAnimals _animals;
        private string _param;
        public WriteStatus(IZooAnimals animals, IDisplayWriter writer, params string[] paramArr)
        {
            _writer = writer;
            _param = paramArr[1];
            _animals = animals;
        }
        public void Execute()
        {
            if (_param.ToLower() == "all")
            {
                StringBuilder sb = new StringBuilder();
                foreach (IAnimal animal in _animals.GetAnimals())
                {
                    sb.AppendLine(animal.GetState());
                }
                _message = sb.ToString();
            }
            else
            {
                IAnimal animal = _animals.GetAnimals().First(a => a.GetName() == _param);
                _message = animal.GetState();
            }

            _writer.Log(_message);
        }
    }
}
