using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBankingSystem
{
    #region Custom Exceptions
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
    public class MinimumBalanceException : Exception
    {
        public MinimumBalanceException(string message) : base(message) { }
    }
    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException(string message) : base(message) { }
    }
    #endregion

    #region Abstract Base Class
    public abstract class BankAccount
    {
        public string AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; protected set; }
        public List<string> TransactionHistory { get; set; } = new List<string>();

        protected BankAccount(string accNo, string name, double balance)
        {
            AccountNumber = accNo;
            CustomerName = name;
            Balance = balance;
        }
        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
                throw new InvalidTransactionException("Deposit amount must be positive.");

            Balance += amount;
            TransactionHistory.Add($"Deposited: {amount}");
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new InvalidTransactionException("Withdrawal amount must be positive.");

            if (amount > Balance)
                throw new InsufficientBalanceException("Insufficient balance.");

            Balance -= amount;
            TransactionHistory.Add($"Withdrawn: {amount}");
        }

        public abstract double CalculateInterest();
        public void ShowTransactions()
        {
            Console.WriteLine($"Transactions for {AccountNumber}");
            foreach (var t in TransactionHistory)
                Console.WriteLine(t);
        }
    }
    #endregion

    #region Derived Classes
    public class SavingsAccount : BankAccount
    {
        private const double MinimumBalance = 1000;
        private const double InterestRate = 0.04;

        public SavingsAccount(string accNo, string name, double balance)
            : base(accNo, name, balance)
        {
            if (balance < MinimumBalance)
                throw new MinimumBalanceException("Initial balance below minimum.");
        }
        public override void Withdraw(double amount)
        {
            if ((Balance - amount) < MinimumBalance)
                throw new MinimumBalanceException("Minimum balance violation.");

            base.Withdraw(amount);
        }
        public override double CalculateInterest()
        {
            return Balance * InterestRate;
        }
    }

    public class CurrentAccount : BankAccount
    {
        private const double OverdraftLimit = 20000;

        public CurrentAccount(string accNo, string name, double balance)
            : base(accNo, name, balance) { }

        public override void Withdraw(double amount)
        {
            if ((Balance + OverdraftLimit) < amount)
                throw new InsufficientBalanceException("Overdraft limit exceeded.");

            Balance -= amount;
            TransactionHistory.Add($"Withdrawn: {amount}");
        }

        public override double CalculateInterest()
        {
            return 0; // No interest
        }
    }

    public class LoanAccount : BankAccount
    {
        private const double InterestRate = 0.08;

        public LoanAccount(string accNo, string name, double balance)
            : base(accNo, name, balance) { }

        public override void Deposit(double amount)
        {
            throw new InvalidTransactionException("Cannot deposit in loan account.");
        }

        public override double CalculateInterest()
        {
            return Balance * InterestRate;
        }
    }

    #endregion

    class Program
    {
        static List<BankAccount> accounts = new List<BankAccount>();

        static void Main(string[] args)
        {
            SeedData();

            while (true)
            {
                Console.WriteLine("\n=== SMART BANKING SYSTEM ===");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Show All Accounts");
                Console.WriteLine("6. LINQ Reports");
                Console.WriteLine("7. Exit");
                Console.Write("Choice: ");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1": CreateAccount(); break;
                        case "2": Deposit(); break;
                        case "3": Withdraw(); break;
                        case "4": Transfer(); break;
                        case "5": ShowAll(); break;
                        case "6": RunLinqReports(); break;
                        case "7": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("Account Type (1-Savings 2-Current 3-Loan): ");
            int type = int.Parse(Console.ReadLine());

            Console.Write("Account Number: ");
            string accNo = Console.ReadLine();

            Console.Write("Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Initial Balance: ");
            double balance = double.Parse(Console.ReadLine());

            BankAccount account = type switch
            {
                1 => new SavingsAccount(accNo, name, balance),
                2 => new CurrentAccount(accNo, name, balance),
                3 => new LoanAccount(accNo, name, balance),
                _ => throw new InvalidTransactionException("Invalid account type.")
            };

            accounts.Add(account);
            Console.WriteLine("Account created successfully.");
        }

        static BankAccount GetAccount(string accNo)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accNo)
                   ?? throw new Exception("Account not found.");
        }

        static void Deposit()
        {
            Console.Write("Account Number: ");
            var acc = GetAccount(Console.ReadLine());

            Console.Write("Amount: ");
            acc.Deposit(double.Parse(Console.ReadLine()));
        }

        static void Withdraw()
        {
            Console.Write("Account Number: ");
            var acc = GetAccount(Console.ReadLine());

            Console.Write("Amount: ");
            acc.Withdraw(double.Parse(Console.ReadLine()));
        }

        static void Transfer()
        {
            Console.Write("From Account: ");
            var from = GetAccount(Console.ReadLine());

            Console.Write("To Account: ");
            var to = GetAccount(Console.ReadLine());

            Console.Write("Amount: ");
            double amount = double.Parse(Console.ReadLine());

            from.Withdraw(amount);
            to.Deposit(amount);

            Console.WriteLine("Transfer successful.");
        }

        static void ShowAll()
        {
            foreach (var acc in accounts)
            {
                Console.WriteLine($"{acc.AccountNumber} | {acc.CustomerName} | {acc.Balance} | {acc.GetType().Name}");
            }
        }

        static void RunLinqReports()
        {
            Console.WriteLine("\nAccounts with balance > 50,000:");
            var highBalance = accounts.Where(a => a.Balance > 50000);
            foreach (var acc in highBalance)
                Console.WriteLine(acc.AccountNumber);

            Console.WriteLine("\nTotal Bank Balance:");
            Console.WriteLine(accounts.Sum(a => a.Balance));

            Console.WriteLine("\nTop 3 Highest Balance:");
            var top3 = accounts.OrderByDescending(a => a.Balance).Take(3);
            foreach (var acc in top3)
                Console.WriteLine(acc.AccountNumber);

            Console.WriteLine("\nGrouped by Account Type:");
            var grouped = accounts.GroupBy(a => a.GetType().Name);
            foreach (var group in grouped)
                Console.WriteLine($"{group.Key} Count: {group.Count()}");

            Console.WriteLine("\nCustomers starting with 'R':");
            var rCustomers = accounts.Where(a => a.CustomerName.StartsWith("R"));
            foreach (var acc in rCustomers)
                Console.WriteLine(acc.CustomerName);
        }

        static void SeedData()
        {
            accounts.Add(new SavingsAccount("S1001", "Rahul", 60000));
            accounts.Add(new CurrentAccount("C1001", "Riya", 45000));
            accounts.Add(new LoanAccount("L1001", "Amit", 90000));
        }
    }
}
