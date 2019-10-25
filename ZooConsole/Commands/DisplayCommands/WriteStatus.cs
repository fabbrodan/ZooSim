using System;
using ZooConsole.Interfaces;
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
                if (_animals.GetAnimals().Count > 0)
                {
                    foreach (IAnimal animal in _animals.GetAnimals())
                    {
                        sb.AppendLine(animal.GetState());
                    }
                }
                else
                {
                    sb.Append("No animals in the Zoo!");
                }
                _message = sb.ToString();
            }
            else
            {
                IAnimal animal = null;
                try
                {
                     animal = _animals.GetAnimals().First(a => a.GetName() == _param);
                    _message = animal.GetState();
                }
                catch (InvalidOperationException)
                {
                    _message = "No animal with the name " + _param + "!";
                }
            }

            _writer.Log(_message);
        }
    }
}
