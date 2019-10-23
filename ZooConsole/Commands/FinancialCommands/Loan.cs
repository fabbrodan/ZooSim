using System;
using ZooConsole.Interfaces;
using ZooSim.Financial;
using ZooSim.Interfaces;

namespace ZooConsole.Commands
{
    class Loan : ICommand
    {
        private IZooAccount _account;
        private decimal _amount;

        public Loan(IZooAccount account, params string[] paramArr)
        {
            _account = account;
            _ = decimal.TryParse(paramArr[1], out _amount);
        }
        public void Execute()
        {
            _account.AddLoan(_amount);
        }
    }
}
