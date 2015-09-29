using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region SRP Solution
/*
namespace Solid.Principles.Demo.SRP.Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1- Create a savings account
            WriteYellowLine("---------------------------");
            WriteYellowLine("| Savings Account Details |");
            WriteYellowLine("---------------------------");

            Random rand = new Random();
            int accNo = rand.Next(100000000, 999999999);
            decimal balance = (decimal)814.85;
            int freeTransaction = 10;

            SavingsAccount savings = new SavingsAccount(accNo, balance, freeTransaction);
            Console.WriteLine("Account Number: {0}", savings.AccountNumber.ToString("###-####-##"));
            Console.WriteLine("Balance : {0:C}", savings.Balance);
            Console.WriteLine("Free Transactions: {0}", savings.FreeTransactions);
            Console.WriteLine();
            // 2- Create a cheque account
            WriteYellowLine("---------------------------");
            WriteYellowLine("| Cheque Account Details |");
            WriteYellowLine("---------------------------");

            accNo = rand.Next(100000000, 999999999);
            balance = (decimal)158.64;
            ChequeAccount cheque = new ChequeAccount(accNo, balance);

            Console.WriteLine("Account Number: {0}", cheque.AccountNumber.ToString("###-####-##"));
            Console.WriteLine("Balance : {0:C}", cheque.Balance);
            Console.WriteLine("Expire Date: {0}", cheque._ExpireDate);
            Console.WriteLine();
            // 3- Perform funds transfer between the two accounts
            WriteYellowLine("--------------------------------------------");
            WriteYellowLine("| Transferring Funds  From Savings to Cheque |");
            WriteYellowLine("--------------------------------------------");

            decimal transferAmt = (decimal)100.00;
            Console.WriteLine("Amount to transfer: {0:C}", transferAmt);
            Transfer trans = new Transfer(savings, cheque, transferAmt);
            trans.TransferFunds();

            Console.WriteLine("Account Number: {0}", savings.AccountNumber.ToString("###-####-##"));
            Console.WriteLine("Balance : {0:C}", savings.Balance);
            Console.WriteLine("Account Number: {0}", cheque.AccountNumber.ToString("###-####-##"));
            Console.WriteLine("Balance : {0:C}", cheque.Balance);
            Console.WriteLine();
            // 4- Perform deposit to cheque account
            WriteYellowLine("----------------------------------");
            WriteYellowLine("| Deposit Funds To Cheque Account |");
            WriteYellowLine("----------------------------------");

            decimal depositAmt = (decimal)5600.00;
            Console.WriteLine("Amount to deposit: {0:C}", depositAmt);
            Deposit dep = new Deposit(cheque, depositAmt);
            dep.DepositFunds();

            Console.WriteLine("Account Number: {0}", cheque.AccountNumber.ToString("###-####-##"));
            Console.WriteLine("Balance : {0:C}", cheque.Balance);
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
*/
#endregion

#region OCP Solution

namespace Solid.Principles.Demo.OCP.Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1- Create a savings account
            WriteYellowLine("---------------------------");
            WriteYellowLine("| Savings Account Details |");
            WriteYellowLine("---------------------------");

            Random rand = new Random();
            int accNo = rand.Next(100000000, 999999999);
            decimal balance = (decimal)814.85;
            int freeTransaction = 10;

            SavingsAccount savings = new SavingsAccount(accNo, balance, (decimal)7.00, freeTransaction);
            Console.WriteLine("Account Number: {0}", savings.AccountNumber.ToString("###-####-##"));
            Console.WriteLine("Balance : {0:C}", savings.Balance);
            Console.WriteLine("Free Transactions: {0}", savings.FreeTransactions);
            Console.WriteLine();
            // 2- Create a cheque account
            WriteYellowLine("---------------------------");
            WriteYellowLine("| Cheque Account Details |");
            WriteYellowLine("---------------------------");

            accNo = rand.Next(100000000, 999999999);
            balance = (decimal)480.64;
            ChequeAccount cheque = new ChequeAccount(accNo, balance, (decimal)79.00);

            Console.WriteLine("Account Number: {0}", cheque.AccountNumber.ToString("###-####-##"));
            Console.WriteLine("Balance : {0:C}", cheque.Balance);
            Console.WriteLine("Expire Date: {0}", cheque._ExpireDate);
            Console.WriteLine();
            // 3- Calculate total amount to be made on service fees
            WriteYellowLine("--------------------------------------");
            WriteYellowLine("| Calculate Monthly Service Fee Total |");
            WriteYellowLine("--------------------------------------");

            List<BankAccount> bankAccounts = new List<BankAccount>();
            bankAccounts.Add(savings);
            bankAccounts.Add(cheque);
            ServiceFeeCalculator calc = new ServiceFeeCalculator(bankAccounts);
            decimal total = calc.CalculateTotalFees();

            Console.WriteLine("Total : {0:C}", total);
            Console.WriteLine();
            // 4- Deduct service fees
            WriteYellowLine("--------------------------------------------");
            WriteYellowLine("| Deduct monthly service fees from accounts |");
            WriteYellowLine("--------------------------------------------");

            AccountServiceFee savingsFees = new AccountServiceFee(savings);
            savingsFees.DeductServiceFee();
            AccountServiceFee chequeFees = new AccountServiceFee(cheque);
            chequeFees.DeductServiceFee();

            Console.WriteLine("New Saving Account Balance: {0:C}", savings.Balance);
            Console.WriteLine("New Cheque Account Balance: {0:C}", cheque.Balance);
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

