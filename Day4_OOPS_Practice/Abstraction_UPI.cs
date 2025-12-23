using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day4_OOPS_Practice
{
    abstract class Payment
    {
        public decimal Amount { get; }
        protected Payment(decimal amount)
        {
            Amount =  amount;
        }
        
        public void PrintReceipt()
        {
            Console.WriteLine("Amount Recieved : " + Amount);
        }
        public abstract void Pay();

    }

     class UPI : Payment
    {
        public string upiId { get; }
         public UPI(decimal amount, string upiId) : base(amount) {
            this.upiId = upiId;
            
        }
         
        
        public override void Pay()
        {
            Console.WriteLine("Upi ID: " + upiId + " amount is :" + Amount);
        }
    }
    class Cash : Payment
    {
        public string notes_recieved { get; }
        public Cash(string notes_recieved, int amount) : base(amount)
        {
            this.notes_recieved = notes_recieved;
           
        }
        
        public override void Pay()
        {
            Console.WriteLine("Recieved amount : " + Amount + " in notes of " + notes_recieved);
        }
    }

        public class Abstraction_UPI
    {
        public static void Main(String[] args)
        {
            
            UPI upi = new UPI(450.99m, "abc@abc");
            upi.PrintReceipt();
            upi.Pay();

            Cash cash = new Cash("200 notes of 500", 100000);
            cash.PrintReceipt();
            cash.Pay();
           
        }
    }
}
