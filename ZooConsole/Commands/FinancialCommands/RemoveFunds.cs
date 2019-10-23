using System;
using System.Collections.Generic;
using System.Text;
using ZooConsole.Interfaces;
using ZooSim.Financial;
using ZooSim.Interfaces;

namespace ZooConsole.Commands
{
    class RemoveFunds : ICommand
    {
        private IZooAccount _account;
        private decimal _amount;

        public RemoveFunds(IZooAccount account, params string[] paramArray)
        {
            _account = account;
            _ = decimal.TryParse(paramArray[1], out _amount);
        }

        public void Execute()
        {
            _account.RemoveFunds(_amount);
        }
    }
}
