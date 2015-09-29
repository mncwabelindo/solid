using System;

namespace Solid.Principles
{
    public class BankAccountService
    {
        private readonly BankAccount account;
        public BankAccountService(BankAccount bankAccount)
        {
            this.account = bankAccount;
        }
        
        public void AddFunds(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("The amount must be bigger than 0");

            account.Balance += value;
        }
        public void RemoveFunds(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("The amount must be bigger than 0");
            account.Balance -= value;
        }
    }

    public class Deposit
    {
        BankAccountService depositAccount;
        private readonly decimal value;
        public Deposit(BankAccount bankAccount, decimal amount)
        {
            depositAccount = new BankAccountService(bankAccount);
            value = amount;
        }

        public void DepositFunds()
        {
            depositAccount.AddFunds(value);
        }
    }

    public class Transfer
    {
        BankAccountService sourceAccount;
        BankAccountService destinationAccount;
        private readonly decimal value;

        public Transfer(BankAccount source, BankAccount destination, decimal _value)
        {
            sourceAccount = new BankAccountService(source);
            destinationAccount = new BankAccountService(destination);
            this.value = _value;
        }
        public void TransferFunds()
        {
            sourceAccount.RemoveFunds(value);
            destinationAccount.AddFunds(value);
        }
    }
}
