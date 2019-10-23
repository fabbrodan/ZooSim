using System;
using System.Collections.Generic;
using System.Text;
using ZooConsole.Interfaces;
using ZooSim.Financial;
using ZooSim.Interfaces;

namespace ZooConsole.Commands
{
    class AddFunds : ICommand
    {
        private IZooAccount _account;
        private decimal _amount;

        public AddFunds(IZooAccount account, params string[] paramArr)
        {
            _account = account;
            _ = decimal.TryParse(paramArr[1], out _amount);
        }

        public void Execute()
        {
            _account.AddFunds(_amount);
        }
    }
}
