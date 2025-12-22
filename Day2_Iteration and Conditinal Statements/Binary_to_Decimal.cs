using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// This profeam converts Binary to Decimal without any inbuilt functions
    /// </summary>
    class BinaryToDecimal
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter a Binary Number:");
            string binary = Console.ReadLine();

            int decimalNumber = 0;   
            int power = 1;           // Represents 2^0 initially

            
            for (int i = binary.Length - 1; i >= 0; i--)
            {
               
                int digit = binary[i] - '0';
                decimalNumber += digit * power;
                power *= 2;
            }
            Console.WriteLine("Decimal Equivalent: " + decimalNumber);
        }
    }
}

