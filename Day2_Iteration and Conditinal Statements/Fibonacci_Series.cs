using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// This program prints fibonacci series upto a certain no. of terms
    /// </summary>
    public class Fibonacci_Series
    {
        static void Main()
        {
            
            Console.Write("Enter number of terms: ");

            int n = int.Parse(Console.ReadLine());

            int a = 0;
            int b = 1;

            Console.WriteLine("Fibonacci Series:");

            for (int i = 1; i <= n; i++)
            {

                Console.Write(a + " ");

                int next = a + b;
                a = b;
                b = next;
            }
        }
    }

}
