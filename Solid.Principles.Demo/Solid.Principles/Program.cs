using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Solid.Principles
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IBankAccount, BankAccount>();
            container.RegisterType<IBankAccountService, BankAccountService>();
            container.RegisterType<IDeposit, Deposit>();
            container.RegisterType<ITransfer, Transfer>();

            Random rand = new Random();
            var number = rand.Next(100000000, 999999999);
            BankAccount savings = new SavingsAccount()
            {
                AccountNumber = number,
                Balance = (decimal)8904.67,
                FreeTransactions = 21
            };

            ShowSavingsStatement(savings);

            //BankAccountManager manager = new BankAccountManager(new Deposit(new BankAccountService()),
            //    new Transfer(new BankAccountService()));
            BankAccountManager manager = container.Resolve<BankAccountManager>();
            manager.DepositFunds(savings, (decimal)400.00);

            WriteYellowLine("Deposit was successful");
            ShowSavingsStatement(savings);
        }
        static void ShowSavingsStatement(BankAccount savings)
        {
            WriteYellowLine("----------------------------");
            WriteYellowLine("| Saving Account Statement  |");
            WriteYellowLine("----------------------------");
            Console.WriteLine("Account Number: {0}", savings.AccountNumber.ToString("##-####-##-#"));
            Console.WriteLine("Balance: {0:C}", savings.Balance);
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
