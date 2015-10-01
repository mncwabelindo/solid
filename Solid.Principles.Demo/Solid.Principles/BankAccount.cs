using System;

namespace Solid.Principles
{
    public interface IBankAccount
    {
        void DeductServiceFee();
    }
    public abstract class BankAccount : IBankAccount
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public abstract void DeductServiceFee();
    }

    public class SavingsAccount : BankAccount
    {
        public int FreeTransactions { get; set; } // TO COMPLECATE CONSIDER THIS: free withdraws, free swipes, etc.. ALSO CONSIDER charges for each transaction after free changes have been depleted

        public override void DeductServiceFee()
        {
            Balance -= (decimal)15.00;
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

        public override void DeductServiceFee()
        {
            Balance -= (decimal)107.90;
        }
    }
}
