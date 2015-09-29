using System;

namespace Solid.Principles.Demo.SRP.Solution
{
    public abstract class BankAccount
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }

    public class SavingsAccount : BankAccount
    {
        public int FreeTransactions { get; set; } // TO COMPLECATE CONSIDER THIS: free withdraws, free swipes, etc.. ALSO CONSIDER charges for each transaction after free changes have been depleted
        public SavingsAccount(int accNo, decimal balance, int freeTransactions)
        {
            AccountNumber = accNo;
            Balance = balance;
            FreeTransactions = freeTransactions;
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
        public ChequeAccount(int accNo, decimal balance)
        {
            AccountNumber = accNo;
            Balance = balance;
            _ExpireDate = DateTime.Now.AddMonths(50);
        }
    }
}
