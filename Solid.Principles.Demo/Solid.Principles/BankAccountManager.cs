using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Principles
{
    public class BankAccountManagerA
    {
        public BankAccountManagerA(IDeposit deposit, ITransfer transfer)
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
    
    public class BankAccountManagerB : BankAccountManagerA
    {
        public BankAccountManagerB(IDeposit deposit, ITransfer transfer, IProcessCharges processCharges) : base(deposit, transfer)
        {
            _deposit = deposit;
            _transfer = transfer;
            _processCharges = processCharges;
        }
        IDeposit _deposit;
        ITransfer _transfer;
        IProcessCharges _processCharges;

        public void ProcessCharges(BankAccount account)
        {
            _processCharges.ProcessAccountCharges(account);
        }
    }
}
