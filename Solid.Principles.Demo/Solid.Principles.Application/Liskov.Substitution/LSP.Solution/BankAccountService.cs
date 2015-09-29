using System;

namespace Solid.Principles.Demo.LSP.Solution
{
    public class BankAccountService
    {                
        private void AddFunds(BankAccount account,decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("The amount must be bigger than 0");
            
            account.Balance += value;
        }
        private void RemoveFunds(BankAccount account,decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("The amount must be bigger than 0");
            if (value > account.Balance)
                throw new Exception("Insuficient funds!");

            account.Balance -= value;
        }

        public void DepositFunds(BankAccount account,decimal value)
        {
            AddFunds(account,value);
        }
        public void TransferFunds(BankAccount fromAccount,BankAccount toAccount,decimal value)
        {
            RemoveFunds(fromAccount, value);
            AddFunds(toAccount, value);
        }
        public void WithdrawFunds(BankAccount account,decimal value)
        {
            RemoveFunds(account, value);
        }
    }
}
