using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini_Training
{
    /// <summary>
    /// Checks if the number is a Strong number or not.
    /// </summary>
    class Strong_Number
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int originalNumber = number;
            int sum = 0;               

            
            while (number > 0)
            {
                int digit = number % 10; 
                int fact = 1;

                for (int i = 1; i <= digit; i++)
                {
                    fact = fact * i;
                }

                sum = sum + fact; 
                number = number / 10; 
            }

  
            if (sum == originalNumber)
            {
                Console.WriteLine(originalNumber + " is a Strong Number");
            }
            else
            {
                Console.WriteLine(originalNumber + " is NOT a Strong Number");
            }
        }
    }
}

