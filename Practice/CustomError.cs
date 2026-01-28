namespace CSharp.Practice
{
    // Custom Exception
    public class InsufficientWalletBalanceException : Exception
    {
        public InsufficientWalletBalanceException(string message)
            : base(message) { }
    }

    // EcommerceShop class
    public class EcommerceShop
    {
        public string UserName { get; set; }
        public double WalletBalance { get; set; }
        public double TotalPurchaseAmount { get; set; }

        // Method to make payment
        public static EcommerceShop MakePayment(string name, double balance, double amount)
        {
            if (balance < amount)
            {
                throw new InsufficientWalletBalanceException(
                    "Insufficient balance in your digital wallet."
                );
            }

            return new EcommerceShop
            {
                UserName = name,
                WalletBalance = balance - amount,
                TotalPurchaseAmount = amount,
            };
        }
    }

    class CustomError
    {
        static void Main()
        {
            try
            {
                string name = Console.ReadLine();
                double balance = double.Parse(Console.ReadLine());
                double amount = double.Parse(Console.ReadLine());

                EcommerceShop.MakePayment(name, balance, amount);
                Console.WriteLine("Payment successful.");
            }
            catch (InsufficientWalletBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
