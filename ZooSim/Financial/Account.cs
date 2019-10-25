using ZooSim.Interfaces;
using System;

namespace ZooSim.Financial
{
    public class Account : IZooAccount
    {
        public decimal Balance;
        public decimal Loan;
        private static readonly decimal _interest = 0.15m;
        private DateTime _nextInterestTime = DateTime.Now.AddMinutes(5);

        public Account(decimal balance)
        {
            Balance = balance;
            Loan = 0.00m;
        }

        public void AddFunds(decimal amount)
        {
            Balance += amount;
        }

        public void AddLoan(decimal amount)
        {
            AddFunds(amount);
            Loan += amount;
        }

        public decimal GetBalance() => Balance;

        public decimal GetLoan() => Loan;

        public void PayLoan(decimal amount)
        {
            if (Balance - amount > 0)
            {
                RemoveFunds(amount);
                Loan -= amount;
            }
        }

        public void RemoveFunds(decimal amount)
        {
            if (Balance - amount > 0)
            {
                Balance -= amount;
            }
        }

        public void WithdrawInterest(DateTime gameTime)
        {
            if (gameTime >= _nextInterestTime)
            {
                _nextInterestTime = _nextInterestTime.AddMinutes(5);
                Balance -= Loan * _interest;
            }
        }
    }
}
