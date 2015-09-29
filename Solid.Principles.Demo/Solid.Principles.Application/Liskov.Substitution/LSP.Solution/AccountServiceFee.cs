using System.Collections.Generic;

namespace Solid.Principles.Demo.LSP.Solution
{
    public class AccountServiceFee
    {
        public void DeductServiceFee(BankAccount account)
        {
            account.DeductServiceFees();
        }
        public decimal CalculateTotalFees(List<BankAccount> bankAccounts)
        {
            decimal total = (decimal)0.00;

            foreach (var account in bankAccounts)
            {
                total += account.ServiceFee;
            }
            return total;
        }
    }
}
