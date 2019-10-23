using System;

namespace ZooSim.Interfaces
{
    public interface IAnimal
    {
        void Eat();
        void Sleep();
        void Update(DateTime gameTime);
        string GetState();
        string GetName();
    }
}
