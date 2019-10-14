using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Interfaces;

namespace ZooSim.Animals
{
    public abstract class Animal : IAnimal
    {
        protected string Name { get; set; }
        protected int Age { get; set; }
        protected int HungerLevel { get; set; }
        protected int EnergyLevel { get; set; }
        protected Animal(string Name, int Age)
        {
            HungerLevel = 0;
            this.Name = Name;
            this.Age = Age;
        }
        public abstract void Eat();

        public abstract void Sleep();

        public abstract void Update();
        public abstract string GetState();
    }
}
