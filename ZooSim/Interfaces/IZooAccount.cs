using System;
using System.Collections.Generic;
using System.Text;

namespace ZooSim.Interfaces
{
    public interface IZooAccount
    {
        void RemoveFunds(decimal amount);
        void AddFunds(decimal amount);
        void AddLoan(decimal amount);
        void PayLoan(decimal amount);
        decimal GetBalance();
        decimal GetLoan();
        void WithdrawInterest(DateTime gameTime);
    }
}
