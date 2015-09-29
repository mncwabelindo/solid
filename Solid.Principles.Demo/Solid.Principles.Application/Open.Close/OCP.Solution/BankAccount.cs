using System;

namespace Solid.Principles.Demo.OCP.Solution
{
    public abstract class BankAccount
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal ServiceFee { get; set; }

        public abstract void DeductServiceFees();
    }

    public class SavingsAccount : BankAccount
    {
        public int FreeTransactions { get; set; } // TO COMPLECATE CONSIDER THIS: free withdraws, free swipes, etc.. ALSO CONSIDER charges for each transaction after free changes have been depleted
        public SavingsAccount(int accNo, decimal balance, decimal serviceFee, int freeTransactions)
        {
            AccountNumber = accNo;
            Balance = balance;
            ServiceFee = serviceFee;
            FreeTransactions = freeTransactions;
        }

        public override void DeductServiceFees()
        {
            Balance -= (decimal)7.00;
        }
    }

    public class ChequeAccount : BankAccount
    {
        private DateTime ExpireDate;
        public DateTime _ExpireDate
        {
            get { return ExpireDate; }
            private set
            {
                ExpireDate = value;
            }
        }
        public ChequeAccount(int accNo, decimal balance, decimal serviceFee)
        {
            AccountNumber = accNo;
            Balance = balance;
            ServiceFee = serviceFee;
            _ExpireDate = DateTime.Now.AddMonths(50);
        }

        public override void DeductServiceFees()
        {
            Balance -= (decimal)79.00;
        }
    }
}
