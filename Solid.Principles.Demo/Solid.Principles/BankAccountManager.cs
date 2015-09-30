using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Principles
{
    public interface IBankAccountManager
    {
        void DepositFunds(BankAccount account, decimal value);
        void TransferFunds(BankAccount sourceAccount, BankAccount destinationAccount, decimal value);
    }
    public class BankAccountManager : IBankAccountManager
    {
        public BankAccountManager(IDeposit deposit, ITransfer transfer)
        {
            _deposit = deposit;
            _transfer = transfer;
        }
        IDeposit _deposit;
        ITransfer _transfer;

        public void DepositFunds(BankAccount account, decimal value)
        {
            _deposit.DepositFunds(account, value);
        }
        public void TransferFunds(BankAccount sourceAccount, BankAccount destinationAccount, decimal value)
        {
            _transfer.TransferFunds(sourceAccount, destinationAccount, value);
        }
    }
}
