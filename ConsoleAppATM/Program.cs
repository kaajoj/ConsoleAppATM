using System;

namespace ConsoleAppATM
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal accountBalance = 1000.00m;  
            bool clientCardOwnsByBank = true;  
            Console.WriteLine("Balance before withdraw: " + accountBalance);

            Console.Write("Amount to withdraw: ");
            var moneyToWithdraw = Convert.ToDecimal(Console.ReadLine());

            accountBalance = withdrawMoney(moneyToWithdraw, accountBalance, clientCardOwnsByBank);
            Console.WriteLine("Account balance after operation: " + accountBalance);
            
            Console.ReadLine();
        }

        private static decimal withdrawMoney(decimal moneyToWithdraw, decimal accountBalance, bool clientCardOwnsByBank)
        {
            decimal fee = 5.00m;
            decimal withdrawAmount;

            if (moneyToWithdraw % 10 != 0)
            {
                withdrawAmount = Math.Round(moneyToWithdraw / 10) * 10;
            }
            else withdrawAmount = moneyToWithdraw;

            Console.WriteLine("Withdraw amount rounded to 10 EUR: " + withdrawAmount);

            if (withdrawAmount <= 0)
            {
                return accountBalance;
            }

            if (clientCardOwnsByBank)
            {
                fee = 0.00m;
            }
            else
            {
                if (withdrawAmount <= 100)
                {
                    fee = (decimal)0.1 * withdrawAmount;
                    if (fee < 5)
                    {
                        fee = 5.00m;
                    }
                } else if (withdrawAmount > 100)
                {
                    fee = (decimal)0.05 * withdrawAmount;
                }
            }

            if (accountBalance >= (withdrawAmount + fee))
            {
                accountBalance -= (withdrawAmount + fee);
                Console.WriteLine("Transaction fee: " + fee);
            }
            else
            {
                Console.WriteLine("No enough money.");
            }

            return accountBalance;
        }
    }
}
