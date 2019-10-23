using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Interfaces;
using ZooSim.Animals;

namespace ZooSim.Factories
{
    public class MonkeyFactory : IAnimalFactory<Monkey>
    {
        public Monkey GetAnimal(string name, int age)
        {
            return new Monkey(name, age);
        }
    }
}
