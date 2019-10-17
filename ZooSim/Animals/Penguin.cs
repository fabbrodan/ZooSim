using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim.Animals
{
    public class Penguin : Animal
    {
        public Penguin(string Name, int Age) : base(Name, Age)
        {
            HungerLevel = 0;
            EnergyLevel = 15;
            nextUpdateTime = DateTime.Now.AddMinutes(5);
            Price = 90.00m;
        }
        public override void Eat()
        {
            HungerLevel = 0;
        }

        public override string GetState()
        {
            return "Penguin " + Name + " is " + Age + " years old. It is currently " + HungerLevel + " hungry and " + EnergyLevel + " energetic.";
        }

        public override void Sleep()
        {
            EnergyLevel = 15;
        }

        public override async Task Update(DateTime gameTime)
        {
            await Task.Run(async () =>
            {
                await UpdateAge(gameTime);
                if (gameTime > nextUpdateTime)
                {
                    HungerLevel++;
                    EnergyLevel--;
                    nextUpdateTime = gameTime.AddMinutes(5);
                }
            });
        }
    }
}
