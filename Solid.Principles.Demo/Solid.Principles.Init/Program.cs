using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Principles.Initial
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1- Create savings account
            Random rand = new Random();
            var accno = rand.Next(100000000, 900000000);
            BankAccount savings = new BankAccount()
            {
                AccountNumber = accno,
                Balance = (decimal)56988.34
            };

            WriteYellowLine("-------------------------");
            WriteYellowLine("| Saving Account Details |");
            WriteYellowLine("-------------------------");
            Console.WriteLine("Account Number: {0}", savings.AccountNumber.ToString("##-#####-##"));
            Console.WriteLine("Balance: {0:C}", savings.Balance);
            Console.WriteLine();
            // 2- Deposit funds into savings account
            savings.DepositFunds(350);
            WriteYellowLine("Funds deposited into savings account...");
            // 3- Display new savings account balance
            Console.WriteLine("Account Number: {0}", savings.AccountNumber.ToString("##-#####-##"));
            Console.WriteLine("New Balance: {0:C}", savings.Balance);
            Console.WriteLine();
            // 3- Withdraw funds from savings account
            savings.WithdrawFunds(1500);
            WriteYellowLine("Funds withdrawn from savings account...");
            // 4- Display new savings account balance
            Console.WriteLine("Account Number: {0}", savings.AccountNumber.ToString("##-#####-##"));
            Console.WriteLine("New Balance: {0:C}", savings.Balance);
            Console.WriteLine();
            // 5- Create cheque account
            accno = rand.Next(100000000, 999999999);
            BankAccount cheque = new BankAccount()
            {
                AccountNumber = accno,
                Balance = (decimal)33456.33
            };

            WriteYellowLine("-------------------------");
            WriteYellowLine("| Cheque Account Details |");
            WriteYellowLine("-------------------------");
            Console.WriteLine("Account Number: {0}", cheque.AccountNumber.ToString("##-#####-##"));
            Console.WriteLine("Balance: {0:C}", cheque.Balance);
            Console.WriteLine();

            // 6- Transfer funds from savings to cheque account
            savings.TransferFunds(cheque, 20000);
            WriteYellowLine("Tranferred funds from savings to cheque...");
            Console.WriteLine("Savings Account Balance: {0:C}", savings.Balance);
            Console.WriteLine("Cheque Account Balance: {0:C}", cheque.Balance);
            Console.WriteLine();
        }
        static void WriteYellowLine(string line)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ResetColor();
        }
    }
}
