using System;
using System.Reflection;
using System.Collections.Generic;
using ZooConsole.Interfaces;
using ZooSim.Interfaces;
using ZooConsole.Utils;
using ZooSim.Animals;

namespace ZooConsole.Commands
{
    public class Add<T> : ICommand where T : IAnimal
    {
        private string _name;
        private int _age;
        //private IAnimalFactory<T> _factory;
        private IZooAnimals _animals;

        public Add(IZooAnimals animals, params string[] nameAndAge)
        {
            _name = nameAndAge[0];
            _ = Int32.TryParse(nameAndAge[1], out _age);
            //_factory = factory;
            _animals = animals;
        }

        public void Execute()
        {
            IAnimal animal = (T)Activator.CreateInstance(typeof(T), new object[] { _name, _age });
            //IAnimal animal = _factory.GetAnimal(_name, _age);
            _animals.Add(animal);
        }
    }
}
