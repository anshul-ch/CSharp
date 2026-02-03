namespace CSharp.Practice.BankAccount
{
    public class Program
    {
        public decimal Balance { get; private set; }

        public Program(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new Exception("Deposit amount cannot be negative");

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient funds.");

            Balance -= amount;
        }
    }

    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            Program acc = new Program(1000);
            acc.Deposit(500);
            Assert.AreEqual(1500, acc.Balance);
        }

        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            Program acc = new Program(1000);
            var ex = Assert.Throws<Exception>(() => acc.Deposit(-200));
            Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
        }

        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            Program acc = new Program(1000);
            acc.Withdraw(400);
            Assert.AreEqual(600, acc.Balance);
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            Program acc = new Program(500);
            var ex = Assert.Throws<Exception>(() => acc.Withdraw(800));
            Assert.AreEqual("Insufficient funds.", ex.Message);
        }
    }
}
