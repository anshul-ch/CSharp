using System;
using System.Numerics; // Required for BigInteger to handle large factorial values
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// This program calculates factorual of a number
    /// </summary>
    class Factorial_LargeNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to calculate its factorial:");
            int n = int.Parse(Console.ReadLine());

            // BigInteger is used to avoid overflow for large factorial values
            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial = factorial * i;
            }

            Console.WriteLine("Factorial of " + n + " is:");
            Console.WriteLine(factorial);
        }
    }
}
