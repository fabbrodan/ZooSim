using System;
using System.Collections.Generic;
using ZooConsole.Interfaces;
using ZooSim.Interfaces;
using System.Linq;

namespace ZooConsole.Commands
{
    public class Feed : ICommand
    {
        private string _name;
        private IZooAnimals _animals;

        public Feed (IZooAnimals animals, params string[] inputAsArray)
        {
            _name = inputAsArray[1];
            _animals = animals;
        }
        public void Execute()
        {
            IAnimal animalToFeed = _animals.GetAnimals().First(a => a.GetName() == _name);
            animalToFeed.Eat();
        }
    }
}
