using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// This program checks for all the numebrs from 1 to 50 but not multiples of 3.
    /// </summary>
    class Continue_Example
    {
        static void Main(string[] args)
        {
            // Loop from 1 to 50
            for (int i = 1; i <= 50; i++)
            {
                
                if (i % 3 == 0)
                {
                    continue;
                }

               
                Console.Write(i + " ");
            }
            Console.ReadLine();
        }
    }
}

