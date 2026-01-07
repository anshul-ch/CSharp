using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// This program prints a pascal triangle
    /// </summary>
    class Pascals_Triangle
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of rows: ");
            int n = int.Parse(Console.ReadLine());

          
            for (int i = 0; i < n; i++)
            {
                int number = 1; // First value in every row is always 1

                for (int space = 0; space < n - i - 1; space++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(number + " ");

                    number = number * (i - j) / (j + 1);
                }

                Console.WriteLine();
            }
        }
    }
}