#endregion

#region LSP Solution
/*
namespace Solid.Principles.Demo.LSP.Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1- Create a fixed savings account
            WriteYellowLine("--------------------------------");
            WriteYellowLine("| Joined Savings Account Details |");
            WriteYellowLine("--------------------------------");

            Random rand = new Random();
            int accNo = rand.Next(100000000, 999999999);
            decimal balance = (decimal)316000.00;

            BankAccount joinedSavings = new JoinedSavingsAccount()
            {
                AccountNumber = accNo,
                Balance = balance,
                FreeTransactions = 22
            };
            Console.WriteLine("Account Number: {0}", joinedSavings.AccountNumber.ToString("###-####-##"));
            Console.WriteLine("Balance : {0:C}", joinedSavings.Balance);
            Console.WriteLine();
            // 2- Deduct service fees from fixed savings account
            WriteYellowLine("--------------------------------------------------");
            WriteYellowLine("| Deduct Service Fees From Joined Savings Account |");
            WriteYellowLine("--------------------------------------------------");

            AccountServiceFee service = new AccountServiceFee();
            service.DeductServiceFee(joinedSavings);
            Console.WriteLine("Account Number: {0}", joinedSavings.AccountNumber.ToString("###-####-##"));
            Console.WriteLine("Balance : {0:C}", joinedSavings.Balance);
            Console.WriteLine();
        }

        private static void WriteYellowLine(string v)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(v);
            Console.ResetColor();
        }
    }
}
*/
#endregion




#region Single Responsibity Principle
/*
------------------------------------
SRP.Violation
------------------------------------
class BankAccount
    var AccountNumber
    var Balance

    AddFunds()
    RemoveFunds()
    TransferFunds()

------------------------------------
SRP.Solution
------------------------------------
abstract class BankAccount
    prop AccountNumber
    prop Balance

clas SavingsAccount : BankAccount
    prop FreeTransactions

class ChequeAccount : BankAccount
    prop ExpireDate

class Transfer
    var sourceAccount
    var destinationAccount
    var value
    
    TransferFunds()

class Deposit
    var depositAccount
    var value

    DepositFunds()

class BankAccountService
    var account

    AddFunds()
    RemoveFunds()
*/
#endregion

#region Open Close Principle
/*
------------------------------------
OCP.Violation
------------------------------------
class abstract BankAccount
    var AccountNumber
    var Balance
class SavingsAccount : BankAccount
    var FreeTransactions

class ChequeAccount : BankAccount
    var ExpireDate

class BankAccountService
    var account

    AddFunds()
    RemoveFunds()
class Transfer
    var sourceAccount
    var destinationAccount
    var value
    
    TransferFunds()
class Deposit
    var depositAccount
    var value

    DepositFunds()

class AccountServiceFee
    var object bankAccount

    DeductServiceFee()
class ServiceFeeCalculator
    var bankAccounts

    CalculateTotalFees()

------------------------------------
OCP.Solution
------------------------------------
class abstract BankAccount
    var AccountNumber
    var Balance
    var ServiceFee

    abstract DeductServiceFee()
class SavingsAccount : BankAccount
    var FreeTransactions

    DeductServiceFee()
class ChequeAccount : BankAccount
    var ExpireDate

    DeductServiceFee();
class BankAccountService
    var account

    AddFunds()
    RemoveFunds()
class Transfer
    var sourceAccount
    var destinationAccount
    var value
    
    TransferFunds()
class Deposit
    var depositAccount
    var value

    DepositFunds()

class AccountServiceFee
    var object bankAccount

    DeductServiceFee()
class ServiceFeeCalculator
    var bankAccounts

    CalculateTotalFees()
*/
#endregion