using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Animals;
using ZooSim.Interfaces;


namespace ZooSim.Factories
{
    public class ElephantFactory : IAnimalFactory<Elephant>
    {
        public Elephant GetAnimal(string name, int age)
        {
            return new Elephant(name, age);
        }
    }
}
