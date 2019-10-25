using System;
using System.Linq;
using ZooConsole.Interfaces;
using ZooSim.Interfaces;

namespace ZooConsole.Commands
{
    public class Sleep : ICommand
    {
        private IZooAnimals _animals;
        private string _name;

        public Sleep(IZooAnimals animals, params string[] param)
        {
            _animals = animals;
            _name = param[1];
        }
        public void Execute()
        {
            IAnimal animal = null;
            try
            {
                animal = _animals.GetAnimals().First(a => a.GetName() == _name);
                animal.Sleep();
            }
            catch (InvalidOperationException)
            {
                return;
            }
        }
    }
}
