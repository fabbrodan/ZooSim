using System.Collections.Generic;
using ZooSim.Interfaces;
using ZooConsole.Interfaces;
using System.Linq;

namespace ZooConsole.Commands
{
    public class Kill : ICommand
    {
        private string _name;
        private IZooAnimals _animals;

        public Kill(IZooAnimals animals, params string[] inputAsArray)
        {
            _name = inputAsArray[1];
            _animals = animals;
        }
        public void Execute()
        {
            if (_animals.GetAnimals().Count > 0)
            {
                IAnimal animalToRemove = _animals.GetAnimals().First(a => a.GetName() == _name);
                _animals.Remove(animalToRemove);
            }
        }
    }
}
