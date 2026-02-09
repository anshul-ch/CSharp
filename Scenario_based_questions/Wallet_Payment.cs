using System;

namespace CSharp.Scenario_based_questions
{
    class Wallet_Payment
    {
        static void MakePayment(ref double walletBalance, double amount)
        {
            if (amount > 0 && amount <= walletBalance)
            {
                walletBalance -= amount;
            }
        }

        static void Main()
        {
            double walletBalance = Convert.ToDouble(Console.ReadLine());
            double amount = Convert.ToDouble(Console.ReadLine());

            MakePayment(ref walletBalance, amount);

            Console.WriteLine(walletBalance);
        }
    }
}
