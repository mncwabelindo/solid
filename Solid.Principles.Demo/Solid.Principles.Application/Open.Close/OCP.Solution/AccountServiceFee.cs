using System.Collections.Generic;

namespace Solid.Principles.Demo.OCP.Solution
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
            bankAccount.DeductServiceFees();
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
                total += bankAccount.ServiceFee;
            }
            return total;
        }
    }
}
