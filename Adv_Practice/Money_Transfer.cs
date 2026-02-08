using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class Account
    {
        public string AccountId { get; set; }
        public decimal Balance { get; set; }
    }

    public class TransferResult
    {
        public bool Success { get; set; }
    }

    public class MoneyTransferService
    {
        private readonly List<string> auditLog = new List<string>();

        public TransferResult Transfer(Account from, Account to, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException();
            if (from.Balance < amount) throw new InvalidOperationException();

            from.Balance -= amount;
            try
            {
                to.Balance += amount;
                auditLog.Add("Success");
                return new TransferResult { Success = true };
            }
            catch
            {
                from.Balance += amount;
                auditLog.Add("Failure");
                return new TransferResult { Success = false };
            }
        }
    }

    [TestFixture]
    public class MoneyTransferTest
    {
        [Test]
        public void Test_Debit_Credit()
        {
            var from = new Account { AccountId = "ACC1", Balance = 500 };
            var to = new Account { AccountId = "ACC2", Balance = 100 };
            var service = new MoneyTransferService();

            var result = service.Transfer(from, to, 200);

            Assert.That(result.Success, Is.True);
            Assert.That(from.Balance, Is.EqualTo(300));
            Assert.That(to.Balance, Is.EqualTo(300));
        }
    }

    class Money_Transfer
    {
        static void Main() { }
    }
}
