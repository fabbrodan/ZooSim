using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Interfaces;

namespace ZooSim.Animals
{
    public class ZooAnimals : IZooAnimals
    {
        private List<IAnimal> _animalList;

        public ZooAnimals()
        {
            _animalList = new List<IAnimal>();
        }
        public void Add(IAnimal animal)
        {
            _animalList.Add(animal);
        }

        public List<IAnimal> GetAnimals() => _animalList;

        public void Remove(IAnimal animal)
        {
            _animalList.Remove(animal);
        }
    }
}
