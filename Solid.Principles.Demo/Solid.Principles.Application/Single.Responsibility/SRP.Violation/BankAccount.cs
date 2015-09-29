using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Principles.Demo.SRP.Violate
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }

        public void AddFunds(decimal value)
        {
            Balance += value;
        }
        public void RemoveFunds(decimal value)
        {
            Balance -= value;
        }
        public void Transfer() 
        {
            Console.WriteLine("Removed Funds From Source Account.");
            Console.WriteLine("Added Funds To Destination Account.");
        }
        public void Deposit()
        {
            Console.WriteLine("Added Funds To Deposit Account.");
        }
    }
}
