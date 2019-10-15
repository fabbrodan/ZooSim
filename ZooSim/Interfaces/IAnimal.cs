using System;
using System.Collections.Generic;
using System.Text;

namespace ZooSim.Interfaces
{
    public interface IAnimal
    {
        void Eat();
        void Sleep();
        void Update(DateTime gameTime);
        string GetState();
    }
}
