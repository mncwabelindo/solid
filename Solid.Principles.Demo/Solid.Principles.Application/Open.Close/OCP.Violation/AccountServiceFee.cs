using System.Collections.Generic;

namespace Solid.Principles.Demo.OCP.Violation
{
    public class AccountServiceFee
    {
        private readonly BankAccount bankAccount;
        public AccountServiceFee(BankAccount account)
        {
            bankAccount = account;
        }

        public void DeductServiceFee()
        {            
            if(bankAccount is SavingsAccount)
            {                
                bankAccount.Balance -= (decimal)7.00;
            }
            else
            {                
                bankAccount.Balance -= (decimal)79.00;
            }
        }
    }

    public class ServiceFeeCalculator
    {
        private readonly List<BankAccount> _bankAccounts;
        public ServiceFeeCalculator(List<BankAccount> bankAccounts)
        {
            _bankAccounts = bankAccounts;
        }

        public decimal CalculateTotalFees()
        {
            decimal total = (decimal)0.00;

            foreach (var bankAccount in _bankAccounts)
            {
                if (bankAccount is SavingsAccount)
                    total += (decimal)7.00;
                else
                    total += (decimal)79.00;
            }
            return total;
        }
    }
}
