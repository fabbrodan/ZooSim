using System;
using System.Collections.Generic;
using System.Text;

namespace ZooSim.Animals
{
    class Monkey : Animal
    {
        public Monkey(string Name, int Age) : base(Name, Age)
        {
            EnergyLevel = 25;
        }
        public override void Eat()
        {
            HungerLevel = 0;
        }

        public override string GetState()
        {
            return "Monkey " + Name + " is " + Age + " years old. It is currently " + HungerLevel + " hungry and " + EnergyLevel + " energetic.";
        }

        public override void Sleep()
        {
            EnergyLevel = 10;
        }

        public override void Update(DateTime gameTime)
        {
            if (gameTime > nextUpdateTime)
            {
                HungerLevel++;
                EnergyLevel--;
                nextUpdateTime = gameTime.AddMinutes(4);
            }
        }
    }
}
