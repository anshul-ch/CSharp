using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capgemini_Training
{
    /// <summary>
    /// This program prints a diamond pattern of stars
    /// </summary>
    class Diamond_Pattern
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of rows:");
            int n = int.Parse(Console.ReadLine());

            // Upper half of the diamond

            for (int i = 1; i <= n; i++)
            {
                // Print spaces
                for (int space = 1; space <= n - i; space++)
                {
                    Console.Write(" ");
                }

                // Print stars
                for (int star = 1; star <= (2 * i - 1); star++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            // Lower half of the diamond

            for (int i = n - 1; i >= 1; i--)
            {
                
                for (int space = 1; space <= n - i; space++)
                {
                    Console.Write(" ");
                }

                
                for (int star = 1; star <= (2 * i - 1); star++)
                {
                    Console.Write("*");
                }

               Console.WriteLine();
            }
        }
    }
}
