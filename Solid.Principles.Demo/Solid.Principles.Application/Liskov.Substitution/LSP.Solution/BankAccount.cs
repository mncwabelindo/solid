using System;   

namespace Solid.Principles.Demo.LSP.Solution
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

        public override void DeductServiceFees()
        {
            Balance -= (decimal)79.00;
        }
    }
    // Add to demostrate Liskov Substitution Principle
    public class JoinedSavingsAccount : SavingsAccount
    {
        
        public override void DeductServiceFees()
        {
            Balance -= (decimal)7.00 + ((decimal)7.00 * (decimal)0.1);
        }
    }
}
