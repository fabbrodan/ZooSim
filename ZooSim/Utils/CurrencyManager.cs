using System;
using System.Collections.Generic;
using System.Text;

namespace ZooSim.Utils
{
    public class CurrencyManager
    {
        private decimal _money;

        public CurrencyManager (decimal money)
        {
            _money = money;
        }

        public void Add(decimal value)
        {
            _money += value;
        }

        public void Sub(decimal value)
        {
            _money -= value;
        }
    }
}
