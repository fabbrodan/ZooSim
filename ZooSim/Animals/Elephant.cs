using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim.Animals
{
    public class Elephant : Animal
    {
        public Elephant(string Name, int Age) : base(Name, Age)
        {
            EnergyLevel = 15;
            nextUpdateTime = DateTime.Now.AddMinutes(1);
            Price = 250.00m;
        }
        public override void Eat()
        {
            HungerLevel = 0;
        }

        public override void Sleep()
        {
            EnergyLevel = 15;
        }

        public override void Update(DateTime gameTime)
        {
            UpdateAge(gameTime);
            if (gameTime > nextUpdateTime)
            {
                EnergyLevel--;
                HungerLevel++;
                nextUpdateTime = gameTime.AddMinutes(1);
            }
        }

        public override string GetState()
        {
            return "Elephant " + Name + " is " + Age + " years old. It is currently " + HungerLevel + " hungry and " + EnergyLevel + " energetic.";
        }
    }
}
