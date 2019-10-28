using System;
using System.Collections.Generic;
using System.Text;
using ZooSim.Interfaces;
using ZooSim.Financial;
using ZooSim.Animals;

namespace ZooSim
{
    public class Zoo : IZooAccount, IZooAnimals
    {
        public IZooAnimals Animals;
        public IZooAccount Account;

        public Zoo()
        {
            Animals = new ZooAnimals();
            Account = new Account(1000.00m);
        }

        public void Add(IAnimal animal)
        {
            Animals.Add(animal);
        }

        public void AddFunds(decimal amount)
        {
            Account.AddFunds(amount);
        }

        public void AddLoan(decimal amount)
        {
            Account.AddLoan(amount);
        }

        public List<IAnimal> GetAnimals()
        {
            return Animals.GetAnimals();
        }

        public decimal GetBalance()
        {
            return Account.GetBalance();
        }

        public decimal GetLoan()
        {
            return Account.GetLoan();
        }

        public void PayLoan(decimal amount)
        {
            Account.PayLoan(amount);
        }

        public void Remove(IAnimal animal)
        {
            Animals.Remove(animal);
        }

        public void RemoveFunds(decimal amount)
        {
            Account.RemoveFunds(amount);
        }

        public void WithdrawInterest(DateTime gameTime)
        {
            Account.WithdrawInterest(gameTime);
        }
    }
}
