using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Animals;

namespace ZooSim.Factories
{
    class ElephantFactory : AnimalFactory
    {
        private string _name;
        private int _age;

        public ElephantFactory(string Name, int Age)
        {
            _name = Name;
            _age = Age;
        } 
        public override Animal GetAnimal()
        {
            return new Elephant(_name, _age);
        }
    }
}
