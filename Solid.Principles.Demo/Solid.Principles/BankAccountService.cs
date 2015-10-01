using System;

namespace Solid.Principles
{
    public interface IBankAccountService
    {
        void AddFunds(BankAccount account, decimal value);
        void RemoveFunds(BankAccount account, decimal value);
    }
    public class BankAccountService : IBankAccountService
    {

        public void AddFunds(BankAccount account, decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("The amount must be bigger than 0");

            account.Balance += value;
        }
        public void RemoveFunds(BankAccount account, decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("The amount must be bigger than 0");
            account.Balance -= value;
        }
    }

    public interface IDeposit
    {
        void DepositFunds(BankAccount account, decimal value);
    }
    public class Deposit : IDeposit
    {
        public Deposit(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }
        IBankAccountService _bankAccountService;

        public void DepositFunds(BankAccount account, decimal value)
        {
            _bankAccountService.AddFunds(account, value);
        }
    }

    public interface ITransfer
    {
        void TransferFunds(BankAccount sourceAccount, BankAccount destinationAccount, decimal value);
    }
    public class Transfer : ITransfer
    {
        public Transfer(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }
        IBankAccountService _bankAccountService;

        public void TransferFunds(BankAccount sourceAccount, BankAccount destinationAccount, decimal value)
        {
            _bankAccountService.RemoveFunds(sourceAccount, value);
            _bankAccountService.AddFunds(destinationAccount, value);
        }
    }

    public  interface IServiceFeeDeduction
    {
        void DeductServiceFee(BankAccount account);
    }
    public class ServiceFeeDeduction : IServiceFeeDeduction
    {
        public void DeductServiceFee(BankAccount account)
        {
            account.DeductServiceFee();
        }
    }
}
