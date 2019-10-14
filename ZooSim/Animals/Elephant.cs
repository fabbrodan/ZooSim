using System;
using System.Collections.Generic;
using System.Text;

namespace ZooSim.Animals
{
    class Elephant : Animal
    {
        public Elephant(string Name, int Age) : base(Name, Age)
        {
            EnergyLevel = 15;
        }
        public override void Eat()
        {
            HungerLevel = 0;
        }

        public override void Sleep()
        {
            EnergyLevel = 10;
        }

        public override void Update()
        {
            EnergyLevel--;
            HungerLevel++;
        }

        public override string GetState()
        {
            return "Elephant " + Name + " is " + Age + " years old. It is currently " + HungerLevel + " hungry and " + EnergyLevel + " energetic.";
        }
    }
}
