using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Animals;

namespace ZooSim.Factories
{
    abstract class AnimalFactory
    {
        public abstract Animal GetAnimal();
    }
}
