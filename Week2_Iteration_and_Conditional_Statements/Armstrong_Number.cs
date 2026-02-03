using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// This program chedcks if a number is Armstrong Number or not
    /// </summary>
    class Armstrong_Number
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            int original = num;
            int digits = num.ToString().Length;
            int sum = 0;

            // Calculate sum of digits raised to power of number of digits
            while (num > 0)
            {
                int digit = num % 10;
                sum += (int)Math.Pow(digit, digits);
                num /= 10;
            }

            // Check Armstrong condition
            if (sum == original)
                Console.WriteLine("Armstrong Number");
            else
                Console.WriteLine("Not an Armstrong Number");
        }
    }

}
