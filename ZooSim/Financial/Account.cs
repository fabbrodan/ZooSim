using ZooSim.Interfaces;

namespace ZooSim.Financial
{
    public class Account : IZooAccount
    {
        public decimal Balance;
        public decimal Loan;

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
                Balance -= 0;
            }
        }
    }
}
