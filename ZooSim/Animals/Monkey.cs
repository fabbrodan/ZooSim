using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim.Animals
{
    class Monkey : Animal
    {
        public Monkey(string Name, int Age) : base(Name, Age)
        {
            EnergyLevel = 25;
            nextUpdateTime = DateTime.Now.AddMinutes(2);
            Price = 75.00m;
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

        public override async Task Update(DateTime gameTime)
        {
            await Task.Run(async () =>
            {
                await UpdateAge(gameTime);
                if (gameTime > nextUpdateTime)
                {
                    HungerLevel++;
                    EnergyLevel--;
                    nextUpdateTime = gameTime.AddMinutes(4);
                }
            });
        }
    }
}
