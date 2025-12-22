using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini_Training
{
    /// <summary>
    /// This program works as a ATM for cash transactions
    /// </summary>
        class ATM_Withdrawal
        {
            static void Main(string[] args)
            {
                // Initial account balance
                int balance = 10000;

                Console.WriteLine("Insert Card (yes/no): ");
                string card = Console.ReadLine().ToLower();

                
                if (card == "yes")
                {
                    
                    Console.WriteLine("Enter PIN: ");
                    int pin = int.Parse(Console.ReadLine());

                    
                    if (pin == 1234)   // Correct PIN
                    {
                        
                        Console.WriteLine("Enter withdrawal amount: ");
                        int amount = int.Parse(Console.ReadLine());

                        
                        if (amount <= balance)
                        {
                            
                            balance -= amount;

                            Console.WriteLine("Withdrawal Successful!");
                            Console.WriteLine("Remaining Balance: " + balance);
                        }
                        else
                        {
                           
                            Console.WriteLine("Insufficient Balance!");
                        }
                    }
                    else
                    {

                        Console.WriteLine("Invalid PIN!");
                    }
                }
                else
                {
                    Console.WriteLine("Please insert card!");
                }
            }
        } 

}
