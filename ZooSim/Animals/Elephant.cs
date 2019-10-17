using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim.Animals
{
    class Elephant : Animal
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
            EnergyLevel = 10;
        }

        public override async Task Update(DateTime gameTime)
        {
            await Task.Run(async () =>
            {
                await UpdateAge(gameTime);
                if (gameTime > nextUpdateTime)
                {
                    EnergyLevel--;
                    HungerLevel++;
                    nextUpdateTime = gameTime.AddMinutes(1);
                }
            });
        }

        public override string GetState()
        {
            return "Elephant " + Name + " is " + Age + " years old. It is currently " + HungerLevel + " hungry and " + EnergyLevel + " energetic.";
        }
    }
}
