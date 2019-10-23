using ZooSim.Financial;
using ZooConsole.Interfaces;
using ZooSim.Interfaces;

namespace ZooConsole.Commands
{
    public class PayLoan : ICommand
    {
        private IZooAccount _account;
        private decimal _amount;

        public PayLoan(IZooAccount account, params string[] paramArr)
        {
            _account = account;
            _ = decimal.TryParse(paramArr[1], out _amount);
        }

        public void Execute()
        {
            _account.PayLoan(_amount);
        }

    }
}
