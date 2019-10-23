using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Animals;
using ZooSim.Interfaces;

namespace ZooSim.Factories
{
    public class PenguinFactory : IAnimalFactory<Penguin>
    {
        public Penguin GetAnimal(string name, int age)
        {
            return new Penguin(name, age);
        }
    }
}
