using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class Accounts
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public object LockObj { get; } = new object();
    }

    public class SafeTransferService
    {
        public void SafeTransfer(Accounts a, Accounts b, decimal amount)
        {
            var first = a.AccountId < b.AccountId ? a : b;
            var second = a.AccountId < b.AccountId ? b : a;

            lock (first.LockObj)
            {
                lock (second.LockObj)
                {
                    if (a.Balance < amount) throw new InvalidOperationException();
                    a.Balance -= amount;
                    b.Balance += amount;
                }
            }
        }
    }

    [TestFixture]
    public class SafeTransfer_Test
    {
        [Test]
        public void Successful_Transfer_Test()
        {
            var a = new Accounts { AccountId = 1, Balance = 500 };
            var b = new Accounts { AccountId = 2, Balance = 200 };
            var service = new SafeTransferService();

            service.SafeTransfer(a, b, 100);

            Assert.That(a.Balance, Is.EqualTo(400));
            Assert.That(b.Balance, Is.EqualTo(300));
        }
    }

    class Deadlock_Accounts
    {
        static void Main() { }
    }
}
