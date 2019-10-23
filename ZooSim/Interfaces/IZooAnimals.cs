using System;
using System.Collections.Generic;
using System.Text;

namespace ZooSim.Interfaces
{
    public interface IZooAnimals
    {
        List<IAnimal> GetAnimals();
        void Add(IAnimal animal);
        void Remove(IAnimal animal);
    }
}
