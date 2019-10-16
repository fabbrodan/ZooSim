using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Animals;

namespace ZooSim.Factories
{
    class PenguinFactory : AnimalFactory
    {
        private string _name;
        private int _age;

        public PenguinFactory(string Name, int Age)
        {
            _name = Name;
            _age = Age;
        }
        public override Animal GetAnimal()
        {
            return new Penguin(_name, _age);
        }
    }
}
