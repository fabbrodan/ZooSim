using System;
using ZooConsole.Interfaces;
using ZooSim.Interfaces;

namespace ZooConsole.Commands
{
    public class Add<T> : ICommand where T : IAnimal
    {
        private string _name;
        private int _age;
        private IZooAnimals _animals;
        private IZooAccount _account;

        public Add(ZooSim.Zoo zoo, params string[] nameAndAge)
        {
            _name = nameAndAge[0];
            _ = Int32.TryParse(nameAndAge[1], out _age);
            _animals = zoo.Animals;
            _account = zoo.Account;
        }

        public void Execute()
        {
            IAnimal animal = (T)Activator.CreateInstance(typeof(T), new object[] { _name, _age });
            if (_account.CanRemoveFunds(animal.GetPrice()))
            {
                _account.RemoveFunds(animal.GetPrice());
                _animals.Add(animal);
            }
        }
    }
}
