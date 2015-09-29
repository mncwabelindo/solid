using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Principles.Initial
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }

        public void DepositFunds(decimal value)
        {
            Balance += value;
        }
        public void WithdrawFunds(decimal value)
        {
            Balance -= value;
        }
        public void TransferFunds(BankAccount toAccount, decimal value)
        {
            this.WithdrawFunds(value);
            toAccount.DepositFunds(value);
        }
    }
}
