using ZooSim.Interfaces;
using System;

namespace ZooSim.Financial
{
    public class Account : IZooAccount
    {
        private decimal _balance;
        private decimal _loan;
        private static readonly decimal _interest = 0.15m;
        private DateTime _nextInterestTime = DateTime.Now.AddMinutes(5);

        public Account(decimal balance)
        {
            _balance = balance;
            _loan = 0.00m;
        }

        public void AddFunds(decimal amount)
        {
            _balance += amount;
        }

        public void AddLoan(decimal amount)
        {
            AddFunds(amount);
            _loan += amount;
        }

        public decimal GetBalance() => _balance;

        public decimal GetLoan() => _loan;

        public void PayLoan(decimal amount)
        {
            if (_balance - amount > 0 && _loan >= amount)
            {
                RemoveFunds(amount);
                _loan -= amount;
            }
        }

        public void RemoveFunds(decimal amount)
        {
            if (_balance - amount >= 0)
            {
                _balance -= amount;
            }
        }

        public bool CanRemoveFunds(decimal amount)
        {
            return _balance - amount >= 0;
        }

        public void WithdrawInterest(DateTime gameTime)
        {
            if (gameTime >= _nextInterestTime)
            {
                _nextInterestTime = _nextInterestTime.AddMinutes(5);
                _balance -= _loan * _interest;
            }
        }
    }
}
