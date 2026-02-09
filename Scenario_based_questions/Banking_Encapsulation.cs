using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    class BankAccount
    {
        private decimal _balance { get; set; }
        
        public void Deposit(decimal amount)
        {
            if (amount > 0)
                _balance += amount;
            else
                Console.WriteLine("Enter greater than 0 ");
        }
        public void Withdraw(decimal amount)
        {
            if(amount >0 && amount <= _balance)
            {
                _balance -= amount;
            }
            else
            {
                Console.WriteLine("Withdraw amount should be less than balance");
            }
        }
        public void PrintBalance()
        {
            Console.WriteLine("Balance: " + _balance);
        }


    }
    public class Banking_Encapsulation
    {
        static void Main(String[] args)
        {
            BankAccount account = new BankAccount();
            account.Deposit(200);
            account.Withdraw(400);
            account.Deposit(500);
            account.Withdraw(100);
            account.PrintBalance();

        }
    }
}
