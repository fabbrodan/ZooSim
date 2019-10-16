using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Animals;

namespace ZooSim.Factories
{
    class MonkeyFactory : AnimalFactory
    {
        private string _name;
        private int _age;

        public MonkeyFactory(string Name, int Age)
        {
            _name = Name;
            _age = Age;
        }

        public override Animal GetAnimal()
        {
            return new Monkey(_name, _age);
        }
    }
}
