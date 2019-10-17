using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Interfaces;
using System.Threading.Tasks;

namespace ZooSim.Animals
{
    public abstract class Animal : IAnimal
    {
        protected string Name { get; set; }
        protected int Age { get; set; }
        protected int HungerLevel { get; set; }
        protected int EnergyLevel { get; set; }
        public decimal Price { get; set; }
        protected DateTime nextUpdateTime;
        protected DateTime nextAgingTime = DateTime.Now.AddHours(24);
        protected Animal(string Name, int Age)
        {
            HungerLevel = 0;
            this.Name = Name;
            this.Age = Age;
        }
        public abstract void Eat();
        public abstract void Sleep();
        public async Task UpdateAge(DateTime gameTime)
        {
            await Task.Run(() =>
            {
                if (gameTime >= nextAgingTime)
                {
                    nextAgingTime = nextAgingTime.AddHours(24);
                    Age++;
                }
            });
        }
        public abstract Task Update(DateTime gameTime);
        public abstract string GetState();

        public string GetName()
        {
            return Name;
        }
    }
}
