using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim.Interfaces
{
    public interface IAnimal
    {
        void Eat();
        void Sleep();
        Task Update(DateTime gameTime);
        string GetState();
        string GetName();
    }
}
