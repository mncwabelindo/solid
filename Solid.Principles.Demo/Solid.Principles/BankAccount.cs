﻿using System;

namespace Solid.Principles
{
    public interface IBankAccount
    {
        void DeductBankCharges();
    }
    public abstract class BankAccount : IBankAccount
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public abstract void DeductBankCharges();
    }

    public class SavingsAccount : BankAccount
    {
        public int FreeTransactions { get; set; } // TO COMPLECATE CONSIDER THIS: free withdraws, free swipes, etc.. ALSO CONSIDER charges for each transaction after free changes have been depleted

        public override void DeductBankCharges()
        {
            Balance -= (decimal)7.55;
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

        public override void DeductBankCharges()
        {
            Balance -= (decimal)107.90;
        }
    }
}
